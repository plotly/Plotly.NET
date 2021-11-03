namespace Plotly.NET.ChartStudio

open DynamicObj
open System
open System.Runtime.InteropServices
open System.Net.Http
open System.Web

type API() =

    static let RESOURCE = "plots"

    static member buildURL
        (
            resource,
            [<Optional; DefaultParameterValue("")>] ?id: String,
            [<Optional; DefaultParameterValue("")>] ?route: String
        ) =

        let config = Config.getConfigFile ()

        let baseURL =
            match config.TryGetValue "plotly_api_domain" with
            | Some apiDomain -> string apiDomain
            | _ -> "https://api.plotly.com"

        let urlWithID =
            match id with
            | Some x when (not (String.IsNullOrEmpty(x))) -> $"{baseURL}//v2//{resource}//{x}"
            | _ -> $"{baseURL}//v2//{resource}"

        let url =
            match route with
            | Some x when (not (String.IsNullOrEmpty(x))) -> $"{urlWithID}//{route}"
            | _ -> $"{urlWithID}"

        url

    static member create body =
        async {
            use client = new HttpClient()

            let url = API.buildURL RESOURCE
            let content = new StringContent(body)
            printf "%A" url

            let! response = client.PostAsync(url, content) |> Async.AwaitTask

            let! body =
                response.Content.ReadAsStringAsync()
                |> Async.AwaitTask

            return
                match response.IsSuccessStatusCode with
                | true -> Ok body
                | false -> Error body
        }
        |> Async.RunSynchronously

    static member retrieve(fid, [<Optional; DefaultParameterValue("")>] ?share_key: String) =
        async {
            use client = new HttpClient()

            let url =
                API.buildURL (resource = RESOURCE, id = fid)

            let url =
                match share_key with
                | Some key ->
                    let query =
                        HttpUtility.ParseQueryString(String.Empty)

                    query.Add("share_key", key)

                    let builder =
                        new UriBuilder(url, Query = query.ToString())

                    builder.Uri.ToString()
                | _ -> url

            let! response = client.GetAsync(url) |> Async.AwaitTask

            let! content =
                response.Content.ReadAsStringAsync()
                |> Async.AwaitTask

            return content
        }
        |> Async.RunSynchronously
