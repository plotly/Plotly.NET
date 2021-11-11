module Tests.GeoMapCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open Plotly.NET.LayoutObjects
open System

open TestUtils.HtmlCodegen

let basemapChart =
    Chart.PointGeo([], UseDefaults = false) // deliberately empty chart to show the base map only
    |> Chart.withMarginSize(0, 0, 0, 0)

let moreFeaturesBasemapChart =
    let myGeo =
        Geo.init(
            Resolution=StyleParam.GeoResolution.R50,
            ShowCoastLines=true, 
            CoastLineColor=Color.fromString "RebeccaPurple",
            ShowLand=true, 
            LandColor=Color.fromString "LightGreen",
            ShowOcean=true, 
            OceanColor=Color.fromString "LightBlue",
            ShowLakes=true, 
            LakeColor=Color.fromString "Blue",
            ShowRivers=true, 
            RiverColor=Color.fromString "Blue"
        )
    Chart.PointGeo([], UseDefaults = false)
    |> Chart.withGeo myGeo
    |> Chart.withMarginSize(0, 0, 0, 0)

let cultureMapChart =
    let countryGeo =
        Geo.init(
            Visible=false, 
            Resolution=StyleParam.GeoResolution.R50,
            ShowCountries=true, 
            CountryColor=Color.fromString "RebeccaPurple"
        )
    Chart.PointGeo([], UseDefaults = false)
    |> Chart.withGeo countryGeo
    |> Chart.withMarginSize(0, 0, 0, 0)

[<Tests>]
let ``Geo charts`` =
    testList "GeoMapCharts.Geo charts" [
        testCase "Basemap data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"markers\",\"lon\":[],\"lat\":[],\"marker\":{}}];"
            |> chartGeneratedContains basemapChart
        );
        testCase "Basemap layout" ( fun () ->
            "var layout = {\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
            |> chartGeneratedContains basemapChart
        );
        testCase "More features map data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"markers\",\"lon\":[],\"lat\":[],\"marker\":{}}];"
            |> chartGeneratedContains moreFeaturesBasemapChart
        );
        testCase "More features map layout" ( fun () ->
            "var layout = {\"geo\":{\"resolution\":\"50\",\"showcoastline\":true,\"coastlinecolor\":\"RebeccaPurple\",\"showland\":true,\"landcolor\":\"LightGreen\",\"showocean\":true,\"oceancolor\":\"LightBlue\",\"showlakes\":true,\"lakecolor\":\"Blue\",\"showrivers\":true,\"rivercolor\":\"Blue\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
            |> chartGeneratedContains moreFeaturesBasemapChart
        );
        testCase "Cultural map data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"markers\",\"lon\":[],\"lat\":[],\"marker\":{}}];"
            |> chartGeneratedContains cultureMapChart
        );
        testCase "Cultural map layout" ( fun () ->
            "var layout = {\"geo\":{\"resolution\":\"50\",\"visible\":false,\"showcountries\":true,\"countrycolor\":\"RebeccaPurple\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
            |> chartGeneratedContains cultureMapChart
        );
    ]


let pointGeoChart =
    let cityNames = [
        "Montreal"; "Toronto"; "Vancouver"; "Calgary"; "Edmonton";
        "Ottawa"; "Halifax"; "Victoria"; "Winnepeg"; "Regina"
    ]
    
    let lon = [
        -73.57; -79.24; -123.06; -114.1; -113.28;
        -75.43; -63.57; -123.21; -97.13; -104.6
    ]
    let lat = [
        45.5; 43.4; 49.13; 51.1; 53.34; 45.24;
        44.64; 48.25; 49.89; 50.45
    ]
    Chart.PointGeo(
        lon,
        lat,
        Labels=cityNames,
        TextPosition=StyleParam.TextPosition.TopCenter, 
        UseDefaults = false
    )
    |> Chart.withGeoStyle(
        Scope=StyleParam.GeoScope.NorthAmerica, 
        Projection=GeoProjection.init(StyleParam.GeoProjectionType.AzimuthalEqualArea),
        CountryColor = Color.fromString "lightgrey"
    )
    |> Chart.withMarginSize(0, 0, 0, 0)

open Deedle
open FSharp.Data
open System.IO
open System.Text

let flightsMapChart =
    // this is not the original string, but its few first entries
    let data = 
        "start_lat,start_lon,end_lat,end_lon,airline,airport1,airport2,cnt
32.89595056,-97.0372,35.04022222,-106.6091944,AA,DFW,ABQ,444
41.979595,-87.90446417,30.19453278,-97.66987194,AA,ORD,AUS,166
32.89595056,-97.0372,41.93887417,-72.68322833,AA,DFW,BDL,162
18.43941667,-66.00183333,41.93887417,-72.68322833,AA,SJU,BDL,56
32.89595056,-97.0372,33.56294306,-86.75354972,AA,DFW,BHM,168
25.79325,-80.29055556,36.12447667,-86.67818222,AA,MIA,BNA,56
32.89595056,-97.0372,42.3643475,-71.00517917,AA,DFW,BOS,422
25.79325,-80.29055556,42.3643475,-71.00517917,AA,MIA,BOS,392
41.979595,-87.90446417,42.3643475,-71.00517917,AA,ORD,BOS,430
18.43941667,-66.00183333,42.3643475,-71.00517917,AA,SJU,BOS,56
18.33730556,-64.97336111,42.3643475,-71.00517917,AA,STT,BOS,44
25.79325,-80.29055556,39.17540167,-76.66819833,AA,MIA,BWI,112"
        |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

    let opacityVals : float [] = data.["cnt"] |> Series.values |> fun s -> s |> Seq.map (fun v -> v/(Seq.max s)) |> Array.ofSeq
    let startCoords = Series.zipInner data.["start_lon"] data.["start_lat"]
    let endCoords = Series.zipInner data.["end_lon"] data.["end_lat"]
    let coords = Series.zipInner startCoords endCoords |> Series.values

    coords 
    |> Seq.mapi (fun i (startCoords,endCoords) ->
        Chart.LineGeo(
            [startCoords; endCoords],
            Opacity = opacityVals.[i],
            Color = Color.fromString  "red",
            UseDefaults = false
        )
    )
    |> Chart.combine
    |> Chart.withLegend(false)
    |> Chart.withGeoStyle(
        Scope=StyleParam.GeoScope.NorthAmerica, 
        Projection=GeoProjection.init(StyleParam.GeoProjectionType.AzimuthalEqualArea),
        ShowLand=true,
        LandColor = Color.fromString "lightgrey"
    )
    |> Chart.withMarginSize(0,0,50,0)
    |> Chart.withTitle "Feb. 2011 American Airline flights"


[<Tests>]
let ``Scatter and line plots on Geo maps charts`` =
    testList "GeoMapCharts.Scatter and line plots on Geo maps charts" [
        testCase "Point geo data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"markers+text\",\"lon\":[-73.57,-79.24,-123.06,-114.1,-113.28,-75.43,-63.57,-123.21,-97.13,-104.6],\"lat\":[45.5,43.4,49.13,51.1,53.34,45.24,44.64,48.25,49.89,50.45],\"marker\":{},\"text\":[\"Montreal\",\"Toronto\",\"Vancouver\",\"Calgary\",\"Edmonton\",\"Ottawa\",\"Halifax\",\"Victoria\",\"Winnepeg\",\"Regina\"],\"textposition\":\"top center\"}];"
            |> chartGeneratedContains pointGeoChart
        );
        testCase "Point geo layout" ( fun () ->
            "var layout = {\"geo\":{\"scope\":\"north america\",\"projection\":{\"type\":\"azimuthal equal area\"},\"countrycolor\":\"lightgrey\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
            |> chartGeneratedContains pointGeoChart
        );
        testCase "Flight map data" ( fun () ->
            "var data = [{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-97.0372,-106.6091944],\"lat\":[32.89595056,35.04022222],\"opacity\":1.0,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-87.90446417,-97.66987194],\"lat\":[41.979595,30.19453278],\"opacity\":0.3738738738738739,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-97.0372,-72.68322833],\"lat\":[32.89595056,41.93887417],\"opacity\":0.36486486486486486,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-66.00183333,-72.68322833],\"lat\":[18.43941667,41.93887417],\"opacity\":0.12612612612612611,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-97.0372,-86.75354972],\"lat\":[32.89595056,33.56294306],\"opacity\":0.3783783783783784,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-80.29055556,-86.67818222],\"lat\":[25.79325,36.12447667],\"opacity\":0.12612612612612611,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-97.0372,-71.00517917],\"lat\":[32.89595056,42.3643475],\"opacity\":0.9504504504504504,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-80.29055556,-71.00517917],\"lat\":[25.79325,42.3643475],\"opacity\":0.8828828828828829,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-87.90446417,-71.00517917],\"lat\":[41.979595,42.3643475],\"opacity\":0.9684684684684685,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-66.00183333,-71.00517917],\"lat\":[18.43941667,42.3643475],\"opacity\":0.12612612612612611,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-64.97336111,-71.00517917],\"lat\":[18.33730556,42.3643475],\"opacity\":0.0990990990990991,\"marker\":{\"color\":\"red\"}},{\"type\":\"scattergeo\",\"mode\":\"lines\",\"lon\":[-80.29055556,-76.66819833],\"lat\":[25.79325,39.17540167],\"opacity\":0.25225225225225223,\"marker\":{\"color\":\"red\"}}];"
            |> chartGeneratedContains flightsMapChart
        );
        testCase "Flight map layout" ( fun () ->
            "var layout = {\"showlegend\":false,\"geo\":{\"scope\":\"north america\",\"projection\":{\"type\":\"azimuthal equal area\"},\"showland\":true,\"landcolor\":\"lightgrey\"},\"margin\":{\"l\":0,\"r\":0,\"t\":50,\"b\":0},\"title\":{\"text\":\"Feb. 2011 American Airline flights\"}};"
            |> chartGeneratedContains flightsMapChart
        );
    ]


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


let choroplethMap1Chart =
    Chart.ChoroplethMap(
        locations,z,
        Locationmode=StyleParam.LocationFormat.CountryNames, 
        UseDefaults = false
    )
    
let choroplethMap2Chart =
    Chart.ChoroplethMap(
        locations,z,
        Locationmode=StyleParam.LocationFormat.CountryNames, 
        UseDefaults = false
    )
    |> Chart.withGeoStyle(
        Projection=GeoProjection.init(projectionType=StyleParam.GeoProjectionType.Mollweide),
        ShowLakes=true,
        ShowOcean=true,
        OceanColor= Color.fromString "lightblue",
        ShowRivers=true)
    |> Chart.withColorBarStyle (
        Title.init(Text="Alcohol consumption[l/y]")
        ,Length=0.5
    )

[<Tests>]
let ``Choropleth maps charts`` =
    testList "GeoMapCharts.Choropleth maps charts" [
        testCase "Choropleth map 1 data" ( fun () ->
            "var data = [{\"type\":\"choropleth\",\"locations\":[\"Belarus\",\"Moldova\",\"Lithuania\",\"Russia\",\"Romania\",\"Ukraine\",\"Andorra\",\"Hungary\",\"Czech Republic\",\"Slovakia\",\"Portugal\",\"Serbia\",\"Grenada\",\"Poland\",\"Latvia\",\"Finland\",\"South Korea\",\"France\",\"Australia\",\"Croatia\",\"Ireland\",\"Luxembourg\",\"Germany\",\"Slovenia\",\"United Kingdom\",\"Denmark\",\"Bulgaria\",\"Spain\",\"Belgium\",\"South Africa\",\"New Zealand\",\"Gabon\",\"Namibia\",\"Switzerland\",\"Saint Lucia\",\"Austria\",\"Estonia\",\"Greece\",\"Kazakhstan\",\"Canada\",\"Nigeria\",\"Netherlands\",\"Uganda\",\"Rwanda\",\"Chile\",\"Argentina\",\"Burundi\",\"United States\",\"Cyprus\",\"Sweden\",\"Venezuela\",\"Paraguay\",\"Brazil\",\"Sierra Leone\",\"Montenegro\",\"Belize\",\"Cameroon\",\"Botswana\",\"Saint Kitts and Nevis\",\"Guyana\",\"Peru\",\"Panama\",\"Niue\",\"Palau\",\"Norway\",\"Tanzania\",\"Georgia\",\"Uruguay\",\"Angola\",\"Laos\",\"Japan\",\"Mexico\",\"Ecuador\",\"Dominica\",\"Iceland\",\"Thailand\",\"Bosnia and Herzegovina\",\"Sao Tome and Principe\",\"Malta\",\"Albania\",\"Bahamas\",\"Dominican Republic\",\"Mongolia\",\"Cape Verde\",\"Barbados\",\"Burkina Faso\",\"Italy\",\"Trinidad and Tobago\",\"China\",\"Macedonia\",\"Saint Vincent and the Grenadines\",\"Equatorial Guinea\",\"Suriname\",\"Vietnam\",\"Lesotho\",\"Haiti\",\"Cook Islands\",\"Colombia\",\"Ivory Coast\",\"Bolivia\",\"Swaziland\",\"Zimbabwe\",\"Seychelles\",\"Cambodia\",\"Puerto Rico\",\"Netherlands Antilles\",\"Philippines\",\"Costa Rica\",\"Armenia\",\"Cuba\",\"Nicaragua\",\"Jamaica\",\"Ghana\",\"Liberia\",\"Uzbekistan\",\"Chad\",\"United Arab Emirates\",\"Kyrgyzstan\",\"India\",\"Turkmenistan\",\"Kenya\",\"Ethiopia\",\"Honduras\",\"Guinea-Bissau\",\"Zambia\",\"Republic of the Congo\",\"Guatemala\",\"Central African Republic\",\"North Korea\",\"Sri Lanka\",\"Mauritius\",\"Samoa\",\"Democratic Republic of the Congo\",\"Nauru\",\"Gambia\",\"Federated States of Micronesia\",\"El Salvador\",\"Fiji\",\"Papua New Guinea\",\"Kiribati\",\"Tajikistan\",\"Israel\",\"Sudan\",\"Malawi\",\"Lebanon\",\"Azerbaijan\",\"Mozambique\",\"Togo\",\"Nepal\",\"Brunei\",\"Benin\",\"Singapore\",\"Turkey\",\"Madagascar\",\"Solomon Islands\",\"Tonga\",\"Tunisia\",\"Tuvalu\",\"Qatar\",\"Vanuatu\",\"Djibouti\",\"Malaysia\",\"Syria\",\"Maldives\",\"Mali\",\"Eritrea\",\"Algeria\",\"Iran\",\"Oman\",\"Brunei\",\"Morocco\",\"Jordan\",\"Bhutan\",\"Guinea\",\"Burma\",\"Afghanistan\",\"Senegal\",\"Indonesia\",\"Timor-Leste\",\"Iraq\",\"Somalia\",\"Egypt\",\"Niger\",\"Yemen\",\"Comoros\",\"Saudi Arabia\",\"Bangladesh\",\"Kuwait\",\"Libya\",\"Mauritania\",\"Pakistan\"],\"z\":[17.5,16.8,15.4,15.1,14.4,13.9,13.8,13.3,13.0,13.0,12.9,12.6,12.5,12.5,12.3,12.3,12.3,12.2,12.2,12.2,11.9,11.9,11.8,11.6,11.6,11.4,11.4,11.2,11.0,11.0,10.9,10.9,10.8,10.7,10.4,10.3,10.3,10.3,10.3,10.2,10.1,9.9,9.8,9.8,9.6,9.3,9.3,9.2,9.2,9.2,8.9,8.8,8.7,8.7,8.7,8.5,8.4,8.4,8.2,8.1,8.1,8.0,8.0,7.9,7.7,7.7,7.7,7.6,7.5,7.3,7.2,7.2,7.2,7.1,7.1,7.1,7.1,7.1,7.0,7.0,6.9,6.9,6.9,6.9,6.8,6.8,6.7,6.7,6.7,6.7,6.6,6.6,6.6,6.6,6.5,6.4,6.4,6.2,6.0,5.9,5.7,5.7,5.6,5.5,5.4,5.4,5.4,5.4,5.3,5.2,5.0,4.9,4.8,4.7,4.6,4.4,4.3,4.3,4.3,4.3,4.3,4.2,4.0,4.0,4.0,3.9,3.8,3.8,3.7,3.7,3.6,3.6,3.6,3.5,3.4,3.3,3.2,3.0,3.0,3.0,2.8,2.8,2.7,2.5,2.4,2.3,2.3,2.3,2.2,2.1,2.1,2.0,2.0,1.8,1.7,1.6,1.5,1.5,1.5,1.4,1.3,1.3,1.2,1.2,1.1,1.1,1.0,1.0,0.9,0.9,0.9,0.7,0.7,0.7,0.7,0.7,0.6,0.6,0.6,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0.1,0.1,0.1,0.1],\"locationmode\":\"country names\"}];"
            |> chartGeneratedContains choroplethMap1Chart
        );
        testCase "Choropleth map 1 layout" ( fun () ->
            emptyLayout choroplethMap1Chart
        );
        testCase "Choropleth map 2 data" ( fun () ->
            "var data = [{\"type\":\"choropleth\",\"locations\":[\"Belarus\",\"Moldova\",\"Lithuania\",\"Russia\",\"Romania\",\"Ukraine\",\"Andorra\",\"Hungary\",\"Czech Republic\",\"Slovakia\",\"Portugal\",\"Serbia\",\"Grenada\",\"Poland\",\"Latvia\",\"Finland\",\"South Korea\",\"France\",\"Australia\",\"Croatia\",\"Ireland\",\"Luxembourg\",\"Germany\",\"Slovenia\",\"United Kingdom\",\"Denmark\",\"Bulgaria\",\"Spain\",\"Belgium\",\"South Africa\",\"New Zealand\",\"Gabon\",\"Namibia\",\"Switzerland\",\"Saint Lucia\",\"Austria\",\"Estonia\",\"Greece\",\"Kazakhstan\",\"Canada\",\"Nigeria\",\"Netherlands\",\"Uganda\",\"Rwanda\",\"Chile\",\"Argentina\",\"Burundi\",\"United States\",\"Cyprus\",\"Sweden\",\"Venezuela\",\"Paraguay\",\"Brazil\",\"Sierra Leone\",\"Montenegro\",\"Belize\",\"Cameroon\",\"Botswana\",\"Saint Kitts and Nevis\",\"Guyana\",\"Peru\",\"Panama\",\"Niue\",\"Palau\",\"Norway\",\"Tanzania\",\"Georgia\",\"Uruguay\",\"Angola\",\"Laos"
            |> chartGeneratedContains choroplethMap2Chart
        );
        testCase "Choropleth map 2 layout" ( fun () ->
            "var layout = {\"geo\":{\"projection\":{\"type\":\"mollweide\"},\"showocean\":true,\"oceancolor\":\"lightblue\",\"showlakes\":true,\"showrivers\":true}};"
            |> chartGeneratedContains choroplethMap2Chart
        );
    ]