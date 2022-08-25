
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.CapFill CapFill
        (

            Optional<double> Fill = default,
            Optional<bool> Show = default
        ) => 
            Plotly.NET.TraceObjects.CapFill.init(

                Fill: Fill.ToOption(),
                Show: Show.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Caps Caps
        (

            Optional<Plotly.NET.TraceObjects.CapFill> X = default,
            Optional<Plotly.NET.TraceObjects.CapFill> Y = default,
            Optional<Plotly.NET.TraceObjects.CapFill> Z = default
        ) => 
            Plotly.NET.TraceObjects.Caps.init(

                X: X.ToOption(),
                Y: Y.ToOption(),
                Z: Z.ToOption()
            );
}

