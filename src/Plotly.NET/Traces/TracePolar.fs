namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open DynamicObj.Operators
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

                trace

                ++?? ("subplot", PolarId , StyleParam.SubPlotId.toString)
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
            [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
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

                trace

                ++? ("name", Name               )
                ++?? ("visible", Visible            , StyleParam.Visible.convert)
                ++? ("showlegend", ShowLegend         )
                ++? ("legendrank", LegendRank         )
                ++? ("legendgroup", LegendGroup        )
                ++? ("legendgrouptitle", LegendGroupTitle   )
                ++? ("opacity", Opacity            )
                ++?? ("mode", Mode               , StyleParam.Mode.convert)
                ++? ("ids", Ids                )
                ++? ("r", R                  )
                ++? ("r0", R0                 )
                ++? ("dr", DR                 )
                ++? ("theta", Theta              )
                ++? ("theta0", Theta0             )
                ++? ("dtheta", DTheta             )
                ++?? ("thetaunit", ThetaUnit          , StyleParam.AngularUnit.convert)
                ++? ("text", Text               )
                ++?? ("textposition", TextPosition       , StyleParam.TextPosition.convert)
                ++? ("texttemplate", TextTemplate       )
                ++? ("hovertext", HoverText          )
                ++? ("hoverinfo", HoverInfo          )
                ++? ("hovertemplate", HoverTemplate      )
                ++? ("meta", Meta               )
                ++? ("customdata", CustomData         )
                ++? ("subplot", Subplot            )
                ++? ("marker", Marker             )
                ++? ("line", Line               )
                ++? ("textfont", TextFont           )
                ++? ("selectedpoints", SelectedPoints     )
                ++? ("selected", Selected           )
                ++? ("unselected", Unselected         )
                ++? ("cliponaxis", ClipOnAxis         )
                ++? ("connectgaps", ConnectGaps        )
                ++?? ("fill", Fill               , StyleParam.Fill.convert)
                ++? ("fillcolor", FillColor          )
                ++? ("hoverlabel", HoverLabel         )
                ++? ("hoveron", HoverOn            )
                ++? ("uirevision", UIRevision         )
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
                    
                trace

                ++? ("name", Name                )
                ++?? ("visible", Visible             , StyleParam.Visible.convert)
                ++? ("showlegend", ShowLegend          )
                ++? ("legendrank", LegendRank          )
                ++? ("legendgroup", LegendGroup         )
                ++? ("legendgrouptitle", LegendGroupTitle    )
                ++? ("opacity", Opacity             )
                ++? ("ids", Ids                 )
                ++? ("base", Base                )
                ++? ("r", R                   )
                ++? ("r0", R0                  )
                ++? ("dr", DR                  )
                ++? ("theta", Theta               )
                ++? ("theta0", Theta0              )
                ++? ("dtheta", DTheta              )
                ++?? ("thetaunit", ThetaUnit           , StyleParam.AngularUnit.convert)
                ++? ("width", Width               )
                ++? ("offset", Offset              )
                ++? ("text", Text                )
                ++? ("hovertext", HoverText           )
                ++? ("hoverinfo", HoverInfo           )
                ++? ("hovertemplate", HoverTemplate       )
                ++? ("meta", Meta                )
                ++? ("customdata", CustomData          )
                ++? ("subplot", Subplot             )
                ++? ("marker", Marker              )
                ++? ("selectedpoints", SelectedPoints      )
                ++? ("selected", Selected            )
                ++? ("unselected", Unselected          )
                ++? ("hoverlabel", HoverLabel          )
                ++? ("uirevision", UIRevision          )
            )