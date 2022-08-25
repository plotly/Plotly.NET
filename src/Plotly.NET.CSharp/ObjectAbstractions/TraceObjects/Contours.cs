
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.ContourProject ContourProject
        (

            Optional<bool> X = default,
            Optional<bool> Y = default,
            Optional<bool> Z = default
        ) => 
            Plotly.NET.TraceObjects.ContourProject.init(

                X: X.ToOption(),
                Y: Y.ToOption(),
                Z: Z.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Contour Contour
        (

            Optional<Color> Color = default,
            Optional<double> End = default,
            Optional<bool> Highlight = default,
            Optional<Color> HighlightColor = default,
            Optional<double> HighlightWidth = default,
            Optional<Plotly.NET.TraceObjects.ContourProject> Project = default,
            Optional<bool> Show = default,
            Optional<double> Size = default,
            Optional<double> Start = default,
            Optional<bool> UseColorMap = default,
            Optional<double> Width = default
        ) => 
            Plotly.NET.TraceObjects.Contour.init(

                Color: Color.ToOption(),
                End: End.ToOption(),
                Highlight: Highlight.ToOption(),
                HighlightColor: HighlightColor.ToOption(),
                HighlightWidth: HighlightWidth.ToOption(),
                Project: Project.ToOption(),
                Show: Show.ToOption(),
                Size: Size.ToOption(),
                Start: Start.ToOption(),
                UseColorMap: UseColorMap.ToOption(),
                Width: Width.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Contours Contours<ValueType>
        (

            Optional<StyleParam.ContourColoring> Coloring = default,
            Optional<double> End = default,
            Optional<Font> LabelFont = default,
            Optional<string> LabelFormat = default,
            Optional<StyleParam.ConstraintOperation> Operation = default,
            Optional<bool> ShowLabels = default,
            Optional<bool> ShowLines = default,
            Optional<double> Size = default,
            Optional<double> Start = default,
            Optional<StyleParam.ContourType> Type = default,
            Optional<ValueType> Value = default
        ) 
            where ValueType : IConvertible
            => 
            Plotly.NET.TraceObjects.Contours.init(

                Coloring: Coloring.ToOption(),
                End: End.ToOption(),
                LabelFont: LabelFont.ToOption(),
                LabelFormat: LabelFormat.ToOption(),
                Operation: Operation.ToOption(),
                ShowLabels: ShowLabels.ToOption(),
                ShowLines: ShowLines.ToOption(),
                Size: Size.ToOption(),
                Start: Start.ToOption(),
                Type: Type.ToOption(),
                Value: Value.ToOption()
            );
}

