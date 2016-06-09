namespace FSharp.Plotly

open System
open System.IO
open FSharp.Care.Collections
 
open StyleGramar
open ChartArea

open GenericChart
    


//    type key = IConvertible
//    type value = IConvertible

 
// https://plot.ly/javascript-graphing-library/reference/#line          



/// Provides a set of static methods for creating charts.
type Chart =

    /// Uses points, line or both depending on the mode to represent data points
    static member Scatter(x, y, mode, ?Name,?Showlegend,?MakerSymbol,?Color,?Opacity,?Labels,?TextPosition,?TextFont,?Dash,?Width) = 
        let line   = Line()   |> Helpers.ApplyLineStyles(?color=Color,?dash=Dash,?width=Width) 
        let marker = Marker() |> Helpers.ApplyMarkerStyles(?color=Color,?symbol=MakerSymbol) 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=mode, ?name=Name,line=line,marker=marker,
                ?showlegend=Showlegend,?opacity=Opacity,?text=Labels,?textposition=TextPosition,?textfont=TextFont)
        GenericChart.Chart (trace,None)


    /// Uses points to represent data points
    static member Point(x, y, ?Name,?Showlegend,?Color,?Opacity,?MakerSymbol,?Labels) =         
        let marker = Marker() |> Helpers.ApplyMarkerStyles(?color=Color,?symbol=MakerSymbol)       
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=StyleOption.Markers, ?name=Name,marker=marker,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)


    /// Uses points to represent data points
    static member Point(xy, ?Name,?Showlegend,?Color,?Opacity,?MakerSymbol,?Labels) =         
        let x,y = Seq.unzip xy
        Chart.Point(x,y, ?Name=Name,?Showlegend=Showlegend,?Color=Color,?Opacity=Opacity,?MakerSymbol=MakerSymbol,?Labels=Labels)


    /// Uses a line to connect the data points represented
    static member Line(x, y,?Name,?ShowMarkers,?Dash,?Showlegend,?Width,?Color,?Opacity,?MakerSymbol,?Labels) =             
        let line   = Line()   |> Helpers.ApplyLineStyles(?color=Color,?dash=Dash,?width=Width)
        let marker = Marker() |> Helpers.ApplyMarkerStyles(?color=Color,?symbol=MakerSymbol)
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=mode', ?name=Name,line=line,marker=marker,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)
    

    /// Uses a line to connect the data points represented
    static member Line(xy,?Name,?ShowMarkers,?Dash,?Showlegend,?Width,?Color,?Opacity,?MakerSymbol,?Labels) =  
        let x,y = Seq.unzip xy
        Chart.Line(x,y,?Name=Name,?ShowMarkers=ShowMarkers,?Dash=Dash,?Showlegend=Showlegend,
                       ?Width=Width,?Color=Color,?Opacity=Opacity,?MakerSymbol=MakerSymbol,?Labels=Labels)


    /// 
    static member Spline(x, y,?Name,?ShowMarkers,?Dash,?Showlegend,?Width,?Color,?Opacity,?MakerSymbol,?Labels,?Smoothing) =             
        let line   = Line()   |> Helpers.ApplyLineStyles(?color=Color,?dash=Dash,?width=Width,shape=StyleOption.Shape.Spline,?smoothing=Smoothing)
        let marker = Marker() |> Helpers.ApplyMarkerStyles(?color=Color,?symbol=MakerSymbol)
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=mode', ?name=Name,line=line,marker=marker,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)


    /// A variation of the Point chart type, where the data points are replaced by bubbles of different sizes.
    static member Bubble(x, y, size:seq<#IConvertible>,?Name,?Showlegend,?Color,?Opacity,?Labels) =         
        let marker = 
            Marker(size = size) |> Helpers.ApplyMarkerStyles(?color=Color)                 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=StyleOption.Markers, ?name=Name,marker=marker,
                ?showlegend=Showlegend,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)


    /// 
    static member Range(x, y, upper, lower, ?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels) =             
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
            
        let mline = Line()   |> Helpers.ApplyLineStyles(?color=Color)
        let mmark = Marker() |> Helpers.ApplyMarkerStyles(?color=Color)
        let tLine = Line() |> Helpers.ApplyLineStyles(width=0)
        let tmark = Marker(color = if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)")
            

        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=mode', ?name=Name,line=mline,marker=mmark,
                ?showlegend=Showlegend,?fillcolor=Color,?text=Labels)
        let lower = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = lower, mode=StyleOption.Lines,line=tLine,
                showlegend=false,?fillcolor=RangeColor,marker=tmark)
        let upper = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = upper, mode=StyleOption.Lines,fill=StyleOption.ToNext_y,line=tLine,
                showlegend=false,?fillcolor=RangeColor,marker=tmark)
        GenericChart.MultiChart ([lower;upper;trace],None)

    /// 
    static member SplineRange(x, y, upper, lower, ?Name,?ShowMarkers,?Showlegend,?Color,?RangeColor,?Labels,?Smoothing) =             
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
            
        let mline = Line()   |> Helpers.ApplyLineStyles(?color=Color,shape=StyleOption.Shape.Spline,?smoothing=Smoothing)
        let mmark = Marker() |> Helpers.ApplyMarkerStyles(?color=Color)
        let tLine = Line() |> Helpers.ApplyLineStyles(width=0,shape=StyleOption.Shape.Spline,?smoothing=Smoothing)
        let tmark = Marker(color = if RangeColor.IsSome then RangeColor.Value else "rgba(0,0,,0.5)")
            

        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode=mode', ?name=Name,line=mline,marker=mmark,
                ?showlegend=Showlegend,?fillcolor=Color,?text=Labels)
        let lower = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = lower, mode=StyleOption.Lines,line=tLine,
                showlegend=false,?fillcolor=RangeColor,marker=tmark)
        let upper = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = upper, mode=StyleOption.Lines,fill=StyleOption.ToNext_y,line=tLine,
                showlegend=false,?fillcolor=RangeColor,marker=tmark)
        GenericChart.MultiChart ([lower;upper;trace],None)

    ///
    static member Area(x, y, ?Name,?ShowMarkers,?Showlegend,?Color,?Opacity,?Labels) = 
        let mode' = match ShowMarkers with
                    | Some show -> if show then StyleOption.Lines_Markers else StyleOption.Lines
                    | None      -> StyleOption.Lines_Markers // default 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, fill=StyleOption.ToZero_y, mode=mode', ?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)

    static member Bar(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("bar",x = x,y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        GenericChart.Chart (trace,None)

    static member StackedBar(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("bar",x = x,y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
        let layout = Layout (barmode = "stack")
        GenericChart.Chart (trace,Some layout)

    static member Column(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("bar",x = x,y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels,orientation = StyleOption.Orientation.Horizontal)
        GenericChart.Chart (trace,None)

    static member StackedColumn(x, y, ?Name,?Showlegend,?Color,?Opacity,?Labels) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("bar",x = x,y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels,orientation = StyleOption.Orientation.Horizontal)
        let layout = Layout (barmode = "stack")
        GenericChart.Chart (trace,Some layout)

    static member BoxPlot(?x,?y,?Name,?Showlegend, ?Color,?Opacity,?Whiskerwidth,?Boxpoints,?Boxmean,?Jitter,?Pointpos) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("box", ?x=x, ?y = y,?name=Name,
                ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?whiskerwidth=Whiskerwidth,?boxpoints=Boxpoints,
                ?boxmean=Boxmean,?jitter=Jitter,?pointpos=Pointpos)
            
        GenericChart.Chart (trace,None)


    static member HeatMap(data:seq<#seq<#IConvertible>>,?ColNames,?RowNames, ?Name,?Colorscale,?Showscale,?zSmooth,?Colorbar) = 
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("heatmap",z=data,?x=ColNames, ?y=RowNames,?name=Name,
                ?colorScale=Colorscale,?showscale=Showscale,?zsmooth=zSmooth,?colorbar=Colorbar
                                        )                
        GenericChart.Chart (trace,None)

    static member Pie(values,?labels,?Name,?Color) = 
        let marker = Marker() |> Helpers.ApplyMarkerStyles(?color=Color)
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("pie",values=values,?labels=labels,?name=Name,marker=marker
                                        )                
        GenericChart.Chart (trace,None)

    static member Doughnut(values,?labels,?Name,?Color,?hole) = 
        let marker = Marker() |> Helpers.ApplyMarkerStyles(?color=Color)
        let hole = if hole.IsSome then hole.Value else 0.4
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("pie",values=values,?labels=labels,?name=Name,marker=marker,hole=hole
             
//               hoverinfo: 'label+percent+name',
//               textinfo: 'none'
//               text 
//               textposition 
                                        )                
        GenericChart.Chart (trace,None)

    

    /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
    static member Histogram2d(x,y,?Name,?HistNorm,?HistFunc,?Colorscale,?Showscale,?zSmooth,?Colorbar,?zAuto,?zMin,?zMax,?nBinsx,?nBinsy,?Xbins,?Ybins) =         
        let trace = 
            Trace()
            |> Helpers.ApplyTraceStyles("histogram2d",x=x,y=y,?name=Name,?histnorm=HistNorm,?histfunc=HistFunc,
                          ?colorScale=Colorscale,?showscale=Showscale,?zsmooth=zSmooth,?colorbar=Colorbar,
                          ?zauto=zAuto,?zmin=zMin,?zmax=zMax,
                          ?nbinsx=nBinsx,?nbinsy=nBinsy,?xbins=Xbins,?ybins=Ybins
                          )                
        
        GenericChart.Chart (trace,None)

    /// Computes the bi-dimensional histogram of two data samples and auto-determines the bin size.
    static member Histogram2d(xy,?Name,?HistNorm,?HistFunc,?Colorscale,?Showscale,?zSmooth,?Colorbar,?zAuto,?zMin,?zMax,?nBinsx,?nBinsy,?Xbins,?Ybins) =         
        let x,y = Seq.unzip xy
        Chart.Histogram2d(x,y,?Name=Name,?HistNorm=HistNorm,?HistFunc=HistFunc,?Colorscale=Colorscale,
            ?Showscale=Showscale,?Colorbar=Colorbar,?zSmooth=zSmooth,?zAuto=zAuto,?zMin=zMin,?zMax=zMax,
            ?nBinsx=nBinsx,?nBinsy=nBinsy,?Xbins=Xbins,?Ybins=Ybins
            )




//         static member Point3D(x, y, z, ?Name,?ShowMarkers,?Showlegend,?Color,?Opacity,?Labels) = 
//            let trace = 
//                GenericTrace()
//                |> Helpers.ApplyTraceStyles("scatter",x = x,y = y, mode="markers", ?name=Name,
//                    ?showlegend=Showlegend,?fillcolor=Color,?opacity=Opacity,?text=Labels)
//            GenericChart.Chart (trace,None)       
        
    
    /// Create a combined chart with the given charts merged   
    static member Combine(gCharts:seq<GenericChart>) =
        gCharts
        |> Seq.reduce (fun acc elem ->
                            match acc,elem with
                            | MultiChart (traces,l1),Chart (trace,l2)         -> MultiChart (Seq.append traces [trace], combine' l1 l2)
                            | MultiChart (traces1,l1),MultiChart (traces2,l2) -> MultiChart (Seq.append traces1 traces2,combine' l1 l2)
                            | Chart (trace1,l1),Chart (trace2,l2)             -> MultiChart ([trace1;trace2],combine' l1 l2)
                            | Chart (trace,l1),MultiChart (traces,l2)         -> MultiChart (Seq.append [trace] traces ,combine' l1 l2)
                        ) 
 
 
  
    

                        
