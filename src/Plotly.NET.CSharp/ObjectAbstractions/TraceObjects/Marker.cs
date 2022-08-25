
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.Marker Marker
        (

            Optional<bool> AutoColorScale = default,
            Optional<bool> CAuto = default,
            Optional<double> CMax = default,
            Optional<double> CMid = default,
            Optional<double> CMin = default,
            Optional<Color> Color = default,
            Optional<IEnumerable<Color>> Colors = default,
            Optional<StyleParam.SubPlotId> ColorAxis = default,
            Optional<ColorBar> ColorBar = default,
            Optional<StyleParam.Colorscale> Colorscale = default,
            Optional<Gradient> Gradient = default,
            Optional<Line> Outline = default,
            Optional<int> MaxDisplayed = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<Pattern> Pattern = default,
            Optional<bool> ReverseScale = default,
            Optional<bool> ShowScale = default,
            Optional<int> Size = default,
            Optional<IEnumerable<int>> MultiSize = default,
            Optional<int> SizeMin = default,
            Optional<StyleParam.MarkerSizeMode> SizeMode = default,
            Optional<int> SizeRef = default,
            Optional<StyleParam.MarkerSymbol> Symbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiSymbol = default,
            Optional<StyleParam.MarkerSymbol3D> Symbol3D = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol3D>> MultiSymbol3D = default,
            Optional<Color> OutlierColor = default,
            Optional<int> OutlierWidth = default
        ) => 
            Plotly.NET.TraceObjects.Marker.init(

                AutoColorScale: AutoColorScale.ToOption(),
                CAuto: CAuto.ToOption(),
                CMax: CMax.ToOption(),
                CMid: CMid.ToOption(),
                CMin: CMin.ToOption(),
                Color: Color.ToOption(),
                Colors: Colors.ToOption(),
                ColorAxis: ColorAxis.ToOption(),
                ColorBar: ColorBar.ToOption(),
                Colorscale: Colorscale.ToOption(),
                Gradient: Gradient.ToOption(),
                Outline: Outline.ToOption(),
                MaxDisplayed: MaxDisplayed.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Pattern: Pattern.ToOption(),
                ReverseScale: ReverseScale.ToOption(),
                ShowScale: ShowScale.ToOption(),
                Size: Size.ToOption(),
                MultiSize: MultiSize.ToOption(),
                SizeMin: SizeMin.ToOption(),
                SizeMode: SizeMode.ToOption(),
                SizeRef: SizeRef.ToOption(),
                Symbol: Symbol.ToOption(),
                MultiSymbol: MultiSymbol.ToOption(),
                Symbol3D: Symbol3D.ToOption(),
                MultiSymbol3D: MultiSymbol3D.ToOption(),
                OutlierColor: OutlierColor.ToOption(),
                OutlierWidth: OutlierWidth.ToOption()
            );
}

