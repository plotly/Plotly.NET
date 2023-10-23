module CoreTests.HTMLCodegen.ChartMap

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects


open TestUtils.HtmlCodegen
open ChartMapTestCharts

module GeoBaseMap =
    [<Tests>]
    let ``GeoBaseMap chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "GeoBaseMap" [
                testCase "Basemap data" ( fun () ->
                    """var data = [{"type":"scattergeo","mode":"markers","locations":[],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains GeoBaseMap.``Base map only``
                );
                testCase "Basemap layout" ( fun () ->
                    "var layout = {\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
                    |> chartGeneratedContains GeoBaseMap.``Base map only``
                );
                testCase "More features map data" ( fun () ->
                    """var data = [{"type":"scattergeo","mode":"markers","locations":[],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains GeoBaseMap.``styled base map only``
                );
                testCase "More features map layout" ( fun () ->
                    "var layout = {\"geo\":{\"resolution\":\"50\",\"showcoastline\":true,\"coastlinecolor\":\"RebeccaPurple\",\"showland\":true,\"landcolor\":\"LightGreen\",\"showocean\":true,\"oceancolor\":\"LightBlue\",\"showlakes\":true,\"lakecolor\":\"Blue\",\"showrivers\":true,\"rivercolor\":\"Blue\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
                    |> chartGeneratedContains GeoBaseMap.``styled base map only``
                );
                testCase "Cultural map data" ( fun () ->
                    """var data = [{"type":"scattergeo","mode":"markers","locations":[],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains GeoBaseMap.``Base map country borders at 1:50m resolution``
                );
                testCase "Cultural map layout" ( fun () ->
                    "var layout = {\"geo\":{\"resolution\":\"50\",\"visible\":false,\"showcountries\":true,\"countrycolor\":\"RebeccaPurple\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
                    |> chartGeneratedContains GeoBaseMap.``Base map country borders at 1:50m resolution``
                );
            ]
        ]

module ChoroplethMap =
    [<Tests>]
    let ``ChoroplethMap chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "ChoroplethMap" [
                testCase "Choropleth map 1 data" ( fun () ->
                    """var data = [{"type":"choropleth","z":[17.5,16.8,15.4,15.1,14.4,13.9,13.8,13.3,13.0,13.0,12.9,12.6,12.5,12.5,12.3,12.3,12.3,12.2,12.2,12.2,11.9,11.9,11.8,11.6,11.6,11.4,11.4,11.2,11.0,11.0,10.9,10.9,10.8,10.7,10.4,10.3,10.3,10.3,10.3,10.2,10.1,9.9,9.8,9.8,9.6,9.3,9.3,9.2,9.2,9.2,8.9,8.8,8.7,8.7,8.7,8.5,8.4,8.4,8.2,8.1,8.1,8.0,8.0,7.9,7.7,7.7,7.7,7.6,7.5,7.3,7.2,7.2,7.2,7.1,7.1,7.1,7.1,7.1,7.0,7.0,6.9,6.9,6.9,6.9,6.8,6.8,6.7,6.7,6.7,6.7,6.6,6.6,6.6,6.6,6.5,6.4,6.4,6.2,6.0,5.9,5.7,5.7,5.6,5.5,5.4,5.4,5.4,5.4,5.3,5.2,5.0,4.9,4.8,4.7,4.6,4.4,4.3,4.3,4.3,4.3,4.3,4.2,4.0,4.0,4.0,3.9,3.8,3.8,3.7,3.7,3.6,3.6,3.6,3.5,3.4,3.3,3.2,3.0,3.0,3.0,2.8,2.8,2.7,2.5,2.4,2.3,2.3,2.3,2.2,2.1,2.1,2.0,2.0,1.8,1.7,1.6,1.5,1.5,1.5,1.4,1.3,1.3,1.2,1.2,1.1,1.1,1.0,1.0,0.9,0.9,0.9,0.7,0.7,0.7,0.7,0.7,0.6,0.6,0.6,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0.1,0.1,0.1,0.1],"locations":["Belarus","Moldova","Lithuania","Russia","Romania","Ukraine","Andorra","Hungary","Czech Republic","Slovakia","Portugal","Serbia","Grenada","Poland","Latvia","Finland","South Korea","France","Australia","Croatia","Ireland","Luxembourg","Germany","Slovenia","United Kingdom","Denmark","Bulgaria","Spain","Belgium","South Africa","New Zealand","Gabon","Namibia","Switzerland","Saint Lucia","Austria","Estonia","Greece","Kazakhstan","Canada","Nigeria","Netherlands","Uganda","Rwanda","Chile","Argentina","Burundi","United States","Cyprus","Sweden","Venezuela","Paraguay","Brazil","Sierra Leone","Montenegro","Belize","Cameroon","Botswana","Saint Kitts and Nevis","Guyana","Peru","Panama","Niue","Palau","Norway","Tanzania","Georgia","Uruguay","Angola","Laos","Japan","Mexico","Ecuador","Dominica","Iceland","Thailand","Bosnia and Herzegovina","Sao Tome and Principe","Malta","Albania","Bahamas","Dominican Republic","Mongolia","Cape Verde","Barbados","Burkina Faso","Italy","Trinidad and Tobago","China","Macedonia","Saint Vincent and the Grenadines","Equatorial Guinea","Suriname","Vietnam","Lesotho","Haiti","Cook Islands","Colombia","Ivory Coast","Bolivia","Swaziland","Zimbabwe","Seychelles","Cambodia","Puerto Rico","Netherlands Antilles","Philippines","Costa Rica","Armenia","Cuba","Nicaragua","Jamaica","Ghana","Liberia","Uzbekistan","Chad","United Arab Emirates","Kyrgyzstan","India","Turkmenistan","Kenya","Ethiopia","Honduras","Guinea-Bissau","Zambia","Republic of the Congo","Guatemala","Central African Republic","North Korea","Sri Lanka","Mauritius","Samoa","Democratic Republic of the Congo","Nauru","Gambia","Federated States of Micronesia","El Salvador","Fiji","Papua New Guinea","Kiribati","Tajikistan","Israel","Sudan","Malawi","Lebanon","Azerbaijan","Mozambique","Togo","Nepal","Brunei","Benin","Singapore","Turkey","Madagascar","Solomon Islands","Tonga","Tunisia","Tuvalu","Qatar","Vanuatu","Djibouti","Malaysia","Syria","Maldives","Mali","Eritrea","Algeria","Iran","Oman","Brunei","Morocco","Jordan","Bhutan","Guinea","Burma","Afghanistan","Senegal","Indonesia","Timor-Leste","Iraq","Somalia","Egypt","Niger","Yemen","Comoros","Saudi Arabia","Bangladesh","Kuwait","Libya","Mauritania","Pakistan"],"locationmode":"country names"}];"""
                    |> chartGeneratedContains ChoroplethMap.``ChoroplethMap chart of top beverage consumption countries``
                );
                testCase "Choropleth map 1 layout" ( fun () ->
                    emptyLayout ChoroplethMap.``ChoroplethMap chart of top beverage consumption countries``
                );
                testCase "Choropleth map 2 data" ( fun () ->
                    """var data = [{"type":"choropleth","z":[17.5,16.8,15.4,15.1,14.4,13.9,13.8,13.3,13.0,13.0,12.9,12.6,12.5,12.5,12.3,12.3,12.3,12.2,12.2,12.2,11.9,11.9,11.8,11.6,11.6,11.4,11.4,11.2,11.0,11.0,10.9,10.9,10.8,10.7,10.4,10.3,10.3,10.3,10.3,10.2,10.1,9.9,9.8,9.8,9.6,9.3,9.3,9.2,9.2,9.2,8.9,8.8,8.7,8.7,8.7,8.5,8.4,8.4,8.2,8.1,8.1,8.0,8.0,7.9,7.7,7.7,7.7,7.6,7.5,7.3,7.2,7.2,7.2,7.1,7.1,7.1,7.1,7.1,7.0,7.0,6.9,6.9,6.9,6.9,6.8,6.8,6.7,6.7,6.7,6.7,6.6,6.6,6.6,6.6,6.5,6.4,6.4,6.2,6.0,5.9,5.7,5.7,5.6,5.5,5.4,5.4,5.4,5.4,5.3,5.2,5.0,4.9,4.8,4.7,4.6,4.4,4.3,4.3,4.3,4.3,4.3,4.2,4.0,4.0,4.0,3.9,3.8,3.8,3.7,3.7,3.6,3.6,3.6,3.5,3.4,3.3,3.2,3.0,3.0,3.0,2.8,2.8,2.7,2.5,2.4,2.3,2.3,2.3,2.2,2.1,2.1,2.0,2.0,1.8,1.7,1.6,1.5,1.5,1.5,1.4,1.3,1.3,1.2,1.2,1.1,1.1,1.0,1.0,0.9,0.9,0.9,0.7,0.7,0.7,0.7,0.7,0.6,0.6,0.6,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0.1,0.1,0.1,0.1],"locations":["Belarus","Moldova","Lithuania","Russia","Romania","Ukraine","Andorra","Hungary","Czech Republic","Slovakia","Portugal","Serbia","Grenada","Poland","Latvia","Finland","South Korea","France","Australia","Croatia","Ireland","Luxembourg","Germany","Slovenia","United Kingdom","Denmark","Bulgaria","Spain","Belgium","South Africa","New Zealand","Gabon","Namibia","Switzerland","Saint Lucia","Austria","Estonia","Greece","Kazakhstan","Canada","Nigeria","Netherlands","Uganda","Rwanda","Chile","Argentina","Burundi","United States","Cyprus","Sweden","Venezuela","Paraguay","Brazil","Sierra Leone","Montenegro","Belize","Cameroon","Botswana","Saint Kitts and Nevis","Guyana","Peru","Panama","Niue","Palau","Norway","Tanzania","Georgia","Uruguay","Angola","Laos","Japan","Mexico","Ecuador","Dominica","Iceland","Thailand","Bosnia and Herzegovina","Sao Tome and Principe","Malta","Albania","Bahamas","Dominican Republic","Mongolia","Cape Verde","Barbados","Burkina Faso","Italy","Trinidad and Tobago","China","Macedonia","Saint Vincent and the Grenadines","Equatorial Guinea","Suriname","Vietnam","Lesotho","Haiti","Cook Islands","Colombia","Ivory Coast","Bolivia","Swaziland","Zimbabwe","Seychelles","Cambodia","Puerto Rico","Netherlands Antilles","Philippines","Costa Rica","Armenia","Cuba","Nicaragua","Jamaica","Ghana","Liberia","Uzbekistan","Chad","United Arab Emirates","Kyrgyzstan","India","Turkmenistan","Kenya","Ethiopia","Honduras","Guinea-Bissau","Zambia","Republic of the Congo","Guatemala","Central African Republic","North Korea","Sri Lanka","Mauritius","Samoa","Democratic Republic of the Congo","Nauru","Gambia","Federated States of Micronesia","El Salvador","Fiji","Papua New Guinea","Kiribati","Tajikistan","Israel","Sudan","Malawi","Lebanon","Azerbaijan","Mozambique","Togo","Nepal","Brunei","Benin","Singapore","Turkey","Madagascar","Solomon Islands","Tonga","Tunisia","Tuvalu","Qatar","Vanuatu","Djibouti","Malaysia","Syria","Maldives","Mali","Eritrea","Algeria","Iran","Oman","Brunei","Morocco","Jordan","Bhutan","Guinea","Burma","Afghanistan","Senegal","Indonesia","Timor-Leste","Iraq","Somalia","Egypt","Niger","Yemen","Comoros","Saudi Arabia","Bangladesh","Kuwait","Libya","Mauritania","Pakistan"],"locationmode":"country names","colorbar":{"len":0.5,"title":{"text":"Alcohol consumption[l/y]"}}}];"""
                    |> chartGeneratedContains ChoroplethMap.``ChoroplethMap chart of top beverage consumption countries with styled map and projecton``
                );
                testCase "Choropleth map 2 layout" ( fun () ->
                    "var layout = {\"geo\":{\"projection\":{\"type\":\"mollweide\"},\"showocean\":true,\"oceancolor\":\"lightblue\",\"showlakes\":true,\"showrivers\":true}};"
                    |> chartGeneratedContains ChoroplethMap.``ChoroplethMap chart of top beverage consumption countries with styled map and projecton``
                );
            ]
        ]

module ScatterGeo =
    [<Tests>]
    let ``ScatterGeo chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "ScatterGeo" [
            ]
        ]

module PointGeo =
    [<Tests>]
    let ``PointGeo chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "PointGeo" [
                testCase "Point geo data" ( fun () ->
                    """var data = [{"type":"scattergeo","mode":"markers+text","lat":[45.5,43.4,49.13,51.1,53.34,45.24,44.64,48.25,49.89,50.45],"lon":[-73.57,-79.24,-123.06,-114.1,-113.28,-75.43,-63.57,-123.21,-97.13,-104.6],"text":["Montreal","Toronto","Vancouver","Calgary","Edmonton","Ottawa","Halifax","Victoria","Winnepeg","Regina"],"textposition":"top center","marker":{},"line":{}}];"""
                    |> chartGeneratedContains PointGeo.``Point geo chart of canadian cities``
                );
                testCase "Point geo layout" ( fun () ->
                    "var layout = {\"geo\":{\"scope\":\"north america\",\"projection\":{\"type\":\"azimuthal equal area\"},\"countrycolor\":\"lightgrey\"},\"margin\":{\"l\":0,\"r\":0,\"t\":0,\"b\":0}};"
                    |> chartGeneratedContains PointGeo.``Point geo chart of canadian cities``
                );
            ]
        ]

module LineGeo =
    [<Tests>]
    let ``LineGeo chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "LineGeo" [
                testCase "Flight map data" ( fun () ->
                    """var data = [{"type":"scattergeo","opacity":1.0,"mode":"lines","lat":[32.89595056,35.04022222],"lon":[-97.0372,-106.6091944],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.3738738738738739,"mode":"lines","lat":[41.979595,30.19453278],"lon":[-87.90446417,-97.66987194],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.36486486486486486,"mode":"lines","lat":[32.89595056,41.93887417],"lon":[-97.0372,-72.68322833],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.12612612612612611,"mode":"lines","lat":[18.43941667,41.93887417],"lon":[-66.00183333,-72.68322833],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.3783783783783784,"mode":"lines","lat":[32.89595056,33.56294306],"lon":[-97.0372,-86.75354972],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.12612612612612611,"mode":"lines","lat":[25.79325,36.12447667],"lon":[-80.29055556,-86.67818222],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.9504504504504504,"mode":"lines","lat":[32.89595056,42.3643475],"lon":[-97.0372,-71.00517917],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.8828828828828829,"mode":"lines","lat":[25.79325,42.3643475],"lon":[-80.29055556,-71.00517917],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.9684684684684685,"mode":"lines","lat":[41.979595,42.3643475],"lon":[-87.90446417,-71.00517917],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.12612612612612611,"mode":"lines","lat":[18.43941667,42.3643475],"lon":[-66.00183333,-71.00517917],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.0990990990990991,"mode":"lines","lat":[18.33730556,42.3643475],"lon":[-64.97336111,-71.00517917],"marker":{"color":"red"},"line":{}},{"type":"scattergeo","opacity":0.25225225225225223,"mode":"lines","lat":[25.79325,39.17540167],"lon":[-80.29055556,-76.66819833],"marker":{"color":"red"},"line":{}}];"""
                    |> chartGeneratedContains LineGeo.``LineGeo plot of feb. 2011 American Airline flights``
                );
                testCase "Flight map layout" ( fun () ->
                    "var layout = {\"showlegend\":false,\"geo\":{\"scope\":\"north america\",\"projection\":{\"type\":\"azimuthal equal area\"},\"showland\":true,\"landcolor\":\"lightgrey\"},\"margin\":{\"l\":0,\"r\":0,\"t\":50,\"b\":0},\"title\":{\"text\":\"Feb. 2011 American Airline flights\"}};"
                    |> chartGeneratedContains LineGeo.``LineGeo plot of feb. 2011 American Airline flights``
                );
            ]
        ]

module BubbleGeo =
    [<Tests>]
    let ``BubbleGeo chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "BubbleGeo" [
            ]
        ]

module MapboxBaseMap =
    [<Tests>]
    let ``Mapbox base map chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "MapboxBaseMap" [
                testCase "Mapbox open streetmap layer only data" ( fun () ->
                    """var data = [{"type":"scattermapbox","mode":"markers","lat":[],"lon":[],"cluster":{},"marker":{},"line":{}}];"""
                    |> chartGeneratedContains MapboxBaseMap.``Open streetmap layer only``
                );
                testCase "Mapbox open streetmap layer only layout" ( fun () ->
                    "var layout = {\"mapbox\":{\"style\":\"open-street-map\"}};"
                    |> chartGeneratedContains MapboxBaseMap.``Open streetmap layer only``
                );
            ]
        ]

module ScatterMapbox =
    [<Tests>]
    let ``ScatterMapbox chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "ScatterMapbox" [
            ]
        ]

module PointMapbox =
    [<Tests>]
    let ``PointMapbox chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "PointMapbox" [
                testCase "Point mapbox data" ( fun () ->
                    """var data = [{"type":"scattermapbox","mode":"markers+text","lat":[45.5,43.4,49.13,51.1,53.34,45.24,44.64,48.25,49.89,50.45],"lon":[-73.57,-79.24,-123.06,-114.1,-113.28,-75.43,-63.57,-123.21,-97.13,-104.6],"cluster":{},"text":["Montreal","Toronto","Vancouver","Calgary","Edmonton","Ottawa","Halifax","Victoria","Winnepeg","Regina"],"textposition":"top center","marker":{},"line":{}}];"""
                    |> chartGeneratedContains PointMapbox.``Point mapbox chart of canadian cities``
                );
                testCase "Point mapbox layout" ( fun () ->
                    "var layout = {\"mapbox\":{\"style\":\"open-street-map\",\"center\":{\"lon\":-104.6,\"lat\":50.45}}};"
                    |> chartGeneratedContains PointMapbox.``Point mapbox chart of canadian cities``
                );
            ]
        ]
module LineMapbox =
    [<Tests>]
    let ``LineMapbox chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "LineMapbox" [
                testCase "Flights mapbox data" ( fun () ->
                    """var data = [{"type":"scattermapbox","opacity":1.0,"mode":"lines","lat":[32.89595056,35.04022222],"lon":[-97.0372,-106.6091944],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.3738738738738739,"mode":"lines","lat":[41.979595,30.19453278],"lon":[-87.90446417,-97.66987194],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.36486486486486486,"mode":"lines","lat":[32.89595056,41.93887417],"lon":[-97.0372,-72.68322833],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.12612612612612611,"mode":"lines","lat":[18.43941667,41.93887417],"lon":[-66.00183333,-72.68322833],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.3783783783783784,"mode":"lines","lat":[32.89595056,33.56294306],"lon":[-97.0372,-86.75354972],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.12612612612612611,"mode":"lines","lat":[25.79325,36.12447667],"lon":[-80.29055556,-86.67818222],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.9504504504504504,"mode":"lines","lat":[32.89595056,42.3643475],"lon":[-97.0372,-71.00517917],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.8828828828828829,"mode":"lines","lat":[25.79325,42.3643475],"lon":[-80.29055556,-71.00517917],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.9684684684684685,"mode":"lines","lat":[41.979595,42.3643475],"lon":[-87.90446417,-71.00517917],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.12612612612612611,"mode":"lines","lat":[18.43941667,42.3643475],"lon":[-66.00183333,-71.00517917],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.0990990990990991,"mode":"lines","lat":[18.33730556,42.3643475],"lon":[-64.97336111,-71.00517917],"cluster":{},"marker":{},"line":{"color":"red"}},{"type":"scattermapbox","opacity":0.25225225225225223,"mode":"lines","lat":[25.79325,39.17540167],"lon":[-80.29055556,-76.66819833],"cluster":{},"marker":{},"line":{"color":"red"}}];"""
                    |> chartGeneratedContains LineMapbox.``LineMapbox plot of feb. 2011 American Airline flights``
                );
                testCase "Flights mapbox layout" ( fun () ->
                    """var layout = {"mapbox":{"style":"open-street-map","center":{"lon":-97.0372,"lat":32.8959}},"showlegend":false,"margin":{"l":0,"r":0,"t":50,"b":0},"title":{"text":"Feb. 2011 American Airline flights"}};"""
                    |> chartGeneratedContains LineMapbox.``LineMapbox plot of feb. 2011 American Airline flights``
                );
            ]
        ]

module BubbleMapbox =
    [<Tests>]
    let ``BubbleMapbox chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "BubbleMapbox" [
            ]
        ]

module ChoroplethMapbox =
    [<Tests>]
    let ``ChoroplethMapbox chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "ChoroplethMapbox" [
            ]
        ]

module DensityMapbox =
    [<Tests>]
    let ``DensityMapbox chart HTML codegeneration tests`` =
        testList "HTMLCodegen.ChartMap" [
            testList "DensityMapbox" [
                testCase "Density Mapbox data" ( fun () ->
                    """var data = [{"type":"densitymapbox","z":[6.0,5.8,6.2,5.8,5.8,6.7,5.9,6.0,6.0,5.8,5.9,8.2,5.5,5.6,6.0,6.1,8.7,6.0,5.7,5.8,5.9,5.9,5.7,5.7,5.7,5.6,7.3,6.5,5.6,6.4,5.8,5.8,5.8,5.7,5.7,6.3,5.7,6.0,5.6,6.4,6.2,5.6,5.7,5.7,6.3,5.8,5.7,5.7,5.8,5.9,5.6,6.0,5.8,5.8,5.9,5.7,5.7,5.6,5.6],"radius":8,"lat":[19.246,1.863,-20.579,-59.076,11.938,-13.405,27.357,-13.309,-56.452,-24.563,-6.807,-2.608,54.636,-18.697,37.523,-51.84,51.251000000000005,51.639,52.528,51.626000000000005,51.037,51.73,51.775,52.611,51.831,51.948,51.443000000000005,52.773,51.772,52.975,52.99,51.536,13.245,51.812,51.762,52.438,51.946000000000005,51.738,51.486999999999995,53.008,52.184,52.076,51.744,52.056999999999995,53.191,51.447,51.258,52.031000000000006,51.294,55.223,-18.718,52.815,52.188,51.00899999999999,3.026,38.908,51.694,21.526999999999997,25.011],"lon":[145.616,127.352,-173.972,-23.557,126.427,166.62900000000002,87.867,166.21200000000002,-27.043000000000003,178.487,108.988,125.952,161.703,-177.864,73.251,139.741,178.715,175.055,172.007,175.74599999999998,177.84799999999998,173.975,173.058,172.588,174.368,173.96900000000002,179.605,171.97400000000002,174.696,171.09099999999998,170.87400000000002,175.045,-44.922,174.206,174.84099999999998,174.321,173.84,174.56599999999997,176.558,-162.00799999999998,175.505,172.918,175.213,174.116,-161.859,176.46900000000002,173.393,175.41099999999997,179.092,165.426,169.386,171.90400000000002,172.752,179.325,125.951,142.095,176.446,143.08100000000002,94.186],"colorscale":"Viridis"}];"""
                    |> chartGeneratedContains DensityMapbox.``Density mapbox chart of earthquakes``
                );
                testCase "Density Mapbox layout" ( fun () ->
                    "var layout = {\"mapbox\":{\"style\":\"stamen-terrain\",\"center\":{\"lon\":60.0,\"lat\":30.0}}};"
                    |> chartGeneratedContains DensityMapbox.``Density mapbox chart of earthquakes``
                );
            ]
        ]
