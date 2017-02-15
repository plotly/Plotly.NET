namespace FSharp.Plotly

module Scene3d =
    
    /// Scene 
    type Scene() = inherit DynamicObj ()

    /// Init Scene type
    let init (applyStyle:Scene->Scene) = 
        Scene() |> applyStyle

    /// Projection 
    type Projection() = inherit DynamicObj ()

    /// Init Projection type
    let initProjection (applyStyle:Projection->Projection) = 
        Projection() |> applyStyle

    /// 
    type SceneStyle =

        static member Apply
            (   
                ?xAxis:Axis.LinearAxis,
                ?yAxis:Axis.LinearAxis,
                ?zAxis:Axis.LinearAxis,
                ?isSubplotObj     ,
                ?BgColor          
                // ?Camera           ,
                // ?Domain           ,
                // ?Aspectmode       ,
                // ?Aspectratio
            ) =
                (fun (scene:Scene) -> 
                    isSubplotObj |> DynObj.setValueOpt scene "_isSubplotObj"
                    BgColor      |> DynObj.setValueOpt scene "bgcolor"
                    
                    // Update
                    xAxis        |> DynObj.setValueOpt scene "xaxis"
                    yAxis        |> DynObj.setValueOpt scene "yaxis"
                    zAxis        |> DynObj.setValueOpt scene "zaxis"

                    // out ->
                    scene
                ) 
