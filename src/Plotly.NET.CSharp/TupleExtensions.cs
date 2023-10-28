namespace Plotly.NET.CSharp;

/// <summary>
/// Convenience to convert from C# struct tuple literals to the value tuple ones.
/// </summary>
internal static class TupleExtensions 
{
    /// <summary>
    /// Converts a 2 tuple.
    /// </summary>
    internal static Tuple<T1,T2> ToTuple<T1,T2>(this ValueTuple<T1,T2> t) => Tuple.Create(t.Item1, t.Item2);
}