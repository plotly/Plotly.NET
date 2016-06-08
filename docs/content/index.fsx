(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"

(**
FSharp.Plotly
======================

The library FSharp.Plotly implements charting suitable for use from F# scripting. Once you load the library as followed, you can use the members of the 'Chart' type to easily build charts.

FSharp.Plotly is powered by popular JavaScript charting library [Plotly](https://plot.ly/). The library provides a complete mapping for the configuration options of the underlying library but empowers you to use the comfortable style known from the beautiful library [F# Charting](http://fslab.org/FSharp.Charting/). So you get a nice F# interface support with the full power of Plotly.
*)

#r "FSharp.Plotly.dll"
open FSharp.Plotly

(**
Example
-------

The following example creates a combined point and line chart:
*)
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.] 
[
    Chart.Point(x,y,Name="scattern");
    Chart.Line(x,y',Name="line")    
    |> Chart.withLineStyle(Width=1);
] 
|> Chart.Combine

(**
Contributing and copyright
--------------------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding a new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read the [library design notes][readme] to understand how it works.

The library is available under Public Domain license, which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information see the 
[License file][license] in the GitHub repository. 

  [content]: https://github.com/fsprojects/FSharp.Plotly/tree/master/docs/content
  [gh]: https://github.com/fsprojects/FSharp.Plotly
  [issues]: https://github.com/fsprojects/FSharp.Plotly/issues
  [readme]: https://github.com/fsprojects/FSharp.Plotly/blob/master/README.md
  [license]: https://github.com/fsprojects/FSharp.Plotly/blob/master/LICENSE.txt
*)
