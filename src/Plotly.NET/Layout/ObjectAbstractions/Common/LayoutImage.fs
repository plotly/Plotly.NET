namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type LayoutImage() =
    inherit DynamicObj()

    static member init
        (
            ?Layer: StyleParam.Layer,
            ?Name: string,
            ?Opacity: float,
            ?SizeX: int,
            ?SizeY: int,
            ?Sizing: StyleParam.LayoutImageSizing,
            ?Source: string,
            ?TemplateItemname: string,
            ?Visible: bool,
            ?X: #IConvertible,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: #IConvertible,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string
        ) =
        LayoutImage()
        |> LayoutImage.style (
            ?Layer = Layer,
            ?Name = Name,
            ?Opacity = Opacity,
            ?SizeX = SizeX,
            ?SizeY = SizeY,
            ?Sizing = Sizing,
            ?Source = Source,
            ?TemplateItemname = TemplateItemname,
            ?Visible = Visible,
            ?X = X,
            ?XAnchor = XAnchor,
            ?XRef = XRef,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?YRef = YRef
        )

    static member style
        (
            ?Layer: StyleParam.Layer,
            ?Name: string,
            ?Opacity: float,
            ?SizeX: int,
            ?SizeY: int,
            ?Sizing: StyleParam.LayoutImageSizing,
            ?Source: string,
            ?TemplateItemname: string,
            ?Visible: bool,
            ?X: #IConvertible,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: #IConvertible,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string
        ) =
        (fun (layoutImage: LayoutImage) ->

            Layer |> DynObj.setValueOptBy layoutImage "layer" StyleParam.Layer.convert
            ++? ("name", Name )
            ++? ("opacity", Opacity )
            ++? ("sizex", SizeX )
            ++? ("sizey", SizeY )
            Sizing |> DynObj.setValueOptBy layoutImage "sizing" StyleParam.LayoutImageSizing.convert
            ++? ("source", Source )
            ++? ("templateitemname", TemplateItemname )
            ++? ("visible", Visible )
            ++? ("x", X )
            XAnchor |> DynObj.setValueOptBy layoutImage "xanchor" StyleParam.XAnchorPosition.convert
            ++? ("xref", XRef )
            ++? ("y", Y )
            YAnchor |> DynObj.setValueOptBy layoutImage "yanchor" StyleParam.YAnchorPosition.convert
            ++? ("yref", YRef )

            layoutImage)
