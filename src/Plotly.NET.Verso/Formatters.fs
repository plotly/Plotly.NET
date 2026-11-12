namespace Plotly.NET.Verso

open System
open System.IO
open System.Net
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Plotly.NET

module internal Rendering =
    let private script = lazy (
        use stream = typeof<ChartBridge.Snapshot>.Assembly.GetManifestResourceStream("Plotly.NET.Verso.Renderer.js")
        use reader = new StreamReader(stream)
        reader.ReadToEnd())

    let private encode (text: string) = WebUtility.HtmlEncode(text)

    let error message =
        $"<div class=\"plotly-net-verso\" data-plotly-state=\"error\"><div role=\"alert\">Plotly.NET: {encode message}</div></div>"

    let render document (snapshot: ChartBridge.Snapshot) =
        let id = "plotly-" + Guid.NewGuid().ToString("N")
        let mode, url =
            match snapshot.Reference with
            | ChartBridge.Cdn url -> "cdn", url
            | ChartBridge.Full -> "full", ""
            | ChartBridge.NoReference -> "none", ""
            | ChartBridge.Require -> "require", ""
        let payload = JObject()
        payload["id"] <- JValue(id)
        payload["mode"] <- JValue(mode)
        payload["url"] <- JValue(url)
        // Keep the originating serializer's JSON intact (including date strings).
        // Escape HTML delimiters before putting its raw JSON in an inline script.
        let chartJson = snapshot.Json.Replace("<", "\\u003c").Replace(">", "\\u003e").Replace("&", "\\u0026")
        payload["chart"] <- JRaw(chartJson)
        let settings = JsonSerializerSettings(StringEscapeHandling = StringEscapeHandling.EscapeHtml)
        let json = JsonConvert.SerializeObject(payload, Formatting.None, settings)
        let library =
            snapshot.PlotlySource
            |> Option.map (fun source -> "<script type=\"text/javascript\">" + source + "</script>")
            |> Option.defaultValue ""
        let chart =
            $"<div id=\"{id}\" class=\"plotly-net-verso\" data-plotly-state=\"loading\"></div>"
            + library
            + "<script type=\"text/javascript\">" + script.Value.Replace("/*PAYLOAD*/", json) + "</script>"
            + snapshot.Description
        if document then
            "<!DOCTYPE html><html><head><meta charset=\"" + encode snapshot.Charset
            + "\"><title>" + encode snapshot.Title + "</title><meta name=\"description\" content=\""
            + encode snapshot.DocumentDescription + "\">" + snapshot.Favicon + snapshot.HeadTags
            + "</head><body>" + chart + "</body></html>"
        else snapshot.HeadTags + chart

module Formatters =
    /// Creates Verso cell HTML, loading Plotly asynchronously from the chart's CDN reference.
    /// A Full reference embeds Plotly for offline use; NoReference uses an already loaded library.
    let toVersoHTML (gChart: GenericChart) =
        ChartBridge.capture false gChart |> Rendering.render false

    /// Creates a complete HTML document with the originating chart's Plotly library embedded.
    /// User-supplied head tags and chart resources are preserved and may require network access.
    let toVersoHTMLOffline (gChart: GenericChart) =
        ChartBridge.capture true gChart |> Rendering.render true
