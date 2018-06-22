(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"

(**
Getting started...
==================

FSharp.Plotly implements charting suitable for use from F# scripting. Once you load the library as followed, you can use the members of the `Chart` type to easily build charts.

The library provides a complete mapping for the configuration options of the underlying library but empowers you to use the comfortable style known from the beautiful library [F# Charting](http://fslab.org/FSharp.Charting/). So you get a nice F# interface support with the full power of Plotly.
*)


open FSharp.Plotly

// Functional F# scripting style for Two Y-Axes

[
Chart.Scatter ([1; 2; 3; 4],[12; 9; 15; 12],StyleParam.Mode.Lines_Markers,Name="anchor 1")
|> Chart.withAxisAnchor(Y=1);
Chart.Line([1; 2; 3; 4],[90; 110; 190; 120],Name="anchor 2")
|> Chart.withAxisAnchor(Y=2);
]
|> Chart.Combine
|> Chart.withY_AxisStyle("first",Side=StyleParam.Side.Left,Id=1)
|> Chart.withY_AxisStyle("second",Side=StyleParam.Side.Right,Id=2,Overlaying=StyleParam.AxisAnchorId.Y 1)



// Functional F# scripting style for Two Y-Axes same side

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




// Simple Subplot

