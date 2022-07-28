### 0.2.0 - July 28 2022

added C# bindings for finance charts

- [x] OHLC
- [x] Candlestick
- [x] Waterfall
- [x] Funnel
- [x] Funnel Area
- [x] Indicator

Additionally, some GenericChart extensions have been added:

- [x] WithXAxisrangeSlider

### 0.1.0 - July 26 2022

added C# bindings for statistical charts

- [x] Histogram
- [x] Histogram2D
- [x] BoxPlot
- [x] Violin
- [x] Histogram2DContour
- [x] PointDensity
- [x] DensityMapbox
- [x] ContourCarpet

Optional arguments are now wrapped in a custom `Optional<T>` type to allow usage of both reference and value types for optional arguments across the whole API.

Some GenericChart extension methods were also added:
- WithMabox
- WithMaboxStyle

### 0.0.1 - June 15 2022

C# bindings for basic charts and styling for usage in ML.NET notebooks:

**Chart styling / Layouting**

- [x] Extension Methods
	- [x] SaveHtml
	- [x] Show
	- [x] WithTraceInfo
	- [x] WithSize
	- [x] WithXAxisStyle
	- [x] WithYAxisStyle
- [x] Chart.Grid
- [x] Chart.Combine

**Chart generation**
- [x] Chart.Invisible
- [x] Chart2D
	- [x] Scatter
	- [x] Point
	- [x] Line
	- [x] Bar
	- [x] Column
- [x] Chart3D 	  
	- [x] Scatter3D
- [x] ChartPolar	  
	- [x] ScatterPolar
- [x] ChartMap  
	- [x] ScatterGeo
- [x] ChartTernary  
	- [x] ScatterTernary
- [x] ChartCarpet 
	- [x] Carpet
- [x] ChartDomain
	- [x] Pie
 - [x] ChartSmith
	- [x] ScatterSmith