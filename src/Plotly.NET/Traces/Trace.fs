namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System

/// Trace type inherits from dynamic object
type Trace (traceTypeName) =
    inherit DynamicObj ()
    //interface ITrace with
        // Implictit ITrace
    member val ``type`` = traceTypeName with get,set

//-------------------------------------------------------------------------------------------------------------------------------------------------
/// Functions provide the styling of the Chart objects
/// These functions are used internally to style traces of Chart objects. Users are usually pointed
/// to the API layer provided by the `Chart` module/object
type TraceStyle() =
    /// Applies the given TraceInfo style parameters to a Trace object.
    static member TraceInfo
        (    
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?Showlegend: bool,
            ?Legendgroup:string,
            ?Opacity: float,
            ?Uid: string,
            ?Hoverinfo: string
            //?Stream: Stream

        ) =
            (fun (trace:('T :> Trace)) ->  
                Name        |> DynObj.setValueOpt trace "name"
                Visible     |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.toString
                Showlegend  |> DynObj.setValueOpt trace "showlegend"
                Legendgroup |> DynObj.setValueOpt trace "legendgroup"  
                Opacity     |> DynObj.setValueOpt trace "opacity"
                Uid         |> DynObj.setValueOpt trace "uid"
                Hoverinfo   |> DynObj.setValueOpt trace "hoverinfo"
                // Update
                //Stream: Stream                    
                    
                // out ->
                trace
            ) 

    /// Sets the given axis anchor id(s) on a Trace object.
    static member SetAxisAnchor
        (
            ?X:StyleParam.LinearAxisId,
            ?Y:StyleParam.LinearAxisId
        ) =  
            (fun (trace:('T :> Trace)) ->

                X     |> DynObj.setValueOptBy trace "xaxis" StyleParam.LinearAxisId.toString
                Y     |> DynObj.setValueOptBy trace "yaxis" StyleParam.LinearAxisId.toString
                    
                trace
            )

    /// Sets selection of data points on a Trace object.
    static member SetSelection
        (
            ?Selectedpoints,
            ?Selected,
            ?UnSelected
        ) =  
            (fun (trace:('T :> Trace)) ->

                Selectedpoints |> DynObj.setValueOpt trace "Selectedpoints"
                Selected       |> DynObj.setValueOpt trace "Selected"
                UnSelected     |> DynObj.setValueOpt trace "UnSelected"
            
                trace
            )


    /// Sets the given text label styles on a Trace object.
    static member TextLabel
        (    
            ?Text   : seq<#IConvertible>,
            ?Textposition: StyleParam.TextPosition,
            ?Textfont: Font,
            ?Textsrc : string,
            ?Textpositionsrc : string

        ) =
            (fun (trace:('T :> Trace)) ->
                Text            |> DynObj.setValueOpt trace "text"
                Textposition    |> DynObj.setValueOptBy trace "textposition" StyleParam.TextPosition.toString                  
                Textsrc         |> DynObj.setValueOpt trace "textsrc"
                Textpositionsrc |> DynObj.setValueOpt trace "textpositionsrc"
                Textfont        |> DynObj.setValueOpt trace "textfont"
                    
                // out ->
                trace
            )  


    /// Sets the given line on a Trace object.
    static member SetLine
        (
            line:Line
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("line", line)
                trace
            )


    /// Sets the given Line styles on the line property of a Trace object
    static member Line
        (
            ?Width: float,
            ?Color: string,
            ?Shape: StyleParam.Shape,
            ?Dash: StyleParam.DrawingStyle,
            ?Smoothing: float,
            ?Colorscale : StyleParam.Colorscale
        ) =
            (fun (trace:('T :> Trace)) ->
                let line =
                    match (trace.TryGetValue "line") with
                    | Some line -> line :?> Line
                    | None -> Line.init()
                    |> Line.style(?Width=Width,?Color=Color,?Shape=Shape,?Dash=Dash,?Smoothing=Smoothing,?Colorscale=Colorscale)
                    
                trace.SetValue("line", line)
                trace
            )    


    /// Sets the given marker on a Trace object.
    static member SetMarker
        (
            marker:Marker
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("marker", marker)
                trace
            )


    /// Sets the given Marker styles on the marker property of a Trace object
    static member Marker
        (   
            ?Size: int,
            ?Opacity: float,
            ?Color: string,
            ?Symbol: StyleParam.Symbol,
            ?MultiSizes: seq<#IConvertible>,
            ?Line: Line,
            ?ColorBar: ColorBar,
            ?Colorscale : StyleParam.Colorscale,
            ?Colors: seq<string>,
            ?OutlierColor:string,
            ?Maxdisplayed: int,
            ?Sizeref: float,
            ?Sizemin: float,
            ?Sizemode: StyleParam.MarkerSizeMode,
            ?Cauto: bool,
            ?Cmax: float,
            ?Cmin: float,
            ?Cmid: float,
            ?Autocolorscale: bool,
            ?Reversescale: bool,
            ?Showscale: bool

        ) =
            (fun (trace:('T :> Trace)) ->
                let marker =
                    match (trace.TryGetValue "marker") with
                    | Some m -> m :?> Marker
                    | None -> Marker ()
                    
                    |> Marker.style(?Size=Size,?Color=Color,?Symbol=Symbol,
                        ?Opacity=Opacity,?MultiSizes=MultiSizes,?Line=Line,
                        ?ColorBar=ColorBar,?Colorscale=Colorscale,?Colors=Colors,?OutlierColor=OutlierColor,
                        ?Maxdisplayed=Maxdisplayed,?Sizeref=Sizeref,?Sizemin=Sizemin,
                        ?Sizemode=Sizemode,?Cauto=Cauto,?Cmax=Cmax,?Cmin=Cmin,?Cmid=Cmid,
                        ?Autocolorscale=Autocolorscale,?Reversescale=Reversescale,?Showscale=Showscale
                        )

                trace.SetValue("marker", marker)
                trace                   

            )




    /// Sets the given domain on a Trace object.
    static member SetDomain
        (
            domain:Domain
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("domain", domain)
                trace
            )
        
    /// Sets the given Domain styles on the domain property of a Trace object
    static member Domain
        (
            ?X     : StyleParam.Range,
            ?Y     : StyleParam.Range,
            ?Row   : int,
            ?Column: int
        ) =
                (fun (trace:('T :> Trace)) ->
                    let domain =
                        match (trace.TryGetValue "domain") with
                        | Some m -> m :?> Domain
                        | None -> Domain ()
     
                        |> Domain.style(?X=X,?Y=Y,?Row=Row,?Column=Column)

                    trace.SetValue("domain", domain)
                    trace
                )

    // Sets the X-Error an a Trace object.
    static member SetErrorX
        (
            error:Error
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("error_x", error)
                trace
            )

    // Sets Y-Error() to TraceObjects
    static member SetErrorY
        (
            error:Error
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("error_y", error)
                trace
            )

    // Sets Z-Error() to TraceObjects
    static member SetErrorZ
        (
            error:Error
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("error_z", error)
                trace
            )

    // Sets Stackgroup() to TraceObjects
    static member SetStackGroup
        (
            stackgroup: string
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("stackgroup", stackgroup)
                trace
            )