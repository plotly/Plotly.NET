
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.FunnelConnector FunnelConnector
        (

            Optional<Color> FillColor = default,
            Optional<Line> Line = default,
            Optional<bool> Visible = default
        ) => 
            Plotly.NET.TraceObjects.FunnelConnector.init(

                FillColor: FillColor.ToOption(),
                Line: Line.ToOption(),
                Visible: Visible.ToOption()
            );
}

