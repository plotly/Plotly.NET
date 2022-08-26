
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Pathbar InitPathbar
        (
            Optional<bool> Visible = default,
            Optional<StyleParam.Side> Side = default,
            Optional<StyleParam.PathbarEdgeShape> EdgeShape = default,
            Optional<double> Thickness = default,
            Optional<Font> Textfont = default
        ) 
            =>
                Plotly.NET.TraceObjects.Pathbar.init(
                    Visible: Visible.ToOption(),
                    Side: Side.ToOption(),
                    EdgeShape: EdgeShape.ToOption(),
                    Thickness: Thickness.ToOption(),
                    Textfont: Textfont.ToOption()
                );
}

