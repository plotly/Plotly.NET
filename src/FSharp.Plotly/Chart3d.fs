namespace FSharp.Plotly

open System
open System.IO
open FSharp.Care.Collections

open GenericChart3d
    
/// Provides a set of static methods for creating charts.
type Chart3d =

    /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(x, y, z, mode, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let trace = 
            Trace3dObjects.Scatter3d()
            |> Options3d.Scatter3d(X = x,Y = y,Z=z, Mode=mode)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart3d.Chart (trace,None)


