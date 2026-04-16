namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartDomain_Table =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a table.
        ///
        /// The data are arranged in a grid of rows and columns. Most styling can be specified for columns, rows or individual cells. Table is using a row-major order by default, ie. the grid is represented as a vector of row vectors.
        /// </summary>
        /// <param name="header">Sets the header of the table</param>
        /// <param name="cells">Sets the cells of the table</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ColumnOrder">Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.</param>
        /// <param name="ColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
        /// <param name="MultiColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Table
            (
                header: TableHeader,
                cells: TableCells,
                ?Name: string,
                ?ColumnOrder: seq<int>,
                ?ColumnWidth: float,
                ?MultiColumnWidth: seq<float>,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            TraceDomain.initTable (
                TraceDomainStyle.Table(
                    Header = header,
                    Cells = cells,
                    ?Name = Name,
                    ?ColumnOrder = ColumnOrder,
                    ?ColumnWidth = ColumnWidth,
                    ?MultiColumnWidth = MultiColumnWidth

                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates a table.
        ///
        /// The data are arranged in a grid of rows and columns. Most styling can be specified for columns, rows or individual cells. Table is using a row-major order by default, ie. the grid is represented as a vector of row vectors.
        /// </summary>
        /// <param name="headerValues">Sets the values contained in the table header.</param>
        /// <param name="cellsValues">Sets the values contained in the table cells.</param>
        /// <param name="TransposeCells">Whether or not to transpose the cells (i.e. switch from row to column major)</param>
        /// <param name="HeaderAlign">Sets the alignment of the table header.</param>
        /// <param name="HeaderMultiAlign">Sets the alignment of the individual cells in the table header.</param>
        /// <param name="HeaderFillColor">Sets the fill color of the table header.</param>
        /// <param name="HeaderHeight">Sets the height of the table header.</param>
        /// <param name="HeaderOutlineColor">Sets the outline color of the table header cells.</param>
        /// <param name="HeaderOutlineWidth">Sets the outline width of the table header cells.</param>
        /// <param name="HeaderOutlineMultiWidth">Sets the outline width of the individual table header cells.</param>
        /// <param name="HeaderOutline">Sets the outline of the table header cells. (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="CellsAlign">Sets the alignment of the table cells.</param>
        /// <param name="CellsMultiAlign">Sets the alignment of the individual table cells.</param>
        /// <param name="CellsFillColor">Sets the fill color of the table cells.</param>
        /// <param name="CellsHeight">Sets the height color of the table cells.</param>
        /// <param name="CellsOutlineColor">Sets the outline color color of the table cells.</param>
        /// <param name="CellsOutlineWidth">Sets the outline width of the table cells.</param>
        /// <param name="CellsOutlineMultiWidth">Sets the outline width of the individual table cells.</param>
        /// <param name="CellsOutline">Sets the outline of the table cells. (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ColumnOrder">Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.</param>
        /// <param name="ColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
        /// <param name="MultiColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Table
            (
                headerValues: seq<#seq<#IConvertible>>,
                cellsValues: seq<#seq<#IConvertible>>,
                ?TransposeCells: bool,
                ?HeaderAlign: StyleParam.HorizontalAlign,
                ?HeaderMultiAlign: seq<StyleParam.HorizontalAlign>,
                ?HeaderFillColor: Color,
                ?HeaderHeight: int,
                ?HeaderOutlineColor: Color,
                ?HeaderOutlineWidth: float,
                ?HeaderOutlineMultiWidth: seq<float>,
                ?HeaderOutline: Line,
                ?CellsAlign: StyleParam.HorizontalAlign,
                ?CellsMultiAlign: seq<StyleParam.HorizontalAlign>,
                ?CellsFillColor: Color,
                ?CellsHeight: int,
                ?CellsOutlineColor: Color,
                ?CellsOutlineWidth: float,
                ?CellsOutlineMultiWidth: seq<float>,
                ?CellsOutline: Line,
                ?Name: string,
                ?ColumnOrder: seq<int>,
                ?ColumnWidth: float,
                ?MultiColumnWidth: seq<float>,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let transpose =
                defaultArg TransposeCells true

            let cellsValues =
                if transpose then
                    cellsValues |> Seq.map Seq.cast<IConvertible> |> Seq.transpose
                else
                    cellsValues |> Seq.map Seq.cast<IConvertible>

            let headerFill =
                TableFill.init (?Color = HeaderFillColor)

            let headerOutline =
                HeaderOutline
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = HeaderOutlineColor,
                    ?Width = HeaderOutlineWidth,
                    ?MultiWidth = HeaderOutlineMultiWidth
                )

            let header =
                TableHeader.init (
                    Values = headerValues,
                    Fill = headerFill,
                    Line = headerOutline,
                    ?Align = HeaderAlign,
                    ?MultiAlign = HeaderMultiAlign,
                    ?Height = HeaderHeight
                )

            let cellsFill =
                TableFill.init (?Color = CellsFillColor)

            let cellsOutline =
                CellsOutline
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = CellsOutlineColor,
                    ?Width = CellsOutlineWidth,
                    ?MultiWidth = CellsOutlineMultiWidth
                )

            let cells =
                TableCells.init (
                    Values = cellsValues,
                    Fill = cellsFill,
                    Line = cellsOutline,
                    ?Align = CellsAlign,
                    ?MultiAlign = CellsMultiAlign,
                    ?Height = CellsHeight
                )

            Chart.Table(
                header,
                cells,
                ?Name = Name,
                ?ColumnOrder = ColumnOrder,
                ?ColumnWidth = ColumnWidth,
                ?MultiColumnWidth = MultiColumnWidth,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates an Indicator chart.
        ///
        /// An indicator is used to visualize a single `value` along with some contextual information such as `steps` or a `threshold`, using a combination of three visual elements: a number, a delta, and/or a gauge.
        /// Deltas are taken with respect to a `reference`.
        /// Gauges can be either angular or bullet (aka linear) gauges.
        /// </summary>
        /// <param name="value">Sets the number to be displayed.</param>
        /// <param name="mode">Determines how the value is displayed on the graph. `number` displays the value numerically in text. `delta` displays the difference to a reference value in text. Finally, `gauge` displays the value graphically on an axis.</param>
        /// <param name="Range">Sets the Range of the Gauge axis</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Title">Sets the title of this trace.</param>
        /// <param name="Domain">Sets the domain of this trace.</param>
        /// <param name="Align">Sets the horizontal alignment of the `text` within the box. Note that this attribute has no effect if an angular gauge is displayed: in this case, it is always centered</param>
        /// <param name="DeltaReference"></param>
        /// <param name="Delta">Sets how the delta to the delta reference is displayed</param>
        /// <param name="Number">Sets the styles of the displayed number</param>
        /// <param name="GaugeShape">Sets the shape of the gauge</param>
        /// <param name="Gauge">Sets the styles of the gauge</param>
        /// <param name="ShowGaugeAxis">Whether or not to show the gauge axis</param>
        /// <param name="GaugeAxis">Sets the gauge axis</param>
        /// <param name="UseDefaults"></param>
        [<Extension>]
        static member Indicator
            (
                value: IConvertible,
                mode: StyleParam.IndicatorMode,
                ?Range: StyleParam.Range,
                ?Name: string,
                ?Title: string,
                ?Domain: Domain,
                ?Align: StyleParam.IndicatorAlignment,
                ?DeltaReference: #IConvertible,
                ?Delta: IndicatorDelta,
                ?Number: IndicatorNumber,
                ?GaugeShape: StyleParam.IndicatorGaugeShape,
                ?Gauge: IndicatorGauge,
                ?ShowGaugeAxis: bool,
                ?GaugeAxis: LinearAxis,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let axis =
                GaugeAxis
                |> Option.defaultValue (LinearAxis.init ())
                |> LinearAxis.style (?Range = Range, ?Visible = ShowGaugeAxis)

            let gauge =
                Gauge
                |> Option.defaultValue (IndicatorGauge.init ())
                |> IndicatorGauge.style (Axis = axis, ?Shape = GaugeShape)

            let delta =
                Delta
                |> Option.defaultValue (IndicatorDelta.init ())
                |> IndicatorDelta.style (?Reference = DeltaReference)

            TraceDomain.initIndicator (
                TraceDomainStyle.Indicator(
                    ?Name = Name,
                    ?Title = Title,
                    Mode = mode,
                    Value = value,
                    ?Domain = Domain,
                    ?Align = Align,
                    Delta = delta,
                    ?Number = Number,
                    Gauge = gauge
                )
            )
            |> GenericChart.ofTraceObject useDefaults

