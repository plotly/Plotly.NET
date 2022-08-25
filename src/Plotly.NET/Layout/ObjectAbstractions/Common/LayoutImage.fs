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
            [<Optional; DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?SizeX: int,
            [<Optional; DefaultParameterValue(null)>] ?SizeY: int,
            [<Optional; DefaultParameterValue(null)>] ?Sizing: StyleParam.LayoutImageSizing,
            [<Optional; DefaultParameterValue(null)>] ?Source: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemname: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?X: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?XRef: string,
            [<Optional; DefaultParameterValue(null)>] ?Y: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?YRef: string
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
            [<Optional; DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?SizeX: int,
            [<Optional; DefaultParameterValue(null)>] ?SizeY: int,
            [<Optional; DefaultParameterValue(null)>] ?Sizing: StyleParam.LayoutImageSizing,
            [<Optional; DefaultParameterValue(null)>] ?Source: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemname: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?X: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?XRef: string,
            [<Optional; DefaultParameterValue(null)>] ?Y: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?YRef: string
        ) =
        (fun (layoutImage: LayoutImage) ->

            Layer |> DynObj.setValueOptBy layoutImage "layer" StyleParam.Layer.convert
            Name |> DynObj.setValueOpt layoutImage "name"
            Opacity |> DynObj.setValueOpt layoutImage "opacity"
            SizeX |> DynObj.setValueOpt layoutImage "sizex"
            SizeY |> DynObj.setValueOpt layoutImage "sizey"
            Sizing |> DynObj.setValueOptBy layoutImage "sizing" StyleParam.LayoutImageSizing.convert
            Source |> DynObj.setValueOpt layoutImage "source"
            TemplateItemname |> DynObj.setValueOpt layoutImage "templateitemname"
            Visible |> DynObj.setValueOpt layoutImage "visible"
            X |> DynObj.setValueOpt layoutImage "x"
            XAnchor |> DynObj.setValueOptBy layoutImage "xanchor" StyleParam.XAnchorPosition.convert
            XRef |> DynObj.setValueOpt layoutImage "xref"
            Y |> DynObj.setValueOpt layoutImage "y"
            YAnchor |> DynObj.setValueOptBy layoutImage "yanchor" StyleParam.YAnchorPosition.convert
            YRef |> DynObj.setValueOpt layoutImage "yref"

            layoutImage)
