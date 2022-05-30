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
        static internal Microsoft.FSharp.Core.FSharpOption<bool> ToOption(this bool? thing) => thing is null ? Microsoft.FSharp.Core.FSharpOption<bool>.None : new((bool)thing);
        static internal Microsoft.FSharp.Core.FSharpOption<string> ToOption(this string? thing) => thing is null ? Microsoft.FSharp.Core.FSharpOption<string>.None : new((string)thing);
        static internal Microsoft.FSharp.Core.FSharpOption<double> ToOption(this double? thing) => thing is null ? Microsoft.FSharp.Core.FSharpOption<double>.None : new((double)thing);
        static internal Microsoft.FSharp.Core.FSharpOption<int> ToOption(this int? thing) => thing is null ? Microsoft.FSharp.Core.FSharpOption<int>.None : new((int)thing);
    }
}
