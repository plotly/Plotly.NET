using System;
using Plotly.NET;

namespace Plotly.NET.Tests.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StyleParam.TextPosition.MiddleRight.ToString());
            Console.WriteLine(StyleParam.TextPosition.MiddleRight.Convert());
        }
    }
}
