namespace Plotly.NET.Interactive

open System.Threading.Tasks
open Microsoft.DotNet.Interactive
open Microsoft.DotNet.Interactive.Formatting
open Plotly.NET.GenericChart

type FormatterKernelExtension() =

    let registerFormatter () =
        Formatter.Register<GenericChart>
            ((fun chart writer ->
                let html = toChartHTML chart

                writer.Write(html)),
             HtmlFormatter.MimeType)

    interface IKernelExtension with
        member _.OnLoadAsync _ =
            registerFormatter ()

            if isNull KernelInvocationContext.Current |> not then
                let message =
                    "Added Kernerl Extension including formatters for GenericChart"

                KernelInvocationContext.Current.Display(message, "text/markdown")
                |> ignore

            Task.CompletedTask
