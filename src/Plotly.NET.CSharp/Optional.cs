using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp
{
    /// <summary>
    /// Helper type for handling the special way the Plotly.NET core API uses generics.
    /// In short, the problem arises because many optional parameters of Plotly.NET's core API are generics 
    /// with a type constraint for `IConvertible`. This means that these parameters can be both value and reference types 
    /// (e.g. `double` and `System.DateTime` both implement IConvertible).
    /// If we now have a optional parameter of type `T? where T: IConvertible` the compiler will not allow this 
    /// without further type constrainst to either reference or value type.
    /// This is a problem because we want to 1. allow both, and 2. have a reliable way of determining if the value was not set 
    /// because the F# API expects to be passed `Option.None` in that case.
    /// There exist other workarounds like checking if the value is default or null, but that changes valid default values actually set to null as well.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Value">The value to mark as optional</param>
    /// <param name="IsSome">Whether or not the wrapped value is valid. This is used downstream to determine whether to wrap this value into `Option.Some` (if true) or `Option.None` (if false)</param>
    public readonly record struct Optional<T>(T Value, bool IsSome)
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        public static implicit operator Optional<T>(T Value) => new(Value, true);

    }
    /// <summary>
    /// Extension methods for the `Optional` class
    /// </summary>
    public static class OptionalExtensions
    {
        /// <summary>
        /// Converts the `Optional` value to `Some(value)` if the value is valid, or `None` if it is not.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="opt">The `Optional` value to convert to a F# Option</param>
        /// <returns>opt converted to `Option`</returns>
        static internal Microsoft.FSharp.Core.FSharpOption<T> ToOption<T>(this Optional<T> opt) => opt.IsSome ? new(opt.Value) : Microsoft.FSharp.Core.FSharpOption<T>.None;

    }
}
