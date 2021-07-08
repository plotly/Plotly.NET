namespace Plotly.NET.ImageExport
open Plotly.NET

type IGenericChartRenderer =

    abstract member RenderJPG: int * int * GenericChart.GenericChart -> string
    abstract member SaveJPG: string * int * int * GenericChart.GenericChart -> unit

    abstract member RenderPNG: int * int * GenericChart.GenericChart -> string
    abstract member SavePNG: string * int * int * GenericChart.GenericChart -> unit

    abstract member RenderSVG: int * int * GenericChart.GenericChart -> string
    abstract member SaveSVG: string * int * int * GenericChart.GenericChart -> unit
