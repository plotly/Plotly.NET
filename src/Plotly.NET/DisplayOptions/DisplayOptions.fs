namespace Plotly.NET

open DynamicObj
open System.Runtime.InteropServices
open Giraffe.ViewEngine

type DisplayOptions() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new DisplayOptions object with the given styles
    /// </summary>
    /// <param name="AdditionalHeadTags">Additional tags that will be included in the document's head </param>
    /// <param name="Description">HTML tags that appear below the chart in HTML docs</param>
    /// <param name="PlotlyCDN">The PlotlyCDN address used in html docs</param>
    static member init (
        [<Optional; DefaultParameterValue(null)>] ?AdditionalHeadTags: XmlNode list,
        [<Optional; DefaultParameterValue(null)>] ?Description: XmlNode list,
        [<Optional; DefaultParameterValue(null)>] ?PlotlyCDN: string
    ) =
        DisplayOptions()
        |> DisplayOptions.style(
            ?AdditionalHeadTags = AdditionalHeadTags,
            ?Description = Description,
            ?PlotlyCDN = PlotlyCDN
        )

    /// <summary>
    /// Returns a function sthat applies the given styles to a DisplayOptions object
    /// </summary>
    /// <param name="AdditionalHeadTags">Additional tags that will be included in the document's head </param>
    /// <param name="Description">HTML tags that appear below the chart in HTML docs</param>
    /// <param name="PlotlyCDN">The PlotlyCDN address used in html docs</param>
    static member style (
        [<Optional; DefaultParameterValue(null)>] ?AdditionalHeadTags: XmlNode list,
        [<Optional; DefaultParameterValue(null)>] ?Description: XmlNode list,
        [<Optional; DefaultParameterValue(null)>] ?PlotlyCDN: string
    ) =
        (fun (displayOpts: DisplayOptions) ->

            AdditionalHeadTags |> DynObj.setValueOpt displayOpts "AdditionalHeadTags"
            Description        |> DynObj.setValueOpt displayOpts "Description"
            PlotlyCDN          |> DynObj.setValueOpt displayOpts "PlotlyCDN"

            displayOpts)

    /// <summary>
    /// Returns a DisplayOptions Object with the plotly cdn set to Globals.PLOTLYJS_VERSION
    /// </summary>
    static member initCDNOnly() =
        DisplayOptions()
        |> DisplayOptions.style(
            PlotlyCDN = Globals.PLOTLYJS_VERSION
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
        |> DisplayOptions.style (
            ?AdditionalHeadTags = additionalHeadTags,
            ?Description = description
        )

    static member setAdditionalHeadTags(additionalHeadTags: XmlNode list) = 
        (fun (displayOpts: DisplayOptions) -> 
            additionalHeadTags |> DynObj.setValue displayOpts "AdditionalHeadTags"
            displayOpts
            )

    static member tryGetAdditionalHeadTags (displayOpts: DisplayOptions) = displayOpts.TryGetTypedValue<XmlNode list>("AdditionalHeadTags")

    static member getAdditionalHeadTags (displayOpts: DisplayOptions) = displayOpts |> DisplayOptions.tryGetAdditionalHeadTags |> Option.defaultValue []

    static member addAdditionalHeadTags(additionalHeadTags: XmlNode list) =
        (fun (displayOpts: DisplayOptions) -> 
            displayOpts
            |> DisplayOptions.setAdditionalHeadTags(
                List.append 
                    (DisplayOptions.getAdditionalHeadTags displayOpts)
                    additionalHeadTags
            )
        )


    static member setDescription(description: XmlNode list) = 
        (fun (displayOpts: DisplayOptions) -> 
            description |> DynObj.setValue displayOpts "Description"
            displayOpts
            )

    static member tryGetDescription (displayOpts: DisplayOptions) = displayOpts.TryGetTypedValue<XmlNode list>("Description")

    static member getDescription (displayOpts: DisplayOptions) = displayOpts |> DisplayOptions.tryGetDescription |> Option.defaultValue []

    static member addDescription(description: XmlNode list) =
        (fun (displayOpts: DisplayOptions) -> 
            displayOpts
            |> DisplayOptions.setDescription(
                List.append 
                    (DisplayOptions.getDescription displayOpts)
                    description
            )
        )

    static member setPlotlyCDN(plotlyCDN: string) = 
        (fun (displayOpts: DisplayOptions) -> 
            plotlyCDN |> DynObj.setValue displayOpts "PlotlyCDN"
            displayOpts
            )

    static member tryGetPlotlyCDN (displayOpts: DisplayOptions) = displayOpts.TryGetTypedValue<string>("PlotlyCDN")

    static member getPlotlyCDN (displayOpts: DisplayOptions) = displayOpts |> DisplayOptions.tryGetPlotlyCDN |> Option.defaultValue ""
