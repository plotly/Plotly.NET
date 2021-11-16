namespace Plotly.NET.ChartStudio

open DynamicObj
open System
open System.Runtime.InteropServices
open System.IO
open Newtonsoft.Json.Linq
open Newtonsoft.Json
open System.Diagnostics

type Credentials() =
    inherit DynamicObj()

    static let PLOTLY_DIR =
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)

    static let CREDENTIALS_FILE = Path.Combine(PLOTLY_DIR, ".credentials")

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Username: string,
            [<Optional; DefaultParameterValue(null)>] ?APIKEY: string,
            [<Optional; DefaultParameterValue(null)>] ?ProxyUsername: string,
            [<Optional; DefaultParameterValue(null)>] ?ProxyPassword: string
        ) =
        Credentials()
        |> Credentials.style (
            ?Username = Username,
            ?APIKEY = APIKEY,
            ?ProxyUsername = ProxyUsername,
            ?ProxyPassword = ProxyPassword
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Username: string,
            [<Optional; DefaultParameterValue(null)>] ?APIKEY: string,
            [<Optional; DefaultParameterValue(null)>] ?ProxyUsername: string,
            [<Optional; DefaultParameterValue(null)>] ?ProxyPassword: string
        ) =
        fun (credentials: Credentials) ->

            Username
            |> DynObj.setValueOpt credentials "username"

            APIKEY |> DynObj.setValueOpt credentials "api_key"

            ProxyUsername
            |> DynObj.setValueOpt credentials "proxy_username"

            ProxyPassword
            |> DynObj.setValueOpt credentials "proxy_password"

            credentials

    static member getCredentialsFile() =
        try
            let json =
                JObject.Parse(File.ReadAllText(CREDENTIALS_FILE))

            Credentials.init (
                string json.["username"],
                string json.["api_key"],
                string json.["proxy_username"],
                string json.["proxy_password"]
            )
        with
        | _ -> Credentials.init ()

    static member setCredentialsFile
        (
            [<Optional; DefaultParameterValue(null)>] ?Username: string,
            [<Optional; DefaultParameterValue(null)>] ?APIKEY: string,
            [<Optional; DefaultParameterValue(null)>] ?ProxyUsername: string,
            [<Optional; DefaultParameterValue(null)>] ?ProxyPassword: string
        ) =
        let text =
            Credentials()
            |> Credentials.style (
                ?Username = Username,
                ?APIKEY = APIKEY,
                ?ProxyUsername = ProxyUsername,
                ?ProxyPassword = ProxyPassword
            )
            |> JsonConvert.SerializeObject

        try
            File.WriteAllText(CREDENTIALS_FILE, text)
        with
        | e -> Trace.WriteLine(e.Message)



type Config() =
    inherit DynamicObj()

    static let PLOTLY_DIR =
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)

    static let CONFIG_FILE = Path.Combine(PLOTLY_DIR, ".config")

    static member init
        (
            [<Optional; DefaultParameterValue("https://plotly.com")>] ?Domain: string,
            [<Optional; DefaultParameterValue("stream.plotly.com")>] ?StreamingDomain: string,
            [<Optional; DefaultParameterValue("https://api.plotly.com")>] ?APIDomain: string,
            [<Optional; DefaultParameterValue(true)>] ?SSLVerification: bool,
            [<Optional; DefaultParameterValue(false)>] ?ProxyAuthorization: bool,
            [<Optional; DefaultParameterValue(true)>] ?WorldReadable: bool,
            [<Optional; DefaultParameterValue("public")>] ?Sharing: string,
            [<Optional; DefaultParameterValue(true)>] ?AutoOpen: bool
        ) =
        Config()
        |> Config.style (
            ?Domain = Domain,
            ?StreamingDomain = StreamingDomain,
            ?APIDomain = APIDomain,
            ?SSLVerification = SSLVerification,
            ?ProxyAuthorization = ProxyAuthorization,
            ?WorldReadable = WorldReadable,
            ?Sharing = Sharing,
            ?AutoOpen = AutoOpen
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Domain: string,
            [<Optional; DefaultParameterValue(null)>] ?StreamingDomain: string,
            [<Optional; DefaultParameterValue(null)>] ?APIDomain: string,
            [<Optional; DefaultParameterValue(null)>] ?SSLVerification: bool,
            [<Optional; DefaultParameterValue(null)>] ?ProxyAuthorization: bool,
            [<Optional; DefaultParameterValue(null)>] ?WorldReadable: bool,
            [<Optional; DefaultParameterValue(null)>] ?Sharing: string,
            [<Optional; DefaultParameterValue(null)>] ?AutoOpen: bool
        ) =
        fun (config: Config) ->

            Domain
            |> DynObj.setValueOpt config "plotly_domain"

            StreamingDomain
            |> DynObj.setValueOpt config "plotly_streaming_domain"

            APIDomain
            |> DynObj.setValueOpt config "plotly_api_domain"

            SSLVerification
            |> DynObj.setValueOpt config "plotly_ssl_verification"

            ProxyAuthorization
            |> DynObj.setValueOpt config "plotly_proxy_authorization"

            WorldReadable
            |> DynObj.setValueOpt config "world_readable"

            Sharing |> DynObj.setValueOpt config "sharing"

            AutoOpen |> DynObj.setValueOpt config "auto_open"

            config

    static member getConfigFile() =
        let getBool (jtoken: JToken) =
            let _, result = bool.TryParse(string jtoken)
            result

        try
            let json =
                JObject.Parse(File.ReadAllText(CONFIG_FILE))

            Config.init (
                string json.["plotly_domain"],
                string json.["plotly_streaming_domain"],
                string json.["plotly_api_domain"],
                getBool <| json.["plotly_ssl_verification"],
                getBool <| json.["plotly_proxy_authorization"],
                getBool <| json.["world_readable"],
                string json.["sharing"],
                getBool <| json.["auto_open"]
            )
        with
        | _ -> Config.init ()

    static member setConfigFile
        (
            [<Optional; DefaultParameterValue(null)>] ?Domain: string,
            [<Optional; DefaultParameterValue(null)>] ?StreamingDomain: string,
            [<Optional; DefaultParameterValue(null)>] ?APIDomain: string,
            [<Optional; DefaultParameterValue(null)>] ?SSLVerification: bool,
            [<Optional; DefaultParameterValue(null)>] ?ProxyAuthorization: bool,
            [<Optional; DefaultParameterValue(null)>] ?WorldReadable: bool,
            [<Optional; DefaultParameterValue(null)>] ?Sharing: string,
            [<Optional; DefaultParameterValue(null)>] ?AutoOpen: bool
        ) =
        let text =
            Config()
            |> Config.style (
                ?Domain = Domain,
                ?StreamingDomain = StreamingDomain,
                ?APIDomain = APIDomain,
                ?SSLVerification = SSLVerification,
                ?ProxyAuthorization = ProxyAuthorization,
                ?WorldReadable = WorldReadable,
                ?Sharing = Sharing,
                ?AutoOpen = AutoOpen
            )
            |> JsonConvert.SerializeObject

        try
            File.WriteAllText(CONFIG_FILE, text)
        with
        | e -> Trace.WriteLine(e.Message)
