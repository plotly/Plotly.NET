
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Pattern Pattern
        (

            Optional<Color> BGColor = default,
            Optional<Color> FGColor = default,
            Optional<double> FGOpacity = default,
            Optional<StyleParam.PatternFillMode> FillMode = default,
            Optional<StyleParam.PatternShape> Shape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiShape = default,
            Optional<int> Size = default,
            Optional<IEnumerable<int>> MultiSize = default,
            Optional<double> Solidity = default
        ) => 
            Plotly.NET.TraceObjects.Pattern.init(

                BGColor: BGColor.ToOption(),
                FGColor: FGColor.ToOption(),
                FGOpacity: FGOpacity.ToOption(),
                FillMode: FillMode.ToOption(),
                Shape: Shape.ToOption(),
                MultiShape: MultiShape.ToOption(),
                Size: Size.ToOption(),
                MultiSize: MultiSize.ToOption(),
                Solidity: Solidity.ToOption()
            );
}

