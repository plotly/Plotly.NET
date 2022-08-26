
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.WaterfallConnector InitWaterfallConnector
        (
            Optional<Line> Line = default,
            Optional<bool> Visible = default,
            Optional<StyleParam.ConnectorMode> ConnectorMode = default
        ) 
            =>
                Plotly.NET.TraceObjects.WaterfallConnector.init(
                    Line: Line.ToOption(),
                    Visible: Visible.ToOption(),
                    ConnectorMode: ConnectorMode.ToOption()
                );
}

