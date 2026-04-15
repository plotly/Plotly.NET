open System
open Plotly.NET

[<EntryPoint>]
let main _ =

    let xs = [| 1.0; 2.0; 3.0; 4.0; 5.0 |]
    let openValues = [| 100.0; 103.0; 101.0; 106.0; 104.0 |]
    let highValues = [| 106.0; 107.0; 108.0; 110.0; 109.0 |]
    let lowValues = [| 98.0; 100.0; 99.0; 103.0; 101.0 |]
    let closeValues = [| 104.0; 101.0; 107.0; 104.0; 108.0 |]

    let chartCandlestickEncodedRootPoC =
        Chart.Candlestick(
            openEncoded = EncodedTypedArray.ofFloat64Array openValues,
            highEncoded = EncodedTypedArray.ofFloat64Array highValues,
            lowEncoded = EncodedTypedArray.ofFloat64Array lowValues,
            closeEncoded = EncodedTypedArray.ofFloat64Array closeValues,
            xEncoded = EncodedTypedArray.ofFloat64Array xs,
            Name = "encoded candlestick root",
            UseDefaults = true
        )
        |> Chart.withTitle "H1-D: distribution and finance roots with encoded arrays"

    chartCandlestickEncodedRootPoC |> Chart.show

    0
