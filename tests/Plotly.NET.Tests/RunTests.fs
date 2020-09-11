namespace Plotly.NET.Tests

open Expecto

module RunTests =

    [<EntryPoint>]
    let main args =

        Tests.runTestsWithArgs defaultConfig args Tests.testSimpleTests |> ignore

        0

