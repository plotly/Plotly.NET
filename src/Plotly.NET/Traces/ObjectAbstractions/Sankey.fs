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

            Color |> DynObj.setValueOpt sankeyNodes "color"
            CustomData |> DynObj.setValueOpt sankeyNodes "customdata"
            Groups |> DynObj.setValueOpt sankeyNodes "hoverinfo"
            HoverInfo |> DynObj.setValueOptBy sankeyNodes "color" StyleParam.HoverInfo.convert
            HoverLabel |> DynObj.setValueOpt sankeyNodes "hoverlabel"
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt sankeyNodes "hovertemplate"
            Label |> DynObj.setValueOpt sankeyNodes "label"
            Line |> DynObj.setValueOpt sankeyNodes "line"
            Pad |> DynObj.setValueOpt sankeyNodes "pad"
            Thickness |> DynObj.setValueOpt sankeyNodes "thickness"
            X |> DynObj.setValueOpt sankeyNodes "x"
            Y |> DynObj.setValueOpt sankeyNodes "y"

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

            CMax |> DynObj.setValueOpt sankeyLinkColorscale "cmax"
            CMin |> DynObj.setValueOpt sankeyLinkColorscale "cmin"
            ColorScale |> DynObj.setValueOptBy sankeyLinkColorscale "colorscale" StyleParam.Colorscale.convert
            Label |> DynObj.setValueOpt sankeyLinkColorscale "label"
            Name |> DynObj.setValueOpt sankeyLinkColorscale "name"
            TemplateItemName |> DynObj.setValueOpt sankeyLinkColorscale "templateitemname"


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

            ArrowLen |> DynObj.setValueOpt sankeyLinks "arrowlen"
            Color |> DynObj.setValueOpt sankeyLinks "color"
            ColorScales |> DynObj.setValueOpt sankeyLinks "colorscales"
            CustomData |> DynObj.setValueOpt sankeyLinks "customdata"
            HoverInfo |> DynObj.setValueOptBy sankeyLinks "hoverinfo" StyleParam.HoverInfo.convert
            HoverLabel |> DynObj.setValueOpt sankeyLinks "hoverlabel"
            HoverTemplate |> DynObj.setValueOpt sankeyLinks "hovertemplate"
            MultiHoverTemplate |> DynObj.setValueOpt sankeyLinks "multihovertemplate"
            Label |> DynObj.setValueOpt sankeyLinks "label"
            Line |> DynObj.setValueOpt sankeyLinks "line"
            Source |> DynObj.setValueOpt sankeyLinks "source"
            Target |> DynObj.setValueOpt sankeyLinks "target"
            Value |> DynObj.setValueOpt sankeyLinks "value"


            sankeyLinks)
