(*** hide ***)
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"


(** 
# FSharp.Plotly: Parallel Coordinates Plot

*Summary:* This example shows how to create parallel coordinates plot in F#.

Parallel coordinates are a common way of visualizing high-dimensional geometry and analyzing multivariate data.
To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically 
vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; 
the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
*)

open FSharp.Plotly 

let data = 
    ['A',[|1.;4.;3.4;0.7;|]; 'B',[|3.;1.5;1.7;2.3;|]; 'C',[|2.;4.;3.1;5.|]; 'D',[|4.;2.;2.;4.;|];]


(*** define-output:parcoords1 ***)
Chart.ParallelCoord(data,Color="blue")
(*** include-it:parcoords1 ***)


// Dynanic object version
let parcoords = 
    let v = [|
        Dimensions.init([|1.;4.;|],  
            StyleParam.Range.MinMax (1.,5.),StyleParam.Range.MinMax (1.,2.),Label='A');
        Dimensions.init([|3.;1.5;|], 
            StyleParam.Range.MinMax (1.,5.),Label='B',Tickvals=[|1.5;3.;4.;5.;|]);
        Dimensions.init([|2.;4.;|],  
            StyleParam.Range.MinMax (1.,5.),Label='C',Tickvals=[|1.;2.;4.;5.;|],
                TickText=[|"txt 1";"txt 2";"txt 4";"txt 5";|]);
        Dimensions.init([|4.;2.;|],  
            StyleParam.Range.MinMax (1.,5.),Label='D');
    |]
    let dyn = Trace("parcoords")
    dyn?dimensions <- v
    dyn?line <- Line.init(Color = "blue")
    dyn

(*** define-output:parcoords2 ***)
parcoords
|> GenericChart.ofTraceObject
(*** include-it:parcoords2 ***)



