namespace Plotly.NET.Verso

open System
open System.Collections.Generic
open System.Threading.Tasks
open Verso.Abstractions
open Plotly.NET

[<VersoExtension>]
type GenericChartFormatter() =

    interface IExtension with
        member _.ExtensionId = "net.plotly.plotly-net-verso"
        member _.Name = "Plotly.NET"
        member _.Version = "1.0.0"
        member _.Author = "Plotly.NET Contributors"
        member _.Description = "Renders Plotly.NET GenericChart objects as interactive charts in Verso notebooks."
        member _.OnLoadedAsync(_ctx) = Task.CompletedTask
        member _.OnUnloadedAsync() = Task.CompletedTask

    interface IDataFormatter with
        member _.SupportedTypes: IReadOnlyList<Type> =
            [| typeof<GenericChart> |] :> IReadOnlyList<Type>

        member _.Priority = 100

        member _.CanFormat(value, _ctx) = value :? GenericChart

        member _.FormatAsync(value, _ctx) =
            let html = Formatters.toVersoHTML (value :?> GenericChart)
            Task.FromResult(CellOutput(MimeType = "text/html", Content = html))
