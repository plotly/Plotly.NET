namespace FSharp.Plotly

open System
open System.IO
open FSharp.Care.Collections

open GenericChart
    
/// Provides a set of static methods for creating charts.
type Chart =

    /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(x, y,mode,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode=mode)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

    /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(xy,mode,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let x,y = Seq.unzip xy 
        Chart.Scatter(x, y, mode,?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width)


    /// Uses points to represent data points
    static member Point(x, y,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = StyleOption.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
        
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = changeMode StyleOption.Markers)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

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
                | None        -> false
            StyleOption.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleOption.ModeUtils.showMarker (isShowMarker)

        
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = (changeMode StyleOption.Mode.Lines))
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
    static member Spline(x, y,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        let changeMode = 
            let isShowMarker =
                match ShowMarkers with
                | Some isShow -> isShow
                | None        -> false
            StyleOption.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleOption.ModeUtils.showMarker (isShowMarker)
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = (changeMode StyleOption.Mode.Lines), ?Fillcolor=Color)               
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
    static member Bubble(x, y,sizes:seq<#IConvertible>,?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont) = 
        // if text position or font is set than show labels (not only when hovering)
        let changeMode = StyleOption.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
        
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = changeMode StyleOption.Markers)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol, MultiSizes=sizes))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

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
                | None        -> false
            StyleOption.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleOption.ModeUtils.showMarker (isShowMarker)

        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = changeMode StyleOption.Mode.Lines, ?Fillcolor=Color)     
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
                | None        -> false
            StyleOption.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleOption.ModeUtils.showMarker (isShowMarker)

        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = changeMode StyleOption.Mode.Lines,Fill=StyleOption.ToZero_y)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(?Color=Color,?Dash=Dash,?Width=Width))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None) 

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
                | None        -> false
            StyleOption.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
            >> StyleOption.ModeUtils.showMarker (isShowMarker)
        let trace = 
            TraceObjects.Scatter()
            |> Options.Scatter(X = x,Y = y, Mode = changeMode StyleOption.Mode.Lines,Fill=StyleOption.ToZero_y)               
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.ILine(Options.Line(Shape=StyleOption.Shape.Spline,?Color=Color,?Dash=Dash,?Width=Width,?Smoothing=Smoothing))
            |> Options.IMarker(Options.Marker(?Color=Color,?Symbol=MarkerSymbol))
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None) 

    /// Emphasizes the degree of change over time and shows the relationship of the parts to a whole.
    static member SplineArea(xy,?Name,?ShowMarkers,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width,?Smoothing) = 
        let x,y = Seq.unzip xy
        Chart.SplineArea(x, y, ?Name=Name,?ShowMarkers=ShowMarkers,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width,?Smoothing=Smoothing) 


    /// Illustrates comparisons among individual items
    static member Column(keys, values,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let marker =
            match Marker with 
            | Some m -> Options.Marker(?Color=Color) >> m
            | None   -> Options.Marker(?Color=Color)
        let trace = 
            Bar()
            |> Options.Bar(X = keys,Y = values)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.IMarker(marker)
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

    /// Illustrates comparisons among individual items
    static member Column(keysvalues,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.Column(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 

    /// Displays series of column chart type as stacked columns.
    static member StackedColumn(keys, values,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) =            
        let marker =
            match Marker with 
            | Some m -> Options.Marker(?Color=Color) >> m
            | None   -> Options.Marker(?Color=Color)
        let trace = 
            Bar()
            |> Options.Bar(X = keys,Y = values)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.IMarker(marker)
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        let layout = 
            Options.Layout(Barmode=StyleOption.Barmode.Stack)
        GenericChart.Chart (trace,None)
        |>  GenericChart.addLayout layout

    /// Displays series of column chart type as stacked columns.
    static member StackedColumn(keysvalues,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) =  
        let keys,values = Seq.unzip keysvalues
        Chart.StackedColumn(keys, values,?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 

    /// Illustrates comparisons among individual items
    static member Bar(keys, values,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let marker =
            match Marker with 
            | Some m -> Options.Marker(?Color=Color) >> m
            | None   -> Options.Marker(?Color=Color)
        let trace = 
            Bar()
            |> Options.Bar(X = values,Y = keys,Orientation = StyleOption.Orientation.Horizontal)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.IMarker(marker)
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        GenericChart.Chart (trace,None)

    /// Illustrates comparisons among individual items
    static member Bar(keysvalues,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.Bar(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Displays series of tcolumn chart type as stacked bars.
    static member StackedBar(keys, values,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let marker =
            match Marker with 
            | Some m -> Options.Marker(?Color=Color) >> m
            | None   -> Options.Marker(?Color=Color)
        
        let trace = 
            Bar()
            |> Options.Bar(X = values,Y = keys,Orientation = StyleOption.Orientation.Horizontal)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            |> Options.IMarker(marker)
            |> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        
        let layout = 
            Options.Layout(Barmode=StyleOption.Barmode.Stack)
        GenericChart.Chart (trace,None)
        |>  GenericChart.addLayout layout

    /// Displays series of tcolumn chart type as stacked bars.
    static member StackedBar(keysvalues,?Name,?Showlegend,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Marker) = 
        let keys,values = Seq.unzip keysvalues
        Chart.StackedBar(keys, values, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Marker=Marker) 


    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.            
    static member BoxPlot(?x,?y,?Name,?Showlegend,?Color,?Opacity,?Whiskerwidth,?Boxpoints,?Boxmean,?Jitter,?Pointpos,?Orientation) = 
        let trace = 
            Box()
            |> Options.BoxPlot(?X=x, ?Y = y,
                ?Whiskerwidth=Whiskerwidth,?Boxpoints=Boxpoints,
                ?Boxmean=Boxmean,?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation,?Fillcolor=Color)            
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)          

        GenericChart.Chart (trace,None)

    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.       
    static member BoxPlot(xy,?Name,?Showlegend,?Color,?Opacity,?Whiskerwidth,?Boxpoints,?Boxmean,?Jitter,?Pointpos,?Orientation) = 
        let x,y = Seq.unzip xy
        Chart.BoxPlot(x, y, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?Whiskerwidth=Whiskerwidth,?Boxpoints=Boxpoints,?Boxmean=Boxmean,?Jitter=Jitter,?Pointpos=Pointpos,?Orientation=Orientation) 


    /// Shows a graphical representation of a 3-dimensional surface by plotting constant z slices, called contours, on a 2-dimensional format.
    /// That is, given a value for z, lines are drawn for connecting the (x,y) coordinates where that z value occurs.
    static member Heatmap(data:seq<#seq<#IConvertible>>,?ColNames,?RowNames,?Name,?Showlegend,?Opacity,?Colorscale,?Showscale,?zSmooth,?Colorbar) = 
        let trace = 
            Heatmap()
            |> Options.IMapZ(Z=data,?X=ColNames, ?Y=RowNames)
            |> Options.IColormap(?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            //|> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)            
        GenericChart.Chart (trace,None)


    /// Shows a graphical representation of data where the individual values contained in a matrix are represented as colors.
    static member Contour(data:seq<#seq<#IConvertible>>,?X,?Y,?Name,?Showlegend,?Opacity,?Colorscale,?Showscale,?zSmooth,?Colorbar) = 
        let trace = 
            Contour()
            |> Options.IMapZ(Z=data,?X=X, ?Y=Y)
            |> Options.IColormap(?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            //|> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)                                                      
        GenericChart.Chart (trace,None)


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
    static member Pie(values,?Labels,?Name,?Showlegend,?Color,?Text,?Textposition,?TextFont,?Hoverinfo,?Textinfo,?Opacity) =         
        let trace = 
            Pie()
            |> Options.Pie(Values=values,?Labels=Labels,?Textinfo=Textinfo)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity,?Hoverinfo=Hoverinfo)
            |> Options.ITextLabel(?Text=Text,?Textposition=Textposition,?Textfont=TextFont)
            |> Options.IMarker(Marker=Options.Marker(?Color=Color))
                                    
        GenericChart.Chart (trace,None)

    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
    static member Pie(data:seq<#IConvertible*#IConvertible>,?Name,?Showlegend,?Color,?Text,?Textposition,?TextFont,?Hoverinfo,?Textinfo,?Opacity) =         
        let values,labels = Seq.unzip data 
        Chart.Pie(values,Labels=labels,?Name=Name,?Showlegend=Showlegend,?Color=Color,?Text=Text,?Textposition=Textposition,?TextFont=TextFont,?Hoverinfo=Hoverinfo,?Textinfo=Textinfo,?Opacity=Opacity)


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
    static member Doughnut(values,?Labels,?Name,?Showlegend,?Color,?Hole,?Text,?Textposition,?TextFont,?Hoverinfo,?Textinfo,?Opacity) =         
        let hole' = if Hole.IsSome then Hole.Value else 0.4
        let trace = 
            Pie()
            |> Options.Pie(Values=values,?Labels=Labels,?Textinfo=Textinfo,Hole=hole')
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity,?Hoverinfo=Hoverinfo)
            |> Options.ITextLabel(?Text=Text,?Textposition=Textposition,?Textfont=TextFont)
            |> Options.IMarker(Marker=Options.Marker(?Color=Color))
              
        GenericChart.Chart (trace,None)

    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
    static member Doughnut(data:seq<#IConvertible*#IConvertible>,?Name,?Showlegend,?Color,?Hole,?Text,?Textposition,?TextFont,?Hoverinfo,?Textinfo,?Opacity) =         
        let values,labels = Seq.unzip data 
        Chart.Doughnut(values,Labels=labels,?Name=Name,?Showlegend=Showlegend,?Color=Color,?Hole=Hole,?Text=Text,?Textposition=Textposition,?TextFont=TextFont,?Hoverinfo=Hoverinfo,?Textinfo=Textinfo,?Opacity=Opacity)

    
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
    
    /// Displays the distribution of data based on the five number summary: minimum, first quartile, median, third quartile, and maximum.       
    static member Scatter3d(xyz, mode, ?Name,?Showlegend,?MarkerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let x,y,z = Seq.unzip3 xyz
        Chart.Scatter3d(x, y, z, mode, ?Name=Name,?Showlegend=Showlegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width) 

    /// Uses points, line or both depending on the mode to represent 3d-data points
    static member Surface(data:seq<#seq<#IConvertible>>,?X,?Y, ?Name,?Showlegend,?Opacity,?Colorscale,?Showscale,?zSmooth,?Colorbar) = 
        let trace = 
            Trace3dObjects.Surface()
            |> Options.IMapZ(Z=data,?X=X, ?Y=Y)
            |> Options.IColormap(?Colorscale=Colorscale,?Showscale=Showscale,?zSmooth=zSmooth,?Colorbar=Colorbar)
            |> Options.ITraceInfo(?Name=Name,?Showlegend=Showlegend,?Opacity=Opacity)
            //|> Options.ITextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)                                                      
        GenericChart.Chart (trace,None)

