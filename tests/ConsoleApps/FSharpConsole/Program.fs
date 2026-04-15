open Plotly.NET

[<EntryPoint>]
let main _ =

    let chartScatterEncodedRootPoC =
        Chart.Scatter(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 2.0; 3.0; 4.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 0.5; 2.0; 1.5 |],
            mode = StyleParam.Mode.Lines_Markers,
            Name = "encoded scatter root",
            UseDefaults = true
        )
        |> Chart.withTitle "Scatter: encoded x/y at chart root"

    chartScatterEncodedRootPoC |> Chart.show

    0
