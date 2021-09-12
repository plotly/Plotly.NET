namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

/// CellColor type inherits from dynamic object
type CellColor () =
    inherit ImmutableDynamicObj ()

    /// Initialized Line object
    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?Color : Color
        ) =
            CellColor () 
            |> CellColor.style
                (
                    ?Color      = Color  
                )
    // Applies the styles to CellColor()
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Color : Color
        ) =
            (fun (cell:CellColor) -> 
                // out -> 
                cell
                ++? ("color", Color) 
            )


/// Header type inherits from dynamic object
type TableHeader () =
    inherit ImmutableDynamicObj ()

    /// Initialized Header object
    static member init
        (   
            values: seq<#seq<#IConvertible>>, 
            [<Optional;DefaultParameterValue(null)>] ?Align: seq<StyleParam.HorizontalAlign>,
            [<Optional;DefaultParameterValue(null)>] ?Height: float,
            [<Optional;DefaultParameterValue(null)>] ?Fill: CellColor,
            [<Optional;DefaultParameterValue(null)>] ?Font: Font,
            [<Optional;DefaultParameterValue(null)>] ?Line: Line

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
            [<Optional;DefaultParameterValue(null)>] ?Align : seq<StyleParam.HorizontalAlign>,
            [<Optional;DefaultParameterValue(null)>] ?Height: float,
            [<Optional;DefaultParameterValue(null)>] ?Fill: CellColor,
            [<Optional;DefaultParameterValue(null)>] ?Font: Font,
            [<Optional;DefaultParameterValue(null)>] ?Line: Line

        ) =
            (fun (header: TableHeader) -> 

                values |> ++ ("values", ++?? ("align", Align, (Seq.map StyleParam.HorizontalAlign.convert)))
                header
                ++? ("height", Height)
                ++? ("fill", Fill) 
                ++? ("line", Line)    
                ++? ("font", Font)
            )

/// Cells type inherits from dynamic object
type TableCells () =
    inherit ImmutableDynamicObj ()

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

                values |> ++ ("values", ++?? ("align", Align, (Seq.map StyleParam.HorizontalAlign.convert)))
                cells
                ++? ("height", Height)
                ++? ("fill", Fill)
                ++? ("line", Line)     
                ++? ("font", Font)  
            )
