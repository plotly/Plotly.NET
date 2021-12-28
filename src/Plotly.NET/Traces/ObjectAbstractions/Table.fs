namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open DynamicObj.Operators
open System
open System.Runtime.InteropServices

/// CellColor type inherits from dynamic object
type TableFill() =
    inherit ImmutableDynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        TableFill() |> TableFill.style (?Color = Color)

    static member style([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        (fun (fill: TableFill) ->
            fill
            ++? ("color", Color ))


/// Cells type inherits from dynamic object
type TableCells() =
    inherit ImmutableDynamicObj()

    /// Initialized Cells object
    static member init
        (
            ?Align: StyleParam.HorizontalAlign,
            ?MultiAlign: seq<StyleParam.HorizontalAlign>,
            ?Fill: TableFill,
            ?Font: Font,
            ?Format: seq<string>,
            ?Height: int,
            ?Line: Line,
            ?Prefix: string,
            ?MultiPrefix: seq<string>,
            ?Suffix: string,
            ?MultiSuffix: seq<string>,
            ?Values: seq<#seq<#IConvertible>>
        ) =
        TableCells()
        |> TableCells.style (
            ?Align = Align,
            ?MultiAlign = MultiAlign,
            ?Fill = Fill,
            ?Font = Font,
            ?Format = Format,
            ?Height = Height,
            ?Line = Line,
            ?Prefix = Prefix,
            ?MultiPrefix = MultiPrefix,
            ?Suffix = Suffix,
            ?MultiSuffix = MultiSuffix,
            ?Values = Values
        )

    //Applies the styles to TableCells()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.HorizontalAlign,
            [<Optional; DefaultParameterValue(null)>] ?MultiAlign: seq<StyleParam.HorizontalAlign>,
            [<Optional; DefaultParameterValue(null)>] ?Fill: TableFill,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Format: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Height: int,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Prefix: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiPrefix: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Suffix: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiSuffix: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#seq<#IConvertible>>
        ) =
        (fun (cells: TableCells) ->

            (Align, MultiAlign) |> DynObj.setSingleOrMultiOptBy cells "align" StyleParam.HorizontalAlign.convert
            ++? ("fill", Fill )
            ++? ("font", Font )
            ++? ("format", Format )
            ++? ("height", Height )
            ++? ("line", Line )
            (Prefix, MultiPrefix) |> DynObj.setSingleOrMultiOpt cells "prefix"
            (Suffix, MultiSuffix) |> DynObj.setSingleOrMultiOpt cells "suffix"


            cells
            ++? ("values", Values ))

type TableHeader = TableCells
