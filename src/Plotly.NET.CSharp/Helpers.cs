using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FSharp;
using Microsoft.FSharp.Core;

namespace Plotly.NET.CSharp
{
    static class Helpers {
        static internal Microsoft.FSharp.Core.FSharpOption<T> ToOption<T>(this T? thing) => thing is null ? Microsoft.FSharp.Core.FSharpOption<T>.None : new(thing);
    }
}
