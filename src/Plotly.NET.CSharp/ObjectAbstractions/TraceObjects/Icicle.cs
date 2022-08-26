
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.IcicleRoot InitIcicleRoot
        (
            Optional<Color> Color = default
        ) 
            =>
                Plotly.NET.TraceObjects.IcicleRoot.init(
                    Color: Color.ToOption()
                );

    public static Plotly.NET.TraceObjects.IcicleLeaf InitIcicleLeaf
        (
            Optional<double> Opacity = default
        )
            =>
                Plotly.NET.TraceObjects.IcicleLeaf.init(
                    Opacity: Opacity.ToOption()
                );

    public static Plotly.NET.TraceObjects.IcicleTiling InitIcicleTiling
        (

            Optional<StyleParam.TilingFlip> Flip = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<int> Pad = default
        ) 

            =>
            Plotly.NET.TraceObjects.IcicleTiling.init(

                Flip: Flip.ToOption(),
                Orientation: Orientation.ToOption(),
                Pad: Pad.ToOption()
            );
}

