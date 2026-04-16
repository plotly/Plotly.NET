open Plotly.NET

[<EntryPoint>]
let main _ =

    Chart.Heatmap(
        zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0; 7.0; 8.0; 9.0 |], shape = [ 3; 3 ]),
        Name = "encoded heatmap",
        UseDefaults = false
    )|> Chart.show

    0
