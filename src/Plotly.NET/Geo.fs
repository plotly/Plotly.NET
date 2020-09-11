namespace Plotly.NET

/// Determines the style of the map shown in geo traces
///
/// Parameters      :
///
/// FitBounds       : Determines if and how this subplot's view settings are auto-computed to fit trace data
///
/// Resolution      : Sets the resolution of the base layers
///
/// Scope           : Set the scope of the map.
///
/// Projection      : Determines the type of projection used to display the map
///
/// Center          : Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.
///
/// Visible         : Wether or not the base layers are visible
///
/// Domain          : The domain of this geo subplot
///
/// ShowCoastLine   : Sets whether or not the coastlines are drawn.
///
/// CoastLineColor  : Sets the coastline color.
///
/// CoastLineWidth  : Sets the coastline stroke width (in px).
///
/// ShowLand        : Sets whether or not land masses are filled in color.
///
/// LandColor       : Sets the land mass color.
///
/// ShowOcean       : Sets whether or not oceans are filled in color.
///
/// OceanColor      : Sets the ocean color
///
/// ShowLakes       : Sets whether or not lakes are drawn.
///
/// LakeColor       : Sets the color of the lakes.
///
/// ShowRivers      : Sets whether or not rivers are drawn.
///
/// RiverColor      : Sets color of the rivers.
///
/// RiverWidth      : Sets the stroke width (in px) of the rivers.
///
/// ShowCountries   : Sets whether or not country boundaries are drawn.
///
/// CountryColor    : Sets line color of the country boundaries.
///
/// CountryWidth    : Sets line width (in px) of the country boundaries.
///
/// ShowSubunits    : Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.
///
/// SubunitColor    : Sets the color of the subunits boundaries.
///
/// SubunitWidth    : Sets the stroke width (in px) of the subunits boundaries.
///
/// ShowFrame       : Sets whether or not a frame is drawn around the map.
///
/// FrameColor      : Sets the color the frame.
///
/// FrameWidth      : Sets the stroke width (in px) of the frame.
///
/// BgColor         : Set the background color of the map
///
/// LatAxis         : Sets the latitudinal axis for this geo trace
///
/// LonAxis         : Sets the longitudinal axis for this geo trace
type Geo() = 

    inherit DynamicObj ()

    static member init
        (   
           ?FitBounds       : StyleParam.GeoFitBounds,
           ?Resolution      : StyleParam.GeoResolution,
           ?Scope           : StyleParam.GeoScope,
           ?Projection      : GeoProjection,
           ?Center          : (float*float),
           ?Visible         : bool,
           ?Domain          : Domain,
           ?ShowCoastLines  : bool,
           ?CoastLineColor,
           ?CoastLineWidth  : float,
           ?ShowLand        : bool,
           ?LandColor,
           ?ShowOcean       : bool,
           ?OceanColor,
           ?ShowLakes       : bool,
           ?LakeColor,
           ?ShowRivers      : bool,
           ?RiverColor,
           ?RiverWidth      : float,
           ?ShowCountries   : bool,
           ?CountryColor,
           ?CountryWidth    : float,
           ?ShowSubunits    : bool,
           ?SubunitColor,
           ?SubunitWidth    : float,
           ?ShowFrame       : bool,
           ?FrameColor,
           ?FrameWidth      : float,
           ?BgColor,
           ?LatAxis         : Axis.LinearAxis,
           ?LonAxis         : Axis.LinearAxis

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

    static member style
        (   
            ?Domain          : Domain,
            ?FitBounds       : StyleParam.GeoFitBounds,
            ?Resolution      : StyleParam.GeoResolution,
            ?Scope           : StyleParam.GeoScope,
            ?Projection      : GeoProjection,
            ?Center          : (float*float),
            ?Visible         : bool,
            ?ShowCoastLines  : bool,
            ?CoastLineColor,
            ?CoastLineWidth  : float,
            ?ShowLand        : bool,
            ?LandColor,
            ?ShowOcean       : bool,
            ?OceanColor,
            ?ShowLakes       : bool,
            ?LakeColor,
            ?ShowRivers      : bool,
            ?RiverColor,
            ?RiverWidth      : float,
            ?ShowCountries   : bool,
            ?CountryColor,
            ?CountryWidth    : float,
            ?ShowSubunits    : bool,
            ?SubunitColor,
            ?SubunitWidth    : float,
            ?ShowFrame       : bool,
            ?FrameColor,
            ?FrameWidth      : float,
            ?BgColor,
            ?LatAxis         : Axis.LinearAxis,
            ?LonAxis         : Axis.LinearAxis
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