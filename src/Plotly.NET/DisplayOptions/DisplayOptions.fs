namespace Plotly.NET

open DynamicObj
open System.Runtime.InteropServices
open Giraffe.ViewEngine

type MathJax =
    | V2
    | V3
    | NoMathJax

type DisplayOptions = {
    AdditionalHeadTags: XmlNode list
    Description: XmlNode list
    MathJaxVersion: MathJax
} with
    static member Create(
        [<Optional; DefaultParameterValue(null)>] ?AdditionalHeadTags: XmlNode list,
        [<Optional; DefaultParameterValue(null)>] ?Description: XmlNode list,
        [<Optional; DefaultParameterValue(null)>] ?MathJaxVersion: MathJax
    ) =
        {
            AdditionalHeadTags = AdditionalHeadTags |> Option.defaultValue []
            Description = Description |> Option.defaultValue []
            MathJaxVersion = MathJaxVersion |> Option.defaultValue MathJax.V2
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

    static member setMathJaxVersion (version: MathJax) (displayOpts:DisplayOptions) =
        {
            displayOpts with
                MathJaxVersion = version
        }
