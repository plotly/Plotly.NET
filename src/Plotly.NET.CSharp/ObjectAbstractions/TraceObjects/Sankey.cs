
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.SankeyNodes SankeyNodes
        (

            Optional<Color> Color = default,
            Optional<IEnumerable<#IConvertible>> CustomData = default,
            Optional<IEnumerable<#IEnumerable<int>>> Groups = default,
            Optional<StyleParam.HoverInfo> HoverInfo = default,
            Optional<Hoverlabel> HoverLabel = default,
            Optional<string> HoverTemplate = default,
            Optional<IEnumerable<string>> MultiHoverTemplate = default,
            Optional<IEnumerable<string>> Label = default,
            Optional<Line> Line = default,
            Optional<int> Pad = default,
            Optional<int> Thickness = default,
            Optional<IEnumerable<#IConvertible>> X = default,
            Optional<IEnumerable<#IConvertible>> Y = default
        ) => 
            Plotly.NET.TraceObjects.SankeyNodes.init(

                Color: Color.ToOption(),
                CustomData: CustomData.ToOption(),
                Groups: Groups.ToOption(),
                HoverInfo: HoverInfo.ToOption(),
                HoverLabel: HoverLabel.ToOption(),
                HoverTemplate: HoverTemplate.ToOption(),
                MultiHoverTemplate: MultiHoverTemplate.ToOption(),
                Label: Label.ToOption(),
                Line: Line.ToOption(),
                Pad: Pad.ToOption(),
                Thickness: Thickness.ToOption(),
                X: X.ToOption(),
                Y: Y.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.SankeyLinkColorscale SankeyLinkColorscale
        (

            Optional<double> CMax = default,
            Optional<double> CMin = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<string> Label = default,
            Optional<string> Name = default,
            Optional<string> TemplateItemName = default
        ) => 
            Plotly.NET.TraceObjects.SankeyLinkColorscale.init(

                CMax: CMax.ToOption(),
                CMin: CMin.ToOption(),
                ColorScale: ColorScale.ToOption(),
                Label: Label.ToOption(),
                Name: Name.ToOption(),
                TemplateItemName: TemplateItemName.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.SankeyLinks SankeyLinks
        (

            Optional<Color> Color = default,
            Optional<IEnumerable<SankeyLinkColorscale>> ColorScales = default,
            Optional<IEnumerable<#IConvertible>> CustomData = default,
            Optional<StyleParam.HoverInfo> HoverInfo = default,
            Optional<Hoverlabel> HoverLabel = default,
            Optional<string> HoverTemplate = default,
            Optional<IEnumerable<string>> MultiHoverTemplate = default,
            Optional<IEnumerable<string>> Label = default,
            Optional<Line> Line = default,
            Optional<IEnumerable<int>> Source = default,
            Optional<IEnumerable<int>> Target = default,
            Optional<IEnumerable<#IConvertible>> Value = default
        ) => 
            Plotly.NET.TraceObjects.SankeyLinks.init(

                Color: Color.ToOption(),
                ColorScales: ColorScales.ToOption(),
                CustomData: CustomData.ToOption(),
                HoverInfo: HoverInfo.ToOption(),
                HoverLabel: HoverLabel.ToOption(),
                HoverTemplate: HoverTemplate.ToOption(),
                MultiHoverTemplate: MultiHoverTemplate.ToOption(),
                Label: Label.ToOption(),
                Line: Line.ToOption(),
                Source: Source.ToOption(),
                Target: Target.ToOption(),
                Value: Value.ToOption()
            );
}

