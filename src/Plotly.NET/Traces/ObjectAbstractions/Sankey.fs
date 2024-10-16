namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type SankeyNodes() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Groups: seq<#seq<int>>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Label: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Pad: int,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: int,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>
        ) =

        SankeyNodes()
        |> SankeyNodes.style (
            ?Color = Color,
            ?CustomData = CustomData,
            ?Groups = Groups,
            ?HoverInfo = HoverInfo,
            ?HoverLabel = HoverLabel,
            ?HoverTemplate = HoverTemplate,
            ?MultiHoverTemplate = MultiHoverTemplate,
            ?Label = Label,
            ?Line = Line,
            ?Pad = Pad,
            ?Thickness = Thickness,
            ?X = X,
            ?Y = Y

        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Groups: seq<#seq<int>>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Label: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Pad: int,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: int,
            [<Optional; DefaultParameterValue(null)>] ?X: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Y: seq<#IConvertible>
        ) =
        fun (sankeyNodes: SankeyNodes) ->
            sankeyNodes
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "customdata" CustomData
            |> DynObj.withOptionalProperty "groups" Groups
            |> DynObj.withOptionalPropertyBy "hoverinfo" HoverInfo StyleParam.HoverInfo.convert
            |> DynObj.withOptionalProperty "hoverlabel" HoverLabel
            |> DynObj.withOptionalSingleOrMultiProperty "hovertemplate" (HoverTemplate, MultiHoverTemplate)
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "pad" Pad
            |> DynObj.withOptionalProperty "thickness" Thickness
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y

type SankeyLinkColorscale() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?Label: string,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string
        ) =

        SankeyLinkColorscale()
        |> SankeyLinkColorscale.style (
            ?CMax = CMax,
            ?CMin = CMin,
            ?ColorScale = ColorScale,
            ?Label = Label,
            ?Name = Name,
            ?TemplateItemName = TemplateItemName

        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?Label: string,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string
        ) =
        fun (sankeyLinkColorscale: SankeyLinkColorscale) ->

            sankeyLinkColorscale
            |> DynObj.withOptionalProperty "cmax" CMax
            |> DynObj.withOptionalProperty "cmin" CMin
            |> DynObj.withOptionalPropertyBy "colorscale" ColorScale StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName

type SankeyLinks() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?ArrowLen: int,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?ColorScales: seq<SankeyLinkColorscale>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Label: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Source: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?Target: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?Value: seq<#IConvertible>
        ) =

        SankeyLinks()
        |> SankeyLinks.style (
            ?ArrowLen = ArrowLen,
            ?Color = Color,
            ?ColorScales = ColorScales,
            ?CustomData = CustomData,
            ?HoverInfo = HoverInfo,
            ?HoverLabel = HoverLabel,
            ?HoverTemplate = HoverTemplate,
            ?MultiHoverTemplate = MultiHoverTemplate,
            ?Label = Label,
            ?Line = Line,
            ?Source = Source,
            ?Target = Target,
            ?Value = Value

        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?ArrowLen: int,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?ColorScales: seq<SankeyLinkColorscale>,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Label: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Source: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?Target: seq<int>,
            [<Optional; DefaultParameterValue(null)>] ?Value: seq<#IConvertible>
        ) =
        fun (sankeyLinks: SankeyLinks) ->

            sankeyLinks
            |> DynObj.withOptionalProperty "arrowlen" ArrowLen
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "colorscales" ColorScales
            |> DynObj.withOptionalProperty "customdata" CustomData
            |> DynObj.withOptionalPropertyBy "hoverinfo" HoverInfo StyleParam.HoverInfo.convert
            |> DynObj.withOptionalProperty "hoverlabel" HoverLabel
            |> DynObj.withOptionalSingleOrMultiProperty "hovertemplate" (HoverTemplate, MultiHoverTemplate)
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "source" Source
            |> DynObj.withOptionalProperty "target" Target
            |> DynObj.withOptionalProperty "value" Value

