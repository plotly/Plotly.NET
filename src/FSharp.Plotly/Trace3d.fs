namespace FSharp.Plotly

open System


/// Trace type inherits from dynamic object
type Trace3d (traceTypeName) =
    inherit Trace (traceTypeName)


[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Trace3d = 

    let initScatter3d (applyStyle:Trace3d->Trace3d) = 
        Trace3d("scatter3d") |> applyStyle




    /// Functions provide the styling of the Chart objects
    type Trace3dStyle() =

        // ######################## 3d-Charts
    
    
        // Applies the styles to Scatter3d()
        static member Scatter3d
            (   
                ?X      : seq<#IConvertible>,
                ?Y      : seq<#IConvertible>,
                ?Z      : seq<#IConvertible>,
                ?Mode: StyleParam.Mode,             
                ?Surfaceaxis,
                ?Surfacecolor,
                ?Projection : Scene3d.Projection,
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


