module Plotly.NET.Verso.BrowserTests.BrowserHarness

open System
open System.Collections.Concurrent
open System.IO
open System.Net
open System.Text.RegularExpressions
open System.Threading.Tasks
open Expecto
open Plotly.NET
open PuppeteerSharp

let private repositoryRoot = Path.GetFullPath(Path.Combine(__SOURCE_DIRECTORY__, "../../.."))

let private configuredPath name fallback =
    match Environment.GetEnvironmentVariable(name) with
    | null | "" -> fallback
    | value -> Path.GetFullPath(value)

let browserCacheDirectory =
    configuredPath "PUPPETEER_CACHE_DIR" (Path.Combine(repositoryRoot, ".cache", "verso-browser"))

let artifactsDirectory =
    configuredPath "PLOTLY_VERSO_TEST_ARTIFACTS" (Path.Combine(__SOURCE_DIRECTORY__, "TestResults", "artifacts"))

/// The PuppeteerSharp package pins its compatible Chrome revision. Never choose an
/// arbitrary installed browser: CI and local runs must exercise the same engine.
let installBrowser () =
    task {
        Directory.CreateDirectory(browserCacheDirectory) |> ignore
        let fetcher = new BrowserFetcher(BrowserFetcherOptions(Path = browserCacheDirectory))
        let revision = PuppeteerSharp.BrowserData.Chrome.DefaultBuildId
        let executable = fetcher.GetExecutablePath(revision)
        if not (File.Exists executable) then
            printfn "Installing Chromium %s in %s" revision browserCacheDirectory
            try
                let! _ = fetcher.DownloadAsync(revision)
                ()
            with error ->
                raise (InvalidOperationException($"Could not provision Chromium {revision}. Run the FAKE PrepareVersoBrowser target with network access and a writable PUPPETEER_CACHE_DIR. {error.Message}", error))
        if not (File.Exists executable) then
            failwith $"Chromium provisioning did not produce {executable}."
        printfn "Verso browser tests: Chromium %s (%s)" revision executable
        return executable
    }

let private installedBrowser = lazy (installBrowser ())

/// Read the actual bundle from the core assembly under test, including its version.
let plotlySource =
    lazy (
        let assembly = typeof<GenericChart>.Assembly
        let resourceName =
            assembly.GetManifestResourceNames()
            |> Array.find (fun name -> name.EndsWith($"plotly-{Globals.PLOTLYJS_VERSION}.min.js", StringComparison.Ordinal))
        use stream = assembly.GetManifestResourceStream(resourceName)
        use reader = new StreamReader(stream)
        reader.ReadToEnd()
    )

let respondWithPlotly (request: IRequest) =
    request.RespondAsync(ResponseData(Status = HttpStatusCode.OK, ContentType = "application/javascript", Body = plotlySource.Value))

let respondWithFailure (request: IRequest) =
    request.RespondAsync(ResponseData(Status = HttpStatusCode.ServiceUnavailable, ContentType = "text/plain", Body = "Expected test failure"))

let respondWithoutPlotly (request: IRequest) =
    request.RespondAsync(ResponseData(Status = HttpStatusCode.OK, ContentType = "application/javascript", Body = "window.__unrelatedScriptLoaded = true;"))

type Session =
    {
        Page: IPage
        Requests: ConcurrentQueue<string>
        ScriptRequests: ConcurrentQueue<string>
        PageErrors: ConcurrentQueue<string>
        ConsoleErrors: ConcurrentQueue<string>
        ConsoleMessages: ConcurrentQueue<string>
        RoutingErrors: ConcurrentQueue<string>
        Inputs: ConcurrentQueue<string * string>
    }

let private initializeScript =
    """() => {
        window.__plotlyCalls = [];
        window.__unhandledRejections = [];
        window.addEventListener('unhandledrejection', event => {
            window.__unhandledRejections.push(String(event.reason));
        });
        // Verso >= 1.0.15 leaves Monaco's define present without define.amd.
        // The adapter must neither call it nor alter it to load a UMD bundle.
        window.define = function () { throw new Error('Unexpected Monaco AMD call'); };
        window.__originalDefine = window.define;
        let plotly;
        Object.defineProperty(window, 'Plotly', {
            configurable: true,
            get() { return plotly; },
            set(value) {
                plotly = value;
                if (value && typeof value.newPlot === 'function') {
                    const newPlot = value.newPlot;
                    value.newPlot = function (target, ...args) {
                        window.__plotlyCalls.push(typeof target === 'string' ? target : target.id);
                        return newPlot.call(this, target, ...args);
                    };
                }
            }
        });
    }"""

/// Like a notebook output renderer, insert the fragment first and recreate script
/// nodes afterwards. Browser HTML parsing would serialize external scripts and hide
/// the asynchronous-loading regression this suite is meant to catch.
let insert (session: Session) cellId html =
    task {
        session.Inputs.Enqueue(cellId, html)
        do!
            session.Page.EvaluateFunctionAsync(
                """(id, html) => {
                    let cell = document.getElementById(id);
                    if (!cell) {
                        cell = document.createElement('section');
                        cell.id = id;
                        document.body.appendChild(cell);
                    }
                    cell.innerHTML = html;
                    for (const inert of Array.from(cell.querySelectorAll('script'))) {
                        const active = document.createElement('script');
                        for (const attribute of inert.attributes) {
                            active.setAttribute(attribute.name, attribute.value);
                        }
                        active.textContent = inert.textContent;
                        inert.replaceWith(active);
                    }
                }""",
                [| box cellId; box html |]
            )
    }

let waitForState (session: Session) cellId state =
    task {
        use! _handle =
            session.Page.WaitForFunctionAsync(
                """(id, state) => document.getElementById(id)?.querySelector('.plotly-net-verso')?.dataset.plotlyState === state""",
                WaitForFunctionOptions(Timeout = 15000),
                [| box cellId; box state |]
            )
        return ()
    }

let assertRendered (session: Session) cellId =
    task {
        do! waitForState session cellId "ready"
        let! rendered =
            session.Page.EvaluateFunctionAsync<bool>(
                """id => {
                    const graph = document.getElementById(id)?.querySelector('.js-plotly-plot');
                    return !!graph && !!graph.querySelector('svg.main-svg') &&
                        graph.calcdata?.length > 0 && graph._fullLayout.width > 0 &&
                        graph._fullLayout.height > 0 && graph.getBoundingClientRect().height > 0;
                }""",
                [| box cellId |]
            )
        Expect.isTrue rendered $"{cellId} must contain an actual visible Plotly chart, not just a ready marker."
    }

let assertError (session: Session) cellId =
    task {
        do! waitForState session cellId "error"
        let! message =
            session.Page.EvaluateFunctionAsync<string>(
                "id => document.getElementById(id).querySelector('[role=alert]')?.textContent || ''",
                [| box cellId |]
            )
        Expect.isFalse (String.IsNullOrWhiteSpace message) "A failed output must explain the failure visibly."
        return message
    }

let assertCallCount (session: Session) expected =
    task {
        let! count = session.Page.EvaluateExpressionAsync<int>("window.__plotlyCalls.length")
        Expect.equal count expected "Each live output should render exactly once."
    }

let private saveFailure name (session: Session) (error: exn) =
    task {
        let directory = Path.Combine(artifactsDirectory, Regex.Replace(name, "[^A-Za-z0-9_-]", "_"))
        Directory.CreateDirectory(directory) |> ignore
        File.WriteAllText(Path.Combine(directory, "failure.txt"), error.ToString())
        File.WriteAllLines(Path.Combine(directory, "console.txt"), session.ConsoleMessages)
        File.WriteAllLines(Path.Combine(directory, "page-errors.txt"), session.PageErrors)
        File.WriteAllLines(Path.Combine(directory, "requests.txt"), session.Requests)
        File.WriteAllLines(Path.Combine(directory, "routing-errors.txt"), session.RoutingErrors)
        session.Inputs.ToArray()
        |> Array.iteri (fun index (id, html) -> File.WriteAllText(Path.Combine(directory, $"input-{index}-{id}.html"), html))
        try
            let! html = session.Page.GetContentAsync()
            File.WriteAllText(Path.Combine(directory, "page.html"), html)
            do! session.Page.ScreenshotAsync(Path.Combine(directory, "page.png"), ScreenshotOptions(FullPage = true))
        with captureError ->
            File.WriteAllText(Path.Combine(directory, "capture-error.txt"), captureError.ToString())
        eprintfn "Browser failure artifacts: %s" directory
    }

let run name (routeScript: IRequest -> int -> Task) allowResourceFailure (body: Session -> Task<unit>) =
    async {
        let! executable = installedBrowser.Value |> Async.AwaitTask
        let launch =
            LaunchOptions(
                ExecutablePath = executable,
                Headless = true,
                Timeout = 60000,
                Args = [| "--no-sandbox"; "--disable-dev-shm-usage" |]
            )
        use! browser = Puppeteer.LaunchAsync(launch) |> Async.AwaitTask
        use! page = browser.NewPageAsync() |> Async.AwaitTask
        let session =
            {
                Page = page
                Requests = ConcurrentQueue()
                ScriptRequests = ConcurrentQueue()
                PageErrors = ConcurrentQueue()
                ConsoleErrors = ConcurrentQueue()
                ConsoleMessages = ConcurrentQueue()
                RoutingErrors = ConcurrentQueue()
                Inputs = ConcurrentQueue()
            }
        page.PageError.Add(fun event -> session.PageErrors.Enqueue event.Message)
        page.Console.Add(fun event ->
            session.ConsoleMessages.Enqueue($"{event.Message.Type}: {event.Message.Text}")
            if event.Message.Type = ConsoleType.Error then session.ConsoleErrors.Enqueue event.Message.Text)
        page.AddRequestInterceptor(Func<IRequest, Task>(fun request ->
            task {
                try
                    if request.Url.StartsWith("data:", StringComparison.Ordinal)
                       || request.Url.StartsWith("blob:", StringComparison.Ordinal) then
                        // Plotly probes browser image support using an embedded WebP.
                        // These in-memory resources do not constitute network access.
                        do! request.ContinueAsync()
                    else
                        session.Requests.Enqueue(request.Url)
                        if request.ResourceType = ResourceType.Script then
                            session.ScriptRequests.Enqueue(request.Url)
                            do! routeScript request session.ScriptRequests.Count
                        else
                            // No scenario is permitted to depend on outside network access.
                            do! request.AbortAsync()
                with error ->
                    session.RoutingErrors.Enqueue(error.ToString())
                    return raise error
            } :> Task))
        try
            do! page.SetRequestInterceptionAsync(true) |> Async.AwaitTask
            do! page.SetContentAsync("<!doctype html><html><head><meta charset='utf-8'></head><body></body></html>") |> Async.AwaitTask
            do! page.EvaluateFunctionAsync(initializeScript) |> Async.AwaitTask
            do! body session |> Async.AwaitTask
            Expect.isEmpty session.PageErrors "The output must not throw browser JavaScript errors."
            Expect.isEmpty session.RoutingErrors "The deterministic asset router must not fail."
            let unexpectedConsoleErrors =
                session.ConsoleErrors.ToArray()
                |> Array.filter (fun message -> not (allowResourceFailure && message.Contains("Failed to load resource", StringComparison.Ordinal)))
            Expect.isEmpty unexpectedConsoleErrors "The output must not log unexpected console errors."
            let! unhandled = page.EvaluateExpressionAsync<string[]>("window.__unhandledRejections") |> Async.AwaitTask
            Expect.isEmpty unhandled "Rejected render/load promises must be handled."
            let! unchanged = page.EvaluateExpressionAsync<bool>("window.define === window.__originalDefine && !window.define.amd && typeof window.requirejs === 'undefined'") |> Async.AwaitTask
            Expect.isTrue unchanged "Rendering must preserve the corrected host's Monaco loader and avoid RequireJS."
        with error ->
            do! saveFailure name session error |> Async.AwaitTask
            return raise error
    }

let servePlotly request _ = respondWithPlotly request

let rejectNetwork (request: IRequest) _ = request.AbortAsync()

/// A gate, not a sleep, proves that the output is waiting while the asset is absent.
type DelayedScript() =
    let started = TaskCompletionSource<unit>(TaskCreationOptions.RunContinuationsAsynchronously)
    let release = TaskCompletionSource<unit>(TaskCreationOptions.RunContinuationsAsynchronously)
    member _.Started = started.Task.WaitAsync(TimeSpan.FromSeconds 15.)
    member _.Release() = release.TrySetResult() |> ignore
    member _.Route(request: IRequest, _index: int) : Task =
        task {
            started.TrySetResult() |> ignore
            do! release.Task.WaitAsync(TimeSpan.FromSeconds 15.)
            do! respondWithPlotly request
        }
