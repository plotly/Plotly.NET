namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type Dimensions () =
    inherit DynamicObj ()

    /// Initialized Dimensions object
    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Range: StyleParam.Range,
            [<Optional;DefaultParameterValue(null)>] ?Constraintrange: StyleParam.Range,
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Label: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Tickvals: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TickText: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TickFormat: StyleParam.TickMode
        ) =
            Dimensions () 
            |> Dimensions.style
                (
                    ?Values          = Values    ,
                    ?Range           = Range     ,
                    ?Constraintrange = Constraintrange,
                    ?Visible         = Visible,
                    ?Label           = Label,
                    ?Tickvals        = Tickvals,
                    ?TickText        = TickText,
                    ?TickFormat      = TickFormat
                )


    // Applies the styles to Dimensions()
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Range: StyleParam.Range,
            [<Optional;DefaultParameterValue(null)>] ?Constraintrange: StyleParam.Range,
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Label: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Tickvals: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TickText: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TickFormat: StyleParam.TickMode
        ) =
            (fun (dims:Dimensions) -> 
                ++? ("values", Values           )
                ++?? ("range", Range            , StyleParam.Range.convert                )
                ++?? ("constraintrange", Constraintrange  , StyleParam.Range.convert                 )
                ++? ("Visible", Visible          )
                ++? ("label", Label            )
                ++? ("tickvals", Tickvals         )
                ++? ("ticktext", TickText         )   
                ++? ("tickformat", TickFormat       )
                
                // out -> 
                dims
            )



               