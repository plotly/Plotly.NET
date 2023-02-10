namespace Plotly.NET

open DynamicObj
open System.Runtime.InteropServices
open Giraffe.ViewEngine

type DisplayOptions = {
    AdditionalHeadTags: XmlNode list
    Description: XmlNode list
} with
    static member Create(
        [<Optional; DefaultParameterValue(null)>] ?AdditionalHeadTags: XmlNode list,
        [<Optional; DefaultParameterValue(null)>] ?Description: XmlNode list
    ) =
        {
            AdditionalHeadTags = AdditionalHeadTags |> Option.defaultValue []
            Description = Description |> Option.defaultValue []
        }

    static member addAdditionalHeadTags (additionalHeadTags: XmlNode list) (displayOpts:DisplayOptions) =
        {
            displayOpts with
                AdditionalHeadTags = List.append displayOpts.AdditionalHeadTags additionalHeadTags
        }

    static member addDescription (description: XmlNode list) (displayOpts:DisplayOptions) =
        {
            displayOpts with
                Description = List.append displayOpts.Description description
        }
