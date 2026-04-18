using System;
using System.Collections.Generic;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp;

public static partial class Chart
{
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
        public static GenericChart Table(
            TableCells header, 
            TableCells cells, 
            Optional<string> Name = default, 
            Optional<IEnumerable<int>> ColumnOrder = default, 
            Optional<double> ColumnWidth = default, 
            Optional<IEnumerable<double>> MultiColumnWidth = default, 
            Optional<bool> UseDefaults = default
        )
            =>
                Plotly.NET.ChartDomain_Table.Chart.Table(
                   header: header,
                   cells: cells,
                   Name: Name.ToOption(),
                   ColumnOrder: ColumnOrder.ToOption(),
                   ColumnWidth: ColumnWidth.ToOption(),
                   MultiColumnWidth: MultiColumnWidth.ToOption(),
                   UseDefaults: UseDefaults.ToOption()
                );
}
