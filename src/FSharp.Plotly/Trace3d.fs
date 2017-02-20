namespace FSharp.Plotly

open System


/// Trace type inherits from dynamic object
type Trace3d (traceTypeName) =
    inherit Trace (traceTypeName)


[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Trace3d = 

    /// Init trace for 3d-scatter plot
    let initScatter3d (applyStyle:Trace3d->Trace3d) = 
        Trace3d("scatter3d") |> applyStyle

    /// Init trace for 3d-contour plot
    let initSurface (applyStyle:Trace3d->Trace3d) = 
        Trace3d("surface") |> applyStyle
        
    /// Init trace for 3d-mesh plot
    let initMesh3d (applyStyle:Trace3d->Trace3d) = 
        Trace3d("mesh3d") |> applyStyle



    /// Functions provide the styling of the Chart objects
    type Trace3dStyle() =

        // ######################## 3d-Charts
    
    
        // Applies the styles to Scatter3d()
        static member Scatter3d
            (   
                ?X      : seq<#IConvertible>,
                ?Y      : seq<#IConvertible>,
                ?Z      : seq<#IConvertible>,
                ?Mode   : StyleParam.Mode,             
                ?Surfaceaxis,
                ?Surfacecolor,
                ?Projection : Projection,
                ?Scene,          
                ?Error_y: Error,
                ?Error_x: Error,
                ?Error_z: Error,
                ?Xsrc   : string,
                ?Ysrc   : string,
                ?Zsrc   : string
            ) =
                 //(fun (scatter:('T :> Trace3d)) ->
                 (fun (scatter: Trace3d) ->
                    //scatter.set_type plotType                     
                    X            |> DynObj.setValueOpt scatter "x"
                    Y            |> DynObj.setValueOpt scatter "y"
                    Z            |> DynObj.setValueOpt scatter "z"
                    Mode         |> DynObj.setValueOptBy scatter "mode" StyleParam.Mode.toString
                    
                    Surfaceaxis  |> DynObj.setValueOpt scatter "xsrc"
                    Surfacecolor |> DynObj.setValueOpt scatter "xsrc"                
                    Scene        |> DynObj.setValueOpt scatter "xsrc"
                    Xsrc         |> DynObj.setValueOpt scatter "xsrc"
                    Ysrc         |> DynObj.setValueOpt scatter "ysrc"
                    Zsrc         |> DynObj.setValueOpt scatter "zsrc"
                    
                    // Update
                    Error_x      |> DynObj.setValueOpt scatter "error_x"
                    Error_y      |> DynObj.setValueOpt scatter "error_y"
                    Error_z      |> DynObj.setValueOpt scatter "error_z"
                    Projection   |> DynObj.setValueOpt scatter "projecton"

                    // out ->
                    scatter
                )



        /// Applies the styles of 3d-surface to TraceObjects 
        static member Surface
            (                
                ?Z : seq<#seq<#IConvertible>>,
                ?X : seq<#IConvertible>,
                ?Y : seq<#IConvertible>,            
                ?cAuto          ,
                ?cMin           ,
                ?cMax           ,
                ?Colorscale     ,
                ?Autocolorscale : bool,
                ?Reversescale   : bool,
                ?Showscale      : bool,
                ?Colorbar       ,
                ?Contours       ,
                ?Hidesurface    ,
                ?Lightposition  ,
                ?Lighting       ,
                ?Xcalendar      ,
                ?Ycalendar      ,
                ?Zcalendar      ,

                ?Zsrc           ,
                ?Xsrc           ,
                ?Ysrc           ,
                ?Surfacecolorsrc

            ) =
                (fun (surface:('T :> Trace)) -> 
                
                    Z              |> DynObj.setValueOpt surface "z"         
                    X              |> DynObj.setValueOpt surface "x"               
                    Y              |> DynObj.setValueOpt surface "y"        
 
                    cAuto          |> DynObj.setValueOpt surface "cauto"     
                    cMin           |> DynObj.setValueOpt surface "cmin"      
                    cMax           |> DynObj.setValueOpt surface "cmax"      
                    Colorscale     |> DynObj.setValueOptBy surface "colorscale" StyleParam.Colorscale.convert 
                    Autocolorscale |> DynObj.setValueOpt surface "autocolorscale"
                    Reversescale   |> DynObj.setValueOpt surface "reversescale"  
                    Showscale      |> DynObj.setValueOpt surface "showscale"
                    Colorbar       |> DynObj.setValueOpt surface "colorbar"    
                    Contours       |> DynObj.setValueOpt surface "contours"  
                    Hidesurface    |> DynObj.setValueOpt surface "Hidesurface"
                    Lightposition  |> DynObj.setValueOpt surface "Lightposition"
                    Lighting       |> DynObj.setValueOpt surface "Lighting"
                    Xcalendar      |> DynObj.setValueOpt surface "Xcalendar"
                    Ycalendar      |> DynObj.setValueOpt surface "Ycalendar"
                    Zcalendar      |> DynObj.setValueOpt surface "Zcalendar"
                    Zsrc           |> DynObj.setValueOpt surface "zsrc"       
                    Xsrc           |> DynObj.setValueOpt surface "xsrc"       
                    Ysrc           |> DynObj.setValueOpt surface "ysrc" 
                    Surfacecolorsrc|> DynObj.setValueOpt surface "surfacecolorsrc"
                    
                    // out ->
                    surface 
                )


        // Applies the styles to Scatter3d()
        static member Mesh3d
            (   
                ?X            : seq<#IConvertible>,
                ?Y            : seq<#IConvertible>,
                ?Z            : seq<#IConvertible>,
                ?I            : seq<#IConvertible>,
                ?J            : seq<#IConvertible>,
                ?K            : seq<#IConvertible>,
                ?Delaunayaxis : StyleParam.Delaunayaxis, 
                ?Alphahull                       ,
                ?Intensity    : seq<#IConvertible>,
                ?Vertexcolor                     ,
                ?Facecolor                       ,
                ?Flatshading                     ,
                ?Contour                         ,
                ?Colorscale     ,
                ?Autocolorscale ,
                ?Reversescale   ,
                ?Showscale      ,
                ?Colorbar       ,
                ?Lightposition  : Ligth.Lightposition, // Obj
                ?Lighting       : Ligth.Lighting, // Obj
                ?Scene          ,
                ?Xcalendar      , 
                ?Ycalendar      ,
                ?Zcalendar      ,
                ?Xsrc   : string,
                ?Ysrc   : string,
                ?Zsrc   : string,
                ?Isrc   : string,
                ?Jsrc   : string,
                ?Ksrc   : string,
                ?Intensityscr   : string,
                ?Vertexcolorscr : string,
                ?Facecolorscr   : string
                

            ) =
                 //(fun (scatter:('T :> Trace3d)) ->
                 (fun (mesh3d: Trace3d) ->
                    //scatter.set_type plotType                     
                    X              |> DynObj.setValueOpt mesh3d "x"
                    Y              |> DynObj.setValueOpt mesh3d "y"
                    Z              |> DynObj.setValueOpt mesh3d "z"
                    I              |> DynObj.setValueOpt mesh3d "i"
                    J              |> DynObj.setValueOpt mesh3d "j"
                    K              |> DynObj.setValueOpt mesh3d "k"
                    Alphahull      |> DynObj.setValueOpt mesh3d "alphahull  "
                    Intensity      |> DynObj.setValueOpt mesh3d "intensity  "
                    Vertexcolor    |> DynObj.setValueOpt mesh3d "vertexcolor"
                    Facecolor      |> DynObj.setValueOpt mesh3d "facecolor  "
                    Flatshading    |> DynObj.setValueOpt mesh3d "flatshading"
                    Contour        |> DynObj.setValueOpt mesh3d "contour    "

                    Colorscale     |> DynObj.setValueOpt mesh3d "colorscale"
                    Autocolorscale |> DynObj.setValueOpt mesh3d "autocolorscale"
                    Reversescale   |> DynObj.setValueOpt mesh3d "reversescale"
                    Showscale      |> DynObj.setValueOpt mesh3d "showscale"
                    Colorbar       |> DynObj.setValueOpt mesh3d "colorbar"
                    Lightposition  |> DynObj.setValueOpt mesh3d "lightposition"
                    Lighting       |> DynObj.setValueOpt mesh3d "lighting"
                    Scene          |> DynObj.setValueOpt mesh3d "scene"
                    Xcalendar      |> DynObj.setValueOpt mesh3d "xcalendar"
                    Ycalendar      |> DynObj.setValueOpt mesh3d "ycalendar"
                    Zcalendar      |> DynObj.setValueOpt mesh3d "zcalendar"
                    
                    Xsrc           |> DynObj.setValueOpt mesh3d "xsrc"
                    Ysrc           |> DynObj.setValueOpt mesh3d "ysrc"
                    Zsrc           |> DynObj.setValueOpt mesh3d "zsrc"                    
                    Isrc           |> DynObj.setValueOpt mesh3d "isrc"
                    Jsrc           |> DynObj.setValueOpt mesh3d "jsrc"
                    Ksrc           |> DynObj.setValueOpt mesh3d "ksrc"
                    Intensityscr   |> DynObj.setValueOpt mesh3d "intensityscr"
                    Vertexcolorscr |> DynObj.setValueOpt mesh3d "vertexcolorscr"
                    Facecolorscr   |> DynObj.setValueOpt mesh3d "facecolorscr"

                    Delaunayaxis   |> DynObj.setValueOptBy mesh3d "delaunayaxis" StyleParam.Delaunayaxis.convert
                    
                    // out ->
                    mesh3d
                ) 


