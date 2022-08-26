
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.SplomDiagonal InitSplomDiagonal
        (
            Optional<bool> Visible = default
        ) 
            =>
                Plotly.NET.TraceObjects.SplomDiagonal.init(
                    Visible: Visible.ToOption()
                );
}

