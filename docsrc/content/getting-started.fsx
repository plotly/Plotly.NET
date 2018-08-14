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

(**
## Using functional F# scripting style
*)


Chart.Scatter ([1; 2; 3; 4],[12; 9; 15; 12],
      StyleParam.Mode.Lines_Markers,
      Name="lines and markers")

(**
## Using dynamic object style
*)

let scattern = 
    let dyn = Trace("scatter")
    dyn?x <- [1; 2; 3; 4]
    dyn?y <- [12; 9; 15; 12]
    dyn?mode <- "lines+markers"
    dyn?name <- "lines and markers"
    dyn

scattern
|> GenericChart.ofTraceObject



(**
## Using guided dynamic style
*)

Trace.initScatter (
       Trace.TraceStyle.Scatter
            ( X    = [1; 2; 3; 4],
              Y    = [12; 9; 15; 12], 
              Mode = StyleParam.Mode.Lines_Markers
            )     )               
|> Trace.TraceStyle.TraceInfo(Name="lines and markers")
|> GenericChart.ofTraceObject 


(**
## Using mixed dynamic object style
*)
Trace.initScatter 
    (fun scatter ->
        scatter?x <- [1; 2; 3; 4]
        scatter?y <- [12; 9; 15; 12]
        scatter?mode <- "lines+markers"
        scatter?name <- "lines and markers"
        scatter
    )
|> GenericChart.ofTraceObject

