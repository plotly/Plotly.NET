(**
// can't yet format YamlFrontmatter (["title: Choropleth maps"; "category: Map Charts"; "categoryindex: 6"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Choropleth maps

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=5_0_choropleth-map.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/5_0_choropleth-map.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/5_0_choropleth-map.ipynb)

*Summary:* This example shows how to create choropleth map in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 

// Pure alcohol consumption among adults (age 15+) in 2010
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
(**
Choropleth Maps display divided geographical areas or regions that are coloured, shaded or patterned in relation to 
a data variable. This provides a way to visualise values over a geographical area, which can show variation or 
patterns across the displayed location.
*)
let choroplethMap1 =
    Chart.ChoroplethMap(
        locations,z,
        Locationmode=StyleParam.LocationFormat.CountryNames
    )(* output: 
<div id="f204a4f7-5a7b-411f-bf45-99058522e047" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f204a4f75a7b411fbf4599058522e047 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"choropleth","locations":["Belarus","Moldova","Lithuania","Russia","Romania","Ukraine","Andorra","Hungary","Czech Republic","Slovakia","Portugal","Serbia","Grenada","Poland","Latvia","Finland","South Korea","France","Australia","Croatia","Ireland","Luxembourg","Germany","Slovenia","United Kingdom","Denmark","Bulgaria","Spain","Belgium","South Africa","New Zealand","Gabon","Namibia","Switzerland","Saint Lucia","Austria","Estonia","Greece","Kazakhstan","Canada","Nigeria","Netherlands","Uganda","Rwanda","Chile","Argentina","Burundi","United States","Cyprus","Sweden","Venezuela","Paraguay","Brazil","Sierra Leone","Montenegro","Belize","Cameroon","Botswana","Saint Kitts and Nevis","Guyana","Peru","Panama","Niue","Palau","Norway","Tanzania","Georgia","Uruguay","Angola","Laos","Japan","Mexico","Ecuador","Dominica","Iceland","Thailand","Bosnia and Herzegovina","Sao Tome and Principe","Malta","Albania","Bahamas","Dominican Republic","Mongolia","Cape Verde","Barbados","Burkina Faso","Italy","Trinidad and Tobago","China","Macedonia","Saint Vincent and the Grenadines","Equatorial Guinea","Suriname","Vietnam","Lesotho","Haiti","Cook Islands","Colombia","Ivory Coast","Bolivia","Swaziland","Zimbabwe","Seychelles","Cambodia","Puerto Rico","Netherlands Antilles","Philippines","Costa Rica","Armenia","Cuba","Nicaragua","Jamaica","Ghana","Liberia","Uzbekistan","Chad","United Arab Emirates","Kyrgyzstan","India","Turkmenistan","Kenya","Ethiopia","Honduras","Guinea-Bissau","Zambia","Republic of the Congo","Guatemala","Central African Republic","North Korea","Sri Lanka","Mauritius","Samoa","Democratic Republic of the Congo","Nauru","Gambia","Federated States of Micronesia","El Salvador","Fiji","Papua New Guinea","Kiribati","Tajikistan","Israel","Sudan","Malawi","Lebanon","Azerbaijan","Mozambique","Togo","Nepal","Brunei","Benin","Singapore","Turkey","Madagascar","Solomon Islands","Tonga","Tunisia","Tuvalu","Qatar","Vanuatu","Djibouti","Malaysia","Syria","Maldives","Mali","Eritrea","Algeria","Iran","Oman","Brunei","Morocco","Jordan","Bhutan","Guinea","Burma","Afghanistan","Senegal","Indonesia","Timor-Leste","Iraq","Somalia","Egypt","Niger","Yemen","Comoros","Saudi Arabia","Bangladesh","Kuwait","Libya","Mauritania","Pakistan"],"z":[17.5,16.8,15.4,15.1,14.4,13.9,13.8,13.3,13.0,13.0,12.9,12.6,12.5,12.5,12.3,12.3,12.3,12.2,12.2,12.2,11.9,11.9,11.8,11.6,11.6,11.4,11.4,11.2,11.0,11.0,10.9,10.9,10.8,10.7,10.4,10.3,10.3,10.3,10.3,10.2,10.1,9.9,9.8,9.8,9.6,9.3,9.3,9.2,9.2,9.2,8.9,8.8,8.7,8.7,8.7,8.5,8.4,8.4,8.2,8.1,8.1,8.0,8.0,7.9,7.7,7.7,7.7,7.6,7.5,7.3,7.2,7.2,7.2,7.1,7.1,7.1,7.1,7.1,7.0,7.0,6.9,6.9,6.9,6.9,6.8,6.8,6.7,6.7,6.7,6.7,6.6,6.6,6.6,6.6,6.5,6.4,6.4,6.2,6.0,5.9,5.7,5.7,5.6,5.5,5.4,5.4,5.4,5.4,5.3,5.2,5.0,4.9,4.8,4.7,4.6,4.4,4.3,4.3,4.3,4.3,4.3,4.2,4.0,4.0,4.0,3.9,3.8,3.8,3.7,3.7,3.6,3.6,3.6,3.5,3.4,3.3,3.2,3.0,3.0,3.0,2.8,2.8,2.7,2.5,2.4,2.3,2.3,2.3,2.2,2.1,2.1,2.0,2.0,1.8,1.7,1.6,1.5,1.5,1.5,1.4,1.3,1.3,1.2,1.2,1.1,1.1,1.0,1.0,0.9,0.9,0.9,0.7,0.7,0.7,0.7,0.7,0.6,0.6,0.6,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0.1,0.1,0.1,0.1],"locationmode":"country names"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('f204a4f7-5a7b-411f-bf45-99058522e047', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f204a4f75a7b411fbf4599058522e047();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f204a4f75a7b411fbf4599058522e047();
            }
</script>
*)
(**
## Map styling

you can access various map styles via `Chart.withMapStyle`, such as the projection type, lake/ocean color, and so on.
*)
let choroplethMap2 =
    Chart.ChoroplethMap(
        locations,z,
        Locationmode=StyleParam.LocationFormat.CountryNames
    )
    |> Chart.withMapStyle(
        Projection=GeoProjection.init(projectionType=StyleParam.GeoProjectionType.Mollweide),
        ShowLakes=true,
        ShowOcean=true,
        OceanColor="lightblue",
        ShowRivers=true)
    |> Chart.withColorBarStyle ("Alcohol consumption[l/y]",Length=0.5)(* output: 
<div id="60626490-3ea7-4172-805f-0e6e2856351e" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_606264903ea74172805f0e6e2856351e = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"choropleth","locations":["Belarus","Moldova","Lithuania","Russia","Romania","Ukraine","Andorra","Hungary","Czech Republic","Slovakia","Portugal","Serbia","Grenada","Poland","Latvia","Finland","South Korea","France","Australia","Croatia","Ireland","Luxembourg","Germany","Slovenia","United Kingdom","Denmark","Bulgaria","Spain","Belgium","South Africa","New Zealand","Gabon","Namibia","Switzerland","Saint Lucia","Austria","Estonia","Greece","Kazakhstan","Canada","Nigeria","Netherlands","Uganda","Rwanda","Chile","Argentina","Burundi","United States","Cyprus","Sweden","Venezuela","Paraguay","Brazil","Sierra Leone","Montenegro","Belize","Cameroon","Botswana","Saint Kitts and Nevis","Guyana","Peru","Panama","Niue","Palau","Norway","Tanzania","Georgia","Uruguay","Angola","Laos","Japan","Mexico","Ecuador","Dominica","Iceland","Thailand","Bosnia and Herzegovina","Sao Tome and Principe","Malta","Albania","Bahamas","Dominican Republic","Mongolia","Cape Verde","Barbados","Burkina Faso","Italy","Trinidad and Tobago","China","Macedonia","Saint Vincent and the Grenadines","Equatorial Guinea","Suriname","Vietnam","Lesotho","Haiti","Cook Islands","Colombia","Ivory Coast","Bolivia","Swaziland","Zimbabwe","Seychelles","Cambodia","Puerto Rico","Netherlands Antilles","Philippines","Costa Rica","Armenia","Cuba","Nicaragua","Jamaica","Ghana","Liberia","Uzbekistan","Chad","United Arab Emirates","Kyrgyzstan","India","Turkmenistan","Kenya","Ethiopia","Honduras","Guinea-Bissau","Zambia","Republic of the Congo","Guatemala","Central African Republic","North Korea","Sri Lanka","Mauritius","Samoa","Democratic Republic of the Congo","Nauru","Gambia","Federated States of Micronesia","El Salvador","Fiji","Papua New Guinea","Kiribati","Tajikistan","Israel","Sudan","Malawi","Lebanon","Azerbaijan","Mozambique","Togo","Nepal","Brunei","Benin","Singapore","Turkey","Madagascar","Solomon Islands","Tonga","Tunisia","Tuvalu","Qatar","Vanuatu","Djibouti","Malaysia","Syria","Maldives","Mali","Eritrea","Algeria","Iran","Oman","Brunei","Morocco","Jordan","Bhutan","Guinea","Burma","Afghanistan","Senegal","Indonesia","Timor-Leste","Iraq","Somalia","Egypt","Niger","Yemen","Comoros","Saudi Arabia","Bangladesh","Kuwait","Libya","Mauritania","Pakistan"],"z":[17.5,16.8,15.4,15.1,14.4,13.9,13.8,13.3,13.0,13.0,12.9,12.6,12.5,12.5,12.3,12.3,12.3,12.2,12.2,12.2,11.9,11.9,11.8,11.6,11.6,11.4,11.4,11.2,11.0,11.0,10.9,10.9,10.8,10.7,10.4,10.3,10.3,10.3,10.3,10.2,10.1,9.9,9.8,9.8,9.6,9.3,9.3,9.2,9.2,9.2,8.9,8.8,8.7,8.7,8.7,8.5,8.4,8.4,8.2,8.1,8.1,8.0,8.0,7.9,7.7,7.7,7.7,7.6,7.5,7.3,7.2,7.2,7.2,7.1,7.1,7.1,7.1,7.1,7.0,7.0,6.9,6.9,6.9,6.9,6.8,6.8,6.7,6.7,6.7,6.7,6.6,6.6,6.6,6.6,6.5,6.4,6.4,6.2,6.0,5.9,5.7,5.7,5.6,5.5,5.4,5.4,5.4,5.4,5.3,5.2,5.0,4.9,4.8,4.7,4.6,4.4,4.3,4.3,4.3,4.3,4.3,4.2,4.0,4.0,4.0,3.9,3.8,3.8,3.7,3.7,3.6,3.6,3.6,3.5,3.4,3.3,3.2,3.0,3.0,3.0,2.8,2.8,2.7,2.5,2.4,2.3,2.3,2.3,2.2,2.1,2.1,2.0,2.0,1.8,1.7,1.6,1.5,1.5,1.5,1.4,1.3,1.3,1.2,1.2,1.1,1.1,1.0,1.0,0.9,0.9,0.9,0.7,0.7,0.7,0.7,0.7,0.6,0.6,0.6,0.5,0.5,0.4,0.3,0.3,0.2,0.2,0.2,0.1,0.1,0.1,0.1],"locationmode":"country names","colorbar":{"len":0.5,"title":"Alcohol consumption[l/y]"}}];
            var layout = {"geo":{"projection":{"type":"mollweide"},"showocean":true,"oceancolor":"lightblue","showlakes":true,"showrivers":true}};
            var config = {};
            Plotly.newPlot('60626490-3ea7-4172-805f-0e6e2856351e', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_606264903ea74172805f0e6e2856351e();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_606264903ea74172805f0e6e2856351e();
            }
</script>
*)

