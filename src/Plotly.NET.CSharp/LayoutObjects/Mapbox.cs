// this file was auto-generated using Plotly.NET.Codegen on 06.09.22 targeting Plotly.NET, Version=3.0.0.0, Culture=neutral, PublicKeyToken=c98c6d87097b7615.
// Do not edit this, as it will most likely be overwritten on the next codegen run.
// Instead, file an issue or target the codegen with your changes directly.
// Bugs that are not caused by wrong codegen are most likely not found in this file, but in the F# source this file is generated from.

namespace Plotly.NET.CSharp.LayoutObjects;

public static class Mapbox {
    public static Plotly.NET.LayoutObjects.Mapbox Init(
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<System.String> AccessToken = default,
        Optional<Plotly.NET.StyleParam.MapboxStyle> Style = default,
        Optional<System.Tuple<System.Double,System.Double>> Center = default,
        Optional<System.Double> Zoom = default,
        Optional<System.Double> Bearing = default,
        Optional<System.Double> Pitch = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.MapboxLayer>> Layers = default
    )

        =>
            Plotly.NET.LayoutObjects.Mapbox.init(
                Domain: Domain.ToOption(),
                AccessToken: AccessToken.ToOption(),
                Style: Style.ToOption(),
                Center: Center.ToOption(),
                Zoom: Zoom.ToOption(),
                Bearing: Bearing.ToOption(),
                Pitch: Pitch.ToOption(),
                Layers: Layers.ToOption()
            );
    public static Plotly.NET.LayoutObjects.Mapbox Style(
        this Plotly.NET.LayoutObjects.Mapbox obj,
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<System.String> AccessToken = default,
        Optional<Plotly.NET.StyleParam.MapboxStyle> Style = default,
        Optional<System.Tuple<System.Double,System.Double>> Center = default,
        Optional<System.Double> Zoom = default,
        Optional<System.Double> Bearing = default,
        Optional<System.Double> Pitch = default,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.MapboxLayer>> Layers = default
    )

        =>
            Plotly.NET.LayoutObjects.Mapbox.style(
                Domain: Domain.ToOption(),
                AccessToken: AccessToken.ToOption(),
                Style: Style.ToOption(),
                Center: Center.ToOption(),
                Zoom: Zoom.ToOption(),
                Bearing: Bearing.ToOption(),
                Pitch: Pitch.ToOption(),
                Layers: Layers.ToOption()
            ).Invoke(obj);
}