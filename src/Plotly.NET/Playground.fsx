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
#load "Contours.fs"
#load "Dimensions.fs"
#load "Domain.fs"
#load "Line.fs"
#load "WaterfallConnector.fs"
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
#load "LayoutGrid.fs"
#load "Layout.fs"
#load "Template.fs"
#load "Config.fs"
#r @"..\..\packages\Newtonsoft.Json\lib\netstandard2.0\Newtonsoft.Json.dll"
#load "GenericChart.fs"
#load "Chart.fs"
#load "ChartExtensions.fs"
#load "GenericChartExtensions.fs"
#load "CandelstickExtension.fs"
#load "SankeyExtension.fs"

open Plotly.NET
open GenericChart

let myTemplate = 
    ChartTemplates.dark
    |> Template.withColorWay ChartTemplates.ColorWays.plotly

//F# functional pipeline to compose a chart with functions
//
[
    [(1,5);(2,10)]
    [(2,4);(3,9)]
    [(3,3);(4,8)]
    [(4,2);(5,7)]
    [(5,1);(6,6)]

]
|> List.map Chart.Line
|> Chart.Combine
|> Chart.withTraceName("Hello from F#",Showlegend=true)
//|> Chart.withY_AxisStyle("xAxis",Showline=true)
//|> Chart.withX_AxisStyle("yAxis",Showline=true)
|> Chart.withTemplate myTemplate
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

let yAxis =
    let tmp = Axis.LinearAxis()
    tmp?title <- "yAxis"
    tmp?showgrid <- false
    tmp?showline <- true    
    tmp

let layout =
    let tmp = Layout()
    tmp?xaxis <- xAxis
    tmp?yaxis <- yAxis
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

let locations,z = 
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
Chart.ChoroplethMap(locations,z,Locationmode=StyleParam.LocationFormat.CountryNames,Colorscale=StyleParam.Colorscale.Electric)
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




let grid ((gCharts:seq<#seq<GenericChart>>),sharedAxes:bool,xGap,yGap) =

    let nRows = Seq.length gCharts
    let nCols = gCharts |> Seq.maxBy Seq.length |> Seq.length
    let pattern = if sharedAxes then StyleParam.LayoutGridPattern.Coupled else StyleParam.LayoutGridPattern.Independent

    let grid = 
        LayoutGrid.init(
            Rows=nRows,Columns=nCols,XGap= xGap,YGap= yGap,Pattern=pattern
        )

    let generateDomainRanges (count:int) (gap:float) =
        [|0. .. (1. / (float count)) .. 1.|]
        |> fun doms -> 
            doms
            |> Array.windowed 2
            |> Array.mapi (fun i x -> 
                if i = 0 then
                    x.[0], (x.[1] - (gap / 2.))
                elif i = (doms.Length - 1) then
                   (x.[0] + (gap / 2.)),x.[1]
                else
                   (x.[0] + (gap / 2.)) , (x.[1] - (gap / 2.))
            )

    let yDomains = generateDomainRanges nRows yGap
    let xDomains = generateDomainRanges nCols xGap

    gCharts
    |> Seq.mapi (fun rowIndex row ->
        row |> Seq.mapi (fun colIndex gChart ->
            let xdomain = xDomains.[colIndex]
            let ydomain = yDomains.[rowIndex]

            let newXIndex, newYIndex =
                (if sharedAxes then colIndex + 1 else ((nRows * rowIndex) + (colIndex + 1))),
                (if sharedAxes then rowIndex + 1 else ((nRows * rowIndex) + (colIndex + 1)))


            let xaxis,yaxis,layout = 
                let layout = GenericChart.getLayout gChart
                let xAxisName, yAxisName = StyleParam.AxisId.X 1 |> StyleParam.AxisId.toString, StyleParam.AxisId.Y 1 |> StyleParam.AxisId.toString
                
                let updateXAxis index domain axis = 
                    axis |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.X index,Domain=StyleParam.Range.MinMax domain)
                
                let updateYAxis index domain axis = 
                    axis |> Axis.LinearAxis.style(Anchor=StyleParam.AxisAnchorId.Y index,Domain=StyleParam.Range.MinMax domain)
                match (layout.TryGetTypedValue<Axis.LinearAxis> xAxisName),(layout.TryGetTypedValue<Axis.LinearAxis> yAxisName) with
                | Some x, Some y ->
                    // remove axis
                    DynObj.remove layout xAxisName
                    DynObj.remove layout yAxisName

                    x |> updateXAxis newXIndex xdomain,
                    y |> updateYAxis newYIndex ydomain,
                    layout

                | Some x, None -> 
                    // remove x - axis
                    DynObj.remove layout xAxisName

                    x |> updateXAxis newXIndex xdomain,
                    Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.Y newYIndex ,Domain=StyleParam.Range.MinMax ydomain),
                    layout

                | None, Some y -> 
                    // remove y - axis
                    DynObj.remove layout yAxisName

                    Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.X newXIndex,Domain=StyleParam.Range.MinMax xdomain),
                    y |> updateYAxis newYIndex ydomain,
                    layout
                | None, None ->
                    Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.X newXIndex,Domain=StyleParam.Range.MinMax xdomain),
                    Axis.LinearAxis.init(Anchor=StyleParam.AxisAnchorId.Y newYIndex,Domain=StyleParam.Range.MinMax ydomain),
                    layout

            gChart
            |> GenericChart.setLayout layout
            |> Chart.withAxisAnchor(X=newXIndex,Y=newYIndex) 
            |> Chart.withX_Axis(xaxis,newXIndex)
            |> Chart.withY_Axis(yaxis,newYIndex)
        )
    )
    |> Seq.map Chart.Combine
    |> Chart.Combine
    |> Chart.withLayoutGrid grid

grid ([
    [Chart.Point([(0,1)]);Chart.Point([(0,1)]);Chart.Point([(0,1)]);]
    [Chart.Point([(0,1)]);Chart.Point([(0,1)]);Chart.Point([(0,1)]);]
    [Chart.Point([(0,1)]);Chart.Point([(0,1)]);Chart.Point([(0,1)]);]
],true, 0.05,0.05)
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
    TitleFont=Font.init(Size=20)
)
|> Chart.Show
