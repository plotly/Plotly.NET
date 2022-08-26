
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.SlicesFill InitSlicesFill<LocationsType>
        (
            Optional<double> Fill = default,
            Optional<IEnumerable<LocationsType>> Locations = default,
            Optional<bool> Show = default
        ) 
            where LocationsType: IConvertible
            =>
                Plotly.NET.TraceObjects.SlicesFill.init(
                    Fill: Fill.ToOption(),
                    Locations: Locations.ToOption(),
                    Show: Show.ToOption()
                );
    public static Plotly.NET.TraceObjects.Slices InitSlices
        (
            Optional<Plotly.NET.TraceObjects.SlicesFill> X = default,
            Optional<Plotly.NET.TraceObjects.SlicesFill> Y = default,
            Optional<Plotly.NET.TraceObjects.SlicesFill> Z = default
        ) 
            =>
                Plotly.NET.TraceObjects.Slices.init(
                    X: X.ToOption(),
                    Y: Y.ToOption(),
                    Z: Z.ToOption()
                );
}

