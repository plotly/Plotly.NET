
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.ProjectionDimension InitProjectionDimension
        (
            Optional<double> Opacity = default,
            Optional<double> Scale = default,
            Optional<bool> Show = default
        ) 
            =>
                Plotly.NET.TraceObjects.ProjectionDimension.init(
                    Opacity: Opacity.ToOption(),
                    Scale: Scale.ToOption(),
                    Show: Show.ToOption()
                );
    public static Plotly.NET.TraceObjects.Projection InitProjection
        (
            Optional<Plotly.NET.TraceObjects.ProjectionDimension> X = default,
            Optional<Plotly.NET.TraceObjects.ProjectionDimension> Y = default,
            Optional<Plotly.NET.TraceObjects.ProjectionDimension> Z = default
        ) 
            =>
                Plotly.NET.TraceObjects.Projection.init(
                    X: X.ToOption(),
                    Y: Y.ToOption(),
                    Z: Z.ToOption()
                );
}

