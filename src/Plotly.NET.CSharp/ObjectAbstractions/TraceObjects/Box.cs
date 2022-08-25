
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Box Box
        (

            Optional<bool> Visible = default,
            Optional<double> Width = default,
            Optional<Color> FillColor = default,
            Optional<Color> LineColor = default,
            Optional<double> LineWidth = default
        ) => 
            Plotly.NET.TraceObjects.Box.init(

                Visible: Visible.ToOption(),
                Width: Width.ToOption(),
                FillColor: FillColor.ToOption(),
                LineColor: LineColor.ToOption(),
                LineWidth: LineWidth.ToOption()
            );
}

