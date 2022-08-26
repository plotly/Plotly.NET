
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.TreemapRoot InitTreemapRoot
        (
            Optional<Color> Color = default
        ) 
            =>
                Plotly.NET.TraceObjects.TreemapRoot.init(
                    Color: Color.ToOption()
                );
    public static Plotly.NET.TraceObjects.TreemapLeaf InitTreemapLeaf
        (
            Optional<double> Opacity = default
        ) 
            =>
                Plotly.NET.TraceObjects.TreemapLeaf.init(
                    Opacity: Opacity.ToOption()
                );
    public static Plotly.NET.TraceObjects.TreemapTiling InitTreemapTiling
        (
            Optional<StyleParam.TreemapTilingPacking> Packing = default,
            Optional<double> SquarifyRatio = default,
            Optional<StyleParam.TilingFlip> Flip = default,
            Optional<double> Pad = default
        ) 
            =>
                Plotly.NET.TraceObjects.TreemapTiling.init(
                    Packing: Packing.ToOption(),
                    SquarifyRatio: SquarifyRatio.ToOption(),
                    Flip: Flip.ToOption(),
                    Pad: Pad.ToOption()
                );
}

