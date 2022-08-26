
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.SunburstRoot InitSunburstRoot
        (
            Optional<Color> Color = default
        ) 
            =>
                Plotly.NET.TraceObjects.SunburstRoot.init(
                    Color: Color.ToOption()
                );
    public static Plotly.NET.TraceObjects.SunburstLeaf InitSunburstLeaf
        (
            Optional<double> Opacity = default
        ) 
            =>
                Plotly.NET.TraceObjects.SunburstLeaf.init(
                    Opacity: Opacity.ToOption()
                );
}

