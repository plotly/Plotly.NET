(*** hide ***)
#r "netstandard"
#r "../../bin/FSharp.Plotly/netstandard2.0/FSharp.Plotly.dll"
open FSharp.Plotly

(** 
# FSharp.Plotly: Parallel Categories Plot

*Summary:* This example shows how to create parallel categories plot in F#.

The parallel categories diagram (also known as parallel sets or alluvial diagram) is a visualization of multi-dimensional categorical data sets. Each variable in the data set is represented by a column of rectangles, where each rectangle corresponds to a discrete value taken on by that variable. The relative heights of the rectangles reflect the relative frequency of occurrence of the corresponding value.

Combinations of category rectangles across dimensions are connected by ribbons, where the height of the ribbon corresponds to the relative frequency of occurrence of the combination of categories in the data set.
*)


let dims' =
    [
        Dimensions.init(["Cat1";"Cat1";"Cat1";"Cat1";"Cat2";"Cat2";"Cat3"],Label="A")
        Dimensions.init([0;1;0;1;0;0;0],Label="B",TickText=["YES","NO"])
    ]

let parcats =
    Chart.ParallelCategories(dims=dims',Color=[0.;1.;0.;1.;0.;0.;0.],Colorscale = StyleParam.Colorscale.Blackbody)


(***do-not-eval***)
parcats |> Chart.Show

(*** include-value:parcats ***)
