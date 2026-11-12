namespace Plotly.NET.Verso.IntegrationTests

open System
open System.Collections.Concurrent
open System.Diagnostics
open System.IO
open System.Net
open System.Text.Json.Nodes
open System.Threading.Tasks
open PuppeteerSharp
open Infrastructure

module BrowserTests =
    // Opening a notebook can prompt before its outputs are mounted, as can its first execution.
    // This process owns the generated fixture and approves only its exact extension package.
    let private approveFixture = "for (const modal of document.querySelectorAll('.verso-modal')) { if (modal.textContent.includes('Plotly.NET.Verso') && modal.querySelector('.verso-modal-btn--primary')) modal.querySelector('.verso-modal-btn--primary').click(); }"

    let private wait (page: IPage) expression = task {
        let! _ = page.WaitForFunctionAsync("() => { " + approveFixture + " return (" + expression + ")(); }", WaitForFunctionOptions(Timeout = 90000))
        return ()
    }

    let private waitCharts (page: IPage) count =
        wait page $"() => {{ const charts = [...document.querySelectorAll('.plotly-net-verso')]; return charts.length === {count} && charts.every(c => c.dataset.plotlyState === 'ready' && c.querySelector('svg.main-svg')); }}"

    let private runCell (page: IPage) (index: int) = task {
        // Cell completion and notebook-wide readiness are separate Blazor renders. A disabled
        // button silently ignores click(), so wait for readiness before issuing exactly one run.
        let startExecution =
            """() => {
                const cell = document.querySelectorAll('.verso-cell')[/*INDEX*/];
                const button = cell?.querySelector('button.verso-cell-btn--run');
                if (!button || button.disabled) return false;
                const previous = cell.querySelector('.verso-cell-status-count')?.textContent || '';
                const state = { started: false, done: false };
                window.__versoTestExecution = state;
                const observe = () => {
                    const running = cell.classList.contains('verso-cell--executing');
                    const runButton = cell.querySelector('button.verso-cell-btn--run');
                    state.started ||= running;
                    state.done = !running && !!runButton && !runButton.disabled &&
                        (state.started || (cell.querySelector('.verso-cell-status-count')?.textContent || '') !== previous);
                    if (state.done) observer.disconnect();
                };
                const observer = new MutationObserver(observe);
                observer.observe(cell, { attributes: true, childList: true, subtree: true, characterData: true });
                button.click();
                return true;
            }""".Replace("/*INDEX*/", string index)
        // Counts can equal the saved CLI counts in a fresh browser kernel. Observe the execution
        // lifecycle as well as the counter, including fast cells that finish between polling ticks.
        // wait has a 90-second bound; it polls readiness but never repeats a started execution.
        do! wait page startExecution
        let watch = Stopwatch.StartNew()
        let mutable complete = false
        while not complete && watch.Elapsed < TimeSpan.FromSeconds(120.) do
            // This harness creates the only package offered for approval. Never approve an unrelated dialog.
            do! page.EvaluateFunctionAsync("() => { " + approveFixture + " }")
            let! doneNow = page.EvaluateFunctionAsync<bool>("() => window.__versoTestExecution.done")
            complete <- doneNow
            if not complete then do! Task.Delay(200)
        require complete $"Cell {index} did not finish in the browser."
        let! errors = page.EvaluateFunctionAsync<string>("i => [...document.querySelectorAll('.verso-cell')[i].querySelectorAll('.verso-output--error')].map(e=>e.textContent).join(String.fromCharCode(10))", [| box index |])
        require (String.IsNullOrWhiteSpace errors) $"Cell {index} failed in the real browser host: {errors}"
    }

    let run (environment: TestEnvironment) cli onlineNotebook offlineNotebook = task {
        let browserCache =
            match Environment.GetEnvironmentVariable("PUPPETEER_CACHE_DIR") with
            | null | "" -> Path.Combine(environment.Repository, ".cache", "verso-browser")
            | value -> Path.GetFullPath(value)
        let fetcher = new BrowserFetcher(BrowserFetcherOptions(Path = browserCache))
        let! installed = fetcher.DownloadAsync().WaitAsync(TimeSpan.FromMinutes(4.))
        let args =
            if Environment.GetEnvironmentVariable("CI") = "true" && OperatingSystem.IsLinux() then [| "--no-sandbox" |]
            else Array.empty
        use! browser = Puppeteer.LaunchAsync(LaunchOptions(Headless = true, ExecutablePath = installed.GetExecutablePath(), Args = args, ProtocolTimeout = 30000))
        let plotlyFile = Directory.GetFiles(Path.Combine(environment.Repository, "src", "Plotly.NET"), "plotly-*.min.js") |> Array.exactlyOne
        let bundle = File.ReadAllText(plotlyFile)

        let exercise (name: string) (notebook: string) (count: int) (offline: bool) = task {
            // Separate hosts also isolate the host's process-wide background-exception observer
            // from work finishing on a disposed circuit from the preceding fixture.
            let port = freePort()
            let baseUrl = $"http://127.0.0.1:{port}"
            use server = new ChildProcess(cli, [ "serve"; "--no-browser"; "--no-https"; "--port"; string port; "--language"; "en" ],
                                          environment.RunDirectory, environment.Variables, Path.Combine(environment.RunDirectory, name + "-serve.log"))
            do! waitForServer server baseUrl
            use! page = browser.NewPageAsync()
            page.DefaultTimeout <- 90000
            page.DefaultNavigationTimeout <- 90000
            let errors = new ConcurrentQueue<string>()
            let messages = new ConcurrentQueue<string>()
            let mutable plotlyRequests = 0
            page.PageError.Add(fun e -> errors.Enqueue(e.Message))
            page.Console.Add(fun e ->
                messages.Enqueue(e.Message.Type.ToString() + ": " + e.Message.Text)
                if e.Message.Type = ConsoleType.Error then errors.Enqueue("Console error: " + e.Message.Text))
            do! page.SetRequestInterceptionAsync(true)
            page.Request.Add(fun e ->
                task {
                    try
                        let uri = Uri(e.Request.Url)
                        let isPlotly = uri.Host.Equals("cdn.plot.ly", StringComparison.OrdinalIgnoreCase)
                        if isPlotly then
                            System.Threading.Interlocked.Increment(&plotlyRequests) |> ignore
                            if offline then do! e.Request.AbortAsync()
                            else
                                // Deterministic network timing and the actual repository bundle, never a CDN-dependent pass.
                                do! Task.Delay(350)
                                do! e.Request.RespondAsync(ResponseData(Status = HttpStatusCode.OK, ContentType = "application/javascript", Body = bundle))
                        elif offline && uri.Scheme <> "data" && uri.Scheme <> "blob" && not uri.IsLoopback then
                            // Verso lazily loads tokenizers/workers and Mermaid after opening a
                            // notebook. Permit only those host assets, never chart dependencies.
                            let isHostAsset = uri.Host = "cdn.jsdelivr.net" &&
                                              (uri.AbsolutePath.StartsWith("/npm/monaco-editor@0.45.0/min/") ||
                                               uri.AbsolutePath = "/npm/mermaid@11/dist/mermaid.min.js")
                            if isHostAsset then do! e.Request.ContinueAsync()
                            else
                                errors.Enqueue("Unexpected external request during Full rendering: " + e.Request.Url)
                                do! e.Request.AbortAsync()
                        else do! e.Request.ContinueAsync()
                    with ex -> errors.Enqueue("Request interception: " + ex.Message)
                } |> ignore)
            let openNotebook () = task {
                let! _ = page.GoToAsync(baseUrl).WaitAsync(TimeSpan.FromSeconds(100.))
                do! wait page "() => !!window.monaco && !!window.versoMonaco"
                do! page.EvaluateFunctionAsync("() => window.versoMonaco.waitForReady()")
                // Opening interactively avoids Verso 1.2.3's recover-query prerender waiting for
                // consent before the browser has an interactive circuit to answer that consent.
                // Cached Monaco may initialize before Blazor has attached button handlers.
                // Retry this harmless toggle until its input is visibly mounted.
                do! wait page "() => { if(document.querySelector('input.verso-toolbar-input')) return true; if(Date.now()-(window.__versoOpenClickAt||0)>750) { const button=[...document.querySelectorAll('button.verso-toolbar-btn')].find(b=>b.textContent.trim()==='Open'); if(button) {window.__versoOpenClickAt=Date.now(); button.click();} } return false; }"
                do! page.TypeAsync("input.verso-toolbar-input", notebook)
                do! page.EvaluateFunctionAsync("() => [...document.querySelectorAll('button.verso-toolbar-btn')].find(b=>b.textContent.trim()==='Go').click()")
                do! waitCharts page count
                do! wait page "() => !document.querySelector('.verso-modal')"
            }
            try
                do! openNotebook()
                let! amdSafe = page.EvaluateFunctionAsync<bool>("() => !window.define || !window.define.amd")
                require amdSafe "The supported host still exposes define.amd."
                let! distinct = page.EvaluateFunctionAsync<bool>("() => {const ids=[...document.querySelectorAll('.js-plotly-plot')].map(c=>c.id); return ids.length===new Set(ids).size;}")
                require distinct "Separate notebook charts share a DOM id."
                if offline then require (plotlyRequests = 0) "Full rendering requested a CDN dependency."
                else require (plotlyRequests > 0) "The CDN fixture did not exercise asynchronous external script loading."

                // Execute the actual packaged extension in the UI kernel, then rerun the first chart twice.
                do! runCell page 0
                do! runCell page 1
                let! provenance = page.EvaluateFunctionAsync<string>("() => document.querySelectorAll('.verso-cell')[1].innerText")
                Notebook.validateProvenance environment provenance
                let mutable lastChartId = ""
                for _ in 1 .. 2 do
                    let! oldId = page.EvaluateFunctionAsync<string>("() => document.querySelectorAll('.verso-cell')[2].querySelector('.js-plotly-plot').id")
                    do! runCell page 2
                    do! waitCharts page count
                    let! newId = page.EvaluateFunctionAsync<string>("() => document.querySelectorAll('.verso-cell')[2].querySelector('.js-plotly-plot').id")
                    require (newId <> oldId) "Rerunning a cell did not replace its chart."
                    lastChartId <- newId
                if not offline then
                    let! traces = page.EvaluateFunctionAsync<int>("() => document.querySelectorAll('.verso-cell')[3].querySelector('.js-plotly-plot').data.length")
                    require (traces = 2) "MultiChart lost a trace in the host renderer."
                let beforeSave = File.GetLastWriteTimeUtc(notebook)
                do! page.EvaluateFunctionAsync("() => { const button = [...document.querySelectorAll('button.verso-toolbar-btn')].find(b => b.textContent.trim().startsWith('Save')); if (!button) throw new Error('Save button missing'); button.click(); }")
                let saving = Stopwatch.StartNew()
                let mutable persisted = false
                while not persisted && saving.Elapsed < TimeSpan.FromSeconds(15.) do
                    if File.GetLastWriteTimeUtc(notebook) <> beforeSave then
                        try
                            // A Full output is several megabytes. Timestamp changes at the start
                            // of the asynchronous write, before its file lock is released.
                            let saved = JsonNode.Parse(File.ReadAllText(notebook))
                            let savedCell = saved["cells"].AsArray()[2]
                            let savedOutputs = savedCell["outputs"]
                            persisted <- savedOutputs.AsArray() |> Seq.exists (fun o -> o["content"].GetValue<string>().Contains(lastChartId))
                        with
                        | :? IOException -> ()
                        | :? System.Text.Json.JsonException -> ()
                    if not persisted then do! Task.Delay(100)
                require persisted "Save did not persist the rerun browser chart within 15 seconds."
                do! page.EvaluateFunctionAsync("() => window.versoRecovery.clearState()")
                do! openNotebook()
                let! reopenedId = page.EvaluateFunctionAsync<string>("() => document.querySelectorAll('.verso-cell')[2].querySelector('.js-plotly-plot').id")
                require (reopenedId = lastChartId) "Reopening did not restore the chart saved after rerun."
                let! values = page.EvaluateFunctionAsync<int array>("() => document.querySelectorAll('.verso-cell')[2].querySelector('.js-plotly-plot').data[0].y")
                require (values = [| 4; 6; 5 |]) "Reopened chart data changed."
                if offline then require (plotlyRequests = 0) "Reopened Full output requested a CDN dependency."
                require errors.IsEmpty ("Browser errors: " + String.Join("\n", errors))
                let! chartElement = page.QuerySelectorAsync(".js-plotly-plot")
                do! chartElement.ScreenshotAsync(Path.Combine(environment.RunDirectory, name + "-chart.png")).WaitAsync(TimeSpan.FromSeconds(10.))
                do! page.ScreenshotAsync(Path.Combine(environment.RunDirectory, name + ".png"), ScreenshotOptions(FullPage = true)).WaitAsync(TimeSpan.FromSeconds(10.))
                printfn "PASS real Verso browser: %s, rerun, save, reopen" name
                File.WriteAllLines(Path.Combine(environment.RunDirectory, name + "-console.log"), messages)
                File.WriteAllLines(Path.Combine(environment.RunDirectory, name + "-errors.log"), errors)
            with ex ->
                try
                    let! html = page.GetContentAsync().WaitAsync(TimeSpan.FromSeconds(10.))
                    File.WriteAllText(Path.Combine(environment.RunDirectory, name + "-failure.html"), html)
                    do! page.ScreenshotAsync(Path.Combine(environment.RunDirectory, name + "-failure.png"), ScreenshotOptions(FullPage = true)).WaitAsync(TimeSpan.FromSeconds(10.))
                with _ -> ()
                File.WriteAllLines(Path.Combine(environment.RunDirectory, name + "-console.log"), messages)
                File.WriteAllLines(Path.Combine(environment.RunDirectory, name + "-errors.log"), errors)
                return raise ex
        }
        do! exercise "online" onlineNotebook 2 false
        // A fresh document has no window.Plotly. Block Plotly requests from first paint while allowing
        // the host's own Monaco CDN dependency, so this measures the chart's offline contract.
        do! exercise "offline" offlineNotebook 1 true
    }
