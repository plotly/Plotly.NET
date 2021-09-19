namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type LayoutImage () =
    inherit DynamicObj ()

    static member init
        (
            ?Layer              : StyleParam.Layer,
            ?Name               : string,
            ?Opacity            : float,
            ?SizeX              : int,
            ?SizeY              : int,
            ?Sizing             : StyleParam.LayoutImageSizing,
            ?Source             : string,
            ?TemplateItemname   : string,
            ?Visible            : bool,
            ?X                  : #IConvertible,
            ?XAnchor            : StyleParam.XAnchorPosition,
            ?XRef               : string,            
            ?Y                  : #IConvertible,
            ?YAnchor            : StyleParam.YAnchorPosition,
            ?YRef               : string
        ) =
            LayoutImage () 
            |> LayoutImage.style
                (
                    ?Layer              = Layer           ,
                    ?Name               = Name            ,
                    ?Opacity            = Opacity         ,
                    ?SizeX              = SizeX           ,
                    ?SizeY              = SizeY           ,
                    ?Sizing             = Sizing          ,
                    ?Source             = Source          ,
                    ?TemplateItemname   = TemplateItemname,
                    ?Visible            = Visible         ,
                    ?X                  = X               ,
                    ?XAnchor            = XAnchor          ,
                    ?XRef               = XRef            ,
                    ?Y                  = Y               ,
                    ?YAnchor            = YAnchor          ,
                    ?YRef               = YRef            
                )

    static member style
        (
            ?Layer              : StyleParam.Layer,
            ?Name               : string,
            ?Opacity            : float,
            ?SizeX              : int,
            ?SizeY              : int,
            ?Sizing             : StyleParam.LayoutImageSizing,
            ?Source             : string,
            ?TemplateItemname   : string,
            ?Visible            : bool,
            ?X                  : #IConvertible,
            ?XAnchor            : StyleParam.XAnchorPosition,
            ?XRef               : string,            
            ?Y                  : #IConvertible,
            ?YAnchor            : StyleParam.YAnchorPosition,
            ?YRef               : string
        ) =
            (fun (layoutImage:LayoutImage) -> 
                
                Layer            |> DynObj.setValueOptBy layoutImage "layer" StyleParam.Layer.convert
                Name             |> DynObj.setValueOpt layoutImage "name"
                Opacity          |> DynObj.setValueOpt layoutImage "opacity"
                SizeX            |> DynObj.setValueOpt layoutImage "sizex"
                SizeY            |> DynObj.setValueOpt layoutImage "sizey"
                Sizing           |> DynObj.setValueOptBy layoutImage "sizing" StyleParam.LayoutImageSizing.convert
                Source           |> DynObj.setValueOpt layoutImage "source"
                TemplateItemname |> DynObj.setValueOpt layoutImage "templateitemname"
                Visible          |> DynObj.setValueOpt layoutImage "visible"
                X                |> DynObj.setValueOpt layoutImage "x"
                XAnchor          |> DynObj.setValueOptBy layoutImage "xanchor" StyleParam.XAnchorPosition.convert
                XRef             |> DynObj.setValueOpt layoutImage "xref"
                Y                |> DynObj.setValueOpt layoutImage "y"
                YAnchor          |> DynObj.setValueOptBy layoutImage "yanchor" StyleParam.YAnchorPosition.convert
                YRef             |> DynObj.setValueOpt layoutImage "yref"

                layoutImage
            )