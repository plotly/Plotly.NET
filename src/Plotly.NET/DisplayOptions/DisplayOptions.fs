namespace Plotly.NET

open DynamicObj
open System.Runtime.InteropServices
open Giraffe.ViewEngine


///Sets how plotly is referenced in the head of html docs.
type PlotlyJSReference =
    /// The url for a script tag that references the plotly.js CDN When
    | CDN of string
    /// Full plotly.js source code (~3MB) is included in the output. HTML files generated with this option are fully self-contained and can be used offline
    | Full
    /// Use requirejs to reference plotlyjs from a url
    | Require of string
    //include no plotlyjs script at all. This can be helpfull when embedding the output into a document that already references plotly.
    | NoReference

type DisplayOptions() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new DisplayOptions object with the given styles
    /// </summary>
    /// <param name="AdditionalHeadTags">Additional tags that will be included in the document's head </param>
    /// <param name="Description">HTML tags that appear below the chart in HTML docs</param>
    /// <param name="PlotlyJSReference">Sets how plotly is referenced in the head of html docs. When CDN, a script tag that references the plotly.js CDN is included in the output. When Full, a script tag containing the plotly.js source code (~3MB) is included in the output. HTML files generated with this option are fully self-contained and can be used offline</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?AdditionalHeadTags: XmlNode list,
            [<Optional; DefaultParameterValue(null)>] ?Description: XmlNode list,
            [<Optional; DefaultParameterValue(null)>] ?PlotlyJSReference: PlotlyJSReference
        ) =
        DisplayOptions()
        |> DisplayOptions.style (
            ?AdditionalHeadTags = AdditionalHeadTags,
            ?Description = Description,
            ?PlotlyJSReference = PlotlyJSReference
        )

    /// <summary>
    /// Returns a function sthat applies the given styles to a DisplayOptions object
    /// </summary>
    /// <param name="AdditionalHeadTags">Additional tags that will be included in the document's head </param>
    /// <param name="Description">HTML tags that appear below the chart in HTML docs</param>
    /// <param name="PlotlyJSReference">Sets how plotly is referenced in the head of html docs. When CDN, a script tag that references the plotly.js CDN is included in the output. When Full, a script tag containing the plotly.js source code (~3MB) is included in the output. HTML files generated with this option are fully self-contained and can be used offline</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?AdditionalHeadTags: XmlNode list,
            [<Optional; DefaultParameterValue(null)>] ?Description: XmlNode list,
            [<Optional; DefaultParameterValue(null)>] ?PlotlyJSReference: PlotlyJSReference
        ) =
        (fun (displayOpts: DisplayOptions) ->

            AdditionalHeadTags |> DynObj.setValueOpt displayOpts "AdditionalHeadTags"
            Description |> DynObj.setValueOpt displayOpts "Description"
            PlotlyJSReference |> DynObj.setValueOpt displayOpts "PlotlyJSReference"

            displayOpts)

    /// <summary>
    /// Returns a DisplayOptions Object with the plotly cdn set to Globals.PLOTLYJS_VERSION
    /// </summary>
    static member initCDNOnly() =
        DisplayOptions()
        |> DisplayOptions.style (
            PlotlyJSReference = CDN $"https://cdn.plot.ly/plotly-{Globals.PLOTLYJS_VERSION}.min.js"
        )

    /// <summary>
    /// Combines two DisplayOptions objects.
    ///
    /// In case of duplicate dynamic member values, the values of the second DisplayOptions are used.
    ///
    /// For the collections used for the dynamic members
    ///
    /// AdditionalHeadTags, Description
    ///
    /// the values from the second DisplayOptions are appended to those of the first instead.
    /// </summary>
    /// <param name="first">The first DisplayOptions to combine with the second</param>
    /// <param name="second">The second DisplayOptions to combine with the first</param>
    static member combine (first: DisplayOptions) (second: DisplayOptions) =

        let additionalHeadTags =
            InternalUtils.combineOptLists
                (first.TryGetTypedValue<XmlNode list>("AdditionalHeadTags"))
                (second.TryGetTypedValue<XmlNode list>("AdditionalHeadTags"))

        let description =
            InternalUtils.combineOptLists
                (first.TryGetTypedValue<XmlNode list>("Description"))
                (second.TryGetTypedValue<XmlNode list>("Description"))

        DynObj.combine first second
        |> unbox
        |> DisplayOptions.style (?AdditionalHeadTags = additionalHeadTags, ?Description = description)

    static member setAdditionalHeadTags(additionalHeadTags: XmlNode list) =
        (fun (displayOpts: DisplayOptions) ->
            additionalHeadTags |> DynObj.setValue displayOpts "AdditionalHeadTags"
            displayOpts)

    static member tryGetAdditionalHeadTags(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<XmlNode list>("AdditionalHeadTags")

    static member getAdditionalHeadTags(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetAdditionalHeadTags |> Option.defaultValue []

    static member addAdditionalHeadTags(additionalHeadTags: XmlNode list) =
        (fun (displayOpts: DisplayOptions) ->
            displayOpts
            |> DisplayOptions.setAdditionalHeadTags (
                List.append (DisplayOptions.getAdditionalHeadTags displayOpts) additionalHeadTags
            ))


    static member setDescription(description: XmlNode list) =
        (fun (displayOpts: DisplayOptions) ->
            description |> DynObj.setValue displayOpts "Description"
            displayOpts)

    static member tryGetDescription(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<XmlNode list>("Description")

    static member getDescription(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetDescription |> Option.defaultValue []

    static member addDescription(description: XmlNode list) =
        (fun (displayOpts: DisplayOptions) ->
            displayOpts
            |> DisplayOptions.setDescription (List.append (DisplayOptions.getDescription displayOpts) description))

    static member setPlotlyReference(plotlyReference: PlotlyJSReference) =
        (fun (displayOpts: DisplayOptions) ->
            plotlyReference |> DynObj.setValue displayOpts "PlotlyJSReference"
            displayOpts)

    static member tryGetPlotlyReference(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<PlotlyJSReference>("PlotlyJSReference")

    static member getPlotlyPlotlyReference(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetPlotlyReference |> Option.defaultValue (PlotlyJSReference.NoReference)
