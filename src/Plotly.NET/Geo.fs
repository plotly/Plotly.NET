namespace Plotly.NET

/// <summary>Determines the style of the map shown in geo traces</summary>
type Geo() = 

    inherit DynamicObj ()

    /// <summary>Initialize a Geo object that determines the style of the map shown in geo traces</summary>
    /// <param name="FitBounds">Determines if and how this subplot's view settings are auto-computed to fit trace data</param>
    /// <param name="Resolution">Sets the resolution of the base layers</param>
    /// <param name="Scope">Set the scope of the map.</param>
    /// <param name="Projection">Determines the type of projection used to display the map</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.</param>
    /// <param name="Visible">Wether or not the base layers are visible</param>
    /// <param name="Domain">The domain of this geo subplot</param>
    /// <param name="ShowCoastLines">Sets whether or not the coastlines are drawn.</param>
    /// <param name="CoastLineColor">Sets the coastline color.</param>
    /// <param name="CoastLineWidth">Sets the coastline stroke width (in px).</param>
    /// <param name="ShowLand">Sets whether or not land masses are filled in color.</param>
    /// <param name="LandColor">Sets the land mass color.</param>
    /// <param name="ShowOcean">Sets whether or not oceans are filled in color.</param>
    /// <param name="OceanColor">Sets the ocean color</param>
    /// <param name="ShowLakes">Sets whether or not lakes are drawn.</param>
    /// <param name="LakeColor">Sets the color of the lakes.</param>
    /// <param name="ShowRivers">Sets whether or not rivers are drawn.</param>
    /// <param name="RiverColor">Sets color of the rivers.</param>
    /// <param name="RiverWidth">Sets the stroke width (in px) of the rivers.</param>
    /// <param name="ShowCountries">Sets whether or not country boundaries are drawn.</param>
    /// <param name="CountryColor">Sets line color of the country boundaries.</param>
    /// <param name="CountryWidth">Sets line width (in px) of the country boundaries.</param>
    /// <param name="ShowSubunits">Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.</param>
    /// <param name="SubunitColor">Sets the color of the subunits boundaries.</param>
    /// <param name="SubunitWidth">Sets the stroke width (in px) of the subunits boundaries.</param>
    /// <param name="ShowFrame">Sets whether or not a frame is drawn around the map.</param>
    /// <param name="FrameColor">Sets the color the frame.</param>
    /// <param name="FrameWidth">Sets the stroke width (in px) of the frame.</param>
    /// <param name="BgColor">Set the background color of the map</param>
    /// <param name="LatAxis">Sets the latitudinal axis for this geo trace</param>
    /// <param name="LonAxis">Sets the longitudinal axis for this geo trace</param>
    static member init
        (   
           ?FitBounds: StyleParam.GeoFitBounds,
           ?Resolution: StyleParam.GeoResolution,
           ?Scope: StyleParam.GeoScope,
           ?Projection: GeoProjection,
           ?Center: (float*float),
           ?Visible: bool,
           ?Domain: Domain,
           ?ShowCoastLines: bool,
           ?CoastLineColor: string,
           ?CoastLineWidth: float,
           ?ShowLand: bool,
           ?LandColor: string,
           ?ShowOcean: bool,
           ?OceanColor: string,
           ?ShowLakes: bool,
           ?LakeColor: string,
           ?ShowRivers: bool,
           ?RiverColor: string,
           ?RiverWidth: float,
           ?ShowCountries: bool,
           ?CountryColor: string,
           ?CountryWidth: float,
           ?ShowSubunits: bool,
           ?SubunitColor: string,
           ?SubunitWidth: float,
           ?ShowFrame: bool,
           ?FrameColor: string,
           ?FrameWidth: float,
           ?BgColor: string,
           ?LatAxis: Axis.LinearAxis,
           ?LonAxis: Axis.LinearAxis

        ) =
            Geo()
            |> Geo.style
                (
                    ?FitBounds      = FitBounds     ,
                    ?Resolution     = Resolution    ,
                    ?Scope          = Scope         ,
                    ?Projection     = Projection    ,
                    ?Center         = Center        ,
                    ?Visible        = Visible       ,
                    ?Domain         = Domain        ,
                    ?ShowCoastLines = ShowCoastLines,
                    ?CoastLineColor = CoastLineColor,
                    ?CoastLineWidth = CoastLineWidth,
                    ?ShowLand       = ShowLand      ,
                    ?LandColor      = LandColor     ,
                    ?ShowOcean      = ShowOcean     ,
                    ?OceanColor     = OceanColor    ,
                    ?ShowLakes      = ShowLakes     ,
                    ?LakeColor      = LakeColor     ,
                    ?ShowRivers     = ShowRivers    ,
                    ?RiverColor     = RiverColor    ,
                    ?RiverWidth     = RiverWidth    ,
                    ?ShowCountries  = ShowCountries ,
                    ?CountryColor   = CountryColor  ,
                    ?CountryWidth   = CountryWidth  ,
                    ?ShowSubunits   = ShowSubunits  ,
                    ?SubunitColor   = SubunitColor  ,
                    ?SubunitWidth   = SubunitWidth  ,
                    ?ShowFrame      = ShowFrame     ,
                    ?FrameColor     = FrameColor    ,
                    ?FrameWidth     = FrameWidth    ,
                    ?BgColor        = BgColor       ,
                    ?LatAxis        = LatAxis       ,
                    ?LonAxis        = LonAxis       
                )

    /// <summary>Create a function that applies the given style parameters to a Geo object.</summary>
    /// <param name="FitBounds">Determines if and how this subplot's view settings are auto-computed to fit trace data</param>
    /// <param name="Resolution">Sets the resolution of the base layers</param>
    /// <param name="Scope">Set the scope of the map.</param>
    /// <param name="Projection">Determines the type of projection used to display the map</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.</param>
    /// <param name="Visible">Wether or not the base layers are visible</param>
    /// <param name="Domain">The domain of this geo subplot</param>
    /// <param name="ShowCoastLines">Sets whether or not the coastlines are drawn.</param>
    /// <param name="CoastLineColor">Sets the coastline color.</param>
    /// <param name="CoastLineWidth">Sets the coastline stroke width (in px).</param>
    /// <param name="ShowLand">Sets whether or not land masses are filled in color.</param>
    /// <param name="LandColor">Sets the land mass color.</param>
    /// <param name="ShowOcean">Sets whether or not oceans are filled in color.</param>
    /// <param name="OceanColor">Sets the ocean color</param>
    /// <param name="ShowLakes">Sets whether or not lakes are drawn.</param>
    /// <param name="LakeColor">Sets the color of the lakes.</param>
    /// <param name="ShowRivers">Sets whether or not rivers are drawn.</param>
    /// <param name="RiverColor">Sets color of the rivers.</param>
    /// <param name="RiverWidth">Sets the stroke width (in px) of the rivers.</param>
    /// <param name="ShowCountries">Sets whether or not country boundaries are drawn.</param>
    /// <param name="CountryColor">Sets line color of the country boundaries.</param>
    /// <param name="CountryWidth">Sets line width (in px) of the country boundaries.</param>
    /// <param name="ShowSubunits">Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.</param>
    /// <param name="SubunitColor">Sets the color of the subunits boundaries.</param>
    /// <param name="SubunitWidth">Sets the stroke width (in px) of the subunits boundaries.</param>
    /// <param name="ShowFrame">Sets whether or not a frame is drawn around the map.</param>
    /// <param name="FrameColor">Sets the color the frame.</param>
    /// <param name="FrameWidth">Sets the stroke width (in px) of the frame.</param>
    /// <param name="BgColor">Set the background color of the map</param>
    /// <param name="LatAxis">Sets the latitudinal axis for this geo trace</param>
    /// <param name="LonAxis">Sets the longitudinal axis for this geo trace</param>
    static member style
        (   
            ?FitBounds: StyleParam.GeoFitBounds,
            ?Resolution: StyleParam.GeoResolution,
            ?Scope: StyleParam.GeoScope,
            ?Projection: GeoProjection,
            ?Center: (float*float),
            ?Visible: bool,
            ?Domain: Domain,
            ?ShowCoastLines: bool,
            ?CoastLineColor: string,
            ?CoastLineWidth: float,
            ?ShowLand: bool,
            ?LandColor: string,
            ?ShowOcean: bool,
            ?OceanColor: string,
            ?ShowLakes: bool,
            ?LakeColor: string,
            ?ShowRivers: bool,
            ?RiverColor: string,
            ?RiverWidth: float,
            ?ShowCountries: bool,
            ?CountryColor: string,
            ?CountryWidth: float,
            ?ShowSubunits: bool,
            ?SubunitColor: string,
            ?SubunitWidth: float,
            ?ShowFrame: bool,
            ?FrameColor: string,
            ?FrameWidth: float,
            ?BgColor: string,
            ?LatAxis: Axis.LinearAxis,
            ?LonAxis: Axis.LinearAxis
        ) =
            (fun (geo:Geo) -> 
                
                Domain         |> DynObj.setValueOpt    geo "domain"
                FitBounds      |> DynObj.setValueOptBy  geo "fitbounds" StyleParam.GeoFitBounds.convert
                Resolution     |> DynObj.setValueOptBy  geo "resolution"StyleParam.GeoResolution.convert
                Scope          |> DynObj.setValueOptBy  geo "scope"     StyleParam.GeoScope.convert
                Projection     |> DynObj.setValueOpt    geo "projection"
                
                Center         
                |> Option.map (fun (lon,lat) -> 
                    let t = DynamicObj()
                    t?lon <- lon
                    t?lat <- lat
                    t
                )
                |> DynObj.setValueOpt geo "center"

                Visible         |> DynObj.setValueOpt    geo "visible"
                ShowCoastLines  |> DynObj.setValueOpt    geo "showcoastline"
                CoastLineColor  |> DynObj.setValueOpt    geo "coastlinecolor"
                CoastLineWidth  |> DynObj.setValueOpt    geo "coastlinewidth"
                ShowLand        |> DynObj.setValueOpt    geo "showland"
                LandColor       |> DynObj.setValueOpt    geo "landcolor"
                ShowOcean       |> DynObj.setValueOpt    geo "showocean"
                OceanColor      |> DynObj.setValueOpt    geo "oceancolor"
                ShowLakes       |> DynObj.setValueOpt    geo "showlakes"
                LakeColor       |> DynObj.setValueOpt    geo "lakecolor"
                ShowRivers      |> DynObj.setValueOpt    geo "showrivers"
                RiverColor      |> DynObj.setValueOpt    geo "rivercolor"
                RiverWidth      |> DynObj.setValueOpt    geo "riverwidth"
                ShowCountries   |> DynObj.setValueOpt    geo "showcountries"
                CountryColor    |> DynObj.setValueOpt    geo "countrycolor"
                CountryWidth    |> DynObj.setValueOpt    geo "countrywidth"
                ShowSubunits    |> DynObj.setValueOpt    geo "showsubunits"
                SubunitColor    |> DynObj.setValueOpt    geo "subunitcolor"
                SubunitWidth    |> DynObj.setValueOpt    geo "subunitwidth"
                ShowFrame       |> DynObj.setValueOpt    geo "showframe"
                FrameColor      |> DynObj.setValueOpt    geo "framecolor"
                FrameWidth      |> DynObj.setValueOpt    geo "framewidth"
                BgColor         |> DynObj.setValueOpt    geo "bgcolor"
                LatAxis         |> DynObj.setValueOpt    geo "lataxis"
                LonAxis         |> DynObj.setValueOpt    geo "lonaxis"

                geo
            ) 