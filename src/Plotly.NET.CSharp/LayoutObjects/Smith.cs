// this file was auto-generated using Plotly.NET.Codegen on 06.09.22 targeting Plotly.NET, Version=3.0.0.0, Culture=neutral, PublicKeyToken=c98c6d87097b7615.
// Do not edit this, as it will most likely be overwritten on the next codegen run.
// Instead, file an issue or target the codegen with your changes directly.
// Bugs that are not caused by wrong codegen are most likely not found in this file, but in the F# source this file is generated from.

namespace Plotly.NET.CSharp.LayoutObjects;

public static class Smith {
    public static Plotly.NET.LayoutObjects.Smith Init(
        Optional<Plotly.NET.Color> BGColor = default,
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<Plotly.NET.LayoutObjects.ImaginaryAxis> ImaginaryAxis = default,
        Optional<Plotly.NET.LayoutObjects.RealAxis> RealAxis = default
    )

        =>
            Plotly.NET.LayoutObjects.Smith.init(
                BGColor: BGColor.ToOption(),
                Domain: Domain.ToOption(),
                ImaginaryAxis: ImaginaryAxis.ToOption(),
                RealAxis: RealAxis.ToOption()
            );
    public static Plotly.NET.LayoutObjects.Smith Style(
        this Plotly.NET.LayoutObjects.Smith obj,
        Optional<Plotly.NET.Color> BGColor = default,
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<Plotly.NET.LayoutObjects.ImaginaryAxis> ImaginaryAxis = default,
        Optional<Plotly.NET.LayoutObjects.RealAxis> RealAxis = default
    )

        =>
            Plotly.NET.LayoutObjects.Smith.style(
                BGColor: BGColor.ToOption(),
                Domain: Domain.ToOption(),
                ImaginaryAxis: ImaginaryAxis.ToOption(),
                RealAxis: RealAxis.ToOption()
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.ImaginaryAxis GetImaginaryAxis(
        this Plotly.NET.LayoutObjects.Smith obj,
        Plotly.NET.LayoutObjects.Smith smith
    )

        =>
            Plotly.NET.LayoutObjects.Smith.getImaginaryAxis(
                smith: smith
            );
    public static Plotly.NET.LayoutObjects.Smith SetImaginaryAxis(
        this Plotly.NET.LayoutObjects.Smith obj,
        Plotly.NET.LayoutObjects.ImaginaryAxis imaginaryAxis
    )

        =>
            Plotly.NET.LayoutObjects.Smith.setImaginaryAxis(
                imaginaryAxis: imaginaryAxis
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.RealAxis GetRealAxis(
        this Plotly.NET.LayoutObjects.Smith obj,
        Plotly.NET.LayoutObjects.Smith smith
    )

        =>
            Plotly.NET.LayoutObjects.Smith.getRealAxis(
                smith: smith
            );
    public static Plotly.NET.LayoutObjects.Smith SetRealAxis(
        this Plotly.NET.LayoutObjects.Smith obj,
        Plotly.NET.LayoutObjects.RealAxis realAxis
    )

        =>
            Plotly.NET.LayoutObjects.Smith.setRealAxis(
                realAxis: realAxis
            ).Invoke(obj);
}