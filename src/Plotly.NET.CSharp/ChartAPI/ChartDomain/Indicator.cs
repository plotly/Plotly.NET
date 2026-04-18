using System;
using System.Collections.Generic;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
        /// <summary>
        /// Creates an Indicator chart.
        ///
        /// An indicator is used to visualize a single `value` along with some contextual information such as `steps` or a `threshold`, using a combination of three visual elements: a number, a delta, and/or a gauge.
        /// Deltas are taken with respect to a `reference`.
        /// Gauges can be either angular or bullet (aka linear) gauges.
        /// </summary>
        /// <param name="value">Sets the number to be displayed.</param>
        /// <param name="mode">Determines how the value is displayed on the graph. `number` displays the value numerically in text. `delta` displays the difference to a reference value in text. Finally, `gauge` displays the value graphically on an axis.</param>
        /// <param name="Range">Sets the Range of the Gauge axis</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Title">Sets the title of this trace.</param>
        /// <param name="Domain">Sets the domain of this trace.</param>
        /// <param name="Align">Sets the horizontal alignment of the `text` within the box. Note that this attribute has no effect if an angular gauge is displayed: in this case, it is always centered</param>
        /// <param name="DeltaReference"></param>
        /// <param name="Delta">Sets how the delta to the delta reference is displayed</param>
        /// <param name="Number">Sets the styles of the displayed number</param>
        /// <param name="GaugeShape">Sets the shape of the gauge</param>
        /// <param name="Gauge">Sets the styles of the gauge</param>
        /// <param name="ShowGaugeAxis">Whether or not to show the gauge axis</param>
        /// <param name="GaugeAxis">Sets the gauge axis</param>
        /// <param name="UseDefaults"></param>
        public static GenericChart Indicator<ValueType>(
            ValueType value,
            StyleParam.IndicatorMode mode,
            Optional<StyleParam.Range> Range = default,
            Optional<string> Name = default,
            Optional<string> Title = default,
            Optional<Domain> Domain = default,
            Optional<StyleParam.IndicatorAlignment> Align = default,
            Optional<ValueType> DeltaReference = default,
            Optional<IndicatorDelta> Delta = default,
            Optional<IndicatorNumber> Number = default,
            Optional<StyleParam.IndicatorGaugeShape> GaugeShape = default,
            Optional<IndicatorGauge> Gauge = default,
            Optional<bool> ShowGaugeAxis = default,
            Optional<LinearAxis> GaugeAxis = default,
            Optional<bool> UseDefaults = default
        )
            where ValueType : IConvertible
            =>
                Plotly.NET.ChartDomain_Table.Chart.Indicator<ValueType>(
                    value: value,
                    mode: mode,
                    Range: Range.ToOption(),
                    Name: Name.ToOption(),
                    Title: Title.ToOption(),
                    Domain: Domain.ToOption(),
                    Align: Align.ToOption(),
                    DeltaReference: DeltaReference.ToOption(),
                    Delta: Delta.ToOption(),
                    Number: Number.ToOption(),
                    GaugeShape: GaugeShape.ToOption(),
                    Gauge: Gauge.ToOption(),
                    ShowGaugeAxis: ShowGaugeAxis.ToOption(),
                    GaugeAxis: GaugeAxis.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
