namespace Plotly.NET.Verso

open System
open System.IO
open System.Reflection

/// Only strings cross the boundary between the kernel's and extension's assembly load contexts.
module internal ChartBridge =
    type Reference = Cdn of string | Full | NoReference | Require

    type Snapshot = {
        Json: string
        Reference: Reference
        PlotlySource: string option
        HeadTags: string
        Description: string
        Title: string
        Charset: string
        DocumentDescription: string
        Favicon: string
    }

    let private flags = BindingFlags.Public ||| BindingFlags.Static

    let rec private chartType (candidate: Type) =
        if isNull candidate then None
        elif candidate.FullName = "Plotly.NET.GenericChart"
             && candidate.Assembly.GetName().Name = "Plotly.NET" then Some candidate
        else chartType candidate.BaseType

    let private methodWithArgument (owner: Type) name (argumentType: Type) =
        owner.GetMethod(name, flags, null, [| argumentType |], null)

    let tryGetChartType (value: obj) =
        if isNull value then None
        else
            chartType (value.GetType())
            |> Option.filter (fun sourceType ->
                let serialize = methodWithArgument sourceType "toJson" sourceType
                let display = methodWithArgument sourceType "getDisplayOptions" sourceType
                not (isNull serialize) && serialize.ReturnType = typeof<string> && not (isNull display))

    let private invoke (owner: Type) name (argumentType: Type) argument =
        let methodInfo = methodWithArgument owner name argumentType
        if isNull methodInfo then invalidOp $"The originating Plotly.NET assembly does not provide {owner.Name}.{name}."
        methodInfo.Invoke(null, [| argument |])

    let private property name (value: obj) =
        let info = value.GetType().GetProperty(name)
        if isNull info then invalidOp $"The originating Plotly.NET value does not provide {name}."
        info.GetValue(value)

    let private renderNodes (methodInfo: MethodInfo) options =
        let nodes = methodInfo.Invoke(null, [| options |])
        let nodeType = methodInfo.ReturnType.GetGenericArguments()[0]
        let renderer = nodeType.Assembly.GetType("Giraffe.ViewEngine.RenderView+AsString", true)
        invoke renderer "htmlNodes" methodInfo.ReturnType nodes :?> string

    let capture forceOffline (value: obj) =
        let sourceType = tryGetChartType value |> Option.defaultWith (fun () -> invalidArg "value" "Expected a Plotly.NET GenericChart.")
        let options = invoke sourceType "getDisplayOptions" sourceType value
        // Static getters belong to the declared base type, even for custom options subclasses.
        let optionsType = (methodWithArgument sourceType "getDisplayOptions" sourceType).ReturnType
        let get name = invoke optionsType name optionsType options
        let getString name = get name :?> string
        let htmlList name =
            let getter = methodWithArgument optionsType name optionsType
            if isNull getter then invalidOp $"The originating Plotly.NET assembly does not provide {name}."
            renderNodes getter options
        let resourceName =
            sourceType.Assembly.GetManifestResourceNames()
            |> Array.filter (fun name -> name.StartsWith("Plotly.NET.plotly-", StringComparison.Ordinal) && name.EndsWith(".min.js", StringComparison.Ordinal))
            |> function
                | [| name |] -> name
                | _ -> invalidOp "Cannot identify the originating Plotly.NET JavaScript resource."
        let version = resourceName.Substring("Plotly.NET.plotly-".Length).Replace(".min.js", "")
        let reference =
            if forceOffline then Full
            else
                match get "tryGetPlotlyReference" with
                | null -> Cdn $"https://cdn.plot.ly/plotly-{version}.min.js"
                | some ->
                    let reference = property "Value" some
                    let isCase name = property name reference :?> bool
                    if isCase "IsFull" then Full
                    elif isCase "IsCDN" then Cdn (property "Item" reference :?> string)
                    elif isCase "IsNoReference" then NoReference
                    elif isCase "IsRequire" then Require
                    else invalidOp "Unsupported originating Plotly.NET JavaScript reference."
        let source =
            match reference with
            | Full ->
                use stream = sourceType.Assembly.GetManifestResourceStream(resourceName)
                use reader = new StreamReader(stream)
                Some (reader.ReadToEnd())
            | _ -> None
        let favicon = get "getDocumentFavicon"
        let faviconType = (methodWithArgument optionsType "getDocumentFavicon" optionsType).ReturnType
        let renderer = faviconType.Assembly.GetType("Giraffe.ViewEngine.RenderView+AsString", true)
        {
            Json = invoke sourceType "toJson" sourceType value :?> string
            Reference = reference
            PlotlySource = source
            HeadTags = htmlList "getAdditionalHeadTags"
            Description = htmlList "getChartDescription"
            Title = getString "getDocumentTitle"
            Charset = getString "getDocumentCharset"
            DocumentDescription = getString "getDocumentDescription"
            Favicon = invoke renderer "htmlNode" faviconType favicon :?> string
        }
