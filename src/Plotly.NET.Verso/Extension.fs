namespace Plotly.NET.Verso

open System
open System.Collections.Generic
open System.Reflection
open System.Threading.Tasks
open Verso.Abstractions

[<VersoExtension>]
type GenericChartFormatter() =

    interface IExtension with
        member _.ExtensionId = "net.plotly.plotly-net-verso"
        member _.Name = "Plotly.NET"
        member _.Version =
            let assembly = typeof<GenericChartFormatter>.Assembly
            match assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>() with
            | null -> assembly.GetName().Version.ToString(3)
            | version -> version.InformationalVersion.Split('+')[0]
        member _.Author = "Plotly.NET Contributors"
        member _.Description = "Renders Plotly.NET GenericChart objects as interactive charts in Verso notebooks."
        member _.OnLoadedAsync(_ctx) = Task.CompletedTask
        member _.OnUnloadedAsync() = Task.CompletedTask

    interface IDataFormatter with
        // A local GenericChart Type fails Verso's prefilter for values from the kernel's ALC.
        member _.SupportedTypes: IReadOnlyList<Type> = [| typeof<obj> |]

        member _.Priority = 100

        member _.CanFormat(value, ctx) =
            String.Equals(ctx.MimeType, "text/html", StringComparison.OrdinalIgnoreCase)
            && (ChartBridge.tryGetChartType value |> Option.isSome)

        member _.FormatAsync(value, ctx) =
            task {
                ctx.CancellationToken.ThrowIfCancellationRequested()
                try
                    if not (String.Equals(ctx.MimeType, "text/html", StringComparison.OrdinalIgnoreCase)) then
                        invalidArg "ctx" "The Plotly.NET formatter supports text/html output."
                    let snapshot = ChartBridge.capture false value
                    ctx.CancellationToken.ThrowIfCancellationRequested()
                    let html = Rendering.render false snapshot
                    ctx.CancellationToken.ThrowIfCancellationRequested()
                    return CellOutput(MimeType = "text/html", Content = html)
                with
                | :? OperationCanceledException -> return raise (OperationCanceledException(ctx.CancellationToken))
                | error ->
                    return CellOutput(MimeType = "text/html", Content = Rendering.error (error.GetBaseException().Message), IsError = true)
            }
