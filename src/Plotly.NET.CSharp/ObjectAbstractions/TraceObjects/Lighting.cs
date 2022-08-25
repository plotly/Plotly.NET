
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Lighting Lighting
        (

            Optional<double> Ambient = default,
            Optional<double> Diffuse = default,
            Optional<double> FaceNormalEpsilon = default,
            Optional<double> Fresnel = default,
            Optional<double> Roughness = default,
            Optional<double> Specular = default,
            Optional<double> VertexNormalEpsilon = default
        ) => 
            Plotly.NET.TraceObjects.Lighting.init(

                Ambient: Ambient.ToOption(),
                Diffuse: Diffuse.ToOption(),
                FaceNormalEpsilon: FaceNormalEpsilon.ToOption(),
                Fresnel: Fresnel.ToOption(),
                Roughness: Roughness.ToOption(),
                Specular: Specular.ToOption(),
                VertexNormalEpsilon: VertexNormalEpsilon.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.LightPosition LightPosition
        (

            Optional<double> X = default,
            Optional<double> Y = default,
            Optional<double> Z = default
        ) => 
            Plotly.NET.TraceObjects.LightPosition.init(

                X: X.ToOption(),
                Y: Y.ToOption(),
                Z: Z.ToOption()
            );
}

