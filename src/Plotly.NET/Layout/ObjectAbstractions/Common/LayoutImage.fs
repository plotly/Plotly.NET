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
            layoutImage
            |> DynObj.withOptionalPropertyBy "layer" Layer StyleParam.Layer.convert
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "opacity" Opacity
            |> DynObj.withOptionalProperty "sizex" SizeX
            |> DynObj.withOptionalProperty "sizey" SizeY
            |> DynObj.withOptionalPropertyBy "sizing" Sizing StyleParam.LayoutImageSizing.convert
            |> DynObj.withOptionalProperty "source" Source
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemname
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "xref" XRef
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
            |> DynObj.withOptionalProperty "yref" YRef
        )
