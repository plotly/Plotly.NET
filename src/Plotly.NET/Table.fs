namespace Plotly.NET

open System

/// CellColor type inherits from dynamic object
type CellColor () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            ?Color
        ) =
            CellColor () 
            |> CellColor.style
                (
                    ?Color      = Color  
                )
    // Applies the styles to CellColor()
    static member style
        (
            ?Color
        ) =
            (fun (cell:CellColor) -> 
                Color      |> DynObj.setValueOpt cell "color" 
                // out -> 
                cell
            )


/// Header type inherits from dynamic object
type TableHeader () =
    inherit DynamicObj ()

    /// Initialized Header object
    static member init
        (   
            values: seq<#seq<#IConvertible>>, 
            ?Align: seq<StyleParam.HorizontalAlign>,
            ?Height: float,
            ?Fill: CellColor,
            ?Font: Font,
            ?Line: Line

        ) =
        TableHeader () 
        |> TableHeader.style
            (
                values  = values,
                ?Align  = Align ,
                ?Height = Height,
                ?Fill   = Fill  ,
                ?Font   = Font  ,
                ?Line   = Line

            )

    /// Applies the styles to TableHeader()
    static member style
        (   
            values : seq<#seq<#IConvertible>>, 
            ?Align : seq<StyleParam.HorizontalAlign>,
            ?Height: float,
            ?Fill: CellColor,
            ?Font: Font,
            ?Line: Line

        ) =
            (fun (header: TableHeader) -> 

                values |> DynObj.setValue      header "values" 
                Align  |> DynObj.setValueOptBy header "align" (Seq.map StyleParam.HorizontalAlign.convert)
                Height |> DynObj.setValueOpt   header "height"
                Fill   |> DynObj.setValueOpt   header "fill" 
                Line   |> DynObj.setValueOpt   header "line"    
                Font   |> DynObj.setValueOpt   header "font"
                header
            )

/// Cells type inherits from dynamic object
type TableCells () =
    inherit DynamicObj ()

    /// Initialized Cells object
    static member init
        (   
            values : seq<#seq<#IConvertible>>, 
            ?Align : seq<StyleParam.HorizontalAlign>,
            ?Height: float,
            ?Fill: CellColor, 
            ?Font: Font,
            ?Line: Line 

        ) =
        TableCells () 
        |> TableCells.style
            (
                values  = values,
                ?Align  = Align ,
                ?Height = Height,
                ?Fill   = Fill  ,
                ?Font   = Font  ,
                ?Line   = Line

            )

    //Applies the styles to TableCells()
    static member style
        (   
            values : seq<#seq<#IConvertible>>, 
            ?Align : seq<StyleParam.HorizontalAlign>,
            ?Height: float,
            ?Fill: CellColor, 
            ?Font: Font,
            ?Line: Line 

        ) =
           (fun (cells: TableCells) -> 

                values |> DynObj.setValue      cells "values" 
                Align  |> DynObj.setValueOptBy cells "align" (Seq.map StyleParam.HorizontalAlign.convert)
                Height |> DynObj.setValueOpt   cells "height"
                Fill   |> DynObj.setValueOpt   cells "fill"
                Line   |> DynObj.setValueOpt   cells "line"     
                Font   |> DynObj.setValueOpt   cells "font"  
                cells
            )
