namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Shape type inherits from dynamic object
type Shape () =
    inherit ImmutableDynamicObj ()

    /// Init Shape type
    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?ShapeType: StyleParam.ShapeType,
            [<Optional;DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?X1: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Y1: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Path: string,
            [<Optional;DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional;DefaultParameterValue(null)>] ?Line: Line,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor: Color,
            [<Optional;DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional;DefaultParameterValue(null)>] ?Xref: string,
            [<Optional;DefaultParameterValue(null)>] ?Yref: string
        ) =
            Shape() 
            |> Shape.style
                (
                    ?ShapeType = ShapeType ,
                    ?X0        = X0        ,
                    ?X1        = X1        ,           
                    ?Y0        = Y0        ,
                    ?Y1        = Y1        ,
                    ?Path      = Path      ,
                    ?Opacity   = Opacity   ,
                    ?Line      = Line      ,
                    ?Fillcolor = Fillcolor ,
                    ?Layer     = Layer     ,
                    ?Xref      = Xref      ,
                    ?Yref      = Yref                        
                )

    // Applies the styles to Shape()
    static member style
        (   
            [<Optional;DefaultParameterValue(null)>] ?ShapeType: StyleParam.ShapeType,
            [<Optional;DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?X1: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Y1: #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Path: string,
            [<Optional;DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional;DefaultParameterValue(null)>] ?Line: Line,
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor: Color,
            [<Optional;DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional;DefaultParameterValue(null)>] ?Xref: string,
            [<Optional;DefaultParameterValue(null)>] ?Yref: string
        ) =
            (fun (shape:Shape) -> 

                    
                ++?? ("type", ShapeType, StyleParam.ShapeType.toString)    
                ++? ("xref", Xref)     
                X0        |> DynObj.setValueOpt shape "x0"        
                X1        |> DynObj.setValueOpt shape "x1"        
                ++? ("yref", Yref)     
                Y0        |> DynObj.setValueOpt shape "y0"       
                Y1        |> DynObj.setValueOpt shape "y1"       
                ++? ("path", Path)     
                ++? ("opacity", Opacity)      
                ++? ("line", Line)
                ++? ("fillcolor", Fillcolor)
                ++?? ("layer", Layer, StyleParam.Layer.toString)
                // out ->
                shape
            ) 


