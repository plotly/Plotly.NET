﻿namespace Plotly.NET.ConfigObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type ToImageButtonOptions() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Format: StyleParam.ImageFormat,
            [<Optional; DefaultParameterValue(null)>] ?Filename: string,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?Height: float,
            [<Optional; DefaultParameterValue(null)>] ?Scale: float
        ) =
        ToImageButtonOptions()
        |> ToImageButtonOptions.style (
            ?Format = Format,
            ?Filename = Filename,
            ?Width = Width,
            ?Height = Height,
            ?Scale = Scale
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Format,
            [<Optional; DefaultParameterValue(null)>] ?Filename,
            [<Optional; DefaultParameterValue(null)>] ?Width,
            [<Optional; DefaultParameterValue(null)>] ?Height,
            [<Optional; DefaultParameterValue(null)>] ?Scale
        ) =
        fun (btnConf: ToImageButtonOptions) ->
            btnConf
            |> DynObj.withOptionalPropertyBy "format"    Format      StyleParam.ImageFormat.toString
            |> DynObj.withOptionalProperty   "filename"  Filename    
            |> DynObj.withOptionalProperty   "width"     Width       
            |> DynObj.withOptionalProperty   "height"    Height      
            |> DynObj.withOptionalProperty   "scale"     Scale       
