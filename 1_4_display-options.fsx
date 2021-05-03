(**
// can't yet format YamlFrontmatter (["title: Display Options"; "category: Chart Layout"; "categoryindex: 2"; "index: 5"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Display Options

[![Binder](https://plotly.github.io/Plotly.NET/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=1_4_display-options.ipynb)&emsp;
[![Script](https://plotly.github.io/Plotly.NET/img/badge-script.svg)](https://plotly.github.io/Plotly.NET/1_4_display-options.fsx)&emsp;
[![Notebook](https://plotly.github.io/Plotly.NET/img/badge-notebook.svg)](https://plotly.github.io/Plotly.NET/1_4_display-options.ipynb)

*Summary:* This example shows how to alter the display options that control the html document that contains plotly charts

You can control the html document that gets created via `Chart.Show` with various functions that change a chart's `DisplayOptions`.

Naturally, these full html documents can not be embedded in this documentation page, so images have to suffice in this case.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
(**
## Chart description

To create a chart description to put below the chart, use `ChartDescription.create` to create the description, and `Chart.WithDescription` 
to add the description to the chart's display options:
*)
let description1 =
    ChartDescription.create "Hello" "F#"
let desc1 =
    Chart.Point(x,y,Name="desc1")    
    |> Chart.WithDescription(description1)
    |> Chart.Show
(**
![](https://plotly.github.io/Plotly.NET/img/desc1.png)

The `ChartDescription` type is a bit barebones for now, but you can contain any valid html in both `Heading` and `Text` fields:
*)
let description2 =
    ChartDescription.create "<h1>I am heading</h1>" "<ol><li>Hi</li><li>there</li></ol>"
let desc2 =
    Chart.Point(x,y,Name="desc1")    
    |> Chart.WithDescription(description2)
    |> Chart.Show
(**
![](https://plotly.github.io/Plotly.NET/img/desc2.png)

## Adding additional head tags

You can add any number of additional html tags to the documents `<head>` tag using `Chart.WithAdditionalHeadTags`.

For example, you can load external css libraries to style the chart description:

*)
//html for description containing bulma classes such as "hero"
let bulmaHero = """<section class="hero is-primary is-bold">
  <div class="hero-body">
    <p class="title">
      Hero title
    </p>
    <p class="subtitle">
      Hero subtitle
    </p>
  </div>
</section>
"""

// chart description containing bulma classes
let description3 =
    ChartDescription.create 
        """<h1 class="title">I am heading</h1>""" 
       bulmaHero
let desc3 =
    Chart.Point(x,y,Name="desc3")    
    |> Chart.WithDescription description3
    // Add reference to the bulma css framework
    |> Chart.WithAdditionalHeadTags ["""<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.2/css/bulma.min.css">"""]
    |> Chart.Show
(**
![](https://plotly.github.io/Plotly.NET/img/desc3.png)

## Using MathTeX

By popular request, `Chart.WithMathTex` is a prebuilt function to enable MathTeX for your generated plotly chart documents:

*)
[
    Chart.Point([(1.,2.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
    Chart.Point([(2.,4.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
]
|> Chart.Combine
|> Chart.withTitle @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$"
// include mathtex tags in <head>. pass true to append these scripts, false to ONLY include MathTeX.
|> Chart.WithMathTex(true)
|> Chart.Show
(**
![](https://plotly.github.io/Plotly.NET/img/desc4.png)

*)

