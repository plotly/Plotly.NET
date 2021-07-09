namespace Plotly.NET.ImageExport
open Plotly.NET

type IGenericChartRenderer =

    abstract member RenderJPGAsync: int * int * GenericChart.GenericChart -> Async<string>
    abstract member RenderJPG: int * int * GenericChart.GenericChart -> string

    abstract member SaveJPGAsync: string * int * int * GenericChart.GenericChart -> Async<unit>
    abstract member SaveJPG: string * int * int * GenericChart.GenericChart -> unit

    abstract member RenderPNGAsync: int * int * GenericChart.GenericChart -> Async<string>
    abstract member RenderPNG: int * int * GenericChart.GenericChart -> string

    abstract member SavePNGAsync: string * int * int * GenericChart.GenericChart -> Async<unit>
    abstract member SavePNG: string * int * int * GenericChart.GenericChart -> unit

    abstract member RenderSVGAsync: int * int * GenericChart.GenericChart -> Async<string>
    abstract member RenderSVG: int * int * GenericChart.GenericChart -> string

    abstract member SaveSVGAsync: string * int * int * GenericChart.GenericChart -> Async<unit>
    abstract member SaveSVG: string * int * int * GenericChart.GenericChart -> unit
