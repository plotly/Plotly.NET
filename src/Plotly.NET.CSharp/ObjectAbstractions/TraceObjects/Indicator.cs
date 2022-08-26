
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.IndicatorSymbol InitIndicatorSymbol
        (
            Optional<Color> Color = default,
            Optional<string> Symbol = default
        ) 
            =>
                Plotly.NET.TraceObjects.IndicatorSymbol.init(
                    Color: Color.ToOption(),
                    Symbol: Symbol.ToOption()
                );
    public static Plotly.NET.TraceObjects.IndicatorDelta InitIndicatorDelta<ReferenceType>
        (
            Optional<Plotly.NET.TraceObjects.IndicatorSymbol> Decreasing = default,
            Optional<Font> Font = default,
            Optional<Plotly.NET.TraceObjects.IndicatorSymbol> Increasing = default,
            Optional<StyleParam.IndicatorDeltaPosition> Position = default,
            Optional<ReferenceType> Reference = default,
            Optional<bool> Relative = default,
            Optional<string> ValueFormat = default
        ) 
            where ReferenceType: IConvertible
            =>
                Plotly.NET.TraceObjects.IndicatorDelta.init(
                    Decreasing: Decreasing.ToOption(),
                    Font: Font.ToOption(),
                    Increasing: Increasing.ToOption(),
                    Position: Position.ToOption(),
                    Reference: Reference.ToOption(),
                    Relative: Relative.ToOption(),
                    ValueFormat: ValueFormat.ToOption()
                );
    public static Plotly.NET.TraceObjects.IndicatorNumber InitIndicatorNumber
        (
            Optional<Font> Font = default,
            Optional<string> Prefix = default,
            Optional<string> Suffix = default,
            Optional<string> ValueFormat = default
        ) 

            =>
                Plotly.NET.TraceObjects.IndicatorNumber.init(
                    Font: Font.ToOption(),
                    Prefix: Prefix.ToOption(),
                    Suffix: Suffix.ToOption(),
                    ValueFormat: ValueFormat.ToOption()
                );
    public static Plotly.NET.TraceObjects.IndicatorBar InitIndicatorBar
        (
            Optional<Color> Color = default,
            Optional<Line> Line = default,
            Optional<double> Thickness = default
        ) 
            =>
                Plotly.NET.TraceObjects.IndicatorBar.init(
                    Color: Color.ToOption(),
                    Line: Line.ToOption(),
                    Thickness: Thickness.ToOption()
                );
    public static Plotly.NET.TraceObjects.IndicatorStep InitIndicatorStep
        (
            Optional<Color> Color = default,
            Optional<Line> Line = default,
            Optional<string> Name = default,
            Optional<StyleParam.Range> Range = default,
            Optional<string> TemplateItemName = default,
            Optional<double> Thickness = default
        ) 
            =>
                Plotly.NET.TraceObjects.IndicatorStep.init(
                    Color: Color.ToOption(),
                    Line: Line.ToOption(),
                    Name: Name.ToOption(),
                    Range: Range.ToOption(),
                    TemplateItemName: TemplateItemName.ToOption(),
                    Thickness: Thickness.ToOption()
                );
    public static Plotly.NET.TraceObjects.IndicatorThreshold InitIndicatorThreshold<ValueType>
        (
            Optional<Line> Line = default,
            Optional<double> Thickness = default,
            Optional<ValueType> Value = default
        ) 
            where ValueType: IConvertible
            =>
                Plotly.NET.TraceObjects.IndicatorThreshold.init(
                    Line: Line.ToOption(),
                    Thickness: Thickness.ToOption(),
                    Value: Value.ToOption()
                );
    public static Plotly.NET.TraceObjects.IndicatorGauge InitIndicatorGauge
        (
            Optional<Plotly.NET.LayoutObjects.LinearAxis> Axis = default,
            Optional<Plotly.NET.TraceObjects.IndicatorBar> Bar = default,
            Optional<Color> BGColor = default,
            Optional<Color> BorderColor = default,
            Optional<int> BorderWidth = default,
            Optional<StyleParam.IndicatorGaugeShape> Shape = default,
            Optional<IEnumerable<Plotly.NET.TraceObjects.IndicatorStep>> Steps = default,
            Optional<Plotly.NET.TraceObjects.IndicatorThreshold> Threshold = default
        ) 
            =>
            Plotly.NET.TraceObjects.IndicatorGauge.init(
                Axis: Axis.ToOption(),
                Bar: Bar.ToOption(),
                BGColor: BGColor.ToOption(),
                BorderColor: BorderColor.ToOption(),
                BorderWidth: BorderWidth.ToOption(),
                Shape: Shape.ToOption(),
                Steps: Steps.ToOption(),
                Threshold: Threshold.ToOption()
            );
}

