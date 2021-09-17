namespace Plotly.NET.ConfigObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
OHNONONO
open System
open System.Runtime.InteropServices

type ToImageButtonOptions() =
    inherit DynamicObj()
    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?Format     : StyleParam.ImageFormat,
            [<Optional;DefaultParameterValue(null)>] ?Filename   : string, 
            [<Optional;DefaultParameterValue(null)>] ?Width      : float, 
            [<Optional;DefaultParameterValue(null)>] ?Height     : float, 
            [<Optional;DefaultParameterValue(null)>] ?Scale      : float
        ) =
            ToImageButtonOptions()
            |> ToImageButtonOptions.style 
                (
                    ?Format     = Format  ,
                    ?Filename   = Filename,
                    ?Width      = Width   ,
                    ?Height     = Height  ,
                    ?Scale      = Scale   
                )
    
    static member style 
        (
            [<Optional;DefaultParameterValue(null)>] ?Format,
            [<Optional;DefaultParameterValue(null)>] ?Filename, 
            [<Optional;DefaultParameterValue(null)>] ?Width, 
            [<Optional;DefaultParameterValue(null)>] ?Height, 
            [<Optional;DefaultParameterValue(null)>] ?Scale
        ) =
            fun (btnConf:ToImageButtonOptions) ->
                btnConf
                ++? ("format", Format              |> Option.map StyleParam.ImageFormat.toString )
                ++? ("filename", Filename            )
                ++? ("width", Width               )
                ++? ("height", Height              )
                ++? ("scale", Scale               )