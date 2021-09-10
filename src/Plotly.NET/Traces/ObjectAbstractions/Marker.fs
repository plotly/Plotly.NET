namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Marker type inherits from dynamic object
type Marker () =
    inherit ImmutableDynamicObj ()

    /// Initialized Marker object
    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?Size,
            [<Optional;DefaultParameterValue(null)>] ?Opacity,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Symbol,
            [<Optional;DefaultParameterValue(null)>] ?MultiSizes,
            [<Optional;DefaultParameterValue(null)>] ?Line,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            //[<Optional;DefaultParameterValue(null)>] ?Colors: seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor,
            [<Optional;DefaultParameterValue(null)>] ?Maxdisplayed,
            [<Optional;DefaultParameterValue(null)>] ?Sizeref,
            [<Optional;DefaultParameterValue(null)>] ?Sizemin,
            [<Optional;DefaultParameterValue(null)>] ?Sizemode,
            [<Optional;DefaultParameterValue(null)>] ?Cauto,
            [<Optional;DefaultParameterValue(null)>] ?Cmax,
            [<Optional;DefaultParameterValue(null)>] ?Cmin,
            [<Optional;DefaultParameterValue(null)>] ?Cmid,
            [<Optional;DefaultParameterValue(null)>] ?Autocolorscale,
            [<Optional;DefaultParameterValue(null)>] ?Reversescale,
            [<Optional;DefaultParameterValue(null)>] ?Showscale

        ) =
        Marker () 
        |> Marker.style
            (
                ?Size          = Size           ,
                ?Color         = Color          ,
                ?Symbol        = Symbol         ,
                ?Opacity       = Opacity        ,
                ?MultiSizes    = MultiSizes     ,
                ?Line          = Line           ,
                ?ColorBar      = ColorBar       ,
                ?Colorscale    = Colorscale     ,
                //?Colors        = Colors         ,
                ?OutlierColor  = OutlierColor   ,
                                        
                ?Maxdisplayed  = Maxdisplayed   ,
                ?Sizeref       = Sizeref        ,
                ?Sizemin       = Sizemin        ,
                ?Sizemode      = Sizemode       ,
                ?Cauto         = Cauto          ,
                ?Cmax          = Cmax           ,
                ?Cmid          = Cmid           ,
                ?Cmin          = Cmin           ,
                ?Autocolorscale= Autocolorscale ,
                ?Reversescale  = Reversescale   ,
                ?Showscale     = Showscale      

            )

    // Applies the styles to Marker()
    static member style
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
            (fun (marker: Marker) -> 
                Size           |> DynObj.setValueOpt marker "size" 
                Color          |> DynObj.setValueOpt marker "color"
                Symbol         |> DynObj.setValueOpt marker "symbol"
                Opacity        |> DynObj.setValueOpt marker "opacity"
                MultiSizes     |> DynObj.setValueOpt marker "size"
                Line           |> DynObj.setValueOpt marker "line"        
                ColorBar       |> DynObj.setValueOpt marker "colorbar"       
                Colorscale     |> DynObj.setValueOptBy marker "colorscale" StyleParam.Colorscale.convert
                //Colors         |> DynObj.setValueOpt marker "colors"     
                OutlierColor   |> DynObj.setValueOpt marker "outliercolor"     
                Maxdisplayed   |> DynObj.setValueOpt marker "maxdisplayed"   
                Sizeref        |> DynObj.setValueOpt marker "sizeref"        
                Sizemin        |> DynObj.setValueOpt marker "sizemin"        
                Sizemode       |> DynObj.setValueOptBy marker "sizemode" StyleParam.MarkerSizeMode.convert
                Cauto          |> DynObj.setValueOpt marker "cauto"          
                Cmax           |> DynObj.setValueOpt marker "cmax"           
                Cmid           |> DynObj.setValueOpt marker "cmid"           
                Cmin           |> DynObj.setValueOpt marker "cmin"           
                Autocolorscale |> DynObj.setValueOpt marker "autocolorscale" 
                Reversescale   |> DynObj.setValueOpt marker "reversescale"   
                Showscale      |> DynObj.setValueOpt marker "showscale"      

                marker
            )



