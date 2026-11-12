module Tests.VersoFormatterTests

open System
open System.IO
open System.Reflection
open System.Runtime.Loader
open System.Text.RegularExpressions
open System.Threading
open Expecto
open Giraffe.ViewEngine
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Plotly.NET
open Plotly.NET.Verso
open Verso.Abstractions
open Verso.Testing.Stubs
open TestUtils.HtmlCodegen

let private formatter = GenericChartFormatter() :> IDataFormatter
let private context () = StubFormatterContext()
let private chart () = Chart.Line(x = [ 1; 2; 3 ], y = [ 4; 6; 5 ], UseDefaults = false)

type private CustomDisplayOptions() =
    inherit DisplayOptions()

let private withReference reference chart =
    chart |> GenericChart.setDisplayOptions (DisplayOptions.init (PlotlyJSReference = reference))

let private parseJson (json: string) =
    use text = new StringReader(json)
    use reader = new JsonTextReader(text)
    reader.DateParseHandling <- DateParseHandling.None
    JObject.Load(reader)

let private payload (html: string) =
    let result = Regex.Match(html, @"\}\)\((\{""id"".*)\);\s*</script>", RegexOptions.Singleline)
    Expect.isTrue result.Success "The renderer carries a JSON payload."
    parseJson result.Groups[1].Value

let private assertPayload chart html =
    let expected = GenericChart.toJson chart |> parseJson
    let actual = (payload html).["chart"]
    Expect.isTrue (JToken.DeepEquals(expected, actual)) "The originating serializer supplies all data, layout, and config."

[<Tests>]
let contractTests =
    testList "Verso.Formatter contract" [
        testCase "Object prefilter permits isolated chart types while CanFormat remains selective" (fun () ->
            Expect.contains formatter.SupportedTypes typeof<obj> "Verso's type prefilter must accept foreign charts."
            Expect.isTrue (formatter.CanFormat(chart (), context ())) "Chart accepted."
            for value in [ null; box "not a chart"; obj (); box 42 ] do
                Expect.isFalse (formatter.CanFormat(value, context ())) "Non-chart values are not captured."
            let plain = StubFormatterContext(MimeType = "text/plain")
            Expect.isFalse (formatter.CanFormat(chart (), plain)) "Plain text remains available to other formatters."
            Expect.equal formatter.Priority 100 "Chart formatter priority retained.")

        testCase "Extension metadata is discoverable and follows assembly version" (fun () ->
            let extension = GenericChartFormatter() :> IExtension
            let version = typeof<GenericChartFormatter>.Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion.Split('+').[0]
            Expect.equal extension.Version version "Extension and package version agree."
            Expect.equal extension.ExtensionId "net.plotly.plotly-net-verso" "Stable extension identity."
            Expect.isNotNull (typeof<GenericChartFormatter>.GetCustomAttribute<VersoExtensionAttribute>()) "Verso can discover the extension."
            extension.OnUnloadedAsync().GetAwaiter().GetResult())

        testAsync "FormatAsync returns chart HTML" {
            let source = chart ()
            let! output = formatter.FormatAsync(source, context ()) |> Async.AwaitTask
            Expect.equal output.MimeType "text/html" "HTML output."
            Expect.isFalse output.IsError "A valid chart is not an error."
            Expect.stringContains output.Content "class=\"plotly-net-verso\"" "Chart container."
            assertPayload source output.Content
        }

        testAsync "Invalid values return a useful error output" {
            let! output = formatter.FormatAsync("invalid", context ()) |> Async.AwaitTask
            Expect.isTrue output.IsError "Formatting failure is explicit."
            Expect.stringContains output.Content "role=\"alert\"" "Error is readable in the cell."
            Expect.stringContains output.Content "Expected a Plotly.NET GenericChart" "Error identifies the problem."
        }

        testCase "Cancellation returns a canceled task" (fun () ->
            use cancellation = new CancellationTokenSource()
            cancellation.Cancel()
            let ctx = StubFormatterContext(CancellationToken = cancellation.Token)
            let task = formatter.FormatAsync(chart (), ctx)
            Expect.throwsT<OperationCanceledException> (fun () -> task.GetAwaiter().GetResult() |> ignore) "Cancellation is not converted into a chart error."
            Expect.isTrue task.IsCanceled "Task preserves cancellation state.")
    ]

[<Tests>]
let renderingTests =
    testList "Verso.Formatters" [
        testCase "Default and custom CDN references use the asynchronous renderer" (fun () ->
            let source = chart ()
            let html = Formatters.toVersoHTML source
            let data = payload html
            Expect.equal (string data["mode"]) "cdn" "CDN default."
            Expect.equal (string data["url"]) $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min.js" "Core's bundled version determines the CDN."
            Expect.isFalse (html.Contains("requirejs.config")) "No RequireJS dependency."
            Expect.isFalse (html.Contains("cdnjs.cloudflare.com")) "No fallback loader download."
            assertPayload source html
            let custom = source |> withReference (CDN "https://example.invalid/custom-plotly.js?key=a&b=2")
            Expect.equal (string (payload (Formatters.toVersoHTML custom)).["url"]) "https://example.invalid/custom-plotly.js?key=a&b=2" "Custom CDN is preserved exactly.")

        testCase "Absent and explicit NoReference are distinct" (fun () ->
            let absent = chart () |> GenericChart.setDisplayOptions (DisplayOptions())
            Expect.equal (string (payload (Formatters.toVersoHTML absent)).["mode"]) "cdn" "Missing reference defaults to CDN."
            let explicit = chart () |> withReference NoReference
            Expect.equal (string (payload (Formatters.toVersoHTML explicit)).["mode"]) "none" "Explicit NoReference does not start a download.")

        testCase "Require carries an explicit unsupported mode" (fun () ->
            let html = chart () |> withReference (Require "https://example.invalid/plotly") |> Formatters.toVersoHTML
            Expect.equal (string (payload html).["mode"]) "require" "Legacy mode is identified."
            Expect.stringContains html "RequireJS references are not supported" "The renderer provides an actionable error.")

        testCase "Full is automatically offline and explicit offline helper overrides CDN without mutation" (fun () ->
            let source = chart ()
            let originalReference = source |> GenericChart.getDisplayOptions |> DisplayOptions.getPlotlyReference
            let full = source |> withReference Full
            let automatic = Formatters.toVersoHTML full
            Expect.equal (string (payload automatic).["mode"]) "full" "Full automatically embeds Plotly."
            Expect.stringContains automatic (getFullPlotlyJS ()) "Actual bundled asset is embedded."
            let document = Formatters.toVersoHTMLOffline source
            Expect.stringContains document "<!DOCTYPE html><html><head>" "Offline helper retains complete document contract."
            Expect.stringContains document (getFullPlotlyJS ()) "Explicit offline helper embeds actual asset."
            Expect.equal (source |> GenericChart.getDisplayOptions |> DisplayOptions.getPlotlyReference) originalReference "Input options are unchanged."
            assertPayload source document)

        testCase "Data layout config and defaults survive formatting" (fun () ->
            let sources = [
                chart () |> Chart.withTitle "Custom title" |> Chart.withSize (512, 333) |> Chart.withConfig (Config.init (Responsive = false))
                Chart.Point(x = [ 1; 2 ], y = [ 3; 4 ])
                Chart.Point(x = [ "2026-11-12T14:15:16.1234567+05:45" ], y = [ 3 ], UseDefaults = false)
                chart () |> GenericChart.setDisplayOptions (CustomDisplayOptions())
                [ chart (); Chart.Point(x = [ 1; 2 ], y = [ 8; 9 ], UseDefaults = false) ] |> Chart.combine
            ]
            for source in sources do
                let before = GenericChart.toJson source
                Formatters.toVersoHTML source |> assertPayload source
                Expect.equal (GenericChart.toJson source) before "Formatting leaves chart payload intact.")

        testCase "Descriptions head tags and document metadata are preserved" (fun () ->
            let source = chart () |> Chart.withDisplayOptions (
                DisplayOptions.init (
                    DocumentTitle = "Title <&>", DocumentDescription = "Description <&>", DocumentCharset = "UTF-8",
                    AdditionalHeadTags = [ style [] [ rawText ".test-chart { color: red; }" ] ],
                    ChartDescription = [ p [ _class "test-chart" ] [ str "Description <&>" ] ]))
            let fragment = Formatters.toVersoHTML source
            Expect.stringContains fragment ".test-chart { color: red; }" "Additional head content retained."
            Expect.stringContains fragment "Description &lt;&amp;&gt;" "Description uses source Giraffe escaping."
            Expect.isLessThan (fragment.IndexOf("<style")) (fragment.IndexOf("class=\"plotly-net-verso\"")) "Head tags precede chart."
            let document = Formatters.toVersoHTMLOffline source
            Expect.stringContains document "<title>Title &lt;&amp;&gt;</title>" "Document title escaped and retained.")

        testCase "Payload cannot prematurely close its script and IDs are unique" (fun () ->
            let title = "</script><script>throw new Error('chart text')</script>"
            let source = chart () |> Chart.withTitle title
            let first = Formatters.toVersoHTML source
            let second = Formatters.toVersoHTML source
            Expect.isFalse (first.Contains(title)) "Chart text is escaped for inline script context."
            assertPayload source first
            Expect.notEqual (string (payload first).["id"]) (string (payload second).["id"]) "Each output gets a distinct DOM identifier.")
    ]

type private ChartLoadContext() =
    inherit AssemblyLoadContext("Verso chart test " + Guid.NewGuid().ToString("N"), true)
    let directory = Path.GetDirectoryName(typeof<GenericChartFormatter>.Assembly.Location)
    override this.Load(name) =
        if name.Name = "Verso.Abstractions" then typeof<IDataFormatter>.Assembly
        else
            let path = Path.Combine(directory, name.Name + ".dll")
            if File.Exists(path) then this.LoadFromAssemblyPath(path) else null

[<Tests>]
let isolatedTests =
    testList "Verso.Isolated chart assembly" [
        for multiple in [ false; true ] do
            testCase $"Formats isolated chart; multiple={multiple}" (fun () ->
                let loadContext = ChartLoadContext()
                try
                    let assembly = loadContext.LoadFromAssemblyPath(Assembly.GetExecutingAssembly().Location)
                    let factory = assembly.GetType("Tests.ForeignChartFactory").GetMethod("create")
                    let source = factory.Invoke(null, [| box "cdn"; box multiple |])
                    Expect.isFalse (source :? GenericChart) "Fixture genuinely crosses the assembly type boundary."
                    Expect.isTrue (formatter.SupportedTypes |> Seq.exists (fun t -> t.IsInstanceOfType(source))) "Host prefilter permits value."
                    Expect.isTrue (formatter.CanFormat(source, context ())) "Foreign chart accepted."
                    let output = formatter.FormatAsync(source, context ()).GetAwaiter().GetResult()
                    Expect.isFalse output.IsError output.Content
                    let chartData = (payload output.Content).["chart"].["data"]
                    Expect.equal ((chartData :?> JArray).Count) (if multiple then 2 else 1) "All foreign traces retained."
                    Expect.stringContains output.Content "Foreign description" "Foreign description rendered in its own Giraffe assembly."
                    Expect.stringContains output.Content ".foreign-chart { color: red; }" "Foreign head tags retained."
                    let offline = factory.Invoke(null, [| box "full"; box multiple |])
                    let offlineOutput = formatter.FormatAsync(offline, context ()).GetAwaiter().GetResult()
                    Expect.isFalse offlineOutput.IsError "Foreign offline chart succeeds."
                    Expect.stringContains offlineOutput.Content (getFullPlotlyJS ()) "Foreign assembly's embedded Plotly is included."
                finally loadContext.Unload())
    ]
