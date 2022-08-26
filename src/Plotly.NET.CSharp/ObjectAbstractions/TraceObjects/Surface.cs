
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Surface InitSurface
        (
            Optional<int> Count = default,
            Optional<double> Fill = default,
            Optional<StyleParam.SurfacePattern> Pattern = default,
            Optional<bool> Show = default
        ) 
            =>
                Plotly.NET.TraceObjects.Surface.init(
                    Count: Count.ToOption(),
                    Fill: Fill.ToOption(),
                    Pattern: Pattern.ToOption(),
                    Show: Show.ToOption()
                );
}

