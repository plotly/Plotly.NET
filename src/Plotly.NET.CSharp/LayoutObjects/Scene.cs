// this file was auto-generated using Plotly.NET.Codegen on 06.09.22 targeting Plotly.NET, Version=3.0.0.0, Culture=neutral, PublicKeyToken=c98c6d87097b7615.
// Do not edit this, as it will most likely be overwritten on the next codegen run.
// Instead, file an issue or target the codegen with your changes directly.
// Bugs that are not caused by wrong codegen are most likely not found in this file, but in the F# source this file is generated from.

namespace Plotly.NET.CSharp.LayoutObjects;

public static class Scene {
    public static Plotly.NET.LayoutObjects.Scene Init(
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.Annotation>> Annotations = default,
        Optional<Plotly.NET.StyleParam.AspectMode> AspectMode = default,
        Optional<Plotly.NET.LayoutObjects.AspectRatio> AspectRatio = default,
        Optional<Plotly.NET.Color> BGColor = default,
        Optional<Plotly.NET.LayoutObjects.Camera> Camera = default,
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<Plotly.NET.StyleParam.DragMode> DragMode = default,
        Optional<Plotly.NET.StyleParam.HoverMode> HoverMode = default,
        Optional<System.String> UIRevision = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> XAxis = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> YAxis = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> ZAxis = default
    )

        =>
            Plotly.NET.LayoutObjects.Scene.init(
                Annotations: Annotations.ToOption(),
                AspectMode: AspectMode.ToOption(),
                AspectRatio: AspectRatio.ToOption(),
                BGColor: BGColor.ToOption(),
                Camera: Camera.ToOption(),
                Domain: Domain.ToOption(),
                DragMode: DragMode.ToOption(),
                HoverMode: HoverMode.ToOption(),
                UIRevision: UIRevision.ToOption(),
                XAxis: XAxis.ToOption(),
                YAxis: YAxis.ToOption(),
                ZAxis: ZAxis.ToOption()
            );
    public static Plotly.NET.LayoutObjects.Scene Style(
        this Plotly.NET.LayoutObjects.Scene obj,
        Optional<System.Collections.Generic.IEnumerable<Plotly.NET.LayoutObjects.Annotation>> Annotations = default,
        Optional<Plotly.NET.StyleParam.AspectMode> AspectMode = default,
        Optional<Plotly.NET.LayoutObjects.AspectRatio> AspectRatio = default,
        Optional<Plotly.NET.Color> BGColor = default,
        Optional<Plotly.NET.LayoutObjects.Camera> Camera = default,
        Optional<Plotly.NET.LayoutObjects.Domain> Domain = default,
        Optional<Plotly.NET.StyleParam.DragMode> DragMode = default,
        Optional<Plotly.NET.StyleParam.HoverMode> HoverMode = default,
        Optional<System.String> UIRevision = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> XAxis = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> YAxis = default,
        Optional<Plotly.NET.LayoutObjects.LinearAxis> ZAxis = default
    )

        =>
            Plotly.NET.LayoutObjects.Scene.style(
                Annotations: Annotations.ToOption(),
                AspectMode: AspectMode.ToOption(),
                AspectRatio: AspectRatio.ToOption(),
                BGColor: BGColor.ToOption(),
                Camera: Camera.ToOption(),
                Domain: Domain.ToOption(),
                DragMode: DragMode.ToOption(),
                HoverMode: HoverMode.ToOption(),
                UIRevision: UIRevision.ToOption(),
                XAxis: XAxis.ToOption(),
                YAxis: YAxis.ToOption(),
                ZAxis: ZAxis.ToOption()
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.LinearAxis GetXAxis(
        this Plotly.NET.LayoutObjects.Scene obj,
        Plotly.NET.LayoutObjects.Scene scene
    )

        =>
            Plotly.NET.LayoutObjects.Scene.getXAxis(
                scene: scene
            );
    public static Plotly.NET.LayoutObjects.Scene SetXAxis(
        this Plotly.NET.LayoutObjects.Scene obj,
        Plotly.NET.LayoutObjects.LinearAxis xAxis
    )

        =>
            Plotly.NET.LayoutObjects.Scene.setXAxis(
                xAxis: xAxis
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.LinearAxis GetYAxis(
        this Plotly.NET.LayoutObjects.Scene obj,
        Plotly.NET.LayoutObjects.Scene scene
    )

        =>
            Plotly.NET.LayoutObjects.Scene.getYAxis(
                scene: scene
            );
    public static Plotly.NET.LayoutObjects.Scene SetYAxis(
        this Plotly.NET.LayoutObjects.Scene obj,
        Plotly.NET.LayoutObjects.LinearAxis yAxis
    )

        =>
            Plotly.NET.LayoutObjects.Scene.setYAxis(
                yAxis: yAxis
            ).Invoke(obj);
    public static Plotly.NET.LayoutObjects.LinearAxis GetZAxis(
        this Plotly.NET.LayoutObjects.Scene obj,
        Plotly.NET.LayoutObjects.Scene scene
    )

        =>
            Plotly.NET.LayoutObjects.Scene.getZAxis(
                scene: scene
            );
    public static Plotly.NET.LayoutObjects.Scene SetZAxis(
        this Plotly.NET.LayoutObjects.Scene obj,
        Plotly.NET.LayoutObjects.LinearAxis zAxis
    )

        =>
            Plotly.NET.LayoutObjects.Scene.setZAxis(
                zAxis: zAxis
            ).Invoke(obj);
}