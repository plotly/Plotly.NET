namespace Plotly.NET.Interactive

open System
open System.Threading.Tasks
open Microsoft.DotNet.Interactive
open Microsoft.DotNet.Interactive.Formatting
open Plotly.NET.GenericChart

type FormatterKernelExtension() =

    let registerFormatter () =
        Formatter.Register<GenericChart>
            (
                Action<_,_>(fun chart (writer: IO.TextWriter) ->
                    let html = toChartHTML chart
                    writer.Write(html)
            ),
            HtmlFormatter.MimeType)

    interface IKernelExtension with
        member _.OnLoadAsync _ =
            registerFormatter ()
            Task.CompletedTask
