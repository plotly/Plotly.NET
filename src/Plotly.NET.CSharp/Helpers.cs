using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FSharp;
using Microsoft.FSharp.Core;

namespace Plotly.NET.CSharp
{
    internal class OptionWrapper<T> { 
        internal static FSharpOption<T> WrapAsOption(T? Value) { 
            if (Value is null) {
                return FSharpOption<T>.None;
            } else {
                T v = (T)Value;
                return FSharpOption<T>.Some(v);
            }
        }
    }
}
