namespace Plotly.NET.ImageExport

open System.Threading.Tasks
open Plotly.NET

/// <summary>
/// Interface for Engines that render Plotly.NET's GenericChart to static images.
/// </summary>
type IGenericChartRenderer =

    ///<summary>Async function that returns a base64 encoded string representing the input chart as JPG file with the given width, height, and scale</summary>
    abstract member RenderJPGAsync: width: int * height: int * scale: float * gChart: GenericChart -> Task<string>
    ///<summary>Function that returns a base64 encoded string representing the input chart as JPG file with the given width, height, and scale</summary>
    abstract member RenderJPG: width: int * height: int * scale: float * gChart: GenericChart -> string

    ///<summary>Async function that saves the input chart as JPG file with the given width, height, and scale at the given path</summary>
    abstract member SaveJPGAsync: path: string * width: int * height: int * scale: float * gChart: GenericChart -> Task<unit>
    ///<summary>Function that saves the input chart as JPG file with the given width, height, and scale at the given path</summary>
    abstract member SaveJPG: path: string * width: int * height: int * scale: float * gChart: GenericChart -> unit

    ///<summary>Async function that returns a base64 encoded string representing the input chart as PNG file with the given width, height, and scale</summary>
    abstract member RenderPNGAsync: width: int * height: int * scale: float * gChart: GenericChart -> Task<string>
    ///<summary>Function that returns a base64 encoded string representing the input chart as PNG file with the given width, height, and scale</summary>
    abstract member RenderPNG: width: int * height: int * scale: float * gChart: GenericChart -> string

    ///<summary>Async function that saves the input chart as PNG file with the given width, height, and scale at the given path</summary>
    abstract member SavePNGAsync: path: string * width: int * height: int * scale: float * gChart: GenericChart -> Task<unit>
    ///<summary>Function that saves the input chart as PNG file with the given width, height, and scale at the given path</summary>
    abstract member SavePNG: path: string * width: int * height: int * scale: float * gChart: GenericChart -> unit

    ///<summary>Async function that returns a string representing the input chart as SVG file with the given width, height, and scale</summary>
    abstract member RenderSVGAsync: width: int * height: int * scale: float * gChart: GenericChart -> Task<string>
    ///<summary>Function that returns string representing the input chart as SVG file with the given width, height, and scale</summary>
    abstract member RenderSVG: width: int * height: int * scale: float * gChart: GenericChart -> string

    ///<summary>Async function that saves the input chart as SVG file with the given width, height, and scale at the given path</summary>
    abstract member SaveSVGAsync: path: string * width: int * height: int * scale: float * gChart: GenericChart -> Task<unit>
    ///<summary>Function that saves the input chart as SVG file with the given width, height, and scale at the given path</summary>
    abstract member SaveSVG: path: string * width: int * height: int * scale: float * gChart: GenericChart -> unit
