open System
open Deedle
open System.IO
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects
open DynamicObj
open Giraffe.ViewEngine
open Newtonsoft.Json

[<EntryPoint>]
let main argv =

    let labelAlias = DynamicObj() 
    labelAlias?("1") <- "<b>ONE</b>"
    labelAlias?("0\u00B0") <- "<b>ZERO</b>"

    let linAxis = LinearAxis.init(LabelAlias=labelAlias)
    let angularAxis = AngularAxis.init(LabelAlias=labelAlias)
    let radialAxis = RadialAxis.init(LabelAlias=labelAlias)
    let imaginaryAxis = ImaginaryAxis.init(LabelAlias=labelAlias)
    let realAxis = RealAxis.init(LabelAlias=labelAlias)
    let colorBar = ColorBar.init(LabelAlias=labelAlias)

    [
        Chart.Point([1,1], UseDefaults = false) 
        |> Chart.withXAxis(linAxis)
        |> Chart.withYAxis(linAxis)

        Chart.Point3D([1,1,1], UseDefaults = false)
        |> Chart.withXAxis(linAxis, Id = StyleParam.SubPlotId.Scene 1)
        |> Chart.withYAxis(linAxis, Id = StyleParam.SubPlotId.Scene 1)
        |> Chart.withZAxis(linAxis)

        Chart.PointPolar([1,1], UseDefaults = false)
        |> Chart.withAngularAxis(angularAxis)
        |> Chart.withRadialAxis(radialAxis)

        Chart.PointTernary([1,1,1], UseDefaults = false)
        |> Chart.withAAxis(linAxis)
        |> Chart.withBAxis(linAxis)
        |> Chart.withCAxis(linAxis)


        [
            Chart.Carpet(
                carpetId = "carpet1",
                A = [4.; 4.; 4.; 4.5; 4.5; 4.5; 5.; 5.; 5.; 6.; 6.; 6.], 
                B = [1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.], 
                Y = [2.; 3.5; 4.; 3.; 4.5; 5.; 5.5; 6.5; 7.5; 8.; 8.5; 10.], 
                AAxis = linAxis,
                BAxis = linAxis,
                UseDefaults = false
            )

        ]
        |> Chart.combine

        Chart.Heatmap([[1;2];[3;4]], UseDefaults = false)
        |> Chart.withXAxis(linAxis)
        |> Chart.withYAxis(linAxis)
        |> Chart.withColorBar(colorBar)

        Chart.PointSmith([1,2], UseDefaults = false)
        |> Chart.withImaginaryAxis(imaginaryAxis)
        |> Chart.withRealAxis(realAxis)

        Chart.Indicator(
            value = 1, 
            mode = StyleParam.IndicatorMode.NumberDeltaGauge,
            DeltaReference = 0,
            Range = StyleParam.Range.MinMax(-1., 1.),
            GaugeShape = StyleParam.IndicatorGaugeShape.Bullet,
            ShowGaugeAxis = true,
            GaugeAxis = linAxis,
            UseDefaults = false
        )

    ]
    |> List.iter Chart.show
    0