namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System

type SlicesFill () =
    inherit DynamicObj () 

    static member init 
        (
            ?Fill: float,
            ?Locations: seq<#IConvertible>,
            ?Show: bool
        ) =
            SlicesFill()
            |> SlicesFill.style
                (
                    ?Fill       = Fill,
                    ?Locations  = Locations,
                    ?Show       = Show
                )

    static member style
        (
            ?Fill: float,
            ?Locations: seq<#IConvertible>,
            ?Show: bool
        ) =

            fun (slicesFill: SlicesFill) ->
                
                Fill        |> DynObj.setValueOpt slicesFill "fill"
                Locations   |> DynObj.setValueOpt slicesFill "locations"
                Show        |> DynObj.setValueOpt slicesFill "show"

                slicesFill


type Slices() =
    inherit DynamicObj ()

    static member init
        (
            ?X: SlicesFill,
            ?Y: SlicesFill,
            ?Z: SlicesFill
        ) =

            Slices()
            |> Slices.style
                (
                    ?X  = X,
                    ?Y  = Y,
                    ?Z  = Z
                )
            
    static member style 
        (
            ?X: SlicesFill,
            ?Y: SlicesFill,
            ?Z: SlicesFill
        ) =
            fun (slices: Slices) ->

                X   |> DynObj.setValueOpt slices "x"
                Y   |> DynObj.setValueOpt slices "y"
                Z   |> DynObj.setValueOpt slices "z"

                slices