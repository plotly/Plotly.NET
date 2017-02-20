(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#r "../../bin/Newtonsoft.Json.dll"
#r "../../lib/FSharp.Care.dll"

(**
Getting started...
==================

FSharp.Plotly implements charting suitable for use from F# scripting. Once you load the library as followed, you can use the members of the `Chart` type to easily build charts.

The library provides a complete mapping for the configuration options of the underlying library but empowers you to use the comfortable style known from the beautiful library [F# Charting](http://fslab.org/FSharp.Charting/). So you get a nice F# interface support with the full power of Plotly.
*)

#r "../../bin/FSharp.Plotly.dll"
open FSharp.Plotly


Trace.initScatter (fun scatter ->
    scatter?x <- [1; 2; 3; 4]
    scatter?y <- [1; 2; 3; 4]
    scatter?mode <- "lines+markers"
    scatter?name <- "lines and markers"
    scatter
    )
|> GenericChart.ofTraceObject
|> Chart.Show





open FSharp.Care.Colors
let red' = FSharp.Care.Colors.toHex false Table.Office.red

Chart.Point([1; 2; 3; 4],[12; 9; 15; 12])
|> Chart.withMarkerStyle(Color=red')
|> Chart.Show

