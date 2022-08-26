
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.MeanLine InitMeanLine
        (
            Optional<bool> Visible = default,
            Optional<Color> Color = default,
            Optional<double> Width = default
        ) 
            =>
                Plotly.NET.TraceObjects.MeanLine.init(
                    Visible: Visible.ToOption(),
                    Color: Color.ToOption(),
                    Width: Width.ToOption()
                );
}

