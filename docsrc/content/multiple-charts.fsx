(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#r "netstandard"
#r "../../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"


(**
Multiple charts and subcharts
=============================

How to create subplots in Plotly.NET. Find examples of combined, stacked, and plots with multiple axis.

*)


(**
## Chart subplot grids

### Chart.Grid

`Chart.Grid` takes a 2D input sequence of charts and creates a subplot grid with the dimensions outerlength x (max (innerLengths))



*)
open Plotly.NET


//simple 3x3 subplot grid
let grid = 
    Chart.Grid(
        [
            [Chart.Point([(0,1)]); Chart.Point([(0,1)]); Chart.Point([(0,1)]);]
            [Chart.Point([(0,1)]); Chart.Point([(0,1)]); Chart.Point([(0,1)]);]
            [Chart.Point([(0,1)]); Chart.Point([(0,1)]); Chart.Point([(0,1)]);]
        ]
    )

(***do-not-eval***)
grid |> Chart.Show

(*** include-value:grid ***)


(**
use `sharedAxis=true` to use one shared x axis per column and one shared y axis per row. 
(Try zooming in the single subplots below)
*)

let grid2 =
    Chart.Grid(
        [
            [Chart.Point([(0,1)]); Chart.Point([(0,1)]); Chart.Point([(0,1)]);]
            [Chart.Point([(0,1)]); Chart.Point([(0,1)]); Chart.Point([(0,1)]);]
            [Chart.Point([(0,1)]); Chart.Point([(0,1)]); Chart.Point([(0,1)]);]
        ],sharedAxes=true,rowOrder = StyleParam.LayoutGridRowOrder.BottomToTop
    )

(***do-not-eval***)
grid2 |> Chart.Show

(*** include-value:grid2 ***)


(** 
### Chart.SingleStack

The `Chart.SingleStack` function is a special version of Chart.Grid that creates only one column from a 1D input chart sequence.
It uses a shared x axis per default. You can also use the Chart.withLayoutGridStyle to further style subplot grids:

*)

let singleStack =
    [
        Chart.Point([(0,1)]) |> Chart.withY_AxisStyle("This title must")
        Chart.Point([(0,1)]) 
        |> Chart.withY_AxisStyle("be set on the",Zeroline=false)
        Chart.Point([(0,1)]) 
        |> Chart.withY_AxisStyle("respective subplots",Zeroline=false)
    ]
    |> Chart.SingleStack
    //move xAxis to bottom and increase spacing between plots by using the withLayoutGridStyle function
    |> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom,YGap= 0.1)
    |> Chart.withTitle("Hi i am the new SingleStackChart")
    |> Chart.withX_AxisStyle("im the shared xAxis")


(***do-not-eval***)
singleStack |> Chart.Show

(*** include-value:singleStack ***)

(**
Functional F# scripting style for Two Y-Axes
*)

let twoYaxes =
    [
        Chart.Scatter ([1; 2; 3; 4],[12; 9; 15; 12],StyleParam.Mode.Lines_Markers,Name="anchor 1")
        |> Chart.withAxisAnchor(Y=1);
        Chart.Line([1; 2; 3; 4],[90; 110; 190; 120],Name="anchor 2")
        |> Chart.withAxisAnchor(Y=2);
    ]
    |> Chart.Combine
    |> Chart.withY_AxisStyle("first",Side=StyleParam.Side.Left,Id=1)
    |> Chart.withY_AxisStyle("second",Side=StyleParam.Side.Right,Id=2,Overlaying=StyleParam.AxisAnchorId.Y 1)

(***do-not-eval***)
twoYaxes |> Chart.Show

(*** include-value:twoYaxes ***)

(**
Functional F# scripting style for Two Y-Axes same side
*)

let twoYaxesSide =
    [
        Chart.Scatter ([1; 2; 3; 4],[12; 9; 15; 12],StyleParam.Mode.Lines_Markers,Name="anchor 1")
        |> Chart.withAxisAnchor(Y=1);
        Chart.Line([1; 2; 3; 4],[90; 110; 190; 120],Name="anchor 2")
        |> Chart.withAxisAnchor(Y=2);
    ]
    |> Chart.Combine
    |> Chart.withX_AxisStyle("x-axis",Domain=(0.3, 1.0))
    |> Chart.withY_AxisStyle("first y-axis")
    |> Chart.withY_AxisStyle("second y-axis",Side=StyleParam.Side.Left,Id=2,
            Overlaying=StyleParam.AxisAnchorId.Y 1,Position=0.15,Anchor=StyleParam.AxisAnchorId.Free)

(***do-not-eval***)
twoYaxesSide |> Chart.Show

(*** include-value:twoYaxesSide ***)
