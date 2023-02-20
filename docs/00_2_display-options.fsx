(**
---
title: Display Options
category: General
categoryindex: 1
index: 3
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine, 1.4.0"
#r "../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <- Plotly.NET.DisplayOptions.init(PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)


(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Display Options

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to alter the display options that control the html document that contains plotly charts

You can control the html document that gets created via `Chart.Show` with various functions that change a chart's `DisplayOptions`.

Naturally, these full html documents can not be embedded in this documentation page, so sometimes images have to suffice for demonstrations here.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

(**
## Referencing PlotlyJS

For rendering plotly.js charts in a html document, you need to reference plotly.js in some form (duh!)

Plotly.NET provides multiple ways to do that in the generated html:

- `Full`: Include the full plotly.js source in a script tag. HTML files using this option are self-contained and can be used offline.
- `CDN`: The default. uses a script tag in the head of the generated HTML to load plotly.js from a CDN.
- `Require`: Use requirejs to load plotly. This option is for example used in Plotly.NET.Interactive inside notebooks.
- `NoReference`: Don't include any plotly.js reference. Useful if you want to embed the output into another page that already references plotly - the documentation pages you are reading now are generated with this option.

You can control this on a per-chart basis via `Chart.withDisplayOptionsStyle`, for example if you want to include a script tag with the full plotly.js source:

*)

(***do-not-eval***)
Chart.Point(x = x, y = y)
|> Chart.withDisplayOptionsStyle(
    PlotlyJSReference = Full
)


(**
## Writing HTML tags and including Chart descriptions

Plotly.NET uses [Giraffe.ViewEngine](https://github.com/giraffe-fsharp/Giraffe.ViewEngine) internally to generate HTML documents, which means you can also use that DSL to add additional content to the output.

For example, use `Chart.withDescription` to append a list of html tags below the rendered chart:
*)

open Giraffe.ViewEngine

let desc1 =
    Chart.Point(
        x = x, 
        y = y,
        Name="desc1"
    )    
    |> Chart.withDescription [
        h1 [] [str "Hello"]
        p [] [str "F#"]
        ol [] [
            li [] [str "Item 1"]
            li [] [str "Item 2"]
        ]
    ]


(*** condition: ipynb ***)
#if IPYNB
desc1
#endif // IPYNB

(***hide***)
desc1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Adding additional head tags

_Note: the example here is shown via an image, as the docs themselves are html pages that cannot load additional head tags._

You can add any number of additional html tags to the documents `<head>` tag using `Chart.WithAdditionalHeadTags`.

For example, you can load external css libraries to style the chart description:
*)

//html for description containing bulma classes such as "hero"
let bulmaHero = 
    section [_class"hero is-primary is-bold"] [
        div [_class "hero-body"] [
            p [_class "title"] [str "Hero title"]
            p [_class "subtitle"] [str "Hero subtitle"]
        ]
    ]
// chart description containing bulma classes
let description3 = [
    h1 [_class "title"] [str "I am heading"]
    bulmaHero
]

let desc3 =
    Chart.Point(
        x = x, 
        y = y,
        Name="desc3"
    )    
    |> Chart.withAdditionalHeadTags [
        link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/npm/bulma@0.9.2/css/bulma.min.css"]
    ]
    |> Chart.withDescription description3

(**
![]({{root}}img/desc3.png)

## Using MathTeX

`Chart.WithMathTex` is a prebuilt function to enable MathTeX for your generated plotly chart documents.

It will add a MathJax script reference to your document based on which version (either 2 or 3) you want to use:
*)

let mathtex_chart =
    [
        Chart.Point(xy = [(1.,2.)],Name = @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
        Chart.Point(xy = [(2.,4.)],Name = @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
    ]
    |> Chart.combine
    |> Chart.withTitle @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$"
    |> Chart.withMathTex(AppendTags = true, MathJaxVersion = 3)

(*** condition: ipynb ***)
#if IPYNB
mathtex_chart
#endif // IPYNB

(***hide***)
mathtex_chart |> GenericChart.toChartHTML
(***include-it-raw***)

