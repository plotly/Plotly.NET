namespace Plotly.NET

type Polar () =
    inherit DynamicObj ()

    /// <summary>
    /// Initialize a Polar object that contains layout options concerned with polar plots.
    /// </summary>
    /// <param name="Domain">Sets the domain of this polar subplot</param>
    /// <param name="Sector">Sets angular span of this polar subplot with two angles (in degrees). Sector are assumed to be spanned in the counterclockwise direction with "0" corresponding to rightmost limit of the polar subplot.</param>
    /// <param name="Hole">Sets the fraction of the radius to cut out of the polar subplot.</param>
    /// <param name="BGColor">Set the background color of the subplot</param>
    /// <param name="RadialAxis">Sets the radial axis of the polar subplot.</param>
    /// <param name="AngularAxis">Sets the angular axis of the polar subplot.</param>
    /// <param name="GridShape">Determines if the radial axis grid lines and angular axis line are drawn as "circular" sectors or as "linear" (polygon) sectors. Has an effect only when the angular axis has `type` "category". Note that `radialaxis.angle` is snapped to the angle of the closest vertex when `gridshape` is "circular" (so that radial axis scale is the same as the data scale).</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in axis attributes, if not overridden in the individual axes. Defaults to `layout.uirevision`.</param>
    static member init
        (    
            ?Domain     : Domain,
            ?Sector     : float*float,
            ?Hole       : float,
            ?BGColor    : string,
            ?RadialAxis : Axis.RadialAxis,
            ?AngularAxis: Axis.AngularAxis,
            ?GridShape  : StyleParam.PolarGridShape,
            ?UIRevision : string
        ) =    
            Polar()
            |> Polar.style
                (
                    ?Domain     = Domain     ,
                    ?Sector     = Sector     ,
                    ?Hole       = Hole       ,
                    ?BGColor    = BGColor    ,
                    ?RadialAxis = RadialAxis ,
                    ?AngularAxis= AngularAxis,
                    ?GridShape  = GridShape  ,
                    ?UIRevision = UIRevision 
                )

    /// <summary>
    /// Create a function that applies the given style parameters to a Polar object
    /// </summary>
    /// <param name="Domain">Sets the domain of this polar subplot</param>
    /// <param name="Sector">Sets angular span of this polar subplot with two angles (in degrees). Sector are assumed to be spanned in the counterclockwise direction with "0" corresponding to rightmost limit of the polar subplot.</param>
    /// <param name="Hole">Sets the fraction of the radius to cut out of the polar subplot.</param>
    /// <param name="BGColor">Set the background color of the subplot</param>
    /// <param name="RadialAxis">Sets the radial axis of the polar subplot.</param>
    /// <param name="AngularAxis">Sets the angular axis of the polar subplot.</param>
    /// <param name="GridShape">Determines if the radial axis grid lines and angular axis line are drawn as "circular" sectors or as "linear" (polygon) sectors. Has an effect only when the angular axis has `type` "category". Note that `radialaxis.angle` is snapped to the angle of the closest vertex when `gridshape` is "circular" (so that radial axis scale is the same as the data scale).</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in axis attributes, if not overridden in the individual axes. Defaults to `layout.uirevision`.</param>
    static member style
        (    
            ?Domain     : Domain,
            ?Sector     : float*float,
            ?Hole       : float,
            ?BGColor    : string,
            ?RadialAxis : Axis.RadialAxis,
            ?AngularAxis: Axis.AngularAxis,
            ?GridShape  : StyleParam.PolarGridShape,
            ?UIRevision : string
        ) =
            (fun (polar:Polar) -> 

                Domain      |> DynObj.setValueOpt polar "domain"
                Sector      |> DynObj.setValueOpt polar "sector"
                Hole        |> DynObj.setValueOpt polar "hole"
                BGColor     |> DynObj.setValueOpt polar "bgcolor"
                RadialAxis  |> DynObj.setValueOpt polar "radialaxis"
                AngularAxis |> DynObj.setValueOpt polar "angularaxis"
                GridShape   |> DynObj.setValueOpt polar "gridshape"
                UIRevision  |> DynObj.setValueOpt polar "uirevision"

                polar
            )
