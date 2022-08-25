
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.TreemapRoot TreemapRoot
        (
             ,
             ,
             

        ) => 
            Plotly.NET.TraceObjects.TreemapRoot.init(
                : ,
                : ,
                : 

            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.TreemapLeaf TreemapLeaf
        (
             ,
             ,
             

        ) => 
            Plotly.NET.TraceObjects.TreemapLeaf.init(
                : ,
                : ,
                : 

            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.TreemapTiling TreemapTiling
        (

            Optional<StyleParam.TreemapTilingPacking> Packing = default,
            Optional<double> SquarifyRatio = default,
            Optional<StyleParam.TilingFlip> Flip = default,
            Optional<double> Pad = default
        ) => 
            Plotly.NET.TraceObjects.TreemapTiling.init(

                Packing: Packing.ToOption(),
                SquarifyRatio: SquarifyRatio.ToOption(),
                Flip: Flip.ToOption(),
                Pad: Pad.ToOption()
            );
}

