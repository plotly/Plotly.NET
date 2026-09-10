### 6.0.0 - TBD

This version [removes C# interop from the core F# Plotly.NET library](https://github.com/plotly/Plotly.NET/issues/457), offloading those implementations directly to the native C# lib Plotly.NET.CSharp:

[Milestone link with all the fixed/closed issues](https://github.com/plotly/Plotly.NET/milestone/8)

**Breaking:** Plotly.NET assemblies are no longer strong-named. Maintaining a strong-named build chain has caused recurring friction (see [#452](https://github.com/plotly/Plotly.NET/issues/452), [#371](https://github.com/plotly/Plotly.NET/issues/371), and the broader discussion at [StephenCleary/AsyncEx#129](https://github.com/StephenCleary/AsyncEx/issues/129)) and forced us to maintain a re-packaged signed fork of Giraffe.ViewEngine ([giraffe-fsharp/Giraffe.ViewEngine#23](https://github.com/giraffe-fsharp/Giraffe.ViewEngine/pull/23)). Consumers that still need strong-named binaries can use [brutaldev/StrongNameSigner](https://github.com/brutaldev/StrongNameSigner) to sign assemblies post-build.

As a consequence, the html dsl dependency switches back from `Giraffe.ViewEngine.StrongName 2.0.0-alpha1` to upstream `Giraffe.ViewEngine 1.4.0`. The namespace is unchanged, so user code is not affected.

- Bump bundled plotly.js to **2.28.0**

- [#441](https://github.com/plotly/Plotly.NET/issues/441): **Encoded typed array support** — plotly.js 2.28 introduced a base64 representation for numeric arrays. Plotly.NET supports it for selected trace fields and chart constructors:

  - New `EncodedTypedArray` type (in `Plotly.NET`) carrying a base64 payload (`bdata`), a dtype tag (`dtype`), and an optional shape for multi-dimensional data. Supported dtypes: `Float64`, `Float32`, `Int32`, `UInt32`, `Int16`, `UInt16`, `Int8`, `UInt8`, `UInt8Clamped`.
  - Convenience constructors: `EncodedTypedArray.ofFloat64Array`, `ofFloat32Array`, `ofInt32Array`, `ofUInt32Array`, `ofInt16Array`, `ofUInt16Array`, `ofInt8Array`, `ofUInt8Array`, `ofUInt8ClampedArray` — all accept a 1-D .NET array and an optional `shape` parameter for multi-dimensional layouts.
  - Encoded fields added across the trace style modules (`Trace2DStyle`, `Trace3DStyle`, `TracePolarStyle`, `TraceGeoStyle`, `TraceMapboxStyle`, `TraceTernaryStyle`, `TraceCarpetStyle`, `TraceDomainStyle`, `TraceSmithStyle`), covering data arrays (`XEncoded`, `YEncoded`, `ZEncoded`, etc.), metadata arrays (`IdsEncoded`, `CustomDataEncoded`, `MultiTextEncoded`, `SelectedPointsEncoded`), error bar arrays (`ArrayEncoded`, `ArrayminusEncoded`), and trace-specific fields (e.g. `Q1Encoded`/`MedianEncoded`/`Q3Encoded` on BoxPlot, `OpenEncoded`/`HighEncoded`/`LowEncoded`/`CloseEncoded` on OHLC/Candlestick, `OpacityScaleEncoded` on Surface/Volume/IsoSurface, `IntensityEncoded`/`IEncoded`/`JEncoded`/`KEncoded` on Mesh3D, dimension `ValuesEncoded` on Splom/ParallelCoord).
  - Encoded overloads added to **selected F# `Chart` root functions** (e.g. `Chart.Scatter`, `Chart.Bar`, `Chart.Waterfall`, `Chart.Histogram`, `Chart.BoxPlot`, `Chart.Violin`, `Chart.OHLC`, `Chart.Candlestick`, `Chart.Splom`, `Chart.Histogram2D`, `Chart.Heatmap`, `Chart.Contour`, `Chart.Scatter3D`, `Chart.Surface`, `Chart.Mesh3D`, `Chart.Cone`, `Chart.StreamTube`, `Chart.Volume`, `Chart.IsoSurface`, `Chart.ScatterPolar`, `Chart.BarPolar`, `Chart.ScatterGeo`, `Chart.ChoroplethMap`, `Chart.ScatterMapbox`, `Chart.ChoroplethMapbox`, `Chart.DensityMapbox`, `Chart.ScatterTernary`, `Chart.Carpet`, `Chart.ScatterCarpet`, `Chart.ContourCarpet`, `Chart.ScatterSmith`, `Chart.Pie`, `Chart.FunnelArea`, `Chart.Sunburst`, `Chart.Treemap`, `Chart.Icicle`) and selected derived convenience helpers (e.g. `Chart.Point`, `Chart.Line`, `Chart.Spline`, `Chart.Bubble`, `Chart.Area`, `Chart.SplineArea`, `Chart.StackedArea`, `Chart.Range`, `Chart.Funnel`, `Chart.Histogram`, `Chart.StackedBar`, `Chart.PointDensity`, `Chart.PointPolar`, `Chart.PointGeo`, `Chart.PointMapbox`, `Chart.PointTernary`, `Chart.PointSmith`, `Chart.PointCarpet`, `Chart.Doughnut`).

  - Shared Sankey node/link objects accept encoded positions, source/target/value, and supported numeric metadata. Encoded values replace corresponding plain values when both are supplied in the same init/style call. Labels remain plain strings.
  - One-dimensional samples do not need a shape; matrix inputs use an explicitly shaped flat payload. Strings, arbitrary objects, decimal, and 64-bit integer encoding are outside the supported dtype set. Image pixels and helpers that compute from plain inputs (such as Pareto, Residual, and AnnotatedHeatmap) have no direct encoded overload.
  - The C# package exposes a selected subset of direct chart conveniences, documented in its release notes and the encoded-array guide. This release does not claim all-chart parity or measured encoding performance gains.

- **Sankey node alignment** — `StyleParam.SankeyNodeAlign` supports Left, Right, Center, and Justify through `SankeyNodes` and the F# / C# chart conveniences.
- **Virtual-WebGL** — existing `DisplayOptions.AdditionalHeadTags` can load the optional WebGL 1 virtualization script before plotly.js; the encoded-array guide shows the script ordering.

- [#500](https://github.com/plotly/Plotly.NET/pull/500): Internal refactor — split the monolithic `Chart.fs` into per-chart-family files (`Chart2D_Scatter.fs`, `Chart2D_Bar.fs`, etc.) for better maintainability. No API changes.

- **Set comparison charts** — new composite charts for visualizing set membership and intersections (in `ChartComposite`):

  - `Chart.Venn` draws a Venn diagram comparing two or three sets (`set1`, `set2`, optional `Set3`), annotating each region with its member count. Axes are locked to a 1:1 pixel ratio so the circles always render round, and colors/labels/text font are customizable.
  - `Chart.UpSet` draws an UpSet plot for an arbitrary number of sets: an intersection matrix, an intersection-size bar chart, and a set-size bar chart, with optional per-intersection attribute plots via `SetData`/`SetDataChartsTitle`.
  - Both take plain `#seq<string>` / `#seq<#seq<string>>` set inputs (treated as sets internally; duplicates ignored) and support the standard `UseDefaults` parameter.

- Dev tooling: target framework for build/test projects updated to `net10.0`; NuGet dependency updates (Newtonsoft.Json 13.0.4, Deedle 5.0.0, FSharp.Data 8.1.7, FAKE 6.1.4, Microsoft.NET.Test.Sdk 18.x).

### 5.1.0 - September 04 2024

Maintenance release to prevent Plotly.NET breaking for users that upgrade the DynamicObj dependency to >=3.0.0. DynamicObj is now pinned to the version range [2.0.0, 3.0.0) until we manage to make Plotly.NET work with the major changes in that lib.

### 5.0.0 - May 27 2024

Major release with lots of bug fixes, improvements, and upstream feature additions from plotly.js. Many changes are backwards-incompatible with previous versions.

[Milestone link with all the fixed/closed issues](https://github.com/plotly/Plotly.NET/milestone/5)

- [Improve Chart.Grid](https://github.com/plotly/Plotly.NET/pull/453):
  - Set individual subplot titles per input chart, fixes [#387](https://github.com/plotly/Plotly.NET/issues/387)
  - Fix positioning issues for some subplot types, fixes [#413](https://github.com/plotly/Plotly.NET/issues/413)

- [Add Chart.Pareto](https://github.com/plotly/Plotly.NET/pull/431). This contribution started with the [fslab hackathon 2023](https://github.com/orgs/fslaborg/projects/6) and was submitted by [@rockfaith75](https://github.com/rockfaith75) and [@smoothdeveloper](https://github.com/smoothdeveloper), thank you!

- Make Contours setting directly accessible on all supported traces, fixes [#426](https://github.com/plotly/Plotly.NET/issues/426)

- Allow DynamicObj for the args properties of update buttons, fixes [#414](https://github.com/plotly/Plotly.NET/issues/414)

- [Expand DisplayOptions](https://github.com/plotly/Plotly.NET/commit/488568c789fa2fa050fc55f5bff26a8780ba216e) to include direct fields for document title, description, charset, and favicon, fixes [#374](https://github.com/plotly/Plotly.NET/issues/374)

- Keep up with plotlyjs 2.x incremental updates. Note that v2.28+ will be on Plotly.NET 6.0, as some major changes are needed for supporting it properly (see [#441](https://github.com/plotly/Plotly.NET/issues/441))
  - v2.22:
    - [Implement multi legend support](https://github.com/plotly/Plotly.NET/issues/406)
  - v2.23:
    - [add `xref` and `yref` attributes for Legend and ColorBar](https://github.com/plotly/Plotly.NET/commit/a3e1abcfda7b316c704d477471be1294860b48b7)
  - v2.24:
    - [add pattern to multiple traces](https://github.com/plotly/Plotly.NET/commit/f75125e7e8514299bc794ddddbaee6370e5b420a)
  - v2.25:
    - [Add "Equal Earth" projection to geo subplots](https://github.com/plotly/Plotly.NET/commit/0ea7d3e0da77937e1b9d31bc4a6552d7499a660a)
    - [Complete bindings for geo projections](https://github.com/plotly/Plotly.NET/commit/0ea7d3e0da77937e1b9d31bc4a6552d7499a660a)
    - [Add options to include legends for shapes and newshape](https://github.com/plotly/Plotly.NET/commit/0ea7d3e0da77937e1b9d31bc4a6552d7499a660a)
  - v2.26:
    - [Add new autorange options](https://github.com/plotly/Plotly.NET/commit/92f92a5c9faef6710ef39438f8145183e3054575)
    - [Add [n]-sigma (std deviations) box plots](https://github.com/plotly/Plotly.NET/commit/d1c63b97eadd8576d649986ba62f1c4951eda137)
    - [Add "top left" & "top center" side options to legend title](https://github.com/plotly/Plotly.NET/commit/bebe507963c4af2a37ec6ad5afd960e1543c161a)
    - [Add "false" option to scaleanchor](https://github.com/plotly/Plotly.NET/commit/bad6d531501e37f27b16b11bf83d8711640a7605)
  - v2.27:
    - [Add insiderange to cartesian axes](https://github.com/plotly/Plotly.NET/commit/f7d24df0e76130a323c52f8f4d57cdbe8622d241)

**Additional extension package releases:**:

- [Plotly.NET.ImageExport (5.0.1 -> 6.0.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.ImageExport/RELEASE_NOTES.md)
- [Plotly.NET.Interactive (4.2.0 -> 5.0.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.Interactive/RELEASE_NOTES.md)
- [Plotly.NET.CSharp (0.11.1 -> 0.12.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.CSharp/RELEASE_NOTES.md)

### 4.2.0 - August 02 2023

This release makes Plotly.NET compatible with [LINQPad](https://www.linqpad.net/). 

Read more about this on the respective [pull request](https://github.com/plotly/Plotly.NET/pull/404).

Thanks a lot to [@Peter-B-](https://github.com/Peter-B-).

### 4.1.0 - July 14 2023

This is a maintenance release that aims to keep up with plotlyjs 2.x incremental updates.

The only major change is the usage of Giraffe.ViewEngine.StrongName instead of Giraffe.ViewEngine as html dsl.
This could be considered as a breaking change, but it's not because the Giraffe.ViewEngine.StrongName package is a drop-in replacement for Giraffe.ViewEngine with the only difference being a signed assembly

- Keep up with plotlyjs 2.x incremental updates:
  - v2.22+ will be on Plotly.NET 5.0, because it introduces breaking changes.
  - v2.21:
    - [Add texttemplate attribute to shape.label](https://github.com/plotly/Plotly.NET/commit/77fc2b0c8a9de28a4745230eddd6196eb818b716)
  - v2.20:
    - [Add automargin support to plot titles](https://github.com/plotly/Plotly.NET/commit/c82633a8ee0de60b5a1558050fc0b411a05686b1)
  - v2.19:
    - [Add labelalias to various axes](https://github.com/plotly/Plotly.NET/commit/f9e14fb616b1815487f002ebc35ad8bbde3b110f)
    - [Add label attribute to shapes](https://github.com/plotly/Plotly.NET/commit/2f94e879d23b0bdd259ec76cff99ae8946b375b2)

- misc fixes and improvements:
  - [Add json generation functions for GenericChart](https://github.com/plotly/Plotly.NET/commit/6a87f86c31f76b05e1b7be00f9034c175e90c72f)

**Additional extension package releases:**:

- [Plotly.NET.ImageExport (4.0.0 -> 5.0.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.ImageExport/RELEASE_NOTES.md)
- [Plotly.NET.Interactive (4.1.0 -> 4.2.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.Interactive/RELEASE_NOTES.md)
- [Plotly.NET.CSharp (0.10.0 -> 0.11.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.CSharp/RELEASE_NOTES.md)


### 4.0.0 - February 24 2023

[Milestone link with all the fixed/closed issues](https://github.com/plotly/Plotly.NET/milestone/4)

- [Add high level arg for base layer style to all mapbox charts](https://github.com/plotly/Plotly.NET/commit/5cd6c9966beb9bceebf31dc2d8269ee3b5d5d815)

- [Add ShowXAxisRangeSlider argument for Chart.OHLC and Chart.Candlestick](https://github.com/plotly/Plotly.NET/commit/86a810c1c63410527da740986494590ea3aaee91)

- [Add multicategory data support for 2D traces](https://github.com/plotly/Plotly.NET/commit/197cea162acd445d752837a55e29e5742d59d939)

- [Add high level camera projection args to all 3D chart apis](https://github.com/plotly/Plotly.NET/commit/d60b4540995f4b0a3c67c31464f9403337ff9c50)

- [Add missing Config params](https://github.com/plotly/Plotly.NET/commit/12cd47329fb0c161b386ba07f1e1210eea3e35fe)

- [Refactor DisplayOptions - An object to control the way Charts are displayed in generated HTML files](https://github.com/plotly/Plotly.NET/issues/293):
    - Add various functions to manipulate DisplayOptions, Refactor DisplayOptions as DynamicObj (again)
    - Add `PlotlyJSReference` type and logic to handle various ways of referencing plotly.js in HTML output:
        - `Full`: Include the full plotly.js source code. The currently supported plotly.js version is now included as embedded resource in the package. HTML files using this option are self-contained and can be used offline.
        - `CDN`: The default. uses a script tag in the head of the generated HTML to load plotly.js from a CDN.
        - `Require`: Use requirejs to load plotly. This option is now used in Plotly.NET.Interactive. Unnecessary usage of require.js is now removed from all other options but this.
        - `NoReference`: Don't include any plotly.js reference. Useful if you want to embed the output into another page that already references plotly.

- [Use Giraffe.ViewEngine as html dsl](https://github.com/plotly/Plotly.NET/pull/363)

- Keep up with plotlyjs 2.x incremental updates:
    - v2.18:
        - [Add sync tickmode option](https://github.com/plotly/Plotly.NET/commit/c69a55c534cdd95e9e27bee8a4e5d77b262e338f)
    - v2.17:
        - [Add shift and autoshift to cartesian y axes to help avoid overlapping of multiple axes](https://github.com/plotly/Plotly.NET/commit/9f7edb8281ba87a2c122d99604af32d17efec168)
        - [Introduce group attributes for scatter trace i.e. alignmentgroup, offsetgroup, scattermode and scattergap](https://github.com/plotly/Plotly.NET/commit/67378a3fd8c007cddb2c1e11b545f57e9874fc2d)
        - [Add marker.cornerradius attribute to treemap trace](https://github.com/plotly/Plotly.NET/commit/8ad20db7ae032b2751882fe25d389c39fb327669)
    - v2.16:
        - [Add bounds to mapbox subplots](https://github.com/plotly/Plotly.NET/commit/046e3c472447c720ec7896f2109895028dba471c)
        - [Add clustering options to scattermapbox](https://github.com/plotly/Plotly.NET/commit/0ee67e3e9251515d94a2f40858ed4fdd7398e104)
    - v2.15:
        - [Add entrywidth and entrywidthmode to legend](https://github.com/plotly/Plotly.NET/commit/b9dffc36fe2a3d3da470d82e2bd1ae6ca8d47a8b)
        - [Add minreducedwidth and minreducedheight to layout for increasing control over automargin](https://github.com/plotly/Plotly.NET/commit/9be3f621959593c7b2b16213affe9877449c194c)
        - [Add two new arrow marker symbols](https://github.com/plotly/Plotly.NET/commit/61d70c2565f604a233989eb8c4147e50002745d5)
        - [Add angle, angleref and standoff to marker and add backoff to line](https://github.com/plotly/Plotly.NET/commit/7b8ff1a1983dabff4a631e3de5b25055e14ecdff)
    - v2.14:
        - [Add editSelection option to config](https://github.com/plotly/Plotly.NET/commit/5744e15b14e90007c94c648e2302905fb6dbff19)
        - [Add support for sankey links with arrows](https://github.com/plotly/Plotly.NET/commit/99d635a06e2eb9aaebacfc0703f2449c309e4a63)
    - v2.13:
        - [Add flaglist options including "left", "right", "top", "bottom", "width" and "height" to control the direction of automargin on cartesian axes](https://github.com/plotly/Plotly.NET/commit/5c7cadd4054e09abca58f36389f6bc12cb99f118)
        - [Add selections, newselection and activeselection layout attributes to have persistent and editable selections over cartesian subplots](https://github.com/plotly/Plotly.NET/commit/1042e9ab430e92a0995e52b576cf2bcc7ed6532a)
    - v2.12:
        - [Implement various options to position and style minor ticks and grid lines on cartesian axis types](https://github.com/plotly/Plotly.NET/commit/7ed80ebba4a8d14e387f471f6d489afbf15b6916)
        - [add griddash axis property to cartesian, polar, smith, ternary and geo subplots and add griddash and minorgriddash to carpet trace](https://github.com/plotly/Plotly.NET/commit/6711ecfffd172ce7bbf7ee43b50d1a57f3c19013)
    - v2.10: 
        - [Add support to use version 3 of MathJax and add typesetMath attribute to config](https://github.com/plotly/Plotly.NET/commit/d18345786d69c5b1864948991042a9b06f0121fc)
        - [Add fill pattern to scatter and derived traces / chart APIs](https://github.com/plotly/Plotly.NET/commit/99fcf65fa0515f1a5c65cace2015545ba2980da3)
    - v2.9: 
        - [add ticklabelstep attribute to axes and colorbars](https://github.com/plotly/Plotly.NET/commit/5101dc57a5f43732e642536aedba1289e76d419a)
    - v2.8: 
        - [add horizontal color bar options](https://github.com/plotly/Plotly.NET/commit/f51c61134e1f195edee91a5fcc922d43eb3360e5)

### 3.0.1 - August 26 2022
Minor fixes for Object abstractions:

- Use correct Optional Parameter Attributes everywhere. This affects object abstractions for the following objects, but should be backwards compatible:
    - Annotation
    - LayoutImage
    - Pattern
    - TableCells
- `FontSelectionStyle.init` now correctly returns a FontSelectionStyle instead of unit

### 3.0.0 - June 15 2022

This release adopts strong assembly naming. 
This might cause backwards incompatibility and therefore results in an early major version increase. 
For more insights why we do this, check out the conversation on this [issue](https://github.com/plotly/Plotly.NET/issues/175)

Other additions:

- [fix legend xanchor plotly attribute name](https://github.com/plotly/Plotly.NET/commit/0d612f9c847609c8f676ade0acfada11f137d833) ([#289](https://github.com/plotly/Plotly.NET/issues/289))
