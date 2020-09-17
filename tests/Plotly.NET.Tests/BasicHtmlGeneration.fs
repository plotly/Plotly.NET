module Tests

open Expecto
open Plotly.NET

[<Tests>]
let tests =
    testList "Placeholder" [
        testCase "There be tests" ( fun () ->
            Expect.equal
                42
                42
                "Nope"
        )
    ]