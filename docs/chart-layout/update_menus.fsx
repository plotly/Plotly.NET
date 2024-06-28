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
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../data/Deedle.dll"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Update menus

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create charts with update menus in F#.
*)

open Deedle
open Plotly.NET
open Plotly.NET.LayoutObjects

let data =
    __SOURCE_DIRECTORY__ + "/../data/volcano.csv"
    |> Frame.ReadCsv
    |> Frame.toJaggedArray

let updateMenu =
    UpdateMenu.init (
        Buttons = [   
            UpdateMenuButton.init (
                Args = [
                    let args = DynamicObj.DynamicObj()
                    args?("type") <- "surface"
                    args
                ],
                Label = "Surface",
                Method = StyleParam.UpdateMethod.Restyle
            )
            UpdateMenuButton.init (
                Args = [ 
                    let args = DynamicObj.DynamicObj()
                    args?("type") <- "heatmap"
                    args
                ],
                Label = "Heatmap",
                Method = StyleParam.UpdateMethod.Restyle
              )
        ],
        Direction = StyleParam.UpdateMenuDirection.Down,
        Pad = Padding.init (R = 10, T = 10),
        ShowActive = true,
        X = 0.1,
        XAnchor = StyleParam.XAnchorPosition.Left,
        Y = 1.1,
        YAnchor = StyleParam.YAnchorPosition.Top
    )

let updateChart =
    Chart.Surface(zData = data)
    |> Chart.withUpdateMenu updateMenu
    |> Chart.withAnnotation (
        Annotation.init (
            Text = "Trace Type:",
            ShowArrow = false,
            X = 0,
            Y = 1.085,
            YRef = "paper",
            Align = StyleParam.AnnotationAlignment.Left
        )
    )
    |> Chart.withScene (
        Scene.init (AspectRatio = AspectRatio.init (X = 1., Y = 1., Z = 0.7), AspectMode = StyleParam.AspectMode.Manual)
    )
    |> Chart.withLayoutStyle (Width = 800, Height = 900, AutoSize = false, Margin = Margin.init (0, 0, 0, 0))

(*** condition: ipynb ***)
#if IPYNB
updateChart
#endif // IPYNB

(***hide***)
updateChart |> GenericChart.toChartHTML
(***include-it-raw***)
