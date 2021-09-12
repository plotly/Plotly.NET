namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


type Polar () =
    inherit ImmutableDynamicObj ()

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
            [<Optional;DefaultParameterValue(null)>] ?Domain     : Domain,
            [<Optional;DefaultParameterValue(null)>] ?Sector     : float*float,
            [<Optional;DefaultParameterValue(null)>] ?Hole       : float,
            [<Optional;DefaultParameterValue(null)>] ?BGColor    : Color,
            [<Optional;DefaultParameterValue(null)>] ?RadialAxis : RadialAxis,
            [<Optional;DefaultParameterValue(null)>] ?AngularAxis: AngularAxis,
            [<Optional;DefaultParameterValue(null)>] ?GridShape  : StyleParam.PolarGridShape,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision : string
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
    /// <param name="BarMode">Determines how bars at the same location coordinate are displayed on the graph. With "stack", the bars are stacked on top of one another With "relative", the bars are stacked on top of one another, with negative values below the axis, positive values above With "group", the bars are plotted next to one another centered around the shared location. With "overlay", the bars are plotted over one another, you might need to an "opacity" to see multiple bars.</param>
    /// <param name="BarGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    static member style
        (    
            [<Optional;DefaultParameterValue(null)>] ?Domain     : Domain,
            [<Optional;DefaultParameterValue(null)>] ?Sector     : float*float,
            [<Optional;DefaultParameterValue(null)>] ?Hole       : float,
            [<Optional;DefaultParameterValue(null)>] ?BGColor    : Color,
            [<Optional;DefaultParameterValue(null)>] ?RadialAxis : RadialAxis,
            [<Optional;DefaultParameterValue(null)>] ?AngularAxis: AngularAxis,
            [<Optional;DefaultParameterValue(null)>] ?GridShape  : StyleParam.PolarGridShape,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision : string,
            //these are not documented in the official reference but seem to be the only way to make this work?!
            [<Optional;DefaultParameterValue(null)>] ?BarMode    : StyleParam.BarMode,
            [<Optional;DefaultParameterValue(null)>] ?BarGap     : float

        ) =
            (fun (polar:Polar) -> 

                ++? ("domain", Domain)
                ++?? ("sector", Sector, (fun (a,b) -> [|a;b|]))
                ++? ("hole", Hole)
                ++? ("bgcolor", BGColor)
                ++? ("radialaxis", RadialAxis)
                ++? ("angularaxis", AngularAxis)
                ++?? ("gridshape", GridShape, StyleParam.PolarGridShape.convert)
                ++? ("uirevision", UIRevision)
                ++?? ("barmode", BarMode, StyleParam.BarMode.convert)
                ++? ("bargap", BarGap)

                polar
            )
