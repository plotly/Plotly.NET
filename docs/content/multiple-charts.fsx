(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"


(**
Multiple charts and subcharts
=============================

How to create subplots in FSharp.Plotly. Find examples of combined, stacked, and plots with multiple axis.

*)
open FSharp.Plotly


(**
Functional F# scripting style for Two Y-Axes
*)

(*** define-output:twoYaxes ***)
[
    Chart.Scatter ([1; 2; 3; 4],[12; 9; 15; 12],StyleParam.Mode.Lines_Markers,Name="anchor 1")
    |> Chart.withAxisAnchor(Y=1);
    Chart.Line([1; 2; 3; 4],[90; 110; 190; 120],Name="anchor 2")
    |> Chart.withAxisAnchor(Y=2);
]
|> Chart.Combine
|> Chart.withY_AxisStyle("first",Side=StyleParam.Side.Left,Id=1)
|> Chart.withY_AxisStyle("second",Side=StyleParam.Side.Right,Id=2,Overlaying=StyleParam.AxisAnchorId.Y 1)
(*** include-it:twoYaxes ***)



(**
Functional F# scripting style for Two Y-Axes same side
*)

(*** define-output:twoYaxesSide ***)
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
(*** include-it:twoYaxesSide ***)


(**
Functional F# scripting style simple subplot stacked 2 columns.
Axis style (like: title) is taken from the single chart, but can also be styled by axis id.
*)

(*** define-output:stack ***)
[
    for i=1 to 8 do 
        yield Chart.Scatter ([1; 2; 3; 4],[12; 9; 15; 12],StyleParam.Mode.Lines_Markers) 
              |> Chart.withY_AxisStyle(sprintf "y-title %i" i) 
]
|> Chart.Stack(Columns=2,Space=0.15)
|> Chart.withX_AxisStyle(sprintf "x-title %i" 3,Id=3)
(*** include-it:stack ***)



