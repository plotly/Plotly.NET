namespace FSharp.Plotly

open System
open System.IO
open FSharp.Care.Collections

open GenericChart
    
/// Provides a set of static methods for creating charts.
type Chart =

    /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(x, y, mode, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode=mode)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

    /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(xy, mode, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let x,y = Seq.unzip xy 
        Chart.Scatter(x, y, mode, ?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width)

    /// Uses points to represent data points
    static member Point(x, y, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = StyleOption.Markers)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

    /// Uses points to represent data points
    static member Point(xy,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        let x,y = Seq.unzip xy 
        Chart.Point(x, y, ?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)

    /// Uses lines to represent data points
    static member Line(x, y, ?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let mode' = 
            match ShowMarkers with
            | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
            | None      -> StyleOption.Lines_Markers // default
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = mode')               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

    /// Uses lines to represent data points
    static member Line(xy,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let x,y = Seq.unzip xy 
        Chart.Line(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width)

    /// A Line chart that plots a fitted curve through each data point in a series.
    static member Spline(x, y, ?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        let mode' = 
            match ShowMarkers with
            | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
            | None      -> StyleOption.Lines_Markers // default
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = mode', ?Fillcolor=Color)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width, Shape=StyleOption.Shape.Spline, ?Smoothing=Smoothing))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

    /// A Line chart that plots a fitted curve through each data point in a series.
    static member Spline(xy,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        let x,y = Seq.unzip xy 
        Chart.Spline(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width,?Smoothing=Smoothing) 

    /// A variation of the Point chart type, where the data points are replaced by bubbles of different sizes.
    static member Bubble(x, y, sizes:seq<#IConvertible>,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = StyleOption.Markers)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol, MultiSizes=sizes))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

    /// A variation of the Point chart type, where the data points are replaced by bubbles of different sizes.
    static member Bubble(xyz,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        let x,y,sizes = Seq.unzip3 xyz 
        Chart.Bubble(x, y,sizes=sizes,?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont)

    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line 
    static member Range(x, y, upper, lower, ?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels,?TextPosition,?TextFont) =             
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = mode', ?Fillcolor=Color)     
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend)
            |> Options.ILine(Options.Line(?Color=Color))
            |> Options.IMarker(Options.Marker(?Color=Color))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        let lower = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = lower, Mode=StyleOption.Lines, ?Fillcolor=RangeColor)     
            |> Options.ITraceInfo(Showlegend=false)
            |> Options.ILine(Options.Line(Width=0))
            |> Options.IMarker(Options.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)"))
        let upper = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = upper, Mode=StyleOption.Lines,?Fillcolor=RangeColor, Fill=StyleOption.ToNext_y)    
            |> Options.ITraceInfo(?Showlegend=Showlegend)
            |> Options.ILine(Options.Line(Width=0))
            |> Options.IMarker(Options.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)"))
        GenericChart.MultiChart ([lower;upper;trace],None)

//
//    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line 
//    static member Range(x, y, upper, lower, ?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels) =             
//        let mode' = match ShowMarkers with
//                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
//                    | None      -> StyleOption.Lines_Markers // default 
//            
//        let trace = 
//            TraceObjects.Scatter()
//            |> Options.Scatter(X = x,Y = y, Mode=mode', 
//                TraceOptions=Options.Trace(?Name=Name,?Showlegend=Showlegend),
//                Line=Options.Line(?Color=Color),
//                Marker=Options.Marker(?Color=Color),
//                ?Fillcolor=Color,?Text=Labels)

//        let upper = 
//            TraceObjects.Scatter()
//            |> Options.Scatter(X = x,Y = upper, Mode=StyleOption.Lines,Fill=StyleOption.ToNext_y,
//                TraceOptions=Options.Trace(Showlegend=false),
//                Line=Options.Line(Width=0),
//                Marker=Options.Marker(Color = if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)"),
//                ?Fillcolor=RangeColor)
//        GenericChart.MultiChart ([lower;upper;trace],None)
//

    /// Displays a range of data by plotting two Y values per data point, with each Y value being drawn as a spline 
    static member SplineRange(x, y, upper, lower, ?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels,?TextPosition,?TextFont,?Smoothing) =             
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = mode', ?Fillcolor=Color)     
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend)
            |> Options.ILine(Options.Line(?Color=Color,Shape=StyleOption.Shape.Spline,?Smoothing=Smoothing))
            |> Options.IMarker(Options.Marker(?Color=Color))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        let lower = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = lower, Mode=StyleOption.Lines, ?Fillcolor=RangeColor)     
            |> Options.ITraceInfo(Showlegend=false)
            |> Options.ILine(Options.Line(Width=0,Shape=StyleOption.Shape.Spline,?Smoothing=Smoothing))
            |> Options.IMarker(Options.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)"))
        let upper = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = upper, Mode=StyleOption.Lines,?Fillcolor=RangeColor, Fill=StyleOption.ToNext_y)    
            |> Options.ITraceInfo(?Showlegend=Showlegend)
            |> Options.ILine(Options.Line(Width=0,Shape=StyleOption.Shape.Spline,?Smoothing=Smoothing))
            |> Options.IMarker(Options.Marker(Color=if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)"))
        GenericChart.MultiChart ([lower;upper;trace],None)


    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member Area(x, y, ?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let mode' = 
            match ShowMarkers with
            | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
            | None      -> StyleOption.Lines // default
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = mode',Fill=StyleOption.ToZero_y)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None) 
 

    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member SplineArea(x, y, ?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        let mode' = 
            match ShowMarkers with
            | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
            | None      -> StyleOption.Lines // default
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = mode',Fill=StyleOption.ToZero_y)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width,?Smoothing=Smoothing))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None) 



//    /// Illustrates comparisons among individual items
//    static member Bar(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels,?Marker) = 
//        let marker =
//            match Marker with 
//            | Some m -> Options.Marker(?Color=Color) >> m
//            | None   -> Options.Marker(?Color=Color)
//        let trace = 
//            Bar()
//            |> Options.Bar(X = x,Y = y,
//                TraceOptions=Options.Trace(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity),
//                Marker=marker,
//                ?Text=Labels)
//        GenericChart.Chart (trace,None)
//
//
//    /// Displays series of the same chart type as stacked bars.
//    static member StackedBar(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels,?Marker) = 
//        let marker =
//            match Marker with 
//            | Some m -> Options.Marker(?Color=Color) >> m
//            | None   -> Options.Marker(?Color=Color)
//        let trace = 
//            Bar()
//            |> Options.Bar(X = x,Y = y,
//                TraceOptions=Options.Trace(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity),
//                Marker=marker,
//                ?Text=Labels)
//        
//        let layout = Options.Layout(Barmode=StyleOption.Barmode.Stack)
//        GenericChart.Chart (trace,Some [layout])
//        
//        
//        
//    /// Uses a sequence of columns to compare values across categories.
//    static member Column(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels,?Marker) =  
//        let marker =
//            match Marker with 
//            | Some m -> Options.Marker(?Color=Color) >> m
//            | None   -> Options.Marker(?Color=Color)
//        let trace = 
//            Bar()
//            |> Options.Bar(X = x,Y = y,
//                TraceOptions=Options.Trace(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity),
//                Marker=marker,
//                ?Text=Labels,Orientation = StyleOption.Orientation.Horizontal)
//                
//        GenericChart.Chart (trace,None)
//
//    /// Displays series of the same chart type as stacked columns.
//    static member StackedColumn(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels,?Marker) = 
//        let marker =
//            match Marker with 
//            | Some m -> Options.Marker(?Color=Color) >> m
//            | None   -> Options.Marker(?Color=Color)
//        let trace = 
//            Bar()
//            |> Options.Bar(X = x,Y = y,
//                TraceOptions=Options.Trace(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity),
//                Marker=marker,
//                ?Text=Labels,Orientation = StyleOption.Orientation.Horizontal)
//        
//        let layout = Options.Layout(Barmode=StyleOption.Barmode.Stack)
//        GenericChart.Chart (trace,Some [layout])
//
//    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.            
//    static member BoxPlot(?x,?y,?Name,?Showlegend, ?Color,?Opacity,?Whiskerwidth,?Boxpoints,?Boxmean,?Jitter,?Pointpos,?Line,?Marker) = 
//        let trace = 
//            Box()
//            |> Options.BoxPlot(?X=x, ?Y = y,
//                TraceOptions=Options.Trace(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity),
//                ?Line=Line,?Marker=Marker,
//                ?Fillcolor=Color,?Whiskerwidth=Whiskerwidth,?Boxpoints=Boxpoints,
//                ?Boxmean=Boxmean,?Jitter=Jitter,?Pointpos=Pointpos)
//            
//        GenericChart.Chart (trace,None)

    /// Shows a graphical representation of a 3-dimensional surface by plotting constant z slices, called contours, on a 2-dimensional format.
    /// That is, given a value for z, lines are drawn for connecting the (x,y) coordinates where that z value occurs.
    static member Heatmap(data:seq<#seq<#IConvertible>>,?ColNames,?RowNames, ?Name,?Showlegend,?Opacity,?Colorscale,?Showscale,?zSmooth,?Colorbar) = 
        let trace = 
            Heatmap()
            |> Options.IMapZ(Z=data,?X=ColNames, ?Y=RowNames)
            |> Options.IColormap(?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            //|> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)            
        GenericChart.Chart (trace,None)

    /// Shows a graphical representation of data where the individual values contained in a matrix are represented as colors.
    static member Contour(data:seq<#seq<#IConvertible>>,?X,?Y, ?Name,?Showlegend,?Opacity,?Colorscale,?Showscale,?zSmooth,?Colorbar) = 
        let trace = 
            Contour()
            |> Options.IMapZ(Z=data,?X=X, ?Y=Y)
            |> Options.IColormap(?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            //|> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)                                                      
        GenericChart.Chart (trace,None)


//    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
//    static member Pie(values,?labels,?Name,?Showlegend,?Color,?Hoverinfo,?Textinfo,?Textposition) =         
//        let trace = 
//            Pie()
//            |> Options.Pie(Values=values,?Labels=labels,
//                    TraceOptions=Options.Trace(?Name=Name,?Showlegend=Showlegend,?Hoverinfo=Hoverinfo),
//                    Marker=Options.Marker(?Color=Color),
//                    ?Textinfo=Textinfo,?Textposition=Textposition)                
//        GenericChart.Chart (trace,None)
//
//    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
//    static member Doughnut(values,?labels,?Name,?Showlegend,?Color,?Hole,?Hoverinfo,?Textinfo,?Textposition) =         
//        let hole' = if Hole.IsSome then Hole.Value else 0.4
//        let trace = 
//            Pie()
//            |> Options.Pie(Values=values,?Labels=labels,
//                    TraceOptions=Options.Trace(?Name=Name,?Showlegend=Showlegend,?Hoverinfo=Hoverinfo),
//                    Marker=Options.Marker(?Color=Color),
//                    ?Textinfo=Textinfo,?Textposition=Textposition,Hole=hole')                
//        GenericChart.Chart (trace,None)


    

//    /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
//    static member Histogram2d(x,y,?Name,?HistNorm,?HistFunc,?Colorscale,?Showscale,?zSmooth,?Colorbar,?zAuto,?zMin,?zMax,?nBinsx,?nBinsy,?Xbins,?Ybins) =         
//        let trace = 
//            Trace()
//            |> Helpers.ApplyTraceStyles("histogram2d",x=x,y=y,?name=Name,?histnorm=HistNorm,?histfunc=HistFunc,
//                          ?colorScale=Colorscale,?showscale=Showscale,?zsmooth=zSmooth,?colorbar=Colorbar,
//                          ?zauto=zAuto,?zmin=zMin,?zmax=zMax,
//                          ?nbinsx=nBinsx,?nbinsy=nBinsy,?xbins=Xbins,?ybins=Ybins
//                          )                
//        
//        GenericChart.Chart (trace,None)
//
//    /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
//    static member Histogram2d(xy,?Name,?HistNorm,?HistFunc,?Colorscale,?Showscale,?zSmooth,?Colorbar,?zAuto,?zMin,?zMax,?nBinsx,?nBinsy,?Xbins,?Ybins) =         
//        let x,y = Seq.unzip xy
//        Chart.Histogram2d(x,y,?Name=Name,?HistNorm=HistNorm,?HistFunc=HistFunc,?Colorscale=Colorscale,
//            ?Showscale=Showscale,?Colorbar=Colorbar,?zSmooth=zSmooth,?zAuto=zAuto,?zMin=zMin,?zMax=zMax,
//            ?nBinsx=nBinsx,?nBinsy=nBinsy,?Xbins=Xbins,?Ybins=Ybins
//            )



 
    // ---------------------------------------------------------------------------------------------------------------------------------------------------
    // 3d - Chart --->

    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Scatter3d(x, y, z, mode, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let trace = 
            Trace3dObjects.Scatter3d()
            |> Options.Scatter3d(X = x,Y = y,Z=z, Mode=mode)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)  
    

                        
