
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.TableFill InitTableFill
        (
            Optional<Color> Color = default
        ) 
            =>
                Plotly.NET.TraceObjects.TableFill.init(
                    Color: Color.ToOption()
                );
    public static Plotly.NET.TraceObjects.TableCells InitTableCells<ValuesType>
        (
            Optional<StyleParam.HorizontalAlign> Align = default,
            Optional<IEnumerable<StyleParam.HorizontalAlign>> MultiAlign = default,
            Optional<Plotly.NET.TraceObjects.TableFill> Fill = default,
            Optional<Font> Font = default,
            Optional<IEnumerable<string>> Format = default,
            Optional<int> Height = default,
            Optional<Line> Line = default,
            Optional<string> Prefix = default,
            Optional<IEnumerable<string>> MultiPrefix = default,
            Optional<string> Suffix = default,
            Optional<IEnumerable<string>> MultiSuffix = default,
            Optional<IEnumerable<IEnumerable<ValuesType>>> Values = default
        ) 
            where ValuesType: IConvertible
            =>
                Plotly.NET.TraceObjects.TableCells.init(
                    Align: Align.ToOption(),
                    MultiAlign: MultiAlign.ToOption(),
                    Fill: Fill.ToOption(),
                    Font: Font.ToOption(),
                    Format: Format.ToOption(),
                    Height: Height.ToOption(),
                    Line: Line.ToOption(),
                    Prefix: Prefix.ToOption(),
                    MultiPrefix: MultiPrefix.ToOption(),
                    Suffix: Suffix.ToOption(),
                    MultiSuffix: MultiSuffix.ToOption(),
                    Values: Values.ToOption()
                );
}

