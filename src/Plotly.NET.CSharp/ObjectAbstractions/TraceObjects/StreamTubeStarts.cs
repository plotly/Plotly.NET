
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.StreamTubeStarts InitStreamTubeStarts<XType, YType, ZType>
        (
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<YType>> Y = default,
            Optional<IEnumerable<ZType>> Z = default
        ) 
            where XType: IConvertible
            where YType: IConvertible
            where ZType: IConvertible
            =>
                Plotly.NET.TraceObjects.StreamTubeStarts.init(
                    X: X.ToOption(),
                    Y: Y.ToOption(),
                    Z: Z.ToOption()
                );
}

