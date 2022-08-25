
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Spaceframe Spaceframe
        (

            Optional<double> Fill = default,
            Optional<bool> Show = default
        ) => 
            Plotly.NET.TraceObjects.Spaceframe.init(

                Fill: Fill.ToOption(),
                Show: Show.ToOption()
            );
}

