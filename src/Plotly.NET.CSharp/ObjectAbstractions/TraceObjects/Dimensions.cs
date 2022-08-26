
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Dimension InitParallelDimension<LabelType, TickType, ValuesType>
        (
            Optional<StyleParam.Range> ConstraintRange = default,
            Optional<LabelType> Label = default,
            Optional<bool> MultiSelect = default,
            Optional<string> Name = default,
            Optional<StyleParam.Range> Range = default,
            Optional<string> TemplateItemName = default,
            Optional<StyleParam.TickMode> TickFormat = default,
            Optional<IEnumerable<TickType>> TickText = default,
            Optional<IEnumerable<TickType>> Tickvals = default,
            Optional<IEnumerable<ValuesType>> Values = default,
            Optional<bool> Visible = default
        ) 
            where LabelType : IConvertible
            where TickType : IConvertible
            where ValuesType : IConvertible
            =>
                Plotly.NET.TraceObjects.Dimension.initParallel<LabelType, TickType, TickType, ValuesType>(
                    ConstraintRange: ConstraintRange.ToOption(),
                    Label: Label.ToOption(),
                    MultiSelect: MultiSelect.ToOption(),
                    Name: Name.ToOption(),
                    Range: Range.ToOption(),
                    TemplateItemName: TemplateItemName.ToOption(),
                    TickFormat: TickFormat.ToOption(),
                    TickText: TickText.ToOption(),
                    Tickvals: Tickvals.ToOption(),
                    Values: Values.ToOption(),
                    Visible: Visible.ToOption()
                );

    public static Plotly.NET.TraceObjects.Dimension InitSplomDimension<LabelType, ValuesType>
    (
        Optional<bool> AxisMatches = default,
        Optional<StyleParam.AxisType> AxisType = default,
        Optional<LabelType> Label = default,
        Optional<string> Name = default,
        Optional<string> TemplateItemName = default,
        Optional<IEnumerable<ValuesType>> Values = default,
        Optional<bool> Visible = default
    )
        where LabelType : IConvertible
        where ValuesType : IConvertible
        =>
            Plotly.NET.TraceObjects.Dimension.initSplom<LabelType, ValuesType>(
                AxisMatches: AxisMatches.ToOption(),
                AxisType: AxisType.ToOption(),
                Label: Label.ToOption(),
                Name: Name.ToOption(),
                TemplateItemName: TemplateItemName.ToOption(),
                Values: Values.ToOption(),
                Visible: Visible.ToOption()
            );
}

