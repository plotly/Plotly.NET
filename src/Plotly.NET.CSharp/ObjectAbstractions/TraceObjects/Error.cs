
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Error InitError<ArrayType, ArrayminusType>
        (
            Optional<bool> Visible = default,
            Optional<StyleParam.ErrorType> Type = default,
            Optional<bool> Symmetric = default,
            Optional<IEnumerable<ArrayType>> Array = default,
            Optional<IEnumerable<ArrayminusType>> Arrayminus = default,
            Optional<double> Value = default,
            Optional<double> Valueminus = default,
            Optional<int> Traceref = default,
            Optional<int> Tracerefminus = default,
            Optional<bool> Copy_ystyle = default,
            Optional<Color> Color = default,
            Optional<double> Thickness = default,
            Optional<double> Width = default
        ) 
            where ArrayType: IConvertible
            where ArrayminusType: IConvertible
            =>
                Plotly.NET.TraceObjects.Error.init(
                    Visible: Visible.ToOption(),
                    Type: Type.ToOption(),
                    Symmetric: Symmetric.ToOption(),
                    Array: Array.ToOption(),
                    Arrayminus: Arrayminus.ToOption(),
                    Value: Value.ToOption(),
                    Valueminus: Valueminus.ToOption(),
                    Traceref: Traceref.ToOption(),
                    Tracerefminus: Tracerefminus.ToOption(),
                    Copy_ystyle: Copy_ystyle.ToOption(),
                    Color: Color.ToOption(),
                    Thickness: Thickness.ToOption(),
                    Width: Width.ToOption()
                );
}

