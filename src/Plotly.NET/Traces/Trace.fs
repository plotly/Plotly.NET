namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Trace type inherits from dynamic object
type Trace (traceTypeName) =
    inherit ImmutableDynamicObj ()
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
            [<Optional;DefaultParameterValue(null)>] ?Name: string,
            [<Optional;DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?Showlegend: bool,
            [<Optional;DefaultParameterValue(null)>] ?Legendgroup:string,
            [<Optional;DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional;DefaultParameterValue(null)>] ?Uid: string,
            [<Optional;DefaultParameterValue(null)>] ?Hoverinfo: string
            //?Stream: Stream

        ) =
            (fun (trace:('T :> Trace)) ->  
                ++? ("name", Name)
                ++?? ("visible", Visible, StyleParam.Visible.toString)
                ++? ("showlegend", Showlegend)
                ++? ("legendgroup", Legendgroup)  
                ++? ("opacity", Opacity)
                ++? ("uid", Uid)
                ++? ("hoverinfo", Hoverinfo)
                // Update
                //Stream: Stream                    
                    
                // out ->
                trace
            ) 

    /// Sets selection of data points on a Trace object.
    static member SetSelection
        (
            [<Optional;DefaultParameterValue(null)>] ?Selectedpoints,
            [<Optional;DefaultParameterValue(null)>] ?Selected,
            [<Optional;DefaultParameterValue(null)>] ?UnSelected
        ) =  
            (fun (trace:('T :> Trace)) ->

                ++? ("Selectedpoints", Selectedpoints)
                ++? ("Selected", Selected)
                ++? ("UnSelected", UnSelected)
            
                trace
            )


    /// Sets the given text label styles on a Trace object.
    static member TextLabel
        (    
            [<Optional;DefaultParameterValue(null)>] ?Text   : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Textposition: StyleParam.TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?Textfont: Font,
            [<Optional;DefaultParameterValue(null)>] ?Textsrc : string,
            [<Optional;DefaultParameterValue(null)>] ?Textpositionsrc : string

        ) =
            (fun (trace:('T :> Trace)) ->
                ++? ("text", Text)
                ++?? ("textposition", Textposition, StyleParam.TextPosition.toString)                  
                ++? ("textsrc", Textsrc)
                ++? ("textpositionsrc", Textpositionsrc)
                ++? ("textfont", Textfont)
                    
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
            [<Optional;DefaultParameterValue(null)>] ?Width: float,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color,
            [<Optional;DefaultParameterValue(null)>] ?Shape: StyleParam.Shape,
            [<Optional;DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing: float,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale : StyleParam.Colorscale
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
            [<Optional;DefaultParameterValue(null)>] ?Size: int,
            [<Optional;DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color,
            [<Optional;DefaultParameterValue(null)>] ?Symbol: StyleParam.Symbol,
            [<Optional;DefaultParameterValue(null)>] ?MultiSizes: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Line: Line,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale : StyleParam.Colorscale,
            //[<Optional;DefaultParameterValue(null)>] ?Colors: seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor:Color,
            [<Optional;DefaultParameterValue(null)>] ?Maxdisplayed: int,
            [<Optional;DefaultParameterValue(null)>] ?Sizeref: float,
            [<Optional;DefaultParameterValue(null)>] ?Sizemin: float,
            [<Optional;DefaultParameterValue(null)>] ?Sizemode: StyleParam.MarkerSizeMode,
            [<Optional;DefaultParameterValue(null)>] ?Cauto: bool,
            [<Optional;DefaultParameterValue(null)>] ?Cmax: float,
            [<Optional;DefaultParameterValue(null)>] ?Cmin: float,
            [<Optional;DefaultParameterValue(null)>] ?Cmid: float,
            [<Optional;DefaultParameterValue(null)>] ?Autocolorscale: bool,
            [<Optional;DefaultParameterValue(null)>] ?Reversescale: bool,
            [<Optional;DefaultParameterValue(null)>] ?Showscale: bool

        ) =
            (fun (trace:('T :> Trace)) ->
                let marker =
                    match (trace.TryGetValue "marker") with
                    | Some m -> m :?> Marker
                    | None -> Marker ()
                    
                    |> Marker.style(?Size=Size,?Color=Color,?Symbol=Symbol,
                        ?Opacity=Opacity,?MultiSizes=MultiSizes,?Line=Line,
                        ?ColorBar=ColorBar,?Colorscale=Colorscale,?OutlierColor=OutlierColor,
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
            [<Optional;DefaultParameterValue(null)>] ?X     : StyleParam.Range,
            [<Optional;DefaultParameterValue(null)>] ?Y     : StyleParam.Range,
            [<Optional;DefaultParameterValue(null)>] ?Row   : int,
            [<Optional;DefaultParameterValue(null)>] ?Column: int
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