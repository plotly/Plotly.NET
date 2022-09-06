// this file was auto-generated using Plotly.NET.Codegen on 06.09.22 targeting Plotly.NET, Version=3.0.0.0, Culture=neutral, PublicKeyToken=c98c6d87097b7615.
// Do not edit this, as it will most likely be overwritten on the next codegen run.
// Instead, file an issue or target the codegen with your changes directly.
// Bugs that are not caused by wrong codegen are most likely not found in this file, but in the F# source this file is generated from.

namespace Plotly.NET.CSharp.LayoutObjects;

public static class Polar {
    public static Plotly.NET.LayoutObjects.Polar Init(
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<System.Tuple<System.Double,System.Double>> Sector = default,
        Optional<System.Double> Hole = default,
        Optional<Plotly.NET.Color> BGColor = default,
        Optional<Plotly.NET.LayoutObjects.RadialAxis> RadialAxis = default,
        Optional<Plotly.NET.LayoutObjects.AngularAxis> AngularAxis = default,
        Optional<Plotly.NET.StyleParam.PolarGridShape> GridShape = default,
        Optional<System.String> UIRevision = default
    )

        =>
            Plotly.NET.LayoutObjects.Polar.init(
                Domain: Domain.ToOption(),
                Sector: Sector.ToOption(),
                Hole: Hole.ToOption(),
                BGColor: BGColor.ToOption(),
                RadialAxis: RadialAxis.ToOption(),
                AngularAxis: AngularAxis.ToOption(),
                GridShape: GridShape.ToOption(),
                UIRevision: UIRevision.ToOption()
            );
    public static Plotly.NET.LayoutObjects.Polar Style(
        this Plotly.NET.LayoutObjects.Polar obj,
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<System.Tuple<System.Double,System.Double>> Sector = default,
        Optional<System.Double> Hole = default,
        Optional<Plotly.NET.Color> BGColor = default,
        Optional<Plotly.NET.LayoutObjects.RadialAxis> RadialAxis = default,
        Optional<Plotly.NET.LayoutObjects.AngularAxis> AngularAxis = default,
        Optional<Plotly.NET.StyleParam.PolarGridShape> GridShape = default,
        Optional<System.String> UIRevision = default,
        Optional<Plotly.NET.StyleParam.BarMode> BarMode = default,
        Optional<System.Double> BarGap = default
    )

        =>
            Plotly.NET.LayoutObjects.Polar.style(
                Domain: Domain.ToOption(),
                Sector: Sector.ToOption(),
                Hole: Hole.ToOption(),
                BGColor: BGColor.ToOption(),
                RadialAxis: RadialAxis.ToOption(),
                AngularAxis: AngularAxis.ToOption(),
                GridShape: GridShape.ToOption(),
                UIRevision: UIRevision.ToOption(),
                BarMode: BarMode.ToOption(),
                BarGap: BarGap.ToOption()
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.AngularAxis GetAngularAxis(
        this Plotly.NET.LayoutObjects.Polar obj,
        Plotly.NET.LayoutObjects.Polar polar
    )

        =>
            Plotly.NET.LayoutObjects.Polar.getAngularAxis(
                polar: polar
            );
    public static Plotly.NET.LayoutObjects.Polar SetAngularAxis(
        this Plotly.NET.LayoutObjects.Polar obj,
        Plotly.NET.LayoutObjects.AngularAxis angularAxis
    )

        =>
            Plotly.NET.LayoutObjects.Polar.setAngularAxis(
                angularAxis: angularAxis
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.RadialAxis GetRadialAxis(
        this Plotly.NET.LayoutObjects.Polar obj,
        Plotly.NET.LayoutObjects.Polar polar
    )

        =>
            Plotly.NET.LayoutObjects.Polar.getRadialAxis(
                polar: polar
            );
    public static Plotly.NET.LayoutObjects.Polar SetRadialAxis(
        this Plotly.NET.LayoutObjects.Polar obj,
        Plotly.NET.LayoutObjects.RadialAxis radialAxis
    )

        =>
            Plotly.NET.LayoutObjects.Polar.setRadialAxis(
                radialAxis: radialAxis
            ).Invoke(obj);
}