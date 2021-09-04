namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices


/// Traces for polar subplots, using layout.polar as anchors.
///
/// The following trace types are compatible with polar subplots via the polar attribute:
/// 
/// - scatter-like trace types: scatterpolar and scatterpolargl, which can be used to draw individual markers, curves and filled areas (i.e. radar or spider charts)
/// 
/// - barpolar: useful for wind roses and other polar bar charts

type TracePolar(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "scatterpolar" applying the given trace styling function
    static member initScatterPolar (applyStyle: TracePolar -> TracePolar) = 
        TracePolar("scatterpolar") |> applyStyle

    ///initializes a trace of type "scatterpolargl" applying the given trace styling function
    static member initScatterPolarGL (applyStyle: TracePolar -> TracePolar) = 
        TracePolar("scatterpolargl") |> applyStyle

    ///initializes a trace of type "barpolar" applying the given trace styling function
    static member initBarPolar (applyStyle: TracePolar -> TracePolar) = 
        TracePolar("barpolar") |> applyStyle

type TracePolarStyle() =
    
    static member SetPolar
        (
            [<Optional;DefaultParameterValue(null)>] ?PolarId:StyleParam.SubPlotId
        ) =  
            (fun (trace:TracePolar) ->

                PolarId |> DynObj.setValueOptBy trace "subplot" StyleParam.SubPlotId.toString

                trace
            )

    static member ScatterPolar
        (
            [<Optional;DefaultParameterValue(null)>] ?Name               : string,
            [<Optional;DefaultParameterValue(null)>] ?Visible            : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendRank         : int,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup        : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle   : Title,
            [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
            [<Optional;DefaultParameterValue(null)>] ?Mode               : StyleParam.Mode,
            [<Optional;DefaultParameterValue(null)>] ?Ids                : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?R                  : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?R0                 : IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DR                 : IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Theta              : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Theta0             : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DTheta             : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?ThetaUnit          : StyleParam.AngularUnit,
            [<Optional;DefaultParameterValue(null)>] ?Text               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextInfoPosition,
            [<Optional;DefaultParameterValue(null)>] ?TextTemplate       : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?HoverText          : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?HoverInfo          : string,
            [<Optional;DefaultParameterValue(null)>] ?HoverTemplate      : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Meta               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?CustomData         : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Subplot            : string,
            [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
            [<Optional;DefaultParameterValue(null)>] ?Line               : Line,
            [<Optional;DefaultParameterValue(null)>] ?TextFont           : Font,
            [<Optional;DefaultParameterValue(null)>] ?SelectedPoints     : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Selected           : Selection,
            [<Optional;DefaultParameterValue(null)>] ?Unselected         : Selection,
            [<Optional;DefaultParameterValue(null)>] ?ClipOnAxis         : bool,
            [<Optional;DefaultParameterValue(null)>] ?ConnectGaps        : bool,
            [<Optional;DefaultParameterValue(null)>] ?Fill               : StyleParam.Fill,
            [<Optional;DefaultParameterValue(null)>] ?FillColor          : Color,
            [<Optional;DefaultParameterValue(null)>] ?HoverLabel         : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?HoverOn            : string,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision         : seq<#IConvertible>
        ) =
            (fun (trace:('T :> Trace)) -> 

                Name               |> DynObj.setValueOpt trace "name"
                Visible            |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
                ShowLegend         |> DynObj.setValueOpt trace "showlegend"
                LegendRank         |> DynObj.setValueOpt trace "legendrank"
                LegendGroup        |> DynObj.setValueOpt trace "legendgroup"
                LegendGroupTitle   |> DynObj.setValueOpt trace "legendgrouptitle"
                Opacity            |> DynObj.setValueOpt trace "opacity"
                Mode               |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.convert
                Ids                |> DynObj.setValueOpt trace "ids"
                R                  |> DynObj.setValueOpt trace "r"
                R0                 |> DynObj.setValueOpt trace "r0"
                DR                 |> DynObj.setValueOpt trace "dr"
                Theta              |> DynObj.setValueOpt trace "theta"
                Theta0             |> DynObj.setValueOpt trace "theta0"
                DTheta             |> DynObj.setValueOpt trace "dtheta"
                ThetaUnit          |> DynObj.setValueOptBy trace "thetaunit" StyleParam.AngularUnit.convert
                Text               |> DynObj.setValueOpt trace "text"
                TextPosition       |> DynObj.setValueOptBy trace "textposition" StyleParam.TextInfoPosition.convert
                TextTemplate       |> DynObj.setValueOpt trace "texttemplate"
                HoverText          |> DynObj.setValueOpt trace "hovertext"
                HoverInfo          |> DynObj.setValueOpt trace "hoverinfo"
                HoverTemplate      |> DynObj.setValueOpt trace "hovertemplate"
                Meta               |> DynObj.setValueOpt trace "meta"
                CustomData         |> DynObj.setValueOpt trace "customdata"
                Subplot            |> DynObj.setValueOpt trace "subplot"
                Marker             |> DynObj.setValueOpt trace "marker"
                Line               |> DynObj.setValueOpt trace "line"
                TextFont           |> DynObj.setValueOpt trace "textfont"
                SelectedPoints     |> DynObj.setValueOpt trace "selectedpoints"
                Selected           |> DynObj.setValueOpt trace "selected"
                Unselected         |> DynObj.setValueOpt trace "unselected"
                ClipOnAxis         |> DynObj.setValueOpt trace "cliponaxis"
                ConnectGaps        |> DynObj.setValueOpt trace "connectgaps"
                Fill               |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
                FillColor          |> DynObj.setValueOpt trace "fillcolor"
                HoverLabel         |> DynObj.setValueOpt trace "hoverlabel"
                HoverOn            |> DynObj.setValueOpt trace "hoveron"
                UIRevision         |> DynObj.setValueOpt trace "uirevision"

                trace
            )

    static member BarPolar
        (
            [<Optional;DefaultParameterValue(null)>] ?Name               : string,
            [<Optional;DefaultParameterValue(null)>] ?Visible            : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendRank         : int,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup        : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle   : Title,
            [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
            [<Optional;DefaultParameterValue(null)>] ?Ids                : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Base               : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?R                  : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?R0                 : IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DR                 : IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Theta              : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Theta0             : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DTheta             : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?ThetaUnit          : StyleParam.AngularUnit,
            [<Optional;DefaultParameterValue(null)>] ?Width              : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Offset             : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Text               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?HoverText          : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?HoverInfo          : string,
            [<Optional;DefaultParameterValue(null)>] ?HoverTemplate      : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Meta               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?CustomData         : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Subplot            : string,
            [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
            [<Optional;DefaultParameterValue(null)>] ?SelectedPoints     : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Selected           : Selection,
            [<Optional;DefaultParameterValue(null)>] ?Unselected         : Selection,
            [<Optional;DefaultParameterValue(null)>] ?HoverLabel         : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision         : seq<#IConvertible>
        ) =
            (fun (trace:('T :> Trace)) -> 

                Name                |> DynObj.setValueOpt trace "name"
                Visible             |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
                ShowLegend          |> DynObj.setValueOpt trace "showlegend"
                LegendRank          |> DynObj.setValueOpt trace "legendrank"
                LegendGroup         |> DynObj.setValueOpt trace "legendgroup"
                LegendGroupTitle    |> DynObj.setValueOpt trace "legendgrouptitle"
                Opacity             |> DynObj.setValueOpt trace "opacity"
                Ids                 |> DynObj.setValueOpt trace "ids"
                Base                |> DynObj.setValueOpt trace "base"
                R                   |> DynObj.setValueOpt trace "r"
                R0                  |> DynObj.setValueOpt trace "r0"
                DR                  |> DynObj.setValueOpt trace "dr"
                Theta               |> DynObj.setValueOpt trace "theta"
                Theta0              |> DynObj.setValueOpt trace "theta0"
                DTheta              |> DynObj.setValueOpt trace "dtheta"
                ThetaUnit           |> DynObj.setValueOptBy trace "thetaunit" StyleParam.AngularUnit.convert
                Width               |> DynObj.setValueOpt trace "width"
                Offset              |> DynObj.setValueOpt trace "offset"
                Text                |> DynObj.setValueOpt trace "text"
                HoverText           |> DynObj.setValueOpt trace "hovertext"
                HoverInfo           |> DynObj.setValueOpt trace "hoverinfo"
                HoverTemplate       |> DynObj.setValueOpt trace "hovertemplate"
                Meta                |> DynObj.setValueOpt trace "meta"
                CustomData          |> DynObj.setValueOpt trace "customdata"
                Subplot             |> DynObj.setValueOpt trace "subplot"
                Marker              |> DynObj.setValueOpt trace "marker"
                SelectedPoints      |> DynObj.setValueOpt trace "selectedpoints"
                Selected            |> DynObj.setValueOpt trace "selected"
                Unselected          |> DynObj.setValueOpt trace "unselected"
                HoverLabel          |> DynObj.setValueOpt trace "hoverlabel"
                UIRevision          |> DynObj.setValueOpt trace "uirevision"
                    
                trace
            )