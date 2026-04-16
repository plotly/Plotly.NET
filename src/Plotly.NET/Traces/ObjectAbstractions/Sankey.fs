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
            ?Align: StyleParam.SankeyNodeAlign,
            ?Color: Color,
            ?ColorEncoded: EncodedTypedArray,
            ?CustomData: seq<#IConvertible>,
            ?CustomDataEncoded: EncodedTypedArray,
            ?Groups: seq<#seq<int>>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverLabel: Hoverlabel,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Label: seq<string>,
            ?Line: Line,
            ?Pad: int,
            ?Thickness: int,
            ?X: seq<#IConvertible>,
            ?XEncoded: EncodedTypedArray,
            ?Y: seq<#IConvertible>,
            ?YEncoded: EncodedTypedArray
        ) =

        SankeyNodes()
        |> SankeyNodes.style (
            ?Align = Align,
            ?Color = Color,
            ?ColorEncoded = ColorEncoded,
            ?CustomData = CustomData,
            ?CustomDataEncoded = CustomDataEncoded,
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
            ?XEncoded = XEncoded,
            ?Y = Y,
            ?YEncoded = YEncoded
        )

    static member style
        (
            ?Align: StyleParam.SankeyNodeAlign,
            ?Color: Color,
            ?ColorEncoded: EncodedTypedArray,
            ?CustomData: seq<#IConvertible>,
            ?CustomDataEncoded: EncodedTypedArray,
            ?Groups: seq<#seq<int>>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverLabel: Hoverlabel,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Label: seq<string>,
            ?Line: Line,
            ?Pad: int,
            ?Thickness: int,
            ?X: seq<#IConvertible>,
            ?XEncoded: EncodedTypedArray,
            ?Y: seq<#IConvertible>,
            ?YEncoded: EncodedTypedArray
        ) =
        fun (sankeyNodes: SankeyNodes) ->
            sankeyNodes
            |> DynObj.withOptionalPropertyBy "align" Align StyleParam.SankeyNodeAlign.convert
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "color" ColorEncoded
            |> DynObj.withOptionalProperty "customdata" CustomData
            |> DynObj.withOptionalProperty "customdata" CustomDataEncoded
            |> DynObj.withOptionalProperty "groups" Groups
            |> DynObj.withOptionalPropertyBy "hoverinfo" HoverInfo StyleParam.HoverInfo.convert
            |> DynObj.withOptionalProperty "hoverlabel" HoverLabel
            |> DynObj.withOptionalSingleOrMultiProperty "hovertemplate" (HoverTemplate, MultiHoverTemplate)
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "pad" Pad
            |> DynObj.withOptionalProperty "thickness" Thickness
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "x" XEncoded
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalProperty "y" YEncoded

type SankeyLinkColorscale() =
    inherit DynamicObj()

    static member init
        (
            ?CMax: float,
            ?CMin: float,
            ?ColorScale: StyleParam.Colorscale,
            ?Label: string,
            ?Name: string,
            ?TemplateItemName: string
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
            ?CMax: float,
            ?CMin: float,
            ?ColorScale: StyleParam.Colorscale,
            ?Label: string,
            ?Name: string,
            ?TemplateItemName: string
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
            ?ArrowLen: int,
            ?Color: Color,
            ?ColorEncoded: EncodedTypedArray,
            ?ColorScales: seq<SankeyLinkColorscale>,
            ?CustomData: seq<#IConvertible>,
            ?CustomDataEncoded: EncodedTypedArray,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverLabel: Hoverlabel,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Label: seq<string>,
            ?Line: Line,
            ?Source: seq<int>,
            ?SourceEncoded: EncodedTypedArray,
            ?Target: seq<int>,
            ?TargetEncoded: EncodedTypedArray,
            ?Value: seq<#IConvertible>,
            ?ValueEncoded: EncodedTypedArray
        ) =

        SankeyLinks()
        |> SankeyLinks.style (
            ?ArrowLen = ArrowLen,
            ?Color = Color,
            ?ColorEncoded = ColorEncoded,
            ?ColorScales = ColorScales,
            ?CustomData = CustomData,
            ?CustomDataEncoded = CustomDataEncoded,
            ?HoverInfo = HoverInfo,
            ?HoverLabel = HoverLabel,
            ?HoverTemplate = HoverTemplate,
            ?MultiHoverTemplate = MultiHoverTemplate,
            ?Label = Label,
            ?Line = Line,
            ?Source = Source,
            ?SourceEncoded = SourceEncoded,
            ?Target = Target,
            ?TargetEncoded = TargetEncoded,
            ?Value = Value,
            ?ValueEncoded = ValueEncoded
        )

    static member style
        (
            ?ArrowLen: int,
            ?Color: Color,
            ?ColorEncoded: EncodedTypedArray,
            ?ColorScales: seq<SankeyLinkColorscale>,
            ?CustomData: seq<#IConvertible>,
            ?CustomDataEncoded: EncodedTypedArray,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverLabel: Hoverlabel,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Label: seq<string>,
            ?Line: Line,
            ?Source: seq<int>,
            ?SourceEncoded: EncodedTypedArray,
            ?Target: seq<int>,
            ?TargetEncoded: EncodedTypedArray,
            ?Value: seq<#IConvertible>,
            ?ValueEncoded: EncodedTypedArray
        ) =
        fun (sankeyLinks: SankeyLinks) ->

            sankeyLinks
            |> DynObj.withOptionalProperty "arrowlen" ArrowLen
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "color" ColorEncoded
            |> DynObj.withOptionalProperty "colorscales" ColorScales
            |> DynObj.withOptionalProperty "customdata" CustomData
            |> DynObj.withOptionalProperty "customdata" CustomDataEncoded
            |> DynObj.withOptionalPropertyBy "hoverinfo" HoverInfo StyleParam.HoverInfo.convert
            |> DynObj.withOptionalProperty "hoverlabel" HoverLabel
            |> DynObj.withOptionalSingleOrMultiProperty "hovertemplate" (HoverTemplate, MultiHoverTemplate)
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "source" Source
            |> DynObj.withOptionalProperty "source" SourceEncoded
            |> DynObj.withOptionalProperty "target" Target
            |> DynObj.withOptionalProperty "target" TargetEncoded
            |> DynObj.withOptionalProperty "value" Value
            |> DynObj.withOptionalProperty "value" ValueEncoded

