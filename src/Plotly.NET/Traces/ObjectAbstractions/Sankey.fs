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
        (fun (sankeyNodes: SankeyNodes) ->

            Color |> DynObj.setOptionalProperty sankeyNodes "color"
            CustomData |> DynObj.setOptionalProperty sankeyNodes "customdata"
            Groups |> DynObj.setOptionalProperty sankeyNodes "hoverinfo"
            HoverInfo |> DynObj.setOptionalPropertyBy sankeyNodes "color" StyleParam.HoverInfo.convert
            HoverLabel |> DynObj.setOptionalProperty sankeyNodes "hoverlabel"
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setOptionalSingleOrMultiProperty sankeyNodes "hovertemplate"
            Label |> DynObj.setOptionalProperty sankeyNodes "label"
            Line |> DynObj.setOptionalProperty sankeyNodes "line"
            Pad |> DynObj.setOptionalProperty sankeyNodes "pad"
            Thickness |> DynObj.setOptionalProperty sankeyNodes "thickness"
            X |> DynObj.setOptionalProperty sankeyNodes "x"
            Y |> DynObj.setOptionalProperty sankeyNodes "y"

            sankeyNodes)

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
        (fun (sankeyLinkColorscale: SankeyLinkColorscale) ->

            CMax |> DynObj.setOptionalProperty sankeyLinkColorscale "cmax"
            CMin |> DynObj.setOptionalProperty sankeyLinkColorscale "cmin"
            ColorScale |> DynObj.setOptionalPropertyBy sankeyLinkColorscale "colorscale" StyleParam.Colorscale.convert
            Label |> DynObj.setOptionalProperty sankeyLinkColorscale "label"
            Name |> DynObj.setOptionalProperty sankeyLinkColorscale "name"
            TemplateItemName |> DynObj.setOptionalProperty sankeyLinkColorscale "templateitemname"


            sankeyLinkColorscale)

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
        (fun (sankeyLinks: SankeyLinks) ->

            ArrowLen |> DynObj.setOptionalProperty sankeyLinks "arrowlen"
            Color |> DynObj.setOptionalProperty sankeyLinks "color"
            ColorScales |> DynObj.setOptionalProperty sankeyLinks "colorscales"
            CustomData |> DynObj.setOptionalProperty sankeyLinks "customdata"
            HoverInfo |> DynObj.setOptionalPropertyBy sankeyLinks "hoverinfo" StyleParam.HoverInfo.convert
            HoverLabel |> DynObj.setOptionalProperty sankeyLinks "hoverlabel"
            HoverTemplate |> DynObj.setOptionalProperty sankeyLinks "hovertemplate"
            MultiHoverTemplate |> DynObj.setOptionalProperty sankeyLinks "multihovertemplate"
            Label |> DynObj.setOptionalProperty sankeyLinks "label"
            Line |> DynObj.setOptionalProperty sankeyLinks "line"
            Source |> DynObj.setOptionalProperty sankeyLinks "source"
            Target |> DynObj.setOptionalProperty sankeyLinks "target"
            Value |> DynObj.setOptionalProperty sankeyLinks "value"


            sankeyLinks)
