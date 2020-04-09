namespace FSharp.Plotly

open System
open System.IO
//open FSharp.Care.Collections

open GenericChart
open Trace
open Trace3d
open StyleParam
open System.Runtime.InteropServices


// ###########
// Copied from FSharp.Care.Collections to remove dependancies
[<AutoOpen>]
module Seq = 

    /// Splits a sequence of pairs into two sequences
    let unzip (input:seq<_>) =
        let (lstA, lstB) = 
            Seq.foldBack (fun (a,b) (accA, accB) -> 
                a::accA, b::accB) input ([],[])
        (Seq.ofList lstA, Seq.ofList lstB)    

    /// Splits a sequence of triples into three sequences
    let unzip3 (input:seq<_>) =
        let (lstA, lstB, lstC) = 
            Seq.foldBack (fun (a,b,c) (accA, accB, accC) -> 
                a::accA, b::accB, c::accC) input ([],[],[])
        (Seq.ofList lstA, Seq.ofList lstB, Seq.ofList lstC) 


/// Provides a set of static methods for creating charts.
type Chart =

    /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(x, y,mode,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=mode) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


     /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(xy,mode,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        let x,y = Seq.unzip xy 
        Chart.Scatter(x, y, mode,
            ?Name=Name,
            ?Showlegend=Showlegend,
            ?MarkerSymbol=MarkerSymbol,
            ?Color=Color,?Opacity=Opacity,
            ?Labels=Labels,
            ?TextPosition=TextPosition,
            ?TextFont=TextFont,
            ?Dash=Dash,
            ?Width=Width)


    /// Uses points to represent data points
    static member Point(x, y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
        
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Markers) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 

     /// Uses points to represent data points
    static member Point(xy,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont) = 
        let x,y = Seq.unzip xy 
        Chart.Point(x, y, ?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)


    /// Uses lines to represent data points
    static member Line(x, y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleParam.ModeUtils.showMarker (isShowMarker)

        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Lines) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 

    /// Uses lines to represent data points
    static member Line(xy,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        let x,y = Seq.unzip xy 
        Chart.Line(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width)


    /// A Line chart that plots a fitted curve through each data point in a series.
    static member Spline(x, y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing) = 
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleParam.ModeUtils.showMarker (isShowMarker)

        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Lines) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width, Shape=StyleParam.Shape.Spline, ?Smoothing=Smoothing)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// A Line chart that plots a fitted curve through each data point in a series.
    static member Spline(xy,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing) = 
        let x,y = Seq.unzip xy 
        Chart.Spline(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width,?Smoothing=Smoothing) 


    /// A variation of the Point chart type, where the data points are replaced by bubbles of different sizes.
    static member Bubble(x, y,sizes:seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
        
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Markers) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol, MultiSizes=sizes)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// A variation of the Point chart type, where the data points are replaced by bubbles of different sizes.
    static member Bubble(xysizes,[<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont) = 
        let x,y,sizes = Seq.unzip3 xysizes 
        Chart.Bubble(x, y,sizes=sizes,?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)
    
    
    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line 
    [<Obsolete("Use the constructors with the mandatory mode argument for full functionality")>]
    static member Range(x, y, upper, lower,?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels,?TextPosition,?TextFont) =             
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                >> StyleParam.ModeUtils.showMarker (isShowMarker)


        let trace = 
            Trace.initScatter (
                    TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Markers, ?Fillcolor=Color) )               
            |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend)
            |> TraceStyle.Line(?Color=Color)
            |> TraceStyle.Marker(?Color=Color)
            |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)

        let lower = 
            Trace.initScatter (
                    TraceStyle.Scatter(X = x,Y = lower, Mode=StyleParam.Mode.Lines, ?Fillcolor=RangeColor) )               
            |> TraceStyle.TraceInfo(Showlegend=false)
            |> TraceStyle.Line(Width=0)
            |> TraceStyle.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)")             

        let upper = 
            Trace.initScatter (
                    TraceStyle.Scatter(X = x,Y = upper, Mode=StyleParam.Mode.Lines, ?Fillcolor=RangeColor, Fill=StyleParam.Fill.ToNext_y) )               
            |> TraceStyle.TraceInfo(Showlegend=false)
            |> TraceStyle.Line(Width=0)
            |> TraceStyle.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)")             
 
        GenericChart.MultiChart ([lower;upper;trace],Layout(),Config())

    [<Obsolete("Use the constructors with the mandatory mode argument for full functionality")>]
    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line 
    static member Range(xy, upper, lower,?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels,?TextPosition,?TextFont) =   
        let x,y = Seq.unzip xy
        Chart.Range(x, y, upper, lower, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?Color=Color,?RangeColor=RangeColor,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)



    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line 
    static member Range(x, y, upper, lower,mode,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?RangeColor,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont) =             
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                >> StyleParam.ModeUtils.showMarker (isShowMarker)


        let trace = 
            Trace.initScatter (
                    TraceStyle.Scatter(X = x,Y = y, Mode=mode, ?Fillcolor=Color) )               
            |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend)
            |> TraceStyle.Line(?Color=Color)
            |> TraceStyle.Marker(?Color=Color)
            |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)

        let lower = 
            Trace.initScatter (
                    TraceStyle.Scatter(X = x,Y = lower, Mode=StyleParam.Mode.Lines, ?Fillcolor=RangeColor) )               
            |> TraceStyle.TraceInfo(Showlegend=false)
            |> TraceStyle.Line(Width=0)
            |> TraceStyle.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,0,0.5)")             

        let upper = 
            Trace.initScatter (
                    TraceStyle.Scatter(X = x,Y = upper, Mode=StyleParam.Mode.Lines, ?Fillcolor=RangeColor, Fill=StyleParam.Fill.ToNext_y) )               
            |> TraceStyle.TraceInfo(Showlegend=false)
            |> TraceStyle.Line(Width=0)
            |> TraceStyle.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,0,0.5)")             
 
        GenericChart.MultiChart ([lower;upper;trace],Layout(),Config())


    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line 
    static member Range(xy, upper, lower, mode,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?RangeColor,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont) =    
        let x,y = Seq.unzip xy
        Chart.Range(x, y, upper, lower, mode, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?Color=Color,?RangeColor=RangeColor,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member Area(x, y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleParam.ModeUtils.showMarker (isShowMarker)

        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Lines,Fill=StyleParam.Fill.ToZero_y) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member Area(xy,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        let x,y = Seq.unzip xy
        Chart.Area(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width) 


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member SplineArea(x, y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleParam.ModeUtils.showMarker (isShowMarker)
  
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Lines,Fill=StyleParam.Fill.ToZero_y) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width, Shape=StyleParam.Shape.Spline, ?Smoothing=Smoothing)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member SplineArea(xy,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing) = 
        let x,y = Seq.unzip xy
        Chart.SplineArea(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width,?Smoothing=Smoothing) 

    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member StackedArea(x, y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=StyleParam.Mode.Lines) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> TraceStyle.SetStackGroup "static"
        |> GenericChart.ofTraceObject 

    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member StackedArea(xy,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        let x,y = Seq.unzip xy
        Chart.StackedArea(x, y, ?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width) 

    /// Illustrates comparisons among individual items
    static member Column(keys, values,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Marker) = 
        let marker =
            match Marker with 
            | Some marker -> marker |> FSharp.Plotly.Marker.style(?Color=Color)
            | Option.None        -> FSharp.Plotly.Marker.init (?Color=Color)
                    
        Trace.initBar (TraceStyle.Bar(X = keys,Y = values,Marker=marker))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)        
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject  
            

    /// Illustrates comparisons among individual items
    static member Column(keysvalues,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.Column(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Displays series of column chart type as stacked columns.
    static member StackedColumn(keys, values,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Marker) =            
        let marker =
            match Marker with 
            | Some marker -> marker |> FSharp.Plotly.Marker.style(?Color=Color)
            | Option.None        -> FSharp.Plotly.Marker.init (?Color=Color)

        Trace.initBar (TraceStyle.Bar(X = keys,Y = values,Marker=marker))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)        
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject  
        //|> GenericChart.setLayout (Layout.init (Layout.style(Barmode=StyleParam.Barmode.Stack)))
        |> GenericChart.setLayout (Layout.init (Barmode=StyleParam.Barmode.Stack))


    /// Displays series of column chart type as stacked columns.
    static member StackedColumn(keysvalues,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Marker) =  
        let keys,values = Seq.unzip keysvalues
        Chart.StackedColumn(keys, values,?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Illustrates comparisons among individual items
    static member Bar(keys, values,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Marker) = 
        let marker =
            match Marker with 
            | Some marker -> marker |> FSharp.Plotly.Marker.style(?Color=Color)
            | Option.None        -> FSharp.Plotly.Marker.init (?Color=Color)
        Trace.initBar (TraceStyle.Bar(X = keys,Y = values,Marker=marker,Orientation = StyleParam.Orientation.Horizontal))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)        
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject  


    /// Illustrates comparisons among individual items
    static member Bar(keysvalues,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.Bar(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Displays series of tcolumn chart type as stacked bars.
    static member StackedBar(keys, values,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Marker) = 
        let marker =
            match Marker with 
            | Some marker -> marker |> FSharp.Plotly.Marker.style(?Color=Color)
            | Option.None        -> FSharp.Plotly.Marker.init (?Color=Color)
        Trace.initBar (TraceStyle.Bar(X = values,Y = keys,Marker=marker,Orientation = StyleParam.Orientation.Horizontal))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)        
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject  
        //|> GenericChart.setLayout (Layout.init (Layout.style(Barmode=StyleParam.Barmode.Stack)))
        |> GenericChart.setLayout (Layout.init (Barmode=StyleParam.Barmode.Stack))


    /// Displays series of tcolumn chart type as stacked bars.
    static member StackedBar(keysvalues,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.StackedBar(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.            
    static member BoxPlot
        (
            [<Optional;DefaultParameterValue(null)>] ?x,
            [<Optional;DefaultParameterValue(null)>] ?y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Whiskerwidth,
            [<Optional;DefaultParameterValue(null)>] ?Boxpoints,
            [<Optional;DefaultParameterValue(null)>] ?Boxmean,
            [<Optional;DefaultParameterValue(null)>] ?Jitter,
            [<Optional;DefaultParameterValue(null)>] ?Pointpos,
            [<Optional;DefaultParameterValue(null)>] ?Orientation
        ) = 
            Trace.initBoxPlot (TraceStyle.BoxPlot(?X=x, ?Y = y,
                                ?Whiskerwidth=Whiskerwidth,?Boxpoints=Boxpoints,
                                ?Boxmean=Boxmean,?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation,?Fillcolor=Fillcolor) )
            |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
            |> TraceStyle.Marker(?Color=Color)
            |> GenericChart.ofTraceObject


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.       
    static member BoxPlot(xy,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Whiskerwidth,
            [<Optional;DefaultParameterValue(null)>] ?Boxpoints,
            [<Optional;DefaultParameterValue(null)>] ?Boxmean,
            [<Optional;DefaultParameterValue(null)>] ?Jitter,
            [<Optional;DefaultParameterValue(null)>] ?Pointpos,
            [<Optional;DefaultParameterValue(null)>] ?Orientation) = 
        let x,y = Seq.unzip xy
        Chart.BoxPlot(x, y, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Fillcolor=Fillcolor,?Opacity=Opacity,?Whiskerwidth=Whiskerwidth,?Boxpoints=Boxpoints,?Boxmean=Boxmean,?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation) 


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.            
    static member Violin
        (
            [<Optional;DefaultParameterValue(null)>] ?x,
            [<Optional;DefaultParameterValue(null)>] ?y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Points,
            [<Optional;DefaultParameterValue(null)>] ?Jitter,
            [<Optional;DefaultParameterValue(null)>] ?Pointpos,
            [<Optional;DefaultParameterValue(null)>] ?Orientation
        ) = 
            Trace.initViolin (TraceStyle.Violin(?X=x, ?Y = y,?Points=Points,
                                ?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation,?Fillcolor=Fillcolor) )
            |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
            |> TraceStyle.Marker(?Color=Color)
            |> GenericChart.ofTraceObject


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.       
    static member Violin(xy,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Points,
            [<Optional;DefaultParameterValue(null)>] ?Jitter,
            [<Optional;DefaultParameterValue(null)>] ?Pointpos,
            [<Optional;DefaultParameterValue(null)>] ?Orientation) = 
        let x,y = Seq.unzip xy
        Chart.Violin(x, y, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Fillcolor=Fillcolor,?Opacity=Opacity,?Points=Points,?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation) 


    /// Shows a graphical representation of a 3-dimensional surface by plotting constant z slices, called contours, on a 2-dimensional format.
    /// That is, given a value for z, lines are drawn for connecting the (x,y) coordinates where that z value occurs.
    static member Heatmap(data:seq<#seq<#IConvertible>>,
            [<Optional;DefaultParameterValue(null)>] ?ColNames,
            [<Optional;DefaultParameterValue(null)>] ?RowNames,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Showscale,
            [<Optional;DefaultParameterValue(null)>] ?Xgap,
            [<Optional;DefaultParameterValue(null)>] ?Ygap,
            [<Optional;DefaultParameterValue(null)>] ?zSmooth,
            [<Optional;DefaultParameterValue(null)>] ?Colorbar) = 
        Trace.initHeatmap (TraceStyle.Heatmap(Z=data,?X=ColNames, ?Y=RowNames,
                                ?Xgap=Xgap,?Ygap=Ygap,?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar) )
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        |> GenericChart.ofTraceObject


    /// Shows a graphical representation of data where the individual values contained in a matrix are represented as colors.
    static member Contour(data:seq<#seq<#IConvertible>>,
            [<Optional;DefaultParameterValue(null)>]  ?X,
            [<Optional;DefaultParameterValue(null)>]  ?Y,
            [<Optional;DefaultParameterValue(null)>]  ?Name,
            [<Optional;DefaultParameterValue(null)>]  ?Showlegend,
            [<Optional;DefaultParameterValue(null)>]  ?Opacity,
            [<Optional;DefaultParameterValue(null)>]  ?Colorscale,
            [<Optional;DefaultParameterValue(null)>]  ?Showscale,
            [<Optional;DefaultParameterValue(null)>]  ?zSmooth,
            [<Optional;DefaultParameterValue(null)>]  ?Colorbar) = 
        Trace.initContour (TraceStyle.Contour(Z=data,?X=X, ?Y=Y,
                                ?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar) )
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        |> GenericChart.ofTraceObject


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
    static member Pie(values,
            [<Optional;DefaultParameterValue(null)>]  ?Labels,
            [<Optional;DefaultParameterValue(null)>]  ?Name,
            [<Optional;DefaultParameterValue(null)>]  ?Showlegend,
            [<Optional;DefaultParameterValue(null)>]  ?Color,
            [<Optional;DefaultParameterValue(null)>]  ?TextPosition,
            [<Optional;DefaultParameterValue(null)>]  ?TextFont,
            [<Optional;DefaultParameterValue(null)>]  ?Hoverinfo,
            [<Optional;DefaultParameterValue(null)>]  ?Textinfo,
            [<Optional;DefaultParameterValue(null)>]  ?Opacity) =         
        Trace.initPie (TraceStyle.Pie(Values=values,?Labels=Labels,?Textinfo=Textinfo))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity,?Hoverinfo=Hoverinfo)        
        |> TraceStyle.Marker(?Color=Color)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
    static member Pie(data:seq<#IConvertible*#IConvertible>,
            [<Optional;DefaultParameterValue(null)>]  ?Name,
            [<Optional;DefaultParameterValue(null)>]  ?Showlegend,
            [<Optional;DefaultParameterValue(null)>]  ?Color,
            [<Optional;DefaultParameterValue(null)>]  ?TextPosition,
            [<Optional;DefaultParameterValue(null)>]  ?TextFont,
            [<Optional;DefaultParameterValue(null)>]  ?Hoverinfo,
            [<Optional;DefaultParameterValue(null)>]  ?Textinfo,
            [<Optional;DefaultParameterValue(null)>]  ?Opacity) =         
        let values,labels = Seq.unzip data 
        Chart.Pie(values,Labels=labels,?Name=Name,?Showlegend=Showlegend,?Color=Color,?TextPosition=TextPosition,?TextFont=TextFont,?Hoverinfo=Hoverinfo,?Textinfo=Textinfo,?Opacity=Opacity)


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
    static member Doughnut(values,
            [<Optional;DefaultParameterValue(null)>]  ?Labels,
            [<Optional;DefaultParameterValue(null)>]  ?Name,
            [<Optional;DefaultParameterValue(null)>]  ?Showlegend,
            [<Optional;DefaultParameterValue(null)>]  ?Color,
            [<Optional;DefaultParameterValue(null)>]  ?Hole,
            [<Optional;DefaultParameterValue(null)>]  ?TextPosition,
            [<Optional;DefaultParameterValue(null)>]  ?TextFont,
            [<Optional;DefaultParameterValue(null)>]  ?Hoverinfo,
            [<Optional;DefaultParameterValue(null)>]  ?Textinfo,
            [<Optional;DefaultParameterValue(null)>]  ?Opacity) =         
        let hole' = if Hole.IsSome then Hole.Value else 0.4
        Trace.initPie (TraceStyle.Pie(Values=values,?Labels=Labels,?Textinfo=Textinfo,Hole=hole'))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity,?Hoverinfo=Hoverinfo)        
        |> TraceStyle.Marker(?Color=Color)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
    static member Doughnut(data:seq<#IConvertible*#IConvertible>,
            [<Optional;DefaultParameterValue(null)>]  ?Name,
            [<Optional;DefaultParameterValue(null)>]  ?Showlegend,
            [<Optional;DefaultParameterValue(null)>]  ?Color,
            [<Optional;DefaultParameterValue(null)>]  ?Hole,
            [<Optional;DefaultParameterValue(null)>]  ?TextPosition,
            [<Optional;DefaultParameterValue(null)>]  ?TextFont,
            [<Optional;DefaultParameterValue(null)>]  ?Hoverinfo,
            [<Optional;DefaultParameterValue(null)>]  ?Textinfo,
            [<Optional;DefaultParameterValue(null)>]  ?Opacity) =         
        let values,labels = Seq.unzip data 
        Chart.Doughnut(values,Labels=labels,?Name=Name,?Showlegend=Showlegend,?Color=Color,?Hole=Hole,?TextPosition=TextPosition,?TextFont=TextFont,?Hoverinfo=Hoverinfo,?Textinfo=Textinfo,?Opacity=Opacity)


    /// Uses points, line or both depending on the mode to represent data points in a polar chart
    static member Polar(r, t,mode,
            [<Optional;DefaultParameterValue(null)>]  ?Name,
            [<Optional;DefaultParameterValue(null)>]  ?Showlegend,
            [<Optional;DefaultParameterValue(null)>]  ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>]  ?Color,
            [<Optional;DefaultParameterValue(null)>]  ?Opacity,
            [<Optional;DefaultParameterValue(null)>]  ?Labels,
            [<Optional;DefaultParameterValue(null)>]  ?TextPosition,
            [<Optional;DefaultParameterValue(null)>]  ?TextFont,
            [<Optional;DefaultParameterValue(null)>]  ?Dash,
            [<Optional;DefaultParameterValue(null)>]  ?Width) = 
        Trace.initScatter (
                TraceStyle.Scatter(R = r,T = t, Mode=mode) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


     /// Uses points, line or both depending on the mode to represent data points in a polar chart
    static member Polar(rt,mode,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        let r,t = Seq.unzip rt 
        Chart.Polar(r, t, mode,?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width)



    static member WindRose(r, t,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        Trace.initWindRose (
                TraceStyle.Scatter(R = r,T = t) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 

     /// Computes a histogram with auto-determined the bin size.
    static member Histogram(data,
            [<Optional;DefaultParameterValue(null)>]  ?Orientation,
            [<Optional;DefaultParameterValue(null)>]  ?Name,
            [<Optional;DefaultParameterValue(null)>]  ?Showlegend,
            [<Optional;DefaultParameterValue(null)>]  ?Opacity,
            [<Optional;DefaultParameterValue(null)>]  ?Color,
            [<Optional;DefaultParameterValue(null)>]  ?HistNorm,
            [<Optional;DefaultParameterValue(null)>]  ?HistFunc,
            [<Optional;DefaultParameterValue(null)>]  ?nBinsx,
            [<Optional;DefaultParameterValue(null)>]  ?nBinsy,
            [<Optional;DefaultParameterValue(null)>]  ?Xbins,
            [<Optional;DefaultParameterValue(null)>]  ?Ybins,
            // TODO
            [<Optional;DefaultParameterValue(null)>]  ?xError,
            [<Optional;DefaultParameterValue(null)>]  ?yError) =         
        Trace.initHistogram (
            TraceStyle.Histogram (X=data,?Orientation=Orientation,?HistNorm=HistNorm,?HistFunc=HistFunc,
                                    ?nBinsx=nBinsx,?nBinsy=nBinsy,?xBins=Xbins,?yBins=Ybins)
                             )
        |> TraceStyle.Marker(?Color=Color)
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        
        |> GenericChart.ofTraceObject

     /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
    static member Histogram2d(x,y,
            [<Optional;DefaultParameterValue(null)>] ?Z,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Showscale,
            [<Optional;DefaultParameterValue(null)>] ?zSmooth,
            [<Optional;DefaultParameterValue(null)>] ?Colorbar,
            [<Optional;DefaultParameterValue(null)>] ?zAuto,
            [<Optional;DefaultParameterValue(null)>] ?zMin,
            [<Optional;DefaultParameterValue(null)>] ?zMax,
            [<Optional;DefaultParameterValue(null)>] ?nBinsx,
            [<Optional;DefaultParameterValue(null)>] ?nBinsy,
            [<Optional;DefaultParameterValue(null)>] ?xBins,
            [<Optional;DefaultParameterValue(null)>] ?yBins,
            [<Optional;DefaultParameterValue(null)>] ?HistNorm,
            [<Optional;DefaultParameterValue(null)>] ?HistFunc) =         
        Trace.initHistogram2d (
            TraceStyle.Histogram2d (
                                X=x,
                                Y=y,
                                ?Z=Z,
                                ?Colorscale=Colorscale,
                                ?Showscale=Showscale,
                                ?zSmooth=zSmooth,
                                ?Colorbar=Colorbar,
                                ?zAuto=zAuto,
                                ?zMin=zMin,
                                ?zMax=zMax,
                                ?nBinsx=nBinsx,
                                ?nBinsy=nBinsy,
                                ?xBins=xBins,
                                ?yBins=yBins,
                                ?HistNorm=HistNorm,
                                ?HistFunc=HistFunc ) )
      
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        |> GenericChart.ofTraceObject
 

// //    /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
// //    static member Histogram2d(xy,?Name,?HistNorm,?HistFunc,?Colorscale,?Showscale,?zSmooth,?Colorbar,?zAuto,?zMin,?zMax,?nBinsx,?nBinsy,?Xbins,?Ybins) =         
// //        let x,y = Seq.unzip xy
// //        Chart.Histogram2d(x,y,?Name=Name,?HistNorm=HistNorm,?HistFunc=HistFunc,?Colorscale=Colorscale,
// //            ?Showscale=Showscale,?Colorbar=Colorbar,?zSmooth=zSmooth,?zAuto=zAuto,?zMin=zMin,?zMax=zMax,
// //            ?nBinsx=nBinsx,?nBinsy=nBinsy,?Xbins=Xbins,?Ybins=Ybins
// //            )

     /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
    static member Histogram2dContour(x,y,
            [<Optional;DefaultParameterValue(null)>] ?Z,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Showscale,
            [<Optional;DefaultParameterValue(null)>] ?Line,
            [<Optional;DefaultParameterValue(null)>] ?zSmooth,
            [<Optional;DefaultParameterValue(null)>] ?Colorbar,
            [<Optional;DefaultParameterValue(null)>] ?zAuto,
            [<Optional;DefaultParameterValue(null)>] ?zMin,
            [<Optional;DefaultParameterValue(null)>] ?zMax,
            [<Optional;DefaultParameterValue(null)>] ?nBinsx,
            [<Optional;DefaultParameterValue(null)>] ?nBinsy,
            [<Optional;DefaultParameterValue(null)>] ?xBins,
            [<Optional;DefaultParameterValue(null)>] ?yBins,
            [<Optional;DefaultParameterValue(null)>] ?HistNorm,
            [<Optional;DefaultParameterValue(null)>] ?HistFunc) =         
        Trace.initHistogram2dContour (
            TraceStyle.Histogram2dContour (X=x, Y=y,? Z=Z,?Line=Line,
                    ?Colorscale=Colorscale,
                    ?Showscale=Showscale,
                    ?zSmooth=zSmooth,
                    ?Colorbar=Colorbar,
                    ?zAuto=zAuto,
                    ?zMin=zMin,
                    ?zMax=zMax,
                    ?nBinsx=nBinsx,
                    ?nBinsy=nBinsy,
                    ?xBins=xBins,
                    ?yBins=yBins,
                    ?HistNorm=HistNorm,
                    ?HistFunc=HistFunc                                
                                ) )
        //|> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        |> GenericChart.ofTraceObject


     /// Computes the parallel coordinates plot
    static member ParallelCoord(dims:seq<'key*#seq<'values>>,
            [<Optional;DefaultParameterValue(null)>] ?Range,
            [<Optional;DefaultParameterValue(null)>] ?Constraintrange,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Domain,
            [<Optional;DefaultParameterValue(null)>] ?Labelfont,
            [<Optional;DefaultParameterValue(null)>] ?Tickfont,
            [<Optional;DefaultParameterValue(null)>] ?Rangefont) =
        let dims' = 
            dims |> Seq.map (fun (k,vals) -> 
                Dimensions.init(vals)
                |> Dimensions.style(vals,?Range=Range,?Constraintrange=Constraintrange,Label=k)
                )
        Trace.initParallelCoord (
            TraceStyle.ParallelCoord (Dimensions=dims',?Domain=Domain,?Labelfont=Labelfont,?Tickfont=Tickfont,?Rangefont=Rangefont)             
            )
        |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
        |> GenericChart.ofTraceObject


     /// Computes the parallel coordinates plot
    static member ParallelCoord(dims:seq<Dimensions>,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Domain,
            [<Optional;DefaultParameterValue(null)>] ?Labelfont,
            [<Optional;DefaultParameterValue(null)>] ?Tickfont,
            [<Optional;DefaultParameterValue(null)>] ?Rangefont) =
        Trace.initParallelCoord (
            TraceStyle.ParallelCoord (Dimensions=dims,?Domain=Domain,?Labelfont=Labelfont,?Tickfont=Tickfont,?Rangefont=Rangefont)             
            )
        |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
        |> GenericChart.ofTraceObject

    ///Parallel categories diagram for multidimensional categorical data.
    static member ParallelCategories(dims:seq<'key*#seq<'values>>,
            [<Optional;DefaultParameterValue(null)>] ?Range,
            [<Optional;DefaultParameterValue(null)>] ?Constraintrange,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Domain,
            [<Optional;DefaultParameterValue(null)>] ?Labelfont,
            [<Optional;DefaultParameterValue(null)>] ?Tickfont,
            [<Optional;DefaultParameterValue(null)>] ?Rangefont) =
        let dims' = 
            dims |> Seq.map (fun (k,vals) -> 
                Dimensions.init(vals)
                |> Dimensions.style(vals,?Range=Range,?Constraintrange=Constraintrange,Label=k)
                )
        Trace.initParallelCategories (
            TraceStyle.ParallelCategories(Dimensions=dims',?Domain=Domain,?Labelfont=Labelfont,?Tickfont=Tickfont,?Rangefont=Rangefont)
        )
        |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
        |> GenericChart.ofTraceObject

    ///
    static member ParallelCategories(dims:seq<Dimensions>,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Domain,
            [<Optional;DefaultParameterValue(null)>] ?Labelfont,
            [<Optional;DefaultParameterValue(null)>] ?Tickfont,
            [<Optional;DefaultParameterValue(null)>] ?Rangefont) =
        Trace.initParallelCategories (
            TraceStyle.ParallelCoord (Dimensions=dims,?Domain=Domain,?Labelfont=Labelfont,?Tickfont=Tickfont,?Rangefont=Rangefont)             
            )
        |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
        |> GenericChart.ofTraceObject

    /// Computes the choropleth map plot
    static member ChoroplethMap(locations,z,
            [<Optional;DefaultParameterValue(null)>] ?Text,
            [<Optional;DefaultParameterValue(null)>] ?Locationmode,
            [<Optional;DefaultParameterValue(null)>] ?Autocolorscale,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Colorbar,
            [<Optional;DefaultParameterValue(null)>] ?Marker,
            [<Optional;DefaultParameterValue(null)>] ?Zmin,
            [<Optional;DefaultParameterValue(null)>] ?Zmax) =
        Trace.initChoroplethMap (
            TraceStyle.ChoroplethMap (Locations=locations,Z=z,?Text=Text,?Locationmode=Locationmode,?Autocolorscale=Autocolorscale,
                ?Colorscale=Colorscale,?Colorbar=Colorbar,?Marker=Marker,?Zmin=Zmin,?Zmax=Zmax)              
            )
        |> GenericChart.ofTraceObject        

     /// Computes the parallel coordinates plot
    static member Splom(dims:seq<'key*#seq<'values>>,
            [<Optional;DefaultParameterValue(null)>] ?Range,
            [<Optional;DefaultParameterValue(null)>] ?Constraintrange,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            ?Domain,?Labelfont,?Tickfont,?Rangefont) =
        let dims' = 
            dims |> Seq.map (fun (k,vals) -> 
                Dimensions.init(vals)
                |> Dimensions.style(vals,?Range=Range,?Constraintrange=Constraintrange,Label=k)
                )
        Trace.initSplom (
            TraceStyle.Splom (Dimensions=dims')             
            )
        |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
        |> GenericChart.ofTraceObject


     /// Computes the Splom plot
    static member Splom(dims:seq<Dimensions>,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Domain,
            [<Optional;DefaultParameterValue(null)>] ?Labelfont,
            [<Optional;DefaultParameterValue(null)>] ?Tickfont,
            [<Optional;DefaultParameterValue(null)>] ?Rangefont) =
        Trace.initSplom (
            TraceStyle.Splom (Dimensions=dims)             
            )
        |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
        |> GenericChart.ofTraceObject

    // ---------------------------------------------------------------------------------------------------------------------------------------------------
    // 3d - Chart --->

    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Scatter3d(x, y, z, mode,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        Trace3d.initScatter3d (Trace3dStyle.Scatter3d(X = x,Y = y,Z=z, Mode=mode) )              
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 
          
    
    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Scatter3d(xyz, mode, 
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Labels,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextFont,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Width) = 
        let x,y,z = Seq.unzip3 xyz
        Chart.Scatter3d(x, y, z, mode, ?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width) 

    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Surface(data:seq<#seq<#IConvertible>>,
            [<Optional;DefaultParameterValue(null)>] ?X,
            [<Optional;DefaultParameterValue(null)>] ?Y,
            [<Optional;DefaultParameterValue(null)>] ?Name,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Contours,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Showscale,
            [<Optional;DefaultParameterValue(null)>] ?Colorbar) = 
        Trace3d.initSurface (
            Trace3dStyle.Surface (Z=data,?X=X, ?Y=Y,?Contours=Contours,
                                ?Colorscale=Colorscale,?Showscale=Showscale,?Colorbar=Colorbar ) )              
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        //|> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Mesh3d(x, y, z, mode,
            ?Name,
            ?Showlegend,
            ?MarkerSymbol,
            ?Color,
            ?Opacity,
            ?Labels,
            ?TextPosition,
            ?TextFont,
            ?Dash,
            ?Width) = 
        Trace3d.initMesh3d (Trace3dStyle.Mesh3d(X = x,Y = y,Z=z) )              
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 

    /// creates table out of header sequence and row sequences
    static member Table(headerValues, cellValues, 
            [<Optional;DefaultParameterValue(null)>] ?AlignHeader, 
            [<Optional;DefaultParameterValue(null)>] ?AlignCells,
            [<Optional;DefaultParameterValue(null)>] ?ColumnWidth, 
            [<Optional;DefaultParameterValue(null)>] ?ColumnOrder, 
            [<Optional;DefaultParameterValue(null)>] ?ColorHeader, 
            [<Optional;DefaultParameterValue(null)>] ?ColorCells, 
            [<Optional;DefaultParameterValue(null)>] ?FontHeader, 
            [<Optional;DefaultParameterValue(null)>] ?FontCells, 
            [<Optional;DefaultParameterValue(null)>] ?HeightHeader, 
            [<Optional;DefaultParameterValue(null)>] ?HeightCells, 
            [<Optional;DefaultParameterValue(null)>] ?LineHeader, 
            [<Optional;DefaultParameterValue(null)>] ?LineCells) = 
        Trace.initTable (

                let CellFilling =
                    match ColorCells with 
                    | Some color  -> Some (CellColor.init (?Color=ColorCells))
                    | Option.None -> Option.None

                let HeaderFilling =
                    match ColorHeader with 
                    | Some color   -> Some (CellColor.init (?Color=ColorHeader))
                    | Option.None  -> Option.None
                              
                TraceStyle.Table (
                    header = TableHeader.init (headerValues|> Seq.map seq, ?Align=AlignHeader, ?Fill=HeaderFilling, ?Font=FontHeader, ?Height=HeightHeader, ?Line=LineHeader),
                    cells  = TableCells.init(cellValues |> Seq.transpose, ?Align=AlignCells, ?Fill=CellFilling, ?Font=FontCells, ?Height=HeightCells, ?Line=LineCells),  
                    ?ColumnWidth = ColumnWidth,
                    ?ColumnOrder = ColumnOrder
                    )
                )
        |> GenericChart.ofTraceObject 
