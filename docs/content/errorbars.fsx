(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#r "../../bin/Newtonsoft.Json.dll"
#r "../../lib/FSharp.Care.dll"

(**
Multiple charts and subcharts
=============================

How to create subplots in FSharp.Plotly. Find examples of combined, stacked, and plots with multiple axis.

*)

#r "../../bin/FSharp.Plotly.dll"
open FSharp.Plotly


(**
Functional F# scripting style for Two Y-Axes
*)

[
Chart.Scatter ([1; 2; 3; 4],[12; 9; 15; 12],StyleParam.Mode.Lines_Markers,Name="anchor 1")
|> Chart.withAxisAnchor(Y=1);
Chart.Line([1; 2; 3; 4],[90; 110; 190; 120],Name="anchor 2")
|> Chart.withAxisAnchor(Y=2);
]
|> Chart.Combine
|> Chart.withY_AxisStyle("first",Side=StyleParam.Side.Left,Id=1)
|> Chart.withY_AxisStyle("second",Side=StyleParam.Side.Right,Id=2,Overlaying=StyleParam.AxisAnchorId.Y 1)
|> Chart.Show



(**
Functional F# scripting style for Two Y-Axes same side
*)

[
Chart.Scatter ([1; 2; 3; 4],[12; 9; 15; 12],StyleParam.Mode.Lines_Markers,Name="anchor 1")
|> Chart.withAxisAnchor(Y=1);
Chart.Line([1; 2; 3; 4],[90; 110; 190; 120],Name="anchor 2")
|> Chart.withAxisAnchor(Y=2);
]
|> Chart.Combine
|> Chart.withX_AxisStyle("x-axis",Domain=(0.3, 1.0))
|> Chart.withY_AxisStyle("first y-axis")
|> Chart.withY_AxisStyle("second y-axis",Side=StyleParam.Side.Left,Id=2,Overlaying=StyleParam.AxisAnchorId.Y 1,Position=0.15,Anchor=StyleParam.AxisAnchorId.Free)
|> Chart.Show



// Simple Subplot



