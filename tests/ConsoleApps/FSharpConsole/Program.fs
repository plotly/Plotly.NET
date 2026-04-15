open Plotly.NET

[<EntryPoint>]
let main _ =

    let chartPointDensityEncodedHelpers =
        Chart.PointDensity(
            xEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 2.0; 3.0; 4.0 |],
            yEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 0.5; 2.0; 1.5 |],
            ContoursColoring = StyleParam.ContourColoring.Fill,
            Name = "encoded point density helper",
            UseDefaults = true
        )
        |> Chart.withTitle "PointDensity: encoded x/y at chart helper layer"

    chartPointDensityEncodedHelpers |> Chart.show

    0
