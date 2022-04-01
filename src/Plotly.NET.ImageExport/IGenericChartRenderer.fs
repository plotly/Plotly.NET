namespace Plotly.NET.ImageExport

open Plotly.NET

/// <summary>
/// Interface for Engines that render Plotly.NET's GenericChart to static images.
/// </summary>
type IGenericChartRenderer =

    ///<summary>Async function that returns a base64 encoded string representing the input chart as JPG file with the given width and height</summary>
    abstract member RenderJPGAsync: int * int * GenericChart.GenericChart -> Async<string>
    ///<summary>Function that returns a base64 encoded string representing the input chart as JPG file with the given width and height</summary>
    abstract member RenderJPG: int * int * GenericChart.GenericChart -> string

    ///<summary>Async function that saves the input chart as JPG file with the given width and height at the given path</summary>
    abstract member SaveJPGAsync: string * int * int * GenericChart.GenericChart -> Async<unit>
    ///<summary>Function that saves the input chart as JPG file with the given width and height at the given path</summary>
    abstract member SaveJPG: string * int * int * GenericChart.GenericChart -> unit

    ///<summary>Async function that returns a base64 encoded string representing the input chart as PNG file with the given width and height</summary>
    abstract member RenderPNGAsync: int * int * GenericChart.GenericChart -> Async<string>
    ///<summary>Function that returns a base64 encoded string representing the input chart as PNG file with the given width and height</summary>
    abstract member RenderPNG: int * int * GenericChart.GenericChart -> string

    ///<summary>Async function that saves the input chart as PNG file with the given width and height at the given path</summary>
    abstract member SavePNGAsync: string * int * int * GenericChart.GenericChart -> Async<unit>
    ///<summary>Function that saves the input chart as PNG file with the given width and height at the given path</summary>
    abstract member SavePNG: string * int * int * GenericChart.GenericChart -> unit

    ///<summary>Async function that returns a string representing the input chart as SVG file with the given width and height</summary>
    abstract member RenderSVGAsync: int * int * GenericChart.GenericChart -> Async<string>
    ///<summary>Function that returns string representing the input chart as SVG file with the given width and height</summary>
    abstract member RenderSVG: int * int * GenericChart.GenericChart -> string

    ///<summary>Async function that saves the input chart as SVG file with the given width and height at the given path</summary>
    abstract member SaveSVGAsync: string * int * int * GenericChart.GenericChart -> Async<unit>
    ///<summary>Function that saves the input chart as SVG file with the given width and height at the given path</summary>
    abstract member SaveSVG: string * int * int * GenericChart.GenericChart -> unit
