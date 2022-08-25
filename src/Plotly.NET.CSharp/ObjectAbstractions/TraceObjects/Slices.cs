
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.SlicesFill SlicesFill
        (

            Optional<double> Fill = default,
            Optional<IEnumerable<#IConvertible>> Locations = default,
            Optional<bool> Show = default
        ) => 
            Plotly.NET.TraceObjects.SlicesFill.init(

                Fill: Fill.ToOption(),
                Locations: Locations.ToOption(),
                Show: Show.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Slices Slices
        (

            Optional<SlicesFill> X = default,
            Optional<SlicesFill> Y = default,
            Optional<SlicesFill> Z = default
        ) => 
            Plotly.NET.TraceObjects.Slices.init(

                X: X.ToOption(),
                Y: Y.ToOption(),
                Z: Z.ToOption()
            );
}

