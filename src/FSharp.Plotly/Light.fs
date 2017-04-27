namespace FSharp.Plotly

/// Module containing plotly light modulation for 3d 
module Ligth =
     
    /// Lighting type inherits from dynamic object
    type Lighting () =
        inherit DynamicObj ()
        
        /// Initialized Lighting object
        //[<CompiledName("init")>]
        static member init
            (
                /// Epsilon for vertex normals calculation avoids math issues arising from degenerate geometry. Default 1e-12.
                ?Vertexnormalsepsilon : float,
                ?Facenormalsepsilon   : float,
                ?Ambient              : float,
                ?Diffuse              : float,
                ?Specular             : float,
                ?Roughness            : float,
                ?Fresnel              : float
            ) =
                Lighting () 
                |> Lighting.style
                    (                
                        ?Vertexnormalsepsilon = Vertexnormalsepsilon,
                        ?Facenormalsepsilon   = Facenormalsepsilon  ,
                        ?Ambient              = Ambient             ,
                        ?Diffuse              = Diffuse             ,
                        ?Specular             = Specular            ,
                        ?Roughness            = Roughness           ,
                        ?Fresnel              = Fresnel           
                    ) 

        // [<JsonIgnore>]
        /// Applies the styles to Lighting()
        //[<CompiledName("style")>]
        static member style
            (
                /// Epsilon for vertex normals calculation avoids math issues arising from degenerate geometry. Default 1e-12.
                ?Vertexnormalsepsilon : float,
                ?Facenormalsepsilon   : float,
                ?Ambient              : float,
                ?Diffuse              : float,
                ?Specular             : float,
                ?Roughness            : float,
                ?Fresnel              : float
            ) =
            
                (fun (lighting:Lighting) -> 
                    Vertexnormalsepsilon |> DynObj.setValueOpt lighting "vertexnormalsepsilon"
                    Facenormalsepsilon   |> DynObj.setValueOpt lighting "facenormalsepsilon"
                    Ambient              |> DynObj.setValueOpt lighting "ambient"
                    Diffuse              |> DynObj.setValueOpt lighting "diffuse"
                    Specular             |> DynObj.setValueOpt lighting "specular"
                    Roughness            |> DynObj.setValueOpt lighting "roughness"
                    Fresnel              |> DynObj.setValueOpt lighting "fresnel"
           
                    lighting
                )



    /// Lighting type inherits from dynamic object
    type Lightposition () =
        inherit DynamicObj ()

        /// Initialized Lightposition object
        //[<CompiledName("init")>]
        static member init
            (
                ?X : int,
                ?Y : int,
                ?Z : int
            ) =
                Lightposition ()
                |> Lightposition.style
                    (
                        ?X = X,
                        ?Y = Y,
                        ?Z = Z
                    )

        /// Applies the styles to Lightposition()
        //[<CompiledName("style")>]
        static member style
            (
                ?X : int,
                ?Y : int,
                ?Z : int
            ) =
            
                (fun (lightposition:('T :> Lightposition)) -> 
                    X |> DynObj.setValueOpt lightposition "x"
                    Y |> DynObj.setValueOpt lightposition "y"
                    Z |> DynObj.setValueOpt lightposition "z"
           
                    lightposition
                )

