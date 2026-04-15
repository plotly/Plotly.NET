open Plotly.NET

[<EntryPoint>]
let main _ =

    let chartConeEncodedRootPoC =
        Chart.Cone(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 2.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.5; 1.0 |],
            zEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 0.0 |],
            uEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.5; 0.5 |],
            vEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.5; 1.0 |],
            wEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 1.0; 1.0 |],
            Name = "encoded cone root",
            UseDefaults = true
        )
        |> Chart.withTitle "Cone: encoded vector field at chart root"

    chartConeEncodedRootPoC |> Chart.show

    0
