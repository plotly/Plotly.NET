#r "nuget: FSharp.Data"
#r "nuget: Deedle"
#r "nuget: FSharpAux"

#load "StyleParams.fs"
#load "DynamicObj.fs"
#load "Frame.fs"
#load "Colors.fs"
#load "StockData.fs"
#load "Font.fs"
#load "Pathbar.fs"
#load "TreemapTiling.fs"
#load "Colorbar.fs"
#load "RangeSlider.fs"
#load "Light.fs"
#load "Legend.fs"
#load "Contours.fs"
#load "Dimensions.fs"
#load "Domain.fs"
#load "Line.fs"
#load "WaterfallConnector.fs"
#load "FunnelConnector.fs"
#load "Box.fs"
#load "Meanline.fs"
#load "Marker.fs"
#load "Hoverlabel.fs"
#load "Axis.fs"
#load "Bins.fs"
#load "Cumulative.fs"
#load "Scene.fs"
#load "Selected.fs"
#load "Shape.fs"
#load "Error.fs"
#load "Table.fs"
#load "Trace.fs"
#load "Trace3d.fs"
#load "GeoProjection.fs"
#load "Geo.fs"
#load "MapboxLayerSymbol.fs"
#load "MapboxLayer.fs"
#load "Mapbox.fs"
#load "LayoutGrid.fs"
#load "Annotation.fs"
#load "Layout.fs"
#load "Template.fs"
#load "Config.fs"
#r "nuget: Newtonsoft.Json, 12.0.3"
#load "DisplayOptions.fs"
#load "GenericChart.fs"
#load "Chart.fs"
#load "ChartExtensions.fs"
#load "GenericChartExtensions.fs"
#load "CandelstickExtension.fs"
#load "SankeyExtension.fs"

open Plotly.NET
open GenericChart

open FSharp.Data
open Newtonsoft.Json
open System.Text
open System.IO
open Deedle
open FSharpAux

[
    Chart.Point([1,2;1,3]) 
    |> Chart.withY_AxisStyle("This title must")

    Chart.Line([1,2;1,3]) 
    |> Chart.withY_AxisStyle("be set on the",Zeroline=false)
    
    Chart.Spline([1,2;1,3]) 
    |> Chart.withY_AxisStyle("respective subplots",Zeroline=false)
]
|> Chart.SingleStack(Pattern= StyleParam.LayoutGridPattern.Coupled)
//move xAxis to bottom and increase spacing between plots by using the withLayoutGridStyle function
|> Chart.withLayoutGridStyle(YGap= 0.1)
|> Chart.withTitle("Hi i am the new SingleStackChart")
|> Chart.withX_AxisStyle("im the shared xAxis")
|> Chart.Show

[
    [
        Chart.Point([1,2],Name="1,1")
        |> Chart.withX_AxisStyle "x1"
        |> Chart.withY_AxisStyle "y1"    
        Chart.Point([1,2],Name="1,2")
        |> Chart.withX_AxisStyle "x2"
        |> Chart.withY_AxisStyle "y2"
    ]
    [
        Chart.Point([1,2],Name="2,1")
        |> Chart.withX_AxisStyle "x3"
        |> Chart.withY_AxisStyle "y3"    
    ]
    [
        Chart.Point([1,2],Name="3,1")
        |> Chart.withX_AxisStyle "x4"
        |> Chart.withY_AxisStyle "y4"    
        Chart.Point([1,2],Name="3,2")
        |> Chart.withX_AxisStyle "x5"
        |> Chart.withY_AxisStyle "y5"
    ]
]
|> Chart.Grid()
|> Chart.Show

[
    Chart.Point([1,2],Name="1,1")
    |> Chart.withX_AxisStyle "x1"
    |> Chart.withY_AxisStyle "y1"    
    Chart.Point([1,2],Name="1,2")
    |> Chart.withX_AxisStyle "x2"
    |> Chart.withY_AxisStyle "y2"
    Chart.Point([1,2],Name="2,2")
    |> Chart.withX_AxisStyle "x3"
    |> Chart.withY_AxisStyle "y3"    
    Chart.Point([1,2],Name="3,2")
    |> Chart.withX_AxisStyle "x4"
    |> Chart.withY_AxisStyle "y4"    
    Chart.Point([1,2],Name="1,1")
    |> Chart.withX_AxisStyle "x5"
    |> Chart.withY_AxisStyle "y5"    
    Chart.Point([1,2],Name="1,2")
    |> Chart.withX_AxisStyle "x6"
    |> Chart.withY_AxisStyle "y6"
    Chart.Point([1,2],Name="2,2")
    |> Chart.withX_AxisStyle "x7"
    |> Chart.withY_AxisStyle "y7"    
    Chart.Point([1,2],Name="3,2")
    |> Chart.withX_AxisStyle "x8"
    |> Chart.withY_AxisStyle "y8"    
    Chart.Point([1,2],Name="1,1")
    |> Chart.withX_AxisStyle "x9"
    |> Chart.withY_AxisStyle "y9"    
    Chart.Point([1,2],Name="1,2")
    |> Chart.withX_AxisStyle "x10"
    |> Chart.withY_AxisStyle "y10"
    Chart.Point([1,2],Name="2,2")
    |> Chart.withX_AxisStyle "x11"
    |> Chart.withY_AxisStyle "y11"    
    Chart.Point([1,2],Name="3,2")
    |> Chart.withX_AxisStyle "x12"
    |> Chart.withY_AxisStyle "y12"
]
|> Chart.Grid(6,2,Pattern=StyleParam.LayoutGridPattern.Coupled)
|> Chart.withSize (1000., 2000.)
|> Chart.Show

 
[
    Chart.Point([(1.,2.)])
    |> GenericChart.mapTrace (fun t ->
        t?legendgroup <- "2"
        t
    )
    Chart.Point([(1.,2.)])
    |> GenericChart.mapTrace (fun t ->
        t?legendgroup <- "1"
        t
    )
    Chart.Point([(1.,2.)])
    |> GenericChart.mapTrace (fun t ->
        t?legendgroup <- "1"
        t
    )
]
|> Chart.SingleStack(Pattern=StyleParam.LayoutGridPattern.Coupled)
|> Chart.withLegend(
    Legend.init(
        TraceOrder = StyleParam.TraceOrder.Grouped,
        TraceGroupGap = 300.
    )
)
|> Chart.withAnnotations [
    Annotation.init(1,2,Text= "soos1",YRef="y")
    Annotation.init(1,2,Text= "soos2",YRef="y2")
]
|> Chart.Show


let dataDensityMapbox = 
    Http.RequestString "https://raw.githubusercontent.com/plotly/datasets/master/earthquakes-23k.csv"
    |> fun d -> Frame.ReadCsvString(d,true,separators=",")

dataDensityMapbox.Print()

let lonDensity = dataDensityMapbox.["Longitude"] |> Series.values
let latDensity = dataDensityMapbox.["Latitude"] |> Series.values
let magnitudes = dataDensityMapbox.["Magnitude"] |> Series.values

Chart.DensityMapbox(
    lonDensity,
    latDensity,
    Z = magnitudes,
    Radius=8.,
    Colorscale=StyleParam.Colorscale.Viridis
)
|> Chart.withMapbox(
    Mapbox.init(
        Style = StyleParam.MapboxStyle.StamenTerrain,
        Center = (60.,30.)
    )
)
|> Chart.Show


let dataMapbox = 
     let dataString = Http.RequestString "https://raw.githubusercontent.com/plotly/datasets/master/us-cities-top-1k.csv"
     let byteArray = Encoding.UTF8.GetBytes(dataString)
     use stream = new MemoryStream(byteArray)
     Frame.ReadCsv(stream,true,separators=",",schema="City=string,State=string,Population=int,lat=float,lon=float")

dataMapbox.Print()

let lon: float [] = 
    dataMapbox
    |> Frame.getCol "lon"
    |> Series.values
    |> Array.ofSeq

let lat: float [] = 
    dataMapbox
    |> Frame.getCol "lat"
    |> Series.values
    |> Array.ofSeq

Chart.LineMapbox(
    longitudes=lon,
    latitudes=lat,
    ShowMarkers=true,
    Name="soos"
)
|> Chart.withMapbox(
    Mapbox.init(
        Style = StyleParam.MapboxStyle.OpenStreetMap,
        Center = (-97.61142,38.84028)
    )
)
|> Chart.withSize(1000.,1000.)
|> Chart.withTitle "lol?"
|> Chart.Show

Chart.Column(
    keysvalues= [
        "second",3
        "first", 6
        "third", 1
    ]
)
|> Chart.withX_Axis(
    Axis.LinearAxis.initCategorical(
        StyleParam.CategoryOrder.Array,
        CategoryArray = ["first"; "second"; "third"]
    )
)
|> Chart.Show

Chart.Range(
    x = [1;2],
    y = [2;3],
    upper=[3;4],
    lower=[1;2],
    mode=StyleParam.Mode.Lines,
    UpperLabels=["upper1";"upper2"],
    LowerLabels=["lower1";"lower2"]
)
|> Chart.Show

let geoJson = 
    Http.RequestString "https://raw.githubusercontent.com/plotly/datasets/master/geojson-counties-fips.json"
    |> JsonConvert.DeserializeObject

let data = 
     let dataString = Http.RequestString "https://raw.githubusercontent.com/plotly/datasets/master/fips-unemp-16.csv"
     Frame.ReadCsvString(dataString,true,separators=",",schema="fips=string,unemp=float")

let locations: string [] = 
    data
    |> Frame.getCol "fips"
    |> Series.values
    |> Array.ofSeq

let z: int [] = 
    data
    |> Frame.getCol "unemp"
    |> Series.values
    |> Array.ofSeq

Chart.ChoroplethMapbox(
    locations = locations,
    z = z,
    geoJson = geoJson,
    FeatureIdKey="id"
)
|> Chart.withMapbox(
    Mapbox.init(Style=StyleParam.MapboxStyle.OpenStreetMap)
)
|> Chart.Show

Chart.ChoroplethMap(
    locations = locations,
    z = z,
    Locationmode=StyleParam.LocationFormat.GeoJson_Id,
    GeoJson = geoJson,
    FeatureIdKey="id"
)
|> Chart.withMap(
    Geo.init(
        Scope=StyleParam.GeoScope.Usa
    )
)
|> Chart.Show

Trace.initChoroplethMap(id)
|> fun t ->
    t?z <- z
    t?locations <- locations
    t?geojson <- geoJson
    t?featureidkey <- "id"
    t?locationmode <- "geojson-id"
    t
|> GenericChart.ofTraceObject
|> Chart.withMap(
    Geo.init(
        Scope=StyleParam.GeoScope.Usa
    )
)
|> Chart.Show

System.Random().Next(1,40)

// Funnel examples adapted from Plotly docs: https://plotly.com/javascript/funnel-charts/
let funnel =
    let y = [|"Sales person A"; "Sales person B"; "Sales person C"; "Sales person D"; "Sales person E"|]
    let x = [|1200.; 909.4; 600.6; 300.; 80.|]
    let line = Line.init(Width=2.,Color="3E4E88")
    let connectorLine = Line.init (Color="royalblue", Dash=StyleParam.DrawingStyle.Dot, Width=3.)
    let connector = FunnelConnector.init(Line=connectorLine)
    Chart.Funnel (x,y,Color="59D4E8", Line=line, Connector=connector)
    |> Chart.withMarginSize(Left=100)
    |> Chart.Show

let funnelArea =
    let values = [|5; 4; 3; 2; 1|]
    let text = [|"The 1st"; "The 2nd"; "The 3rd"; "The 4th"; "The 5th"|]
    let line = Line.init (Color="purple", Width=3.)
    Chart.FunnelArea(Values=values, Text=text, Line=line)
    |> Chart.Show

let funnelArea2 =
    let labels = [|1;2;2;3;3;3|]
    Chart.FunnelArea(Labels=labels)
    |> Chart.Show

let yAxis =
    Axis.LinearAxis.init(
        Title = "Y",
        Showline = true,
        Range = StyleParam.Range.MinMax (0.0, 2.0),
        Tickvals = [0.0 .. 2.0],
        Ticktext = [ "zero"; "one"; "two" ]
    )

Chart.Range(
    [1;2],
    [1;1],
    [0.0;0.53622183],
    [1.0;2.0],
    StyleParam.Mode.None,
    Name = "",
    LowerName = "Lower",
    UpperName = "Upper",
    Labels = [])
|> Chart.withY_Axis (yAxis)
|> GenericChart.mapiTrace (fun i t ->
    match i with
    | 0 -> t |> Trace.TraceStyle.TextLabel ["upperOne";"upperTwo"]
    | 1 -> t |> Trace.TraceStyle.TextLabel ["lowerOne";"lowerTwo"]
    | 2 -> t
)
|> Chart.Show

let testAnnotation =
    Annotation.init(X=System.DateTime.Now, Y=0,Text="test")

Chart.Line([System.DateTime.Now, 5])
|> Chart.withAnnotations [testAnnotation]
|> Chart.Show


let descritptionTable ="""<table>
<thead>
    <th colspan="2">A</td>
    <th colspan="2">B</td>
</thead>
<tr>
    <td>A</td>
    <td>A</td>
    <td>B</td>
    <td>B</td>
</tr>
</table>
"""

Chart.Point([1.,2.])
|> Chart.WithDescription (ChartDescription.create "Some Table" descritptionTable)
|> Chart.Show

[
    Chart.Line([(1.,2.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
    Chart.Line([(1.,2.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
]
|> Chart.Combine
|> Chart.withTitle @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$"
|> Chart.WithMathTex(true)
|> Chart.Show


let myTemplate = 
    ChartTemplates.dark
    |> Template.withColorWay ChartTemplates.ColorWays.plotly

let myLegend = 
    Legend.init(
        Orientation = StyleParam.Orientation.Horizontal
    )

//F# functional pipeline to compose a chart with functions
//
[
    [(1,5);(2,10)]
    [(2,4);(3,9)]
    [(3,3);(4,8)]
    [(4,2);(5,7)]
    [(5,1);(6,6)]    
    [(6,-1);(7,5)]
    [(7,-2);(8,4)]
    [(8,-3);(9,3)]
    [(9,-4);(10,2)]
    [(10,-5);(11,1)]

]
|> List.map Chart.Line
|> Chart.Combine
|> Chart.withLegend(myLegend)
|> Chart.Show


// Dynamic object style, which is more or less equivalent to how you would create figure objects in plotly.js.
// Member names set via the `?` operator must be named exactly tzhe same as the javascript equivalent
// It is more verbose, but has the advantage of being able to generate any type of Chart. Usefull if there are no abstractions provided for a certain property
let xAxis = 
    let tmp = Axis.LinearAxis()
    tmp?title <- "xAxis"
    tmp?showgrid <- false
    tmp?showline <- true    
    tmp

let yAxis2 =
    let tmp = Axis.LinearAxis()
    tmp?title <- "yAxis"
    tmp?showgrid <- false
    tmp?showline <- true    
    tmp

let layout =
    let tmp = Layout()
    tmp?xaxis <- xAxis
    tmp?yaxis <- yAxis2
    tmp?showlegend <- true
    tmp

let trace = 
    let tmp = Trace("scatter")
    tmp?x <- [1;2]
    tmp?y <- [5;10]
    tmp?mode <- "markers"
    tmp?name <- "Hello from F#"
    tmp

trace
|> GenericChart.ofTraceObject
|> GenericChart.setLayout layout
|> Chart.Show


Chart.LineGeo(
    [
        -73.57; -79.24; -123.06; -114.1; -113.28;
        -75.43; -63.57; -123.21; -97.13; -104.6
    ],
    [
        45.5;  43.4;  49.13; 51.1; 53.34; 45.24;
        44.64; 48.25; 49.89; 50.45
    ],ShowMarkers = true,MarkerSymbol = StyleParam.Symbol.Cross
)
|> Chart.Show

Chart.ScatterGeo(
    [
        -73.57; -79.24; -123.06; -114.1; -113.28;
        -75.43; -63.57; -123.21; -97.13; -104.6
    ],
    [
        45.5;  43.4;  49.13; 51.1; 53.34; 45.24;
        44.64; 48.25; 49.89; 50.45
    ],
    StyleParam.Mode.Lines
)
|> Chart.withMapStyle(
    Projection=GeoProjection.init(projectionType=StyleParam.GeoProjectionType.AzimuthalEqualArea),
    ShowLakes=true,
    ShowOcean=true,
    OceanColor="lightblue",
    ShowRivers=true)
|> Chart.Show
//test new withMapStyle function

let locations2,z2 = 
   [("Belarus",17.5); ("Moldova",16.8);("Lithuania",15.4);("Russia",15.1);
   ("Romania",14.4);("Ukraine",13.9);("Andorra",13.8);("Hungary",13.3);
   ("Czech Republic",13.);("Slovakia",13.);("Portugal",12.9);("Serbia",12.6);
    ("Grenada",12.5);("Poland",12.5);("Latvia",12.3);("Finland",12.3);
    ("South Korea",12.3);("France",12.2);("Australia",12.2);("Croatia",12.2);
    ("Ireland",11.9);("Luxembourg",11.9);("Germany",11.8);("Slovenia",11.6);
    ("United Kingdom",11.6);("Denmark",11.4);("Bulgaria",11.4);("Spain",11.2);
    ("Belgium",11.);("South Africa",11.);("New Zealand",10.9);("Gabon",10.9);
    ("Namibia",10.8);("Switzerland",10.7);("Saint Lucia",10.4);("Austria",10.3);
    ("Estonia",10.3);("Greece",10.3);("Kazakhstan",10.3);("Canada",10.2);
    ("Nigeria",10.1);("Netherlands",9.9);("Uganda",9.8);("Rwanda",9.8);
    ("Chile",9.6);("Argentina",9.3);("Burundi",9.3);("United States",9.2);
    ("Cyprus",9.2);("Sweden",9.2);("Venezuela",8.9);("Paraguay",8.8);("Brazil",8.7);
    ("Sierra Leone",8.7);("Montenegro",8.7);("Belize",8.5);("Cameroon",8.4);
    ("Botswana",8.4);("Saint Kitts and Nevis",8.2);("Guyana",8.1);("Peru",8.1);
    ("Panama",8.);("Niue",8.);("Palau",7.9);("Norway",7.7);("Tanzania",7.7);
    ("Georgia",7.7);("Uruguay",7.6);("Angola",7.5);("Laos",7.3);("Japan",7.2);
    ("Mexico",7.2);("Ecuador",7.2);("Dominica",7.1);("Iceland",7.1);
    ("Thailand",7.1);("Bosnia and Herzegovina",7.1);("Sao Tome and Principe",7.1);
    ("Malta",7.);("Albania",7.);("Bahamas",6.9);("Dominican Republic",6.9);
    ("Mongolia",6.9);("Cape Verde",6.9);("Barbados",6.8);("Burkina Faso",6.8);
    ("Italy",6.7);("Trinidad and Tobago",6.7);("China",6.7);("Macedonia",6.7);
    ("Saint Vincent and the Grenadines",6.6);("Equatorial Guinea",6.6);
    ("Suriname",6.6);("Vietnam",6.6);("Lesotho",6.5);("Haiti",6.4);
    ("Cook Islands",6.4);("Colombia",6.2);("Ivory Coast",6.);("Bolivia",5.9);
    ("Swaziland",5.7);("Zimbabwe",5.7);("Seychelles",5.6);("Cambodia",5.5);
    ("Puerto Rico",5.4);("Netherlands Antilles",5.4);("Philippines",5.4);
    ("Costa Rica",5.4);("Armenia",5.3);("Cuba",5.2);("Nicaragua",5.);
    ("Jamaica",4.9);("Ghana",4.8);("Liberia",4.7);("Uzbekistan",4.6);
    ("Chad",4.4);("United Arab Emirates",4.3);("Kyrgyzstan",4.3);("India",4.3);
    ("Turkmenistan",4.3);("Kenya",4.3);("Ethiopia",4.2);("Honduras",4.);
    ("Guinea-Bissau",4.);("Zambia",4.);("Republic of the Congo",3.9);("Guatemala",3.8);
    ("Central African Republic",3.8);("North Korea",3.7);("Sri Lanka",3.7);
    ("Mauritius",3.6);("Samoa",3.6);("Democratic Republic of the Congo",3.6);
    ("Nauru",3.5);("Gambia",3.4);("Federated States of Micronesia",3.3);
    ("El Salvador",3.2);("Fiji",3.);("Papua New Guinea",3.);("Kiribati",3.);
    ("Tajikistan",2.8);("Israel",2.8);("Sudan",2.7);("Malawi",2.5);("Lebanon",2.4);
    ("Azerbaijan",2.3);("Mozambique",2.3);("Togo",2.3);("Nepal",2.2);("Brunei",2.1);
    ("Benin",2.1);("Singapore",2.);("Turkey",2.);("Madagascar",1.8);("Solomon Islands",1.7);
    ("Tonga",1.6);("Tunisia",1.5);("Tuvalu",1.5);("Qatar",1.5);("Vanuatu",1.4);
    ("Djibouti",1.3);("Malaysia",1.3);("Syria",1.2);("Maldives",1.2);("Mali",1.1);
    ("Eritrea",1.1);("Algeria",1.);("Iran",1.);("Oman",0.9);("Brunei",0.9);
    ("Morocco",0.9);("Jordan",0.7);("Bhutan",0.7);("Guinea",0.7);("Burma",0.7);
    ("Afghanistan",0.7);("Senegal",0.6);("Indonesia",0.6);("Timor-Leste",0.6);
    ("Iraq",0.5);("Somalia",0.5);("Egypt",0.4);("Niger",0.3);("Yemen",0.3);
    ("Comoros",0.2);("Saudi Arabia",0.2);("Bangladesh",0.2);("Kuwait",0.1);
    ("Libya",0.1);("Mauritania",0.1);("Pakistan",0.1);]
    |> List.unzip


// Pure alcohol consumption among adults (age 15+) in 2010
Chart.ChoroplethMap(locations2,z2,Locationmode=StyleParam.LocationFormat.CountryNames,Colorscale=StyleParam.Colorscale.Electric)
|> Chart.withMapStyle(
    Projection=GeoProjection.init(projectionType=StyleParam.GeoProjectionType.Mollweide),
    ShowLakes=true,
    ShowOcean=true,
    OceanColor="lightblue",
    ShowRivers=true)
|> Chart.withColorBarStyle ("Alcohol consumption[l/y]",Length=0.5)
|> Chart.withSize(1000.,1000.)
|> Chart.Show

let waterfallData = [
    "Sales"              , 60   ,  StyleParam.WaterfallMeasure.Relative
    "Consulting"         , 80   ,  StyleParam.WaterfallMeasure.Relative
    "Net revenue"        , 0    ,  StyleParam.WaterfallMeasure.Total
    "Purchases"          , -60  ,  StyleParam.WaterfallMeasure.Relative
    "Other expenses"     , -20  ,  StyleParam.WaterfallMeasure.Relative
    "Profit before tax"  , 0    ,  StyleParam.WaterfallMeasure.Total
]

Chart.Waterfall(waterfallData)
|> Chart.Show


let manyPoints = 
    let rnd = new System.Random()
    [for i = 0 to 50000 do (rnd.NextDouble(),rnd.NextDouble()) ]
  
let manyBubbles =  
    let rnd = new System.Random()
    [for i = 0 to 50000 do (rnd.NextDouble(),rnd.NextDouble(),rnd.NextDouble()) ]
//we can see here that the advantage of webgl fades with many small scattergl traces.
let manyLines = 
    let rnd = new System.Random()
    [for i = 0 to 5000 do 
        [for i in [0 .. 10 .. 100] do (rnd.NextDouble(),rnd.NextDouble())]
    ]
  
  
//Test Stackgroups

[
    Chart.Scatter(x = [1;2;3], y = [2;3;4],mode=StyleParam.Mode.Markers, StackGroup = "meem", Orientation= StyleParam.Orientation.Vertical, GroupNorm = StyleParam.GroupNorm.Percent )
    Chart.Scatter(x = [1;2;3], y = [4;3;4],mode=StyleParam.Mode.Markers, StackGroup = "meem", Orientation= StyleParam.Orientation.Vertical, GroupNorm = StyleParam.GroupNorm.Percent )
]
|> Chart.Combine
|> Chart.Show

//Just try this, its amazing how much faster WebGL loads and zooms
Chart.Point(manyPoints,UseWebGL=true)
|> Chart.Show

Chart.Point(manyPoints)
|> Chart.Show

manyLines
|> List.map (fun l -> Chart.Line(l,UseWebGL=true))
|> Chart.Combine
|> Chart.Show

Chart.Line(manyPoints,UseWebGL=true)
|> Chart.Show

Chart.Line(manyPoints,UseWebGL=false)
|> Chart.Show

Chart.Spline(manyPoints,UseWebGL=true)
|> Chart.Show

Chart.Spline(manyPoints,UseWebGL=false)
|> Chart.Show

Chart.Bubble(manyBubbles,UseWebGL=true)
|> Chart.Show

Chart.Bubble(manyBubbles,UseWebGL=false)
|> Chart.Show

let stockData =
    [|("2020-01-17T13:40:00", 0.68888, 0.68888, 0.68879, 0.6888);
      ("2020-01-17T13:41:00", 0.68883, 0.68884, 0.68875, 0.68877);
      ("2020-01-17T13:42:00", 0.68878, 0.68889, 0.68878, 0.68886);
      ("2020-01-17T13:43:00", 0.68886, 0.68886, 0.68876, 0.68879);
      ("2020-01-17T13:44:00", 0.68879, 0.68879, 0.68873, 0.68874);
      ("2020-01-17T13:45:00", 0.68875, 0.68877, 0.68867, 0.68868);
      ("2020-01-17T13:46:00", 0.68869, 0.68887, 0.68869, 0.68883);
      ("2020-01-17T13:47:00", 0.68883, 0.68899, 0.68883, 0.68899);
      ("2020-01-17T13:48:00", 0.68898, 0.689, 0.68885, 0.68889);
      ("2020-01-17T13:49:00", 0.68889, 0.68893, 0.68881, 0.68893);
      ("2020-01-17T13:50:00", 0.68891, 0.68896, 0.68886, 0.68891);
    |]
    |> Array.map (fun (d,o,h,l,c)->System.DateTime.Parse d, StockData.Create(o,h,l,c))

Chart.Candlestick stockData
|> Chart.Show

Chart.OHLC stockData
|> Chart.Show

Chart.Treemap(
    ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"],
    [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ],
    Values = [10.; 14.; 12.; 10.; 2.; 6.; 6.; 4.; 4.]
)
|> Chart.withTitle "Treemap test"
|> Chart.Show


//Sunbursst example from plotly docs: https://plotly.com/javascript/sunburst-charts
Chart.Sunburst(
    ["Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"],
    [""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve" ],
    Values = [10.; 14.; 12.; 10.; 2.; 6.; 6.; 4.; 4.]
)
|> Chart.withTitle "Sunburst test"
|> Chart.Show


let stack ( columns:int, space) = 
    (fun (charts:#seq<GenericChart>) ->  

        let col = columns
        let len      = charts |> Seq.length
        let colWidth = 1. / float col
        let rowWidth = 
            let tmp = float len / float col |> ceil
            1. / tmp
        let space = 
            let s = defaultArg space 0.05
            if s < 0. || s > 1. then 
                printfn "Space should be between 0.0 - 1.0. Automaticaly set to default (0.05)"
                0.05
            else
                s

        let contains3d ch =
            ch 
            |> existsTrace (fun t -> 
                match t with
                | :? Trace3d -> true
                | _ -> false)

        charts
        |> Seq.mapi (fun i ch ->
            let colI,rowI,index = (i%col+1), (i/col+1),(i+1)
            let xdomain = (colWidth * float (colI-1), (colWidth * float colI) - space ) 
            let ydomain = (1. - ((rowWidth * float rowI) - space ),1. - (rowWidth * float (rowI-1)))
            xdomain)
        )

let a = 
    stack (2, None) [Chart.Point([0,1]);Chart.Point([0,1])]
    |> Array.ofSeq

let generateDomainRanges nRows nCols =
    
    if nCols > 0 && nRows > 0 then

        [0. .. (1. / (float nRows)) .. 1.]
        |> List.windowed 2
        |> List.map (fun x -> x.[0], x.[1])
        ,
        [0. .. (1. / (float nCols)) .. 1.]
        |> List.windowed 2
        |> List.map (fun x -> x.[0], x.[1])

    else failwith "negative amount of rows or columns is stupid."

generateDomainRanges 8 1




[
    Chart.Point([(0,1)]) |> Chart.withY_AxisStyle("This title")
    Chart.Point([(0,1)]) 
    |> Chart.withY_AxisStyle("Must be set",Zeroline=false)
    Chart.Point([(0,1)]) 
    |> Chart.withY_AxisStyle("on the respective charts",Zeroline=false)
]
|> Chart.SingleStack
|> Chart.withLayoutGridStyle(XSide=StyleParam.LayoutGridXSide.Bottom)
|> Chart.withTitle("Hi i am the new SingleStackChart")
|> Chart.withX_AxisStyle("im the shared xAxis")
|> Chart.Show

[
    [1;2]
    [3;4]
]
|> Chart.Heatmap
|> Chart.withColorBarStyle(
    "Hallo?",
    TitleSide=StyleParam.Side.Right,
    TitleFont=Font.init(Size=20.)
)
|> Chart.Show

// Heatmap example from Plotly docs: https://plotly.net/2_7_heatmaps.html
let matrix =
    [[1.;1.5;0.7;2.7];
    [2.;0.5;1.2;1.4];
    [0.1;2.6;2.4;3.0];]

let rownames = ["p3";"p2";"p1"]
let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]
let colorscaleValue = StyleParam.Colorscale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]

let heat1 =
    Chart.Heatmap(
        matrix,colnames,rownames,
        Colorscale=colorscaleValue,
        Showscale=true,
        UseWebGL=true
    )
    |> Chart.withSize(700.,500.)
    |> Chart.withMarginSize(Left=200.)
    |> Chart.Show

let values,labels = 
    [
    1,"v1"
    2,"v2"
    ]
    |> Seq.unzip

let cols =[|"black";"blue"|]

let doughnut1 =
    Chart.Pie(
        values,
        labels,
        Colors=cols,
        Textinfo=labels
    )
    |> Chart.Show


let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
[
    Chart.Point([(1.,2.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
    Chart.Point([(2.,4.)],@"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$")
]
|> Chart.Combine
|> Chart.withTitle @"$\beta_{1c} = 25 \pm 11 \text{ km s}^{-1}$"
// include mathtex tags in <head>. pass true to append these scripts, false to ONLY include MathTeX.
|> Chart.WithMathTex(true)
|> Chart.Show