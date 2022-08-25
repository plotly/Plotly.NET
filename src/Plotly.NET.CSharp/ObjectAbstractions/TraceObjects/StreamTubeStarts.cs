
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.StreamTubeStarts StreamTubeStarts
        (

            Optional<IEnumerable<#IConvertible>> X = default,
            Optional<IEnumerable<#IConvertible>> Y = default,
            Optional<IEnumerable<#IConvertible>> Z = default
        ) => 
            Plotly.NET.TraceObjects.StreamTubeStarts.init(

                X: X.ToOption(),
                Y: Y.ToOption(),
                Z: Z.ToOption()
            );
}

