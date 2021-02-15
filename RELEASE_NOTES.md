### 2.0.0 - TBD

**Fsharp.Plotly joined the Plotly family and will from now on be released under `Plotly.NET`**

 * [Add Rangesliders for linear Axis](https://github.com/plotly/Plotly.NET/commit/544641492195b1938697721b72814e0187a6c979)
 * [Improve jupyter notebook integration](https://github.com/plotly/Plotly.NET/commit/e9560656bbc8dbf767c9eb6ca35f321c98195238)
 * [Updated Violin Chart](https://github.com/plotly/Plotly.NET/commit/4d3afc527b11cd2f5a18c1d9876ad4e3f83beb02)
 * Add Chart.withColorBar and Chart.withColorBarStyle to change the appearance of colorbars
 * [Add Stackgroup related parameters to all charts derived from the scatter trace]()
 * [Refactor Chart.Stack]():
   * new Charts: 
     * Chart.Grid: Uses the grid object of plotly.js to generate various types of subplot grids
     * Chart.SingleStack: Basically Chart.Grid with one Column
 * [Add Sunburst Chart](https://github.com/plotly/Plotly.NET/commit/3c6cd67219c6cd81f294f0453c62fd8b70c1e689)
 * [Add Treemap Chart](https://github.com/plotly/Plotly.NET/commit/70b86d0cf2e3c446d7d1c501871999a88222b5bf)
 * [Add OHLC Chart](https://github.com/plotly/Plotly.NET/commit/0d787cf070ea10892dfd77d42ef6a162f360408d)
 * [Add option to render all charts derived from the scatter trace type via WebGL as scattergl trace]()
 * [Add Waterfall Chart](https://github.com/plotly/Plotly.NET/commit/4d93598aa03a965abc75007aea2885ff4d282059)
 * [Add ScatterGeo, PointGeo, LineGeo Charts](https://github.com/plotly/Plotly.NET/commit/4865c5ac0356bfb2465422a2352e18c4fce018c3)
 * [Add new `Figure` type to interop with Dash/Kaleido](https://github.com/plotly/Plotly.NET/commit/918adc20843d8ca1194e4511add09ba3cab5415f)
 * [Greatly improve C# interop](https://github.com/plotly/Plotly.NET/commit/c1ed1be0234a4fcfab921acb43f1c0cf128cc233)
 * [Add kernel formatting extension for dotnet interactive notebooks](https://github.com/plotly/Plotly.NET/commit/fa990371dd68ec1f5784288ccd9e2d28d761ac93) (thanks [@WalternativeE](https://github.com/WalternativE))
 * [Add chart templates and related functions](https://github.com/plotly/Plotly.NET/commit/62f297649320783ea0e64725ff4703bb225268d0)
 * [Fix multiple chart htmls not correctly rendering on the same page](https://github.com/plotly/Plotly.NET/commit/ae6680049b02abd259c8989d1abd55e4665445c8)
 * [**Breaking:** Fix keys values order for bar charts](https://github.com/plotly/Plotly.NET/commit/ccb6af7df8bc071f2a0baf020805fc25d2df70b4)
 * [**Possibly breaking:** target netstandad 2.1](https://github.com/plotly/Plotly.NET/commit/0fd6d42d755c060f42cf48465cbcfd02e0a07088)
 * [Add fslab chart template](https://github.com/plotly/Plotly.NET/commit/efde9d82e14319b8c06081aae5568c2eae76ae6b)
 * [Add Legend creation properties and related functions](https://github.com/plotly/Plotly.NET/commit/a96af40901c627817ebd75b517b872f4cc6a941d)


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
