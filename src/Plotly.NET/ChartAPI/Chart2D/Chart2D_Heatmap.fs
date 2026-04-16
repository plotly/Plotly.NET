namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D_Heatmap =
    [<Extension>]
    type Chart =
        [<Extension>]
        static member internal renderHeatmapTrace (useDefaults: bool) (useWebGL: bool) (style: Trace2D -> Trace2D) =
            if useWebGL then
                Trace2D.initHeatmapGL style |> GenericChart.ofTraceObject useDefaults
            else
                Trace2D.initHeatmap style |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        /// </summary>
        /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
        /// <param name="X">Sets the x coordinates</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y coordinates</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Heatmap
            (
                zData: seq<#seq<#IConvertible>>,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let reverseYAxis =
                defaultArg ReverseYAxis false

            let style =
                Trace2DStyle.Heatmap(
                    Z = zData,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth,
                    ?Transpose = Transpose
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderHeatmapTrace useDefaults useWebGL style
            |> fun c ->
                if reverseYAxis then
                    c |> Chart.withYAxis (LinearAxis.init (AutoRange = StyleParam.AutoRange.Reversed))
                else
                    c

        /// <summary>
        /// Creates a heatmap from an encoded z matrix and optional encoded axes.
        /// </summary>
        /// <param name="zEncoded">Sets the 2-dimensional z data as an encoded typed array.</param>
        /// <param name="xEncoded">Sets the x coordinates as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Heatmap
            (
                zEncoded: EncodedTypedArray,
                ?xEncoded: EncodedTypedArray,
                ?yEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let reverseYAxis =
                defaultArg ReverseYAxis false

            let style =
                Trace2DStyle.Heatmap(
                    ZEncoded = zEncoded,
                    ?XEncoded = xEncoded,
                    ?YEncoded = yEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth,
                    ?Transpose = Transpose
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderHeatmapTrace useDefaults useWebGL style
            |> fun c ->
                if reverseYAxis then
                    c |> Chart.withYAxis (LinearAxis.init (AutoRange = StyleParam.AutoRange.Reversed))
                else
                    c

        /// <summary>
        /// Creates a heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        /// </summary>
        /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
        /// <param name="colNames">Sets names for each column (as x coordinates)</param>
        /// <param name="rowNames">Sets names for each row (as y coordinates)</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Heatmap
            (
                zData: seq<#seq<#IConvertible>>,
                colNames: seq<string>,
                rowNames: seq<string>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            Chart.Heatmap(
                zData = zData,
                X = colNames,
                Y = rowNames,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?XGap = XGap,
                ?YGap = YGap,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?ZSmooth = ZSmooth,
                ?Transpose = Transpose,
                ?UseWebGL = UseWebGL,
                ?ReverseYAxis = ReverseYAxis,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a annotated heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        ///
        /// The annotated heatmap additionally contains annotation text on each datum.
        /// </summary>
        /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
        /// <param name="annotationText">Sets the text to display as annotation for each datum.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member AnnotatedHeatmap
            (
                zData: seq<#seq<#IConvertible>>,
                annotationText: seq<#seq<string>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?XGap: int,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let reverseYAxis =
                defaultArg ReverseYAxis false

            let dims = Seq.length zData
            let dims2 = Seq.length annotationText

            if dims <> dims2 then
                failwith "incompatible dims"

            let style =
                Trace2DStyle.Heatmap(
                    Z = zData,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?XGap = XGap,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?YGap = YGap,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth,
                    ?Transpose = Transpose
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderHeatmapTrace useDefaults useWebGL style
            |> fun c ->
                if reverseYAxis then
                    c |> Chart.withYAxis (LinearAxis.init (AutoRange = StyleParam.AutoRange.Reversed))
                else
                    c
            |> Chart.withAnnotations (
                annotationText
                |> Seq.mapi (fun y inner ->
                    inner |> Seq.mapi (fun x text -> Annotation.init (x, y, Text = (string text), ShowArrow = false)))
                |> Seq.concat
            )


        /// <summary>
        /// Creates a annotated heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        ///
        /// The annotated heatmap additionally contains annotation text on each datum.
        /// </summary>
        /// <param name="dataAnnotations">Sets the 2-dimensional z data, which will be visualized with the color scale together with the respective annotation text.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member AnnotatedHeatmap
            (
                dataAnnotations: seq<#seq<#IConvertible * string>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?XGap: int,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            let zData =
                dataAnnotations |> Seq.map (Seq.map fst)

            let annotationText =
                dataAnnotations |> Seq.map (Seq.map snd)

            Chart.AnnotatedHeatmap(
                zData = zData,
                annotationText = annotationText,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?X = X,
                ?MultiX = MultiX,
                ?XGap = XGap,
                ?Y = Y,
                ?MultiY = MultiY,
                ?YGap = YGap,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?ZSmooth = ZSmooth,
                ?Transpose = Transpose,
                ?UseWebGL = UseWebGL,
                ?ReverseYAxis = ReverseYAxis,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Display an image, i.e. data on a 2D regular raster. By default, when an image is displayed in a subplot, its y axis will be reversed (ie. `autorange: 'reversed'`), constrained to the domain (ie. `constrain: 'domain'`) and it will have the same scale as its x axis (ie. `scaleanchor: 'x,`) in order for pixels to be rendered as squares.
        /// </summary>
        /// <param name="Z">A 2-dimensional array in which each element is an array of 3 or 4 numbers representing a color.</param>
        /// <param name="Source">Specifies the data URI of the image to be visualized. The URI consists of "data:image/[&lt;media subtype&gt;][;base64],&lt;data&gt;"</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="ColorModel">Color model used to map the numerical color components described in `z` into colors. If `source` is specified, this attribute will be set to `rgba256` otherwise it defaults to `rgb`.</param>
        /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
        /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Image
            (
                ?Z: seq<#seq<#seq<int>>>,
                ?Source: string,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Ids: seq<#IConvertible>,
                ?ColorModel: StyleParam.ColorModel,
                ?ZMax: StyleParam.ColorComponentBound,
                ?ZMin: StyleParam.ColorComponentBound,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            Trace2D.initImage (
                Trace2DStyle.Image(
                    ?Z = Z,
                    ?Source = Source,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Ids = Ids,
                    ?ColorModel = ColorModel,
                    ?ZMax = ZMax,
                    ?ZMin = ZMin,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Display an image, i.e. data on a 2D regular raster. By default, when an image is displayed in a subplot, its y axis will be reversed (ie. `autorange: 'reversed'`), constrained to the domain (ie. `constrain: 'domain'`) and it will have the same scale as its x axis (ie. `scaleanchor: 'x,`) in order for pixels to be rendered as squares.
        /// </summary>
        /// <param name="z">A 2-dimensional array containing Plotly.NETs ARGB color object.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
        /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Image
            (
                z: seq<#seq<ARGB>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Ids: seq<#IConvertible>,
                ?ZMax: StyleParam.ColorComponentBound,
                ?ZMin: StyleParam.ColorComponentBound,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let z' =
                z
                |> Seq.map (
                    Seq.map (fun argb ->
                        seq {
                            int argb.R
                            int argb.G
                            int argb.B
                            int argb.A
                        })
                )


            Trace2D.initImage (
                Trace2DStyle.Image(
                    Z = z',
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Ids = Ids,
                    ColorModel = StyleParam.ColorModel.RGBA,
                    ?ZMax = ZMax,
                    ?ZMin = ZMin,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a 2D contour plot, which shows the contour lines of a 2D numerical array z, i.e. interpolated lines of isovalues of z.
        ///
        /// A contour line (also isoline, isopleth, or isarithm) of a function of two variables is a curve along which the function has a constant value, so that the curve joins points of equal value
        ///
        /// The data from which contour lines are computed is set in `z`. Data in `z` must be a 2D array of numbers. Say that `z` has N rows and M columns, then by default, these N rows correspond to N y coordinates (set in `y` or auto-generated) and the M columns correspond to M x coordinates (set in `x` or auto-generated). By setting `transpose` to "true", the above behavior is flipped.
        /// </summary>
        /// <param name="zData">Sets the z data which is used for computing the contour lines.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="FillColor">Sets the fill color if `contours.type` is "constraint". Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Contour
            (
                zData: seq<#seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Transpose: bool,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?FillColor: Color,
                ?NContours: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let showContourLines =
                defaultArg ShowContourLines false

            let contourLinesWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLinesWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            Trace2D.initContour (
                Trace2DStyle.Contour(
                    Z = zData,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Transpose = Transpose,
                    ?FillColor = FillColor,
                    ?NContours = NContours,
                    Contours = contours,
                    Line = contourLines
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a contour chart from an encoded z matrix and optional encoded axes.
        /// </summary>
        /// <param name="zEncoded">Sets the 2-dimensional z data as an encoded typed array.</param>
        /// <param name="xEncoded">Sets the x coordinates as an encoded typed array.</param>
        /// <param name="yEncoded">Sets the y coordinates as an encoded typed array.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines.</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values.</param>
        /// <param name="ContoursOperation">Sets the constraint operation.</param>
        /// <param name="ContoursType">Sets the contour representation type.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels.</param>
        /// <param name="ContoursStart">Sets the starting contour level value.</param>
        /// <param name="ContoursEnd">Sets the end contour level value.</param>
        /// <param name="Contours">Sets the styles of the contours.</param>
        /// <param name="FillColor">Sets the fill color if `contours.type` is "constraint".</param>
        /// <param name="NContours">Sets the maximum number of contour levels.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Contour
            (
                zEncoded: EncodedTypedArray,
                ?xEncoded: EncodedTypedArray,
                ?yEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Transpose: bool,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?FillColor: Color,
                ?NContours: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let showContourLines =
                defaultArg ShowContourLines false

            let contourLinesWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLinesWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            Trace2D.initContour (
                Trace2DStyle.Contour(
                    ZEncoded = zEncoded,
                    ?XEncoded = xEncoded,
                    ?YEncoded = yEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Transpose = Transpose,
                    ?FillColor = FillColor,
                    ?NContours = NContours,
                    Contours = contours,
                    Line = contourLines
                )
            )
            |> GenericChart.ofTraceObject useDefaults

