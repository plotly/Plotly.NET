
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.MarkerSelectionStyle MarkerSelectionStyle
        (

            Optional<double> Opacity = default,
            Optional<Color> Color = default,
            Optional<double> Size = default
        ) => 
            Plotly.NET.TraceObjects.MarkerSelectionStyle.init(

                Opacity: Opacity.ToOption(),
                Color: Color.ToOption(),
                Size: Size.ToOption()
            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.FontSelectionStyle FontSelectionStyle
        (
             ,
             ,
             ,
             

        ) => 
            Plotly.NET.TraceObjects.FontSelectionStyle.init(
                : ,
                : ,
                : ,
                : 

            );
}

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Selection Selection
        (

            Optional<MarkerSelectionStyle> MarkerSelectionStyle = default,
            Optional<FontSelectionStyle> FontSelectionStyle = default
        ) => 
            Plotly.NET.TraceObjects.Selection.init(

                MarkerSelectionStyle: MarkerSelectionStyle.ToOption(),
                FontSelectionStyle: FontSelectionStyle.ToOption()
            );
}

