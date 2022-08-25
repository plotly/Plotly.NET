
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.FinanceMarker FinanceMarker
        (

            Optional<Color> MarkerColor = default,
            Optional<Color> LineColor = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default
        ) => 
            Plotly.NET.TraceObjects.FinanceMarker.init(

                MarkerColor: MarkerColor.ToOption(),
                LineColor: LineColor.ToOption(),
                LineWidth: LineWidth.ToOption(),
                LineDash: LineDash.ToOption()
            );
}

