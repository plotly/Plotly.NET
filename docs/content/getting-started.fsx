(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#r "../../bin/Newtonsoft.Json.dll"

(**
FSharp.Plotly
======================

The library FSharp.Plotly implements charting suitable for use from F# scripting. Once you load the library as followed, you can use the members of the `Chart` type to easily build charts.

FSharp.Plotly is powered by popular JavaScript charting library [Plotly](https://plot.ly/). The library provides a complete mapping for the configuration options of the underlying library but empowers you to use the comfortable style known from the beautiful library [F# Charting](http://fslab.org/FSharp.Charting/). So you get a nice F# interface support with the full power of Plotly.
*)

#r "../../bin/FSharp.Plotly.dll"
open FSharp.Plotly



let trace =
    Scatter(
        x = [1; 2; 3; 4],
        y = [12; 9; 15; 12],
        mode = "lines+markers"
        //name = "lines and markers"
    )

let layout =
    Layout()

GenericChart.ofTraceObject trace layout
|> Chart.Show




