
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Cumulative InitCumulative
        (
            Optional<bool> Enabled = default,
            Optional<StyleParam.CumulativeDirection> Direction = default,
            Optional<StyleParam.Currentbin> Currentbin = default
        ) 
            =>
                Plotly.NET.TraceObjects.Cumulative.init(
                    Enabled: Enabled.ToOption(),
                    Direction: Direction.ToOption(),
                    Currentbin: Currentbin.ToOption()
                );
}

