// this file was auto-generated using Plotly.NET.Codegen on 06.09.22 targeting Plotly.NET, Version=3.0.0.0, Culture=neutral, PublicKeyToken=c98c6d87097b7615.
// Do not edit this, as it will most likely be overwritten on the next codegen run.
// Instead, file an issue or target the codegen with your changes directly.
// Bugs that are not caused by wrong codegen are most likely not found in this file, but in the F# source this file is generated from.

namespace Plotly.NET.CSharp.LayoutObjects;

public static class Ternary {
    public static Plotly.NET.LayoutObjects.Ternary Init<a>(
        Optional<Plotly.NET.LayoutObjects.LinearAxis> AAxis = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> BAxis = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> CAxis = default,
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<a> Sum = default,
        Optional<Plotly.NET.Color> BGColor = default
    )
        where a: System.IConvertible
        =>
            Plotly.NET.LayoutObjects.Ternary.init<a>(
                AAxis: AAxis.ToOption(),
                BAxis: BAxis.ToOption(),
                CAxis: CAxis.ToOption(),
                Domain: Domain.ToOption(),
                Sum: Sum.ToOption(),
                BGColor: BGColor.ToOption()
            );
    public static Plotly.NET.LayoutObjects.Ternary Style<a>(
        this Plotly.NET.LayoutObjects.Ternary obj,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> AAxis = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> BAxis = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> CAxis = default,
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<a> Sum = default,
        Optional<Plotly.NET.Color> BGColor = default
    )
        where a: System.IConvertible
        =>
            Plotly.NET.LayoutObjects.Ternary.style<a>(
                AAxis: AAxis.ToOption(),
                BAxis: BAxis.ToOption(),
                CAxis: CAxis.ToOption(),
                Domain: Domain.ToOption(),
                Sum: Sum.ToOption(),
                BGColor: BGColor.ToOption()
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.LinearAxis GetAAxis(
        this Plotly.NET.LayoutObjects.Ternary obj,
        Plotly.NET.LayoutObjects.Ternary ternary
    )

        =>
            Plotly.NET.LayoutObjects.Ternary.getAAxis(
                ternary: ternary
            );
    public static Plotly.NET.LayoutObjects.Ternary SetAAxis(
        this Plotly.NET.LayoutObjects.Ternary obj,
        Plotly.NET.LayoutObjects.LinearAxis aAxis
    )

        =>
            Plotly.NET.LayoutObjects.Ternary.setAAxis(
                aAxis: aAxis
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.LinearAxis GetBAxis(
        this Plotly.NET.LayoutObjects.Ternary obj,
        Plotly.NET.LayoutObjects.Ternary ternary
    )

        =>
            Plotly.NET.LayoutObjects.Ternary.getBAxis(
                ternary: ternary
            );
    public static Plotly.NET.LayoutObjects.Ternary SetBAxis(
        this Plotly.NET.LayoutObjects.Ternary obj,
        Plotly.NET.LayoutObjects.LinearAxis bAxis
    )

        =>
            Plotly.NET.LayoutObjects.Ternary.setBAxis(
                bAxis: bAxis
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.LinearAxis GetCAxis(
        this Plotly.NET.LayoutObjects.Ternary obj,
        Plotly.NET.LayoutObjects.Ternary ternary
    )

        =>
            Plotly.NET.LayoutObjects.Ternary.getCAxis(
                ternary: ternary
            );
    public static Plotly.NET.LayoutObjects.Ternary SetCAxis(
        this Plotly.NET.LayoutObjects.Ternary obj,
        Plotly.NET.LayoutObjects.LinearAxis cAxis
    )

        =>
            Plotly.NET.LayoutObjects.Ternary.setCAxis(
                cAxis: cAxis
            ).Invoke(obj);
}