open System
open Plotly.NET

[<EntryPoint>]
let main _ =

    let pointCount = 250
    let xs = [| for i in 0 .. pointCount - 1 -> float i * 2.0 * Math.PI / float (pointCount - 1) |]
    let ys = xs |> Array.map sin
    let band = xs |> Array.map (fun x -> 0.15 + 0.1 * abs (cos x))
    let upper = Array.map2 (+) ys band
    let lower = Array.map2 (-) ys band

    let chartRangeEncodedHelperPoC =
        Chart.Range(
            x = xs,
            y = ys,
            upper = upper,
            lower = lower,
            XEncoded = EncodedTypedArray.ofFloat64Array xs,
            YEncoded = EncodedTypedArray.ofFloat64Array ys,
            UpperEncoded = EncodedTypedArray.ofFloat64Array upper,
            LowerEncoded = EncodedTypedArray.ofFloat64Array lower,
            mode = StyleParam.Mode.Lines,
            Name = "sin(x)",
            GroupName = "confidence band",
            RangeColor = Color.fromString "rgba(24,119,242,0.2)",
            LineColor = Color.fromString "#1877f2",
            UseDefaults = true
        )
        |> Chart.withTitle "H1-B: scatter-derived helper with encoded arrays"

    chartRangeEncodedHelperPoC |> Chart.show

    0
