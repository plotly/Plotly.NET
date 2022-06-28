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
        /// <summary>
        /// Helper extension method to convert any nullable reference type to a FSharpOption, to be used with F# optional parameters.
        /// The resulting opton will be `None` when the value is null, and Some(value) otherwise
        /// </summary>
        /// <param name="thing">the thing to turn into a FSharpOption</param>
        /// <returns>The original value wrapped as a FSharpOption</returns>
        static internal Microsoft.FSharp.Core.FSharpOption<T> ToOption<T>(this T? thing) {
            if (EqualityComparer<T>.Default.Equals(thing, default(T)))
            {
                return FSharpOption<T>.None;
            }
            else
            {
                return new(thing);
            }
        }
        /// <summary>
        /// Helper extension method to convert any nullable value type to a FSharpOption, to be used with F# optional parameters.
        /// The resulting opton will be `None` when the value is null, and Some(value) otherwise
        /// </summary>
        /// <param name="thing">the thing to turn into a FSharpOption</param>
        /// <returns>The original value wrapped as a FSharpOption</returns>
        static internal Microsoft.FSharp.Core.FSharpOption<T> ToOptionV<T>(this T? thing) where T : struct => thing is { } some ? new(some) : Microsoft.FSharp.Core.FSharpOption<T>.None;
    }
}
