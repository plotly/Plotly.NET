module TestUtils

open System.Reflection
open System.IO
open Expecto
open Plotly.NET
open DynamicObj
open Newtonsoft.Json

module DataGeneration =
    
    //---------------------- Generate linearly spaced vector ----------------------
    let linspace (min,max,n) = 
        if n <= 2 then failwithf "n needs to be larger then 2"
        let bw = float (max - min) / (float n - 1.)
        Array.init n (fun i -> min + (bw * float i))

    //-------------------- Generate linearly spaced mesh grid ---------------------
    let mgrid (min,max,n) = 

        let data = linspace(min,max,n)

        let z = [|for i in 1 .. n do [|for i in 1 .. n do yield data|]|]
        let x = [|for i in 1 .. n do [|for j in 1 .. n do yield [|for k in 1 .. n do yield data.[i-1]|]|]|]
        let y = [|for i in 1 .. n do [|for j in 1 .. n do yield [|for k in 1 .. n do yield data.[j-1]|]|]|]

        x,y,z

    let normal (rnd:System.Random) mu tau =
        let mutable v1 = 2.0 * rnd.NextDouble() - 1.0
        let mutable v2 = 2.0 * rnd.NextDouble() - 1.0
        let mutable r = v1 * v1 + v2 * v2
        while (r >= 1.0 || r = 0.0) do
            v1 <- 2.0 * rnd.NextDouble() - 1.0
            v2 <- 2.0 * rnd.NextDouble() - 1.0
            r <- v1 * v1 + v2 * v2
        let fac = sqrt(-2.0*(log r)/r)
        (tau * v1 * fac + mu)

    // this is not the original string, but its few first entries
    let [<Literal>] FlightData = """start_lat,start_lon,end_lat,end_lon,airline,airport1,airport2,cnt
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
25.79325,-80.29055556,39.17540167,-76.66819833,AA,MIA,BWI,112"""

    let [<Literal>] EarthquakeData ="""Date,Latitude,Longitude,Magnitude
01/02/1965,19.246,145.616,6.0
01/04/1965,1.8630000000000002,127.352,5.8
01/05/1965,-20.579,-173.972,6.2
01/08/1965,-59.076,-23.557,5.8
01/09/1965,11.937999999999999,126.427,5.8
01/10/1965,-13.405,166.62900000000002,6.7
01/12/1965,27.357,87.867,5.9
01/15/1965,-13.309000000000001,166.21200000000002,6.0
01/16/1965,-56.452,-27.043000000000003,6.0
01/17/1965,-24.563000000000002,178.487,5.8
01/17/1965,-6.807,108.988,5.9
01/24/1965,-2.608,125.95200000000001,8.2
01/29/1965,54.636,161.703,5.5
02/01/1965,-18.697,-177.864,5.6
02/02/1965,37.523,73.251,6.0
02/04/1965,-51.84,139.741,6.1
02/04/1965,51.251000000000005,178.715,8.7
02/04/1965,51.638999999999996,175.055,6.0
02/04/1965,52.528,172.007,5.7
02/04/1965,51.626000000000005,175.74599999999998,5.8
02/04/1965,51.037,177.84799999999998,5.9
02/04/1965,51.73,173.975,5.9
02/04/1965,51.775,173.058,5.7
02/04/1965,52.611000000000004,172.588,5.7
02/04/1965,51.831,174.368,5.7
02/04/1965,51.948,173.96900000000002,5.6
02/04/1965,51.443000000000005,179.605,7.3
02/04/1965,52.773,171.97400000000002,6.5
02/04/1965,51.772,174.696,5.6
02/04/1965,52.975,171.09099999999998,6.4
02/04/1965,52.99,170.87400000000002,5.8
02/04/1965,51.536,175.045,5.8
02/04/1965,13.245,-44.922,5.8
02/04/1965,51.812,174.206,5.7
02/05/1965,51.762,174.84099999999998,5.7
02/05/1965,52.438,174.321,6.3
02/05/1965,51.946000000000005,173.84,5.7
02/05/1965,51.738,174.56599999999997,6.0
02/05/1965,51.486999999999995,176.558,5.6
02/06/1965,53.008,-162.00799999999998,6.4
02/06/1965,52.184,175.505,6.2
02/06/1965,52.076,172.918,5.6
02/06/1965,51.744,175.213,5.7
02/06/1965,52.056999999999995,174.11599999999999,5.7
02/06/1965,53.191,-161.859,6.3
02/06/1965,51.446999999999996,176.46900000000002,5.8
02/07/1965,51.258,173.393,5.7
02/07/1965,52.031000000000006,175.41099999999997,5.7
02/07/1965,51.294,179.092,5.8
02/08/1965,55.223,165.426,5.9
02/09/1965,-18.718,169.386,5.6
02/09/1965,52.815,171.90400000000002,6.0
02/12/1965,52.188,172.752,5.8
02/15/1965,51.00899999999999,179.325,5.8
02/15/1965,3.0260000000000002,125.95100000000001,5.9
02/16/1965,38.908,142.095,5.7
02/17/1965,51.693999999999996,176.446,5.7
02/17/1965,21.526999999999997,143.08100000000002,5.6
02/18/1965,25.011,94.186,5.6"""
        

    let beverageConsumptionLocationData = [
        ("Belarus",17.5); ("Moldova",16.8);("Lithuania",15.4);("Russia",15.1);
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
        ("Libya",0.1);("Mauritania",0.1);("Pakistan",0.1);
    ]

module HtmlCodegen =

    let getLogoPNG() =
        let assembly = Assembly.GetExecutingAssembly()
        use str = assembly.GetManifestResourceStream($"FSharpTestBase.logo.png")
        use r = new BinaryReader(str)
        r.ReadBytes(int(str.Length))
        |> System.Convert.ToBase64String

    let getFullPlotlyJS() =
        let assembly = Assembly.GetExecutingAssembly()
        use str = assembly.GetManifestResourceStream($"FSharpTestBase.plotly-{Globals.PLOTLYJS_VERSION}.min.js")
        use r = new StreamReader(str)
        r.ReadToEnd()

    let substringIsInChart chart htmlizer substring =
        chart
        |> htmlizer
        |> Expect.stringContains
        |> (fun expecting -> expecting substring $"Should've contained {substring}")


    let substringListIsInChart chart htmlizer substringList =
        for substring in substringList do
            substringIsInChart chart htmlizer substring


    let chartGeneratedContains chart substring =
        substringIsInChart chart GenericChart.toChartHTML substring
        substringIsInChart chart GenericChart.toEmbeddedHTML substring


    let chartGeneratedContainsList chart substringList =
        for substring in substringList do
            chartGeneratedContains chart substring

    let emptyLayout chart =
        "var layout = {};" |> chartGeneratedContains chart

module JsonGen =
    
    let jsonIs chart expected =
        let json = chart |> GenericChart.toJson
        Expect.equal json expected $"JSON not equal to expected value."

    let figureJsonIs chart expected =
        let json = chart |> GenericChart.toFigureJson
        Expect.equal json expected $"JSON not equal to expected value."

module Objects =

    let jsonFieldIsSetWith fieldName expected (object:#DynamicObj) =
        Expect.equal
            ((object :> DynamicObj)?($"{fieldName}") |> fun o -> JsonConvert.SerializeObject(o, JsonSerializerSettings(ReferenceLoopHandling = ReferenceLoopHandling.Serialize))) 
            expected
            ($"Field `{fieldName}` not set correctly in serialized dynamic object.")

