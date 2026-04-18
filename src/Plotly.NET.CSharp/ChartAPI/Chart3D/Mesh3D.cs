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
        /// Visualizes a 3D mesh.
        ///
        /// Draws sets of triangles with coordinates given by three 1-dimensional arrays in `x`, `y`, `z` and
        ///
        /// (1) a sets of `i`, `j`, `k` indices or
        ///
        /// (2) Delaunay triangulation or
        ///
        /// (3) the Alpha-shape algorithm or
        ///
        /// (4) the Convex-hull algorithm
        /// </summary>
        /// <param name="x">Sets the X coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="y">Sets the Y coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="z">Sets the Z coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="I">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "first" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `i[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `i` represents a point in space, which is the first vertex of a triangle.</param>
        /// <param name="J">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "second" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `j[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `j` represents a point in space, which is the second vertex of a triangle.</param>
        /// <param name="K">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "third" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `k[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `k` represents a point in space, which is the third vertex of a triangle.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Color">Sets the color of the whole mesh</param>
        /// <param name="Contour">Sets the style and visibility of contours</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
        /// <param name="TriangulationAlgorithm">Determines how the mesh surface triangles are derived from the set of vertices (points) represented by the `x`, `y` and `z` arrays, if the `i`, `j`, `k` arrays are not supplied.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Mesh3D<XType, YType, ZType, IType, JType, KType, TextType>(
            IEnumerable<XType> x, 
            IEnumerable<YType> y, 
            IEnumerable<ZType> z, 
            Optional<IEnumerable<IType>> I = default, 
            Optional<IEnumerable<JType>> J = default, 
            Optional<IEnumerable<KType>> K = default, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<Color> Color = default, 
            Optional<Contour> Contour = default, 
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default, 
            Optional<ColorBar> ColorBar = default, 
            Optional<bool> FlatShading = default,
            Optional<StyleParam.TriangulationAlgorithm> TriangulationAlgorithm = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where IType : IConvertible
            where JType : IConvertible
            where KType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart3D_Surface.Chart.Mesh3D<XType, YType, ZType, IType, JType, KType, TextType>(
                    x: x,
                    y: y,
                    z: z,
                    I: I.ToOption(),
                    J: J.ToOption(),
                    K: K.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    Color: Color.ToOption(),
                    Contour: Contour.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    FlatShading: FlatShading.ToOption(),
                    TriangulationAlgorithm: TriangulationAlgorithm.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
}
