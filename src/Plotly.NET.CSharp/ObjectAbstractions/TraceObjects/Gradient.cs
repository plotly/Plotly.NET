
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Gradient Gradient
        (

            Optional<Color> Color = default,
            Optional<StyleParam.GradientType> Type = default,
            Optional<IEnumerable<StyleParam.GradientType>> MultiTypes = default
        ) => 
            Plotly.NET.TraceObjects.Gradient.init(

                Color: Color.ToOption(),
                Type: Type.ToOption(),
                MultiTypes: MultiTypes.ToOption()
            );
}

