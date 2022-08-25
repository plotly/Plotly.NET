
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Bins Bins
        (

            Optional<double> Start = default,
            Optional<double> End = default,
            Optional<double> Size = default
        ) => 
            Plotly.NET.TraceObjects.Bins.init(

                Start: Start.ToOption(),
                End: End.ToOption(),
                Size: Size.ToOption()
            );
}

