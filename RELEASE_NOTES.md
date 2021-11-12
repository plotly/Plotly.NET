### 2.0.0 - TBD

**Fsharp.Plotly joined the Plotly family and will from now on be released under `Plotly.NET`**

**Breaking changes compared to 1.x.x / previous 2.0.0 alpha/beta/preview versions:**

 * [**Breaking:** Fix keys values order for bar charts](https://github.com/plotly/Plotly.NET/commit/ccb6af7df8bc071f2a0baf020805fc25d2df70b4)
 * [**Breaking: fix color assignment of pie and doughnut charts**](https://github.com/plotly/Plotly.NET/commit/2bbb35ad5d44c6de1bf79b23b7b0a64effa8bdf9)
 * **Breaking:** Chart methods now have static type annotations, which may lead to incompatibilities in some cases
 * **Breaking:** Rename ChartDescription type: `Plotly.NET.ChartDescription.Description` -> `Plotly.NET.ChartDescription`
 * [**Possibly breaking:** target netstandad 2.0](https://github.com/plotly/Plotly.NET/commit/0fd6d42d755c060f42cf48465cbcfd02e0a07088)
 * [**Possibly breaking:** target net5.0 as well](https://github.com/plotly/Plotly.NET/commit/4f0633f0481df91cb2e310da61175d7ddb26ee11)
 * **Breaking:** Many functions of the Chart API have been changed to be in lower camelCase (e.g `Chart.Show` -> `Chart.show`, `Chart.withX_Axis` -> `Chart.withXAxis`, etc.) see full set of changes in that category [here](https://github.com/plotly/Plotly.NET/pull/114), thanks [@WhiteBlackGoose](https://github.com/WhiteBlackGoose)
 * **Breaking**: Many Parameters of `init` and `style` functions have been changed to PascalCase, this is ongoing and will be breaking eregularily until unified.
 * SubPlotIds are now unified under the `StyleParam.SubPlotId` type which is used to assign subplots anchors (e.g. scenes for 3d charts, polar for polar charts) This change will be reflectes in trace type modeling in a later release.
 * **Breaking**: Layout and trace object abstractions are now in new namespaces: `Plotly.NET.LayoutObjects`/`Plotly.NET.TraceObjects`
 * **Breaking**: every argument/parameter concerned with color has been changed to use the new Color type isntead of a plain string.
 * **Breaking**: The underlying plotly.js version is now correctly pinned at 2.42
 * [**Breaking**: POC of multivalue support (breaks Bar charts)](https://github.com/plotly/Plotly.NET/commit/c5f6fbb6e3ac14bae06192d696dcf8637dcaa21e)

**Major Additions:**

 * [Add kernel formatting extension for dotnet interactive notebooks](https://github.com/plotly/Plotly.NET/commit/fa990371dd68ec1f5784288ccd9e2d28d761ac93) (thanks [@WalternativeE](https://github.com/WalternativE))
 * [Greatly improve C# interop](https://github.com/plotly/Plotly.NET/commit/c1ed1be0234a4fcfab921acb43f1c0cf128cc233)
 * [Add the Plotly.NET.ImageExport project](https://github.com/plotly/Plotly.NET/pull/94) - Render Plotly.NET charts as static images
 * [Use a statically typed color representation that is compatible with all ways plotly uses colors](https://github.com/plotly/Plotly.NET/commit/19763db129b9160906964d9831ff3f67279926cc) - thanks [@muehlhaus](https://github.com/muehlhaus)
 * [Add a Templating and global default system](https://github.com/plotly/Plotly.NET/pull/237)

**Plotly.NET now has 100% trace coverage! New Charts:**

 * Refactor Chart.Stack into:
     * Chart.Grid: Uses the grid object of plotly.js to generate various types of subplot grids
     * Chart.SingleStack: Basically Chart.Grid with one Column
 * [Add Sunburst Chart](https://github.com/plotly/Plotly.NET/commit/3c6cd67219c6cd81f294f0453c62fd8b70c1e689)
 * [Add Treemap Chart](https://github.com/plotly/Plotly.NET/commit/70b86d0cf2e3c446d7d1c501871999a88222b5bf)
 * [Add OHLC Chart](https://github.com/plotly/Plotly.NET/commit/0d787cf070ea10892dfd77d42ef6a162f360408d)
 * [Add option to render all charts derived from the scatter trace type via WebGL as scattergl trace](https://github.com/plotly/Plotly.NET/commit/75c7a32bb5a72f68cbbea9fd3872e77c30a180ec)
 * [Add Waterfall Chart](https://github.com/plotly/Plotly.NET/commit/4d93598aa03a965abc75007aea2885ff4d282059)
 * [Add ScatterGeo, PointGeo, LineGeo Charts](https://github.com/plotly/Plotly.NET/commit/4865c5ac0356bfb2465422a2352e18c4fce018c3)
 * [Add HeatmapGL](https://github.com/plotly/Plotly.NET/commit/b39f4705b86653aebf8ccb0fadf5d12b89150848), thanks [@Joott](https://github.com/Joott)]
 * [Add Funnel Chart](https://github.com/plotly/Plotly.NET/commit/aae24a780e88d74786f25854559ff44c7350d035), thanks [@Joott](https://github.com/Joott)]
 * [Add FunnelArea Chart](https://github.com/plotly/Plotly.NET/commit/126f5513afcc259ba2945ffe32aaeb987a1ded71), thanks [@Joott](https://github.com/Joott)
 * [Add all Mapbox Charts](https://github.com/plotly/Plotly.NET/pull/93):
    * ScatterMapbox (and derived PointMapbox and LineMapbox)
    * ChoroplethMapbox
    * DensityMapbox
 * [Add all Polar Charts and related layout properties](https://github.com/plotly/Plotly.NET/pull/113) :
    * ScatterPolar (and derived PointPolar, LinePolar, SplinePolar, BubblePolar)
    * BarPolar
    * Polar object
    * Angular and RadialAxis
 * [Add missing 3D charts and related layout options](https://github.com/plotly/Plotly.NET/pull/125)
    * Scatter3d derived Point3d, Line3d, Bubble3d
    * Cone
    * StreamTube
    * Volume
    * IsoSurface
    * Full Scene support
 * [Add Ternary Charts (ScatterTernary and derived PointTernary, LineTernary)](https://github.com/plotly/Plotly.NET/pull/184):
 * [Add image charts](https://github.com/plotly/Plotly.NET/pull/188)
 * [Add all carpet charts](https://github.com/plotly/Plotly.NET/pull/201)
    * Carpet
    * ScatterCarpet (and derived PointCarpet, LineCarpet, SplineCarpet, BubbleCarpet)
    * ContourCarpet
 * [Add indicator charts](https://github.com/plotly/Plotly.NET/pull/207)
 * [Add icicle charts](https://github.com/plotly/Plotly.NET/pull/210)

**Minor Additions/fixes:**

 * [Add Rangesliders for linear Axis](https://github.com/plotly/Plotly.NET/commit/544641492195b1938697721b72814e0187a6c979)
 * [Improve jupyter notebook integration](https://github.com/plotly/Plotly.NET/commit/e9560656bbc8dbf767c9eb6ca35f321c98195238)
 * [Updated Violin Chart](https://github.com/plotly/Plotly.NET/commit/4d3afc527b11cd2f5a18c1d9876ad4e3f83beb02)
 * [Add Chart.withColorBar and Chart.withColorBarStyle to change the appearance of colorbars](https://github.com/plotly/Plotly.NET/commit/d73145acf388df727a7cb1876885d758b463bd7f)
 * [Add Stackgroup related parameters to all charts derived from the scatter trace](https://github.com/plotly/Plotly.NET/commit/75c7a32bb5a72f68cbbea9fd3872e77c30a180ec)
 * [Add new `Figure` type to interop with Dash/Kaleido](https://github.com/plotly/Plotly.NET/commit/918adc20843d8ca1194e4511add09ba3cab5415f)
 * [Add chart templates and related functions](https://github.com/plotly/Plotly.NET/commit/62f297649320783ea0e64725ff4703bb225268d0)
 * [Fix multiple chart htmls not correctly rendering on the same page](https://github.com/plotly/Plotly.NET/commit/ae6680049b02abd259c8989d1abd55e4665445c8)
 * [Add fslab chart template](https://github.com/plotly/Plotly.NET/commit/efde9d82e14319b8c06081aae5568c2eae76ae6b)
 * [Add Legend creation properties and related functions](https://github.com/plotly/Plotly.NET/commit/a96af40901c627817ebd75b517b872f4cc6a941d)
 * [Add Chart.withWithAdditionalHeadTags, Chart.withHeadTags, Chart.WithMathTex extensions for manipulating display options](https://github.com/plotly/Plotly.NET/commit/6ae1212d18a5282f631723342a685ed3b4280315)
 * [Fix Annotation type annotations]((https://github.com/plotly/Plotly.NET/commit/a920492ac03e333c52766928a3771357ca9f669b)) ([#78](https://github.com/plotly/Plotly.NET/issues/78))
 * [Add name option with defaults for the upper and lower bound traces in range charts](https://github.com/plotly/Plotly.NET/commit/3cbb5f116b8b3b0467e8a88707858252780a39f0)
 * [Add functionality and docs for using GeoJSON with geo charts](https://github.com/plotly/Plotly.NET/commit/a68db7de0109e6714aeb044b806be2796f2bd400) [#86](https://github.com/plotly/Plotly.NET/issues/86)
 * [Add functionality to customize Lower and upper labels of range charts](https://github.com/plotly/Plotly.NET/commit/86357cf05e9cfe2f264369255dcf90e31861275a) [#83](https://github.com/plotly/Plotly.NET/issues/86)
 * [Allow custom font family](https://github.com/plotly/Plotly.NET/commit/b99e34c1890989d8b07dbc6b388618572372617e), thanks [@pirrmann](https://github.com/pirrmann)]
 * [Use custom attributes for all parameters for better C# interop](https://github.com/plotly/Plotly.NET/commit/9dfed2c50c69c8f72ca8131b89a8cf20a229bbd0)
 * [Add ToString() and Convert() instance members to StyleParams for better C# interop](https://github.com/plotly/Plotly.NET/commit/cf8658153d6a1af98afe33e41f3735222aed6706)
 * [Improve Trace type system](https://github.com/plotly/Plotly.NET/commit/096f4bf7382441b153687835c3d51c9e2e3497ec)
 * [Fix incorrect scale used in image export](https://github.com/plotly/Plotly.NET/commit/893cf02a5700ce562c6d67470883123a2d84c3c1) - thanks [@pirrmann](https://github.com/pirrmann)]
 * [Improve Chart.Grid](https://github.com/plotly/Plotly.NET/pull/212)
 * [Improve Distribution Charts](https://github.com/plotly/Plotly.NET/pull/220)
 * [fix data property of chart templates](https://github.com/plotly/Plotly.NET/pull/233)
 * [fix rangeslider props](https://github.com/plotly/Plotly.NET/commit/c1789c2197ee19524e543e022070a7c60adb9e06)

**Other notable changes**

These changes do not necessarily reflect changes on the usage layer, but should be attributed/noted nonetheless:

 * 149 tests for html output generation have been added by [@WhiteBlackGoose](https://github.com/WhiteBlackGoose) via [#104](https://github.com/plotly/Plotly.NET/issues/104), thanks!

### 1.2.2 - Apr 9 2020
 * [Opening Charts is now more or less OS agnostic](https://github.com/plotly/Plotly.NET/commit/f6e3dceade085e43e7e56b478b9cf7b533a4fe55)


### 1.2.1 - Apr 8 2020
 * [Improve C# interop](https://github.com/plotly/Plotly.NET/commit/4bc8a45d4cdea3961c15429680923927b47a2840) by using null as default parameter for optional parameters in chart extensions and requiring qualified access for style parameters


### 1.2.0 - Feb 17 2020
Additional functionality:
 * [Various marker style options](https://github.com/plotly/Plotly.NET/commit/11a80f94d9fb9f94a4504073955e009746e9fd0d)
 * [Config support](https://github.com/plotly/Plotly.NET/commit/70998edd586553b40a8b95de56d86639902a5420)
 * [Chart.Stack works now with both 2D and 3D Charts](https://github.com/plotly/Plotly.NET/commit/db7ce675a73f37598590f24ac99c246fce78759e)

Additional plots:
 * [Parallel Categories](https://github.com/plotly/Plotly.NET/commit/adaf9e361d9fe8ac3b51a8832ffbb024cd3d78dc)
 * [Stacked Area](https://github.com/plotly/Plotly.NET/commit/612666883ac07f21350d3da3d6749387a9cb1f4d)
 * [Tables](https://github.com/plotly/Plotly.NET/commit/6bfc9e34072c486546ad3fbf118f027e57c6114c)

Additional functionality and plots thanks to external open source contributors:
 * You can now [add descriptional text to the chart html](https://github.com/plotly/Plotly.NET/commit/bd99364d1fcfe894c772ad2fe9c59b31a37dc547) (thanks @kkkmail)
 * [Sankey and Candlestick Charts are now available](https://github.com/plotly/Plotly.NET/commit/f1e873d7e2c2cc5a60c2365058880419668d1804) (thanks @fwaris)


### 1.1.2 - Aug 16 2018
* Support .net framework 4.7
* Minor improvments 

### 1.1.1 - Jun 22 2018
* Support netStandard 2.0
* Add new chart (SLOMP)

### 1.1.0 - Jan 14 2018
* Add new charts
* Add multiple axis support
* Add subplot support


### 1.0.4 - Oct 17 2017
* Fixed nuget package

### 1.0.3 - Sep 06 2017
* Add different ways to modify Charts


### 1.0.2 - Sep 12 2016
* Add Scatter3d line plots
* Add 3d Surface plots

### 1.0.1 - July 5 2016
* More awesome stuff coming...
* More 3d-Charts
* Multiple axis support
* Shapes 

#### 0.5.0-beta - June 22 2016
* Documentation and tutorial
* TraceObjects with interface implementation
* Extensions for Chart module

#### 0.0.1-beta - May 13 2016
* Initial release
