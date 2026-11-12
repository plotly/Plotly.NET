module Plotly.NET.Verso.BrowserTests.Main

open Expecto

[<EntryPoint>]
let main arguments =
    if arguments = [| "--install-browser" |] then
        BrowserHarness.installBrowser().GetAwaiter().GetResult() |> ignore
        0
    else
        Tests.runTestsInAssemblyWithCLIArgs [] arguments
