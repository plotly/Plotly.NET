namespace Plotly.NET.Interactive

open System
open System.Threading.Tasks
open Microsoft.DotNet.Interactive
open Microsoft.DotNet.Interactive.Formatting
open Plotly.NET

type FormatterKernelExtension() =

    interface IKernelExtension with
        member _.OnLoadAsync _ =

            Formatter.Register<GenericChart>(
                Action<_, _>(fun chart (writer: IO.TextWriter) -> writer.Write(Formatters.toInteractiveHTML chart)),
                "text/html"
            )

            Task.CompletedTask
