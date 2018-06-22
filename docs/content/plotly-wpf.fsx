(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.

(**
FSharp.Plotly
======================

The library FSharp.Plotly implements charting suitable for use from F# scripting. Once you load the library as followed, you can use the members of the `Chart` type to easily build charts.

FSharp.Plotly is powered by popular JavaScript charting library [Plotly](https://plot.ly/). The library provides a complete mapping for the configuration options of the underlying library but empowers you to use the comfortable style known from the beautiful library [F# Charting](http://fslab.org/FSharp.Charting/). So you get a nice F# interface support with the full power of Plotly.
*)

#r "../../bin/FSharp.Plotly.WPF/net461/FSharp.Plotly.dll"
#r "../../bin/FSharp.Plotly.WPF/net461/FSharp.Plotly.WPF.dll"

open FSharp.Plotly
open FSharp.Plotly.WPF

(**
Example
-------

The following example creates a combined point and line chart:
*)
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
(**
Create the combined chart
*)
(*** define-output:pie1 ***)
[
    Chart.Point(x,y,Name="scattern");
    Chart.Line(x,y',Name="line")    
    |> Chart.withLineStyle(Width=2);
] 
|> Chart.Combine
(*** include-it:pie1 ***)
(**
By piping the combined chart into `Chart.Show` function it will be displayed in your browser.
*)
(*** do-not-eval ***)
|> Chart.ShowWPF
