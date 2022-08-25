
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.ProjectionDimension ProjectionDimension
        (

            Optional<double> Opacity = default,
            Optional<double> Scale = default,
            Optional<bool> Show = default
        ) => 
            Plotly.NET.TraceObjects.ProjectionDimension.init(

                Opacity: Opacity.ToOption(),
                Scale: Scale.ToOption(),
                Show: Show.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Projection Projection
        (

            Optional<ProjectionDimension> X = default,
            Optional<ProjectionDimension> Y = default,
            Optional<ProjectionDimension> Z = default
        ) => 
            Plotly.NET.TraceObjects.Projection.init(

                X: X.ToOption(),
                Y: Y.ToOption(),
                Z: Z.ToOption()
            );
}

