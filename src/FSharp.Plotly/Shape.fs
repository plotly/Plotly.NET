namespace FSharp.Plotly


/// Shape type inherits from dynamic object
type Shape () =
    inherit DynamicObj ()


[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Shape =

    /// Init Shape type
    let init (applyStyle:Shape->Shape) = 
        Shape() |> applyStyle

    /// 
    type ShapeStyle =

        // Applies the styles to Shape()
        static member Shape
            (   
            ?ShapeType : StyleParam.ShapeType,
            ?X0        ,
            ?X1        ,           
            ?Y0        ,
            ?Y1        ,
            ?Path      ,
            ?Opacity   ,
            ?Line : Line,
            ?Fillcolor ,
            ?Layer :StyleParam.Layer,
            ?Xref      ,
            ?Yref
            
            
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


