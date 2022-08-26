
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.SankeyNodes InitSankeyNodes<CustomDataType, XType, YType>
        (
            Optional<Color> Color = default,
            Optional<IEnumerable<CustomDataType>> CustomData = default,
            Optional<IEnumerable<IEnumerable<int>>> Groups = default,
            Optional<StyleParam.HoverInfo> HoverInfo = default,
            Optional<Plotly.NET.LayoutObjects.Hoverlabel> HoverLabel = default,
            Optional<string> HoverTemplate = default,
            Optional<IEnumerable<string>> MultiHoverTemplate = default,
            Optional<IEnumerable<string>> Label = default,
            Optional<Line> Line = default,
            Optional<int> Pad = default,
            Optional<int> Thickness = default,
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<YType>> Y = default
        ) 
            where CustomDataType: IConvertible
            where XType: IConvertible
            where YType: IConvertible
            =>
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
    public static Plotly.NET.TraceObjects.SankeyLinkColorscale InitSankeyLinkColorscale
        (
            Optional<double> CMax = default,
            Optional<double> CMin = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<string> Label = default,
            Optional<string> Name = default,
            Optional<string> TemplateItemName = default
        ) 
            =>
                Plotly.NET.TraceObjects.SankeyLinkColorscale.init(
                    CMax: CMax.ToOption(),
                    CMin: CMin.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    Label: Label.ToOption(),
                    Name: Name.ToOption(),
                    TemplateItemName: TemplateItemName.ToOption()
                );
    public static Plotly.NET.TraceObjects.SankeyLinks InitSankeyLinks<CustomDataType, ValueType>
        (
            Optional<Color> Color = default,
            Optional<IEnumerable<Plotly.NET.TraceObjects.SankeyLinkColorscale>> ColorScales = default,
            Optional<IEnumerable<CustomDataType>> CustomData = default,
            Optional<StyleParam.HoverInfo> HoverInfo = default,
            Optional<Plotly.NET.LayoutObjects.Hoverlabel> HoverLabel = default,
            Optional<string> HoverTemplate = default,
            Optional<IEnumerable<string>> MultiHoverTemplate = default,
            Optional<IEnumerable<string>> Label = default,
            Optional<Line> Line = default,
            Optional<IEnumerable<int>> Source = default,
            Optional<IEnumerable<int>> Target = default,
            Optional<IEnumerable<ValueType>> Value = default
        ) 
            where CustomDataType: IConvertible
            where ValueType: IConvertible
            =>
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

