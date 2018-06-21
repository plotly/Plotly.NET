namespace FSharp.Plotly

open System
open System.IO
//open FSharp.Care.Collections

open GenericChart
open Trace
open Trace3d
open StyleParam


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
    static member Scatter(x, y,mode,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=mode) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


     /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(xy,mode,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let x,y = Seq.unzip xy 
        Chart.Scatter(x, y, mode,?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width)


    /// Uses points to represent data points
    static member Point(x, y,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
        
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Markers) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 

     /// Uses points to represent data points
    static member Point(xy,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        let x,y = Seq.unzip xy 
        Chart.Point(x, y, ?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)


    /// Uses lines to represent data points
    static member Line(x, y,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleParam.ModeUtils.showMarker (isShowMarker)

        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Lines) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 

    /// Uses lines to represent data points
    static member Line(xy,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let x,y = Seq.unzip xy 
        Chart.Line(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width)


    /// A Line chart that plots a fitted curve through each data point in a series.
    static member Spline(x, y,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleParam.ModeUtils.showMarker (isShowMarker)

        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Lines) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width, Shape=StyleParam.Shape.Spline, ?Smoothing=Smoothing)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// A Line chart that plots a fitted curve through each data point in a series.
    static member Spline(xy,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        let x,y = Seq.unzip xy 
        Chart.Spline(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width,?Smoothing=Smoothing) 


    /// A variation of the Point chart type, where the data points are replaced by bubbles of different sizes.
    static member Bubble(x, y,sizes:seq<#IConvertible>,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
        
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Markers) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol, MultiSizes=sizes)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// A variation of the Point chart type, where the data points are replaced by bubbles of different sizes.
    static member Bubble(xysizes,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        let x,y,sizes = Seq.unzip3 xysizes 
        Chart.Bubble(x, y,sizes=sizes,?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)


    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line 
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
                    TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Markers, ?Fillcolor=Color) )               
            |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend)
            |> TraceStyle.Line(?Color=Color)
            |> TraceStyle.Marker(?Color=Color)
            |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)

        let lower = 
            Trace.initScatter (
                    TraceStyle.Scatter(X = x,Y = lower, Mode=StyleParam.Lines, ?Fillcolor=RangeColor) )               
            |> TraceStyle.TraceInfo(Showlegend=false)
            |> TraceStyle.Line(Width=0)
            |> TraceStyle.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)")             

        let upper = 
            Trace.initScatter (
                    TraceStyle.Scatter(X = x,Y = upper, Mode=StyleParam.Lines, ?Fillcolor=RangeColor, Fill=StyleParam.ToNext_y) )               
            |> TraceStyle.TraceInfo(Showlegend=false)
            |> TraceStyle.Line(Width=0)
            |> TraceStyle.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)")             
 
        GenericChart.MultiChart ([lower;upper;trace],Layout())


    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line 
    static member Range(xy, upper, lower,?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels,?TextPosition,?TextFont) =   
        let x,y = Seq.unzip xy
        Chart.Range(x, y, upper, lower, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?Color=Color,?RangeColor=RangeColor,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member Area(x, y,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleParam.ModeUtils.showMarker (isShowMarker)

        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Lines,Fill=StyleParam.ToZero_y) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member Area(xy,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let x,y = Seq.unzip xy
        Chart.Area(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width) 


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member SplineArea(x, y,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | Option.None        -> false
            StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleParam.ModeUtils.showMarker (isShowMarker)
  
        Trace.initScatter (
                TraceStyle.Scatter(X = x,Y = y, Mode=changeMode StyleParam.Mode.Lines,Fill=StyleParam.ToZero_y) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width, Shape=StyleParam.Shape.Spline, ?Smoothing=Smoothing)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member SplineArea(xy,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        let x,y = Seq.unzip xy
        Chart.SplineArea(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width,?Smoothing=Smoothing) 


    /// Illustrates comparisons among individual items
    static member Column(keys, values,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let marker =
            match Marker with 
            | Some marker -> marker |> FSharp.Plotly.Marker.style(?Color=Color)
            | Option.None        -> FSharp.Plotly.Marker.init (?Color=Color)
                    
        Trace.initBar (TraceStyle.Bar(X = keys,Y = values,Marker=marker))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)        
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject  
            

    /// Illustrates comparisons among individual items
    static member Column(keysvalues,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.Column(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Displays series of column chart type as stacked columns.
    static member StackedColumn(keys, values,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) =            
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
    static member StackedColumn(keysvalues,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) =  
        let keys,values = Seq.unzip keysvalues
        Chart.StackedColumn(keys, values,?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Illustrates comparisons among individual items
    static member Bar(keys, values,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let marker =
            match Marker with 
            | Some marker -> marker |> FSharp.Plotly.Marker.style(?Color=Color)
            | Option.None        -> FSharp.Plotly.Marker.init (?Color=Color)
        Trace.initBar (TraceStyle.Bar(X = keys,Y = values,Marker=marker,Orientation = StyleParam.Orientation.Horizontal))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)        
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject  


    /// Illustrates comparisons among individual items
    static member Bar(keysvalues,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.Bar(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Displays series of tcolumn chart type as stacked bars.
    static member StackedBar(keys, values,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
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
    static member StackedBar(keysvalues,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.StackedBar(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.            
    static member BoxPlot(?x,?y,?Name,?Showlegend,?Color,?Fillcolor,?Opacity,?Whiskerwidth,?Boxpoints,?Boxmean,?Jitter,?Pointpos,?Orientation) = 
         Trace.initBoxPlot (TraceStyle.BoxPlot(?X=x, ?Y = y,
                                ?Whiskerwidth=Whiskerwidth,?Boxpoints=Boxpoints,
                                ?Boxmean=Boxmean,?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation,?Fillcolor=Fillcolor) )
         |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
         |> TraceStyle.Marker(?Color=Color)
         |> GenericChart.ofTraceObject


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.       
    static member BoxPlot(xy,?Name,?Showlegend,?Color,?Fillcolor,?Opacity,?Whiskerwidth,?Boxpoints,?Boxmean,?Jitter,?Pointpos,?Orientation) = 
        let x,y = Seq.unzip xy
        Chart.BoxPlot(x, y, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Fillcolor=Fillcolor,?Opacity=Opacity,?Whiskerwidth=Whiskerwidth,?Boxpoints=Boxpoints,?Boxmean=Boxmean,?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation) 


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.            
    static member Violin(?x,?y,?Name,?Showlegend,?Color,?Fillcolor,?Opacity,?Points,?Jitter,?Pointpos,?Orientation) = 
         Trace.initViolin (TraceStyle.Violin(?X=x, ?Y = y,?Points=Points,
                                ?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation,?Fillcolor=Fillcolor) )
         |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
         |> TraceStyle.Marker(?Color=Color)
         |> GenericChart.ofTraceObject


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.       
    static member Violin(xy,?Name,?Showlegend,?Color,?Fillcolor,?Opacity,?Points,?Jitter,?Pointpos,?Orientation) = 
        let x,y = Seq.unzip xy
        Chart.Violin(x, y, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Fillcolor=Fillcolor,?Opacity=Opacity,?Points=Points,?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation) 


    /// Shows a graphical representation of a 3-dimensional surface by plotting constant z slices, called contours, on a 2-dimensional format.
    /// That is, given a value for z, lines are drawn for connecting the (x,y) coordinates where that z value occurs.
    static member Heatmap(data:seq<#seq<#IConvertible>>,?ColNames,?RowNames,?Name,?Showlegend,?Opacity,?Colorscale,?Showscale,?Xgap,?Ygap,?zSmooth,?Colorbar) = 
        Trace.initHeatmap (TraceStyle.Heatmap(Z=data,?X=ColNames, ?Y=RowNames,
                                ?Xgap=Xgap,?Ygap=Ygap,?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar) )
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        |> GenericChart.ofTraceObject


    /// Shows a graphical representation of data where the individual values contained in a matrix are represented as colors.
    static member Contour(data:seq<#seq<#IConvertible>>,?X,?Y,?Name,?Showlegend,?Opacity,?Colorscale,?Showscale,?zSmooth,?Colorbar) = 
        Trace.initContour (TraceStyle.Contour(Z=data,?X=X, ?Y=Y,
                                ?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar) )
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        |> GenericChart.ofTraceObject


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
    static member Pie(values,?Labels,?Name,?Showlegend,?Color,?TextPosition,?TextFont,?Hoverinfo,?Textinfo,?Opacity) =         
        Trace.initPie (TraceStyle.Pie(Values=values,?Labels=Labels,?Textinfo=Textinfo))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity,?Hoverinfo=Hoverinfo)        
        |> TraceStyle.Marker(?Color=Color)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
    static member Pie(data:seq<#IConvertible*#IConvertible>,?Name,?Showlegend,?Color,?TextPosition,?TextFont,?Hoverinfo,?Textinfo,?Opacity) =         
        let values,labels = Seq.unzip data 
        Chart.Pie(values,Labels=labels,?Name=Name,?Showlegend=Showlegend,?Color=Color,?TextPosition=TextPosition,?TextFont=TextFont,?Hoverinfo=Hoverinfo,?Textinfo=Textinfo,?Opacity=Opacity)


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
    static member Doughnut(values,?Labels,?Name,?Showlegend,?Color,?Hole,?TextPosition,?TextFont,?Hoverinfo,?Textinfo,?Opacity) =         
        let hole' = if Hole.IsSome then Hole.Value else 0.4
        Trace.initPie (TraceStyle.Pie(Values=values,?Labels=Labels,?Textinfo=Textinfo,Hole=hole'))
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity,?Hoverinfo=Hoverinfo)        
        |> TraceStyle.Marker(?Color=Color)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
    static member Doughnut(data:seq<#IConvertible*#IConvertible>,?Name,?Showlegend,?Color,?Hole,?TextPosition,?TextFont,?Hoverinfo,?Textinfo,?Opacity) =         
        let values,labels = Seq.unzip data 
        Chart.Doughnut(values,Labels=labels,?Name=Name,?Showlegend=Showlegend,?Color=Color,?Hole=Hole,?TextPosition=TextPosition,?TextFont=TextFont,?Hoverinfo=Hoverinfo,?Textinfo=Textinfo,?Opacity=Opacity)


    /// Uses points, line or both depending on the mode to represent data points in a polar chart
    static member Polar(r, t,mode,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        Trace.initScatter (
                TraceStyle.Scatter(R = r,T = t, Mode=mode) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


     /// Uses points, line or both depending on the mode to represent data points in a polar chart
    static member Polar(rt,mode,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let r,t = Seq.unzip rt 
        Chart.Polar(r, t, mode,?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width)



    static member WindRose(r, t,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        Trace.initWindRose (
                TraceStyle.Scatter(R = r,T = t) )               
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 

     /// Computes a histogram with auto-determined the bin size.
    static member Histogram(data,?Orientation,?Name,?Showlegend,?Opacity,?Color,?HistNorm,?HistFunc,?nBinsx,?nBinsy,?Xbins,?Ybins,?xError,?yError) =         
        Trace.initHistogram (
            TraceStyle.Histogram (X=data,?Orientation=Orientation,?HistNorm=HistNorm,?HistFunc=HistFunc,
                                    ?nBinsx=nBinsx,?nBinsy=nBinsy,?xBins=Xbins,?yBins=Ybins)
                             )
        |> TraceStyle.Marker(?Color=Color)
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        |> GenericChart.ofTraceObject

     /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
    static member Histogram2d(x,y,?Z,?Name,?Showlegend,?Opacity,?Colorscale,?Showscale,?zSmooth,?Colorbar,?zAuto,?zMin,?zMax,?nBinsx,?nBinsy,?Xbins,?Ybins,?HistNorm,?HistFunc) =         
        Trace.initHistogram2d (
            TraceStyle.Histogram2d (X=x, Y=y,? Z=Z,
                                ?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar) )
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
    static member Histogram2dContour(x,y,?Z,?Name,?Colorscale,?Showscale,?Line,?zSmooth,?Colorbar,?zAuto,?zMin,?zMax,?nBinsx,?nBinsy,?Xbins,?Ybins,?HistNorm,?HistFunc) =         
        Trace.initHistogram2dContour (
            TraceStyle.Histogram2dContour (X=x, Y=y,? Z=Z,?Line=Line,
                                ?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar) )
        //|> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)   
        |> GenericChart.ofTraceObject


     /// Computes the parallel coordinates plot
    static member ParallelCoord(dims:seq<'key*#seq<'values>>,?Range,?Constraintrange,?Color,?Colorscale,?Width,?Dash,?Domain,?Labelfont,?Tickfont,?Rangefont) =
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
    static member ParallelCoord(dims:seq<Dimensions>,?Color,?Colorscale,?Width,?Dash,?Domain,?Labelfont,?Tickfont,?Rangefont) =
        Trace.initParallelCoord (
            TraceStyle.ParallelCoord (Dimensions=dims,?Domain=Domain,?Labelfont=Labelfont,?Tickfont=Tickfont,?Rangefont=Rangefont)             
            )
        |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
        |> GenericChart.ofTraceObject


     /// Computes the choropleth map plot
    static member ChoroplethMap(locations,z,?Text,?Locationmode,?Autocolorscale,?Colorscale,?Colorbar,?Marker,?Zmin,?Zmax) =
        Trace.initChoroplethMap (
            TraceStyle.ChoroplethMap (Locations=locations,Z=z,?Text=Text,?Locationmode=Locationmode,?Autocolorscale=Autocolorscale,
                ?Colorscale=Colorscale,?Colorbar=Colorbar,?Marker=Marker,?Zmin=Zmin,?Zmax=Zmax)              
            )
        |> GenericChart.ofTraceObject        

     /// Computes the parallel coordinates plot
    static member Splom(dims:seq<'key*#seq<'values>>,?Range,?Constraintrange,?Color,?Colorscale,?Width,?Dash,?Domain,?Labelfont,?Tickfont,?Rangefont) =
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
    static member Splom(dims:seq<Dimensions>,?Color,?Colorscale,?Width,?Dash,?Domain,?Labelfont,?Tickfont,?Rangefont) =
        Trace.initSplom (
            TraceStyle.Splom (Dimensions=dims)             
            )
        |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
        |> GenericChart.ofTraceObject

    // ---------------------------------------------------------------------------------------------------------------------------------------------------
    // 3d - Chart --->

    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Scatter3d(x, y, z, mode, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        Trace3d.initScatter3d (Trace3dStyle.Scatter3d(X = x,Y = y,Z=z, Mode=mode) )              
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
        |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 
          
    
    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Scatter3d(xyz, mode, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let x,y,z = Seq.unzip3 xyz
        Chart.Scatter3d(x, y, z, mode, ?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width) 

    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Surface(data:seq<#seq<#IConvertible>>,?X,?Y, ?Name,?Showlegend,?Opacity,?Contours,?Colorscale,?Showscale,?Colorbar) = 
        Trace3d.initSurface (
            Trace3dStyle.Surface (Z=data,?X=X, ?Y=Y,?Contours=Contours,
                                ?Colorscale=Colorscale,?Showscale=Showscale,?Colorbar=Colorbar ) )              
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        //|> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Mesh3d(x, y, z, mode, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        Trace3d.initMesh3d (Trace3dStyle.Mesh3d(X = x,Y = y,Z=z) )              
        |> TraceStyle.TraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
        |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        |> GenericChart.ofTraceObject 


