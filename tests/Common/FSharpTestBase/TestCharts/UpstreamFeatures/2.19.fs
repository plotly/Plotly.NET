module PlotlyJS_2_19_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects

module ShapeLabel =
    
    let internal x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let internal y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    
    let internal shapes = 
        [
            Shape.init(
                ShapeType=StyleParam.ShapeType.Rectangle,
                X0=2.,X1=4.,Y0=3.,Y1=4.,
                Opacity=0.3,
                FillColor=Color.fromHex "#d3d3d3",
                Label = ShapeLabel.init(Text="Rectangle")
            )
            Shape.init(
                ShapeType=StyleParam.ShapeType.Circle,
                X0=5.,X1=7.,Y0=3.,Y1=4.,
                Opacity=0.3,
                FillColor=Color.fromHex "#d3d3d3",
                Label = ShapeLabel.init(Text="Circle", Padding = 20)
            )
            Shape.init(
                ShapeType=StyleParam.ShapeType.Line,
                    X0=1.,X1=2.,Y0=1.,Y1=2.,
                    Opacity=0.3,
                    FillColor=Color.fromHex "#d3d3d3",
                    Label = ShapeLabel.init(Text="Line")
            )
            Shape.init(
                ShapeType=StyleParam.ShapeType.SvgPath,
                Path=" M 3,7 L2,8 L2,9 L3,10, L4,10 L5,9 L5,8 L4,7 Z",
                Label = ShapeLabel.init(Text="SVGPath", TextAngle = StyleParam.TextAngle.Degrees 33)
            )
        ]


    let ``Rectangular shape with label`` =
        Chart.Line(x = x,y = y, UseDefaults = false)    
        |> Chart.withShape(shapes[0])

    let ``Circular shape with label and padding`` =
        Chart.Line(x = x,y = y, UseDefaults = false)    
        |> Chart.withShape(shapes[1])

    let ``Line shape with label`` =
        Chart.Line(x = x,y = y, UseDefaults = false)    
        |> Chart.withShape(shapes[2])

    let ``SVGPath shape with angled label`` =
        Chart.Line(x = x,y = y, UseDefaults = false)    
        |> Chart.withShape(shapes[3])

module LabelAlias = 

    open DynamicObj

    let internal labelAlias = DynamicObj() 
    labelAlias?("1") <- "<b>ONE</b>"
    labelAlias?("0\u00B0") <- "<b>ZERO</b>"

    let internal linAxis() = LinearAxis.init(LabelAlias=labelAlias)
    let internal angularAxis() = AngularAxis.init(LabelAlias=labelAlias)
    let internal radialAxis() = RadialAxis.init(LabelAlias=labelAlias)
    let internal imaginaryAxis() = ImaginaryAxis.init(LabelAlias=labelAlias)
    let internal realAxis() = RealAxis.init(LabelAlias=labelAlias)
    let internal colorBar() = ColorBar.init(LabelAlias=labelAlias)

    let ``Point chart with label alias`` =
        Chart.Point([1,1], UseDefaults = false) 
        |> Chart.withXAxis(linAxis())
        |> Chart.withYAxis(linAxis())

    let ``3D point chart with label alias`` =
        Chart.Point3D([1,1,1], UseDefaults = false)
        |> Chart.withXAxis(linAxis(), Id = StyleParam.SubPlotId.Scene 1)
        |> Chart.withYAxis(linAxis(), Id = StyleParam.SubPlotId.Scene 1)
        |> Chart.withZAxis(linAxis())

    let ``Polar point chart with leabel alias`` =
        Chart.PointPolar([1,1], UseDefaults = false)
        |> Chart.withAngularAxis(angularAxis())
        |> Chart.withRadialAxis(radialAxis())

    let ``Ternary point chart with label alias`` =
        Chart.PointTernary([1,1,1], UseDefaults = false)
        |> Chart.withAAxis(linAxis())
        |> Chart.withBAxis(linAxis())
        |> Chart.withCAxis(linAxis())

    let ``Carpet chart with label alias`` =
        Chart.Carpet(
            carpetId = "carpet1",
            A = [4.; 4.; 4.; 4.5; 4.5; 4.5; 5.; 5.; 5.; 6.; 6.; 6.], 
            B = [1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.; 1.; 2.; 3.], 
            Y = [2.; 3.5; 4.; 3.; 4.5; 5.; 5.5; 6.5; 7.5; 8.; 8.5; 10.], 
            AAxis = linAxis(),
            BAxis = linAxis(),
            UseDefaults = false
        )

    let ``Heatmap chart with label alias`` =
        Chart.Heatmap([[1;2];[3;4]], UseDefaults = false)
        |> Chart.withXAxis(linAxis())
        |> Chart.withYAxis(linAxis())
        |> Chart.withColorBar(colorBar())

    let ``Point smith chart with label alias`` =
        Chart.PointSmith([1,2], UseDefaults = false)
        |> Chart.withImaginaryAxis(imaginaryAxis())
        |> Chart.withRealAxis(realAxis())

    let ``Bullet gauge indicator chart with label alias`` =
        Chart.Indicator(
            value = 1, 
            mode = StyleParam.IndicatorMode.NumberDeltaGauge,
            DeltaReference = 0,
            Range = StyleParam.Range.MinMax(-1., 1.),
            GaugeShape = StyleParam.IndicatorGaugeShape.Bullet,
            ShowGaugeAxis = true,
            GaugeAxis = linAxis(),
            UseDefaults = false
        )