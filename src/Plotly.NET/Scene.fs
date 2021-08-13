namespace Plotly.NET

open DynamicObj

/// Scene 
type Scene() = 
    inherit DynamicObj ()

    /// Initialized Scene object
    //[<CompiledName("init")>]
    static member init
        (   
            ?xAxis:Axis.LinearAxis,
            ?yAxis:Axis.LinearAxis,
            ?zAxis:Axis.LinearAxis,
            ?isSubplotObj: bool     ,
            ?BgColor: string,
            // ?Camera           ,
            ?Domain:Domain           
            // ?Aspectmode       ,
            // ?Aspectratio
        ) =
            Scene ()
            |> Scene.style
                (
                    ?xAxis        = xAxis         ,
                    ?yAxis        = yAxis         ,
                    ?zAxis        = zAxis         ,
                    ?isSubplotObj = isSubplotObj  ,
                    ?BgColor      = BgColor       ,
                    ?Domain       = Domain         
                )

    // [<JsonIgnore>]
    /// Applies the styles to Scene()
    //[<CompiledName("style")>]
    static member style
        (   
            ?xAxis:Axis.LinearAxis,
            ?yAxis:Axis.LinearAxis,
            ?zAxis:Axis.LinearAxis,
            ?isSubplotObj: bool     ,
            ?BgColor: string,
            // ?Camera           ,
            ?Domain:Domain           
            // ?Aspectmode       ,
            // ?Aspectratio
        ) =
            (fun (scene:Scene) -> 
                isSubplotObj |> DynObj.setValueOpt scene "_isSubplotObj"
                BgColor      |> DynObj.setValueOpt scene "bgcolor"
                Domain       |> DynObj.setValueOpt scene "domain"
                // Update
                xAxis        |> DynObj.setValueOpt scene "xaxis"
                yAxis        |> DynObj.setValueOpt scene "yaxis"
                zAxis        |> DynObj.setValueOpt scene "zaxis"

                // out ->
                scene
            ) 

