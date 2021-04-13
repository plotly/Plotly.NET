namespace Plotly.NET
open System

/// Shape type inherits from dynamic object
type Shape () =
    inherit DynamicObj ()

    /// Init Shape type
    static member init
        (   
            ?ShapeType: StyleParam.ShapeType,
            ?X0: IConvertible,
            ?X1: IConvertible,
            ?Y0: IConvertible,
            ?Y1: IConvertible,
            ?Path: string,
            ?Opacity: float,
            ?Line: Line,
            ?Fillcolor: string ,
            ?Layer: StyleParam.Layer,
            ?Xref: string,
            ?Yref: string
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
            ?ShapeType: StyleParam.ShapeType,
            ?X0: IConvertible,
            ?X1: IConvertible,
            ?Y0: IConvertible,
            ?Y1: IConvertible,
            ?Path: string,
            ?Opacity: float,
            ?Line: Line,
            ?Fillcolor: string ,
            ?Layer: StyleParam.Layer,
            ?Xref: string,
            ?Yref: string
        ) =
            (fun (shape:Shape) -> 

                    
                ShapeType |> DynObj.setValueOptBy shape "type" StyleParam.ShapeType.toString    
                Xref      |> DynObj.setValueOpt shape "xref"     
                X0        |> DynObj.setValueOpt shape "x0"        
                X1        |> DynObj.setValueOpt shape "x1"        
                Yref      |> DynObj.setValueOpt shape "yref"     
                Y0        |> DynObj.setValueOpt shape "y0"       
                Y1        |> DynObj.setValueOpt shape "y1"       
                Path      |> DynObj.setValueOpt shape "path"     
                Opacity   |> DynObj.setValueOpt shape "opacity"      
                Line      |> DynObj.setValueOpt shape "line"
                Fillcolor |> DynObj.setValueOpt shape "fillcolor"
                Layer     |> DynObj.setValueOptBy shape "layer" StyleParam.Layer.toString
                // out ->
                shape
            ) 


