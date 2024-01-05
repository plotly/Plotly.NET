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
            [<Optional; DefaultParameterValue(null)>] ?DocumentTitle: string,
            [<Optional; DefaultParameterValue(null)>] ?DocumentCharset: string,
            [<Optional; DefaultParameterValue(null)>] ?DocumentDescription: string,
            [<Optional; DefaultParameterValue(null)>] ?DocumentFavicon: XmlNode,
            [<Optional; DefaultParameterValue(null)>] ?AdditionalHeadTags: XmlNode list,
            [<Optional; DefaultParameterValue(null)>] ?ChartDescription: XmlNode list,
            [<Optional; DefaultParameterValue(null)>] ?PlotlyJSReference: PlotlyJSReference
        ) =
        DisplayOptions()
        |> DisplayOptions.style (
            ?DocumentTitle = DocumentTitle,
            ?DocumentCharset = DocumentCharset,
            ?DocumentDescription = DocumentDescription,
            ?DocumentFavicon = DocumentFavicon,
            ?AdditionalHeadTags = AdditionalHeadTags,
            ?ChartDescription = ChartDescription,
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
            [<Optional; DefaultParameterValue(null)>] ?DocumentTitle: string,
            [<Optional; DefaultParameterValue(null)>] ?DocumentCharset: string,
            [<Optional; DefaultParameterValue(null)>] ?DocumentDescription: string,
            [<Optional; DefaultParameterValue(null)>] ?DocumentFavicon: XmlNode,
            [<Optional; DefaultParameterValue(null)>] ?AdditionalHeadTags: XmlNode list,
            [<Optional; DefaultParameterValue(null)>] ?ChartDescription: XmlNode list,
            [<Optional; DefaultParameterValue(null)>] ?PlotlyJSReference: PlotlyJSReference
        ) =
        (fun (displayOpts: DisplayOptions) ->

            DocumentTitle |> DynObj.setValueOpt displayOpts "DocumentTitle"
            DocumentCharset |> DynObj.setValueOpt displayOpts "DocumentCharset"
            DocumentDescription |> DynObj.setValueOpt displayOpts "DocumentDescription"
            DocumentFavicon |> DynObj.setValueOpt displayOpts "DocumentFavicon"
            AdditionalHeadTags |> DynObj.setValueOpt displayOpts "AdditionalHeadTags"
            ChartDescription |> DynObj.setValueOpt displayOpts "ChartDescription"
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
                (first.TryGetTypedValue<XmlNode list>("ChartDescription"))
                (second.TryGetTypedValue<XmlNode list>("ChartDescription"))

        DynObj.combine first second
        |> unbox
        |> DisplayOptions.style (?AdditionalHeadTags = additionalHeadTags, ?ChartDescription = description)

    /// <summary>
    /// Sets the given document title on the given DisplayOptions object
    /// </summary>
    /// <param name="documentTitle">The document title to set on the given DisplayOptions object</param>
    static member setDocumentTitle(documentTitle: string) =
        (fun (displayOpts: DisplayOptions) ->
            documentTitle |> DynObj.setValue displayOpts "DocumentTitle"
            displayOpts)

    /// <summary>
    /// Returns Some document title from the given DisplayOptions object if it exists, None otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the document title from</param>
    static member tryGetDocumentTitle(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<string>("DocumentTitle")

    /// <summary>
    /// Returns the document title from the given DisplayOptions object if it exists, an empty string otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the document title from</param>
    static member getDocumentTitle(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetDocumentTitle |> Option.defaultValue ""

    /// <summary>
    /// Sets the given document charset on the given DisplayOptions object
    /// </summary>
    /// <param name="documentCharset">The document charset to set on the given DisplayOptions object</param>
    static member setDocumentCharset(documentCharset: string) =
        (fun (displayOpts: DisplayOptions) ->
            documentCharset |> DynObj.setValue displayOpts "DocumentCharset"
            displayOpts)

    /// <summary>
    /// Returns Some document charset from the given DisplayOptions object if it exists, None otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the document charset from</param>
    static member tryGetDocumentCharset(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<string>("DocumentCharset")

    /// <summary>
    /// Returns the document charset from the given DisplayOptions object if it exists, an empty string otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the document charset from</param>
    static member getDocumentCharset(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetDocumentCharset |> Option.defaultValue ""

    /// <summary>
    /// Sets the given document description on the given DisplayOptions object
    /// </summary>
    /// <param name="documentDescription">The document description to set on the given DisplayOptions object</param>
    static member setDocumentDescription(documentDescription: string) =
        (fun (displayOpts: DisplayOptions) ->
            documentDescription |> DynObj.setValue displayOpts "DocumentDescription"
            displayOpts)

    /// <summary>
    /// Returns Some document description from the given DisplayOptions object if it exists, None otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the document description from</param>
    static member tryGetDocumentDescription(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<string>("DocumentDescription")

    /// <summary>
    /// Returns the document description from the given DisplayOptions object if it exists, an empty string otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the document description from</param>
    static member getDocumentDescription(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetDocumentDescription |> Option.defaultValue ""

    /// <summary>
    /// Sets the given document favicon on the given DisplayOptions object
    /// </summary>
    /// <param name="documentFavicon">The document favicon to set on the given DisplayOptions object</param>
    static member setDocumentFavicon(documentFavicon: XmlNode) =
        (fun (displayOpts: DisplayOptions) ->
            documentFavicon |> DynObj.setValue displayOpts "DocumentFavicon"
            displayOpts)

    /// <summary>
    /// Returns Some document favicon from the given DisplayOptions object if it exists, None otherwise
    /// </summary>
    /// <param name="displayOpts"></param>
    static member tryGetDocumentFavicon(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<XmlNode>("DocumentFavicon")

    /// <summary>
    /// Returns the document favicon from the given DisplayOptions object if it exists, an empty XML Node otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the document favicon from</param>
    static member getDocumentFavicon(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetDocumentFavicon |> Option.defaultValue (rawText "")

    /// <summary>
    /// Sets the given additional head tags on the given DisplayOptions object
    /// </summary>
    /// <param name="additionalHeadTags">The additional head tags to set on the given DisplayOptions object</param>
    static member setAdditionalHeadTags(additionalHeadTags: XmlNode list) =
        (fun (displayOpts: DisplayOptions) ->
            additionalHeadTags |> DynObj.setValue displayOpts "AdditionalHeadTags"
            displayOpts)

    /// <summary>
    /// Returns Some additional head tags from the given DisplayOptions object if they exist, None otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the additional head tags from</param>
    static member tryGetAdditionalHeadTags(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<XmlNode list>("AdditionalHeadTags")

    /// <summary>
    /// Returns the additional head tags from the given DisplayOptions object if they exist, an empty list otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the additional head tags from</param>
    static member getAdditionalHeadTags(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetAdditionalHeadTags |> Option.defaultValue []

    /// <summary>
    /// Adds the given additional head tags to the given DisplayOptions object
    /// </summary>
    /// <param name="additionalHeadTags">The additional head tags to add to the given DisplayOptions object</param>
    static member addAdditionalHeadTags(additionalHeadTags: XmlNode list) =
        (fun (displayOpts: DisplayOptions) ->
            displayOpts
            |> DisplayOptions.setAdditionalHeadTags (
                List.append (DisplayOptions.getAdditionalHeadTags displayOpts) additionalHeadTags
            ))

    /// <summary>
    /// Sets the given chart description on the given DisplayOptions object
    /// </summary>
    /// <param name="chartDescription">The chart chart description to set on the given DisplayOptions object</param>
    static member setChartDescription(chartDescription: XmlNode list) =
        (fun (displayOpts: DisplayOptions) ->
            chartDescription |> DynObj.setValue displayOpts "ChartDescription"
            displayOpts)

    /// <summary>
    /// Returns Some chart description from the given DisplayOptions object if it exists, None otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the chart description from</param>
    static member tryGetChartDescription(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<XmlNode list>("ChartDescription")

    /// <summary>
    /// Returns the chart description from the given DisplayOptions object if it exists, an empty list otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the chart description from</param>
    static member getChartDescription(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetChartDescription |> Option.defaultValue []

    /// <summary>
    /// Adds the given chart description to the given DisplayOptions object
    /// </summary>
    /// <param name="description">The chart description to add to the given DisplayOptions object</param>
    static member addChartDescription(description: XmlNode list) =
        (fun (displayOpts: DisplayOptions) ->
            displayOpts
            |> DisplayOptions.setChartDescription (List.append (DisplayOptions.getChartDescription displayOpts) description))

    /// <summary>
    /// Sets the given reference to a plotly.js source on the given DisplayOptions object
    /// </summary>
    /// <param name="plotlyReference">The reference to a plotly.js source to set on the given DisplayOptions object</param>
    static member setPlotlyReference(plotlyReference: PlotlyJSReference) =
        (fun (displayOpts: DisplayOptions) ->
            plotlyReference |> DynObj.setValue displayOpts "PlotlyJSReference"
            displayOpts)

    /// <summary>
    /// Returns Some reference to a plotly.js source from the given DisplayOptions object if it exists, None otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the reference to a plotly.js source from</param>
    static member tryGetPlotlyReference(displayOpts: DisplayOptions) =
        displayOpts.TryGetTypedValue<PlotlyJSReference>("PlotlyJSReference")

    /// <summary>
    /// Returns the reference to a plotly.js source from the given DisplayOptions object if it exists, NoReference otherwise
    /// </summary>
    /// <param name="displayOpts">The DisplayOptions object to get the reference to a plotly.js source from</param>
    static member getPlotlyReference(displayOpts: DisplayOptions) =
        displayOpts |> DisplayOptions.tryGetPlotlyReference |> Option.defaultValue (PlotlyJSReference.NoReference)
