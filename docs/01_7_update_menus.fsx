(**
---
title: Update menus
category: Chart Layout
categoryindex: 2
index: 8
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Sliders

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create charts with update menus in F#.
*)

#r "nuget: FSharp.Data"
#r "nuget: Deedle"

open FSharp.Data
open Deedle
open Plotly.NET
open Plotly.NET.LayoutObjects

let data =
    "https://raw.githubusercontent.com/plotly/datasets/master/volcano.csv"
    |> Http.RequestString
    |> Frame.ReadCsvString
    |> Frame.toJaggedArray

let updateMenu =
    UpdateMenu.init(
        Buttons = [
            UpdateMenuButton.init(
                Args = ["type"; "surface"],
                Label = "Surface",
                Method = StyleParam.UpdateMethod.Restyle
            )            
            UpdateMenuButton.init(
                Args = ["type"; "heatmap"],
                Label = "Heatmap",
                Method = StyleParam.UpdateMethod.Restyle
            )
        ],
        Direction = StyleParam.UpdateMenuDirection.Down,
        Pad = Padding.init(R = 10, T = 10),
        ShowActive = true,
        X = 0.1,
        XAnchor = StyleParam.XAnchorPosition.Left,
        Y = 1.1,
        YAnchor = StyleParam.YAnchorPosition.Top
    )

let updateChart = 
    Chart.Surface(
        data
    )
    |> Chart.withUpdateMenu updateMenu
    |> Chart.withAnnotation (
        Annotation.init(
            Text = "Trace Type:", 
            ShowArrow = false,
            X = 0,
            Y = 1.085,
            YRef = "paper",
            Align = StyleParam.AnnotationAlignment.Left
        )
    )
    |> Chart.withScene(
        Scene.init(
            AspectRatio = AspectRatio.init(X=1.,Y=1.,Z=0.7),
            AspectMode = StyleParam.AspectMode.Manual
        )
    )
    |> Chart.withLayoutStyle(
        Width = 800,
        Height = 900,
        AutoSize = false,
        Margin = Margin.init(0,0,0,0)
    )

(*** condition: ipynb ***)
#if IPYNB
updateChart
#endif // IPYNB

(***hide***)
updateChart |> GenericChart.toChartHTML
(***include-it-raw***)