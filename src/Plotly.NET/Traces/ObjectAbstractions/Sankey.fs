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

            ++? ("color", Color )
            ++? ("customdata", CustomData )
            ++? ("hoverinfo", Groups )
            HoverInfo |> DynObj.setValueOptBy sankeyNodes "color" StyleParam.HoverInfo.convert
            ++? ("hoverlabel", HoverLabel )
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt sankeyNodes "hovertemplate"
            ++? ("label", Label )
            ++? ("line", Line )
            ++? ("pad", Pad )
            ++? ("thickness", Thickness )
            ++? ("x", X )
            ++? ("y", Y )

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

            ++? ("cmax", CMax )
            ++? ("cmin", CMin )
            ColorScale |> DynObj.setValueOptBy sankeyLinkColorscale "colorscale" StyleParam.Colorscale.convert
            ++? ("label", Label )
            ++? ("name", Name )
            ++? ("templateitemname", TemplateItemName )


            sankeyLinkColorscale)

type SankeyLinks() =
    inherit DynamicObj()

    static member init
        (
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

            ++? ("color", Color )
            ++? ("colorscales", ColorScales )
            ++? ("customdata", CustomData )
            HoverInfo |> DynObj.setValueOptBy sankeyLinks "hoverinfo" StyleParam.HoverInfo.convert
            ++? ("hoverlabel", HoverLabel )
            ++? ("hovertemplate", HoverTemplate )
            ++? ("multihovertemplate", MultiHoverTemplate )
            ++? ("label", Label )
            ++? ("line", Line )
            ++? ("source", Source )
            ++? ("target", Target )
            ++? ("value", Value )


            sankeyLinks)
