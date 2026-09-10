using System;
using System.Collections.Generic;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
        /// <summary>
        /// Creates a DensityMapbox Chart that draws a bivariate kernel density estimation with a Gaussian kernel from `lon` and `lat` coordinates and optional `z` values using a colorscale.
        ///
        /// Customize the mapbox layers, style, etc. by using Chart.withMapbox.
        ///
        /// You might need a Mapbox token, which you can also configure with Chart.withMapbox.
        /// </summary>
        /// <param name="longitudes">Sets the longitude coordinates (in degrees East).</param>
        /// <param name="latitudes">Sets the latitude coordinates (in degrees North).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="MapboxStyle">Sets the base mapbox layer. Default is `OpenStreetMap`. Note that you will need an access token for some Mapbox presets.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opacity of the trace</param>
        /// <param name="Z">Sets the points' weight. For example, a value of 10 would be equivalent to having 10 points of weight 1 in the same spot</param>
        /// <param name="Radius">Sets the radius of influence of one `lon` / `lat` point in pixels. Increasing the value makes the densitymapbox trace smoother, but less detailed.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the colorbar.</param>
        /// <param name="ColorScale">Sets the colorscale.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true.</param>
        /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart DensityMapbox<LongitudesType, LatitudesType, ZType, TextType>(
            IEnumerable<LongitudesType> longitudes,
            IEnumerable<LatitudesType> latitudes,
            Optional<string> Name = default,
            Optional<StyleParam.MapboxStyle> MapboxStyle = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<ZType>> Z = default,
            Optional<int> Radius = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<ColorBar> ColorBar = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<bool> ShowScale = default,
            Optional<bool> ReverseScale = default,
            Optional<string> Below = default,
            Optional<bool> UseDefaults = default
        )
            where LongitudesType: IConvertible
            where LatitudesType: IConvertible
            where ZType: IConvertible
            where TextType: IConvertible
            =>
                Plotly.NET.ChartMap_Density.Chart.DensityMapbox<LongitudesType, LatitudesType, ZType, TextType>(
                    longitudes: longitudes,
                    latitudes: latitudes,
                    Name: Name.ToOption(),
                    MapboxStyle: MapboxStyle.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Z: Z.ToOption(),
                    Radius: Radius.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    Below: Below.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
