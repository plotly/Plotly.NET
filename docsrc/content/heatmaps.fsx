(*** hide ***)
#r "netstandard"
#r "../../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(** 
# Plotly.NET: Heatmaps

*Summary:* This example shows how to create heatmap charts in F#.

A heatmap chart can be created using the `Chart.HeatMap` functions.
When creating heatmap charts, it is usually desirable to provide the values in matrix form, rownames and colnames.
*)

open Plotly.NET 
 

let matrix =
    [[1.;1.5;0.7;2.7];
    [2.;0.5;1.2;1.4];
    [0.1;2.6;2.4;3.0];]

let rownames = ["p3";"p2";"p1"]
let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]



let colorscaleValue = 
    //StyleParam.ColorScale.Electric
    StyleParam.Colorscale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]

// Generating the Heatmap 
let heat1 =
    Chart.Heatmap(matrix,colnames,rownames,Colorscale=colorscaleValue,Showscale=true)
    |> Chart.withSize(700.,500.)
    |> Chart.withMarginSize(Left=200.)

(***do-not-eval***)
heat1 |> Chart.Show

(***include-value:heat1***)

(**
## Styling Colorbars

All charts that contain colorbars can be styled by the `Chart.withColorBarStyle` function.
Here is an example that adds a title to the colorbar:
*)

let heat2 =
    heat1
    |> Chart.withColorBarStyle(
        "Im the Colorbar",
        TitleSide = StyleParam.Side.Right,
        TitleFont = Font.init(Size=20)
    )

(***do-not-eval***)
heat2 |> Chart.Show

(***include-value:heat2***)
