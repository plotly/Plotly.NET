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