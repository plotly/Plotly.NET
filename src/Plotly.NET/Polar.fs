namespace Plotly.NET

type Polar () =
    inherit DynamicObj ()

    static member init
        (    
            
        ) =    
            Polar()
            |> Polar.style
                (
                    
                )

    static member style
        (    
            ?Domain     : Domain,
            ?Sector     : float*float,
            ?Hole       : float,
            ?BgColor    : string,
            ?RadialAxis : Axis.RadialAxis,
            ?AngularAxis: Axis.AngularAxis,
            ?GridShape  : StyleParam.PolarGridShape,
            ?UIRevision : string
        ) =
            (fun (polar:Polar) -> 
                ()
            )
