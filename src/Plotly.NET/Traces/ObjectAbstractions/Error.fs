namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System

/// Error type inherits from dynamic object
type Error () =
    inherit DynamicObj ()
    
    /// <summary>Init Error type</summary>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    static member init
        (   
            ?Symmetric: bool,
            ?Array: seq<#IConvertible>,
            ?Arrayminus: seq<#IConvertible>,
            ?Value: float,
            ?Valueminus: float,
            ?Traceref: int,
            ?Tracerefminus: int,
            ?Copy_ystyle: bool,
            ?Color: string,
            ?Thickness: float,
            ?Width: float
        ) =
            Error() 
            |> Error.style
                (   
                   ?Symmetric     =  Symmetric     ,
                   ?Array         =  Array         ,
                   ?Arrayminus    =  Arrayminus    ,
                   ?Value         =  Value         ,
                   ?Valueminus    =  Valueminus    ,
                   ?Traceref      =  Traceref      ,
                   ?Tracerefminus =  Tracerefminus ,
                   ?Copy_ystyle   =  Copy_ystyle   ,
                   ?Color         =  Color         ,
                   ?Thickness     =  Thickness     ,
                   ?Width         =  Width         
                )

    /// <summary>Creates a function that applies the given style parameters to an Error object</summary>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    static member style
        (   
            ?Symmetric: bool,
            ?Array: seq<#IConvertible>,
            ?Arrayminus: seq<#IConvertible>,
            ?Value: float,
            ?Valueminus: float,
            ?Traceref: int,
            ?Tracerefminus: int,
            ?Copy_ystyle: bool,
            ?Color: string,
            ?Thickness: float,
            ?Width: float

        ) =
            (fun (error:Error) -> 
                Symmetric     |> DynObj.setValueOpt error "symmetric"
                Array         |> DynObj.setValueOpt error "array"
                Arrayminus    |> DynObj.setValueOpt error "arrayminus"
                Value         |> DynObj.setValueOpt error "value"
                Valueminus    |> DynObj.setValueOpt error "valueminus"
                Traceref      |> DynObj.setValueOpt error "traceref"
                Tracerefminus |> DynObj.setValueOpt error "tracerefminus"
                Copy_ystyle   |> DynObj.setValueOpt error "copy_ystyle"
                Color         |> DynObj.setValueOpt error "color"
                Thickness     |> DynObj.setValueOpt error "thickness"
                Width         |> DynObj.setValueOpt error "width"

                // out ->
                error
            )
    
 
            