### 1.2.3 - May 31 2020
 * [Add Rangesliders for linear Axis](https://github.com/muehlhaus/FSharp.Plotly/commit/544641492195b1938697721b72814e0187a6c979)
 * [Improve jupyter notebook integration](https://github.com/muehlhaus/FSharp.Plotly/commit/e9560656bbc8dbf767c9eb6ca35f321c98195238)
 * [Updated Violin Chart](https://github.com/muehlhaus/FSharp.Plotly/commit/4d3afc527b11cd2f5a18c1d9876ad4e3f83beb02)
 * [Refactor Chart.Stack]():
   * new Charts: 
     * Chart.Grid: Uses the grid object of plotly.js to generate various types of subplot grids
     * Chart.SingleStack: Basically Chart.Grid with one Column
 * Add Chart.withColorBar and Chart.withColorBarStyle to change the appearance of colorbars
 * [Add Sunburst Chart]()
 * [Add Treemap Chart]()
 * [Add OHLC Chart]()
 * [Add option to render all charts derived from the scatter trace type via WebGL as scattergl trace]()
 * [Add Stackgroup related parameters to all charts derived from the scatter trace]()

### 1.2.2 - Apr 9 2020
 * [Opening Charts is now more or less OS agnostic](https://github.com/muehlhaus/FSharp.Plotly/commit/f6e3dceade085e43e7e56b478b9cf7b533a4fe55)


### 1.2.1 - Apr 8 2020
 * [Improve C# interop](https://github.com/muehlhaus/FSharp.Plotly/commit/4bc8a45d4cdea3961c15429680923927b47a2840) by using null as default parameter for optional parameters in chart extensions and requiring qualified access for style parameters


### 1.2.0 - Feb 17 2020
Additional functionality:
 * [Various marker style options](https://github.com/muehlhaus/FSharp.Plotly/commit/11a80f94d9fb9f94a4504073955e009746e9fd0d)
 * [Config support](https://github.com/muehlhaus/FSharp.Plotly/commit/70998edd586553b40a8b95de56d86639902a5420)
 * [Chart.Stack works now with both 2D and 3D Charts](https://github.com/muehlhaus/FSharp.Plotly/commit/db7ce675a73f37598590f24ac99c246fce78759e)

Additional plots:
 * [Parallel Categories](https://github.com/muehlhaus/FSharp.Plotly/commit/adaf9e361d9fe8ac3b51a8832ffbb024cd3d78dc)
 * [Stacked Area](https://github.com/muehlhaus/FSharp.Plotly/commit/612666883ac07f21350d3da3d6749387a9cb1f4d)
 * [Tables](https://github.com/muehlhaus/FSharp.Plotly/commit/6bfc9e34072c486546ad3fbf118f027e57c6114c)

Additional functionality and plots thanks to external open source contributors:
 * You can now [add descriptional text to the chart html](https://github.com/muehlhaus/FSharp.Plotly/commit/bd99364d1fcfe894c772ad2fe9c59b31a37dc547) (thanks @kkkmail)
 * [Sankey and Candlestick Charts are now available](https://github.com/muehlhaus/FSharp.Plotly/commit/f1e873d7e2c2cc5a60c2365058880419668d1804) (thanks @fwaris)


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
