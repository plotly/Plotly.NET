namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
OHNONONO
open System
open System.Runtime.InteropServices

/// CellColor type inherits from dynamic object
type CellColor () =
    inherit DynamicObj ()

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
                ++? ("color", Color      )
            )


/// Header type inherits from dynamic object
type TableHeader () =
    inherit DynamicObj ()

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
                header

                ++ ("values", values ) 
                ++?? ("align", Align  , (Seq.map StyleParam.HorizontalAlign.convert))
                ++? ("height", Height )
                ++? ("fill", Fill   ) 
                ++? ("line", Line   )    
                ++? ("font", Font   )
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
                cells

                ++ ("values", values ) 
                ++?? ("align", Align  , (Seq.map StyleParam.HorizontalAlign.convert))
                ++? ("height", Height )
                ++? ("fill", Fill   )
                ++? ("line", Line   )     
                ++? ("font", Font   )
            )
