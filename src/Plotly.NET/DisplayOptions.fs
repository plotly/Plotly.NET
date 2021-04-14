namespace Plotly.NET

type ChartDescription =
    {
        Heading : string
        Text    : string
    }

    static member create heading text =
        {
            Heading = heading
            Text = text
        }

    //to-do: when finally using a html dsl, adapt to return XMLNode
    static member toHtml (d:ChartDescription) =
    
        let html = """<div class=container>
    <h3>[DESCRIPTIONHEADING]</h3>
    <p>[DESCRIPTIONTEXT]</p>
</div>"""

        html
            .Replace("[DESCRIPTIONHEADING]",d.Heading)
            .Replace("[DESCRIPTIONTEXT]",d.Text)


type DisplayOptions() =
    inherit DynamicObj()

    static member init
        (    
            ?AdditionalScriptTags:seq<string>,
            ?Description:ChartDescription
        ) =    
            DisplayOptions()
            |> DisplayOptions.style
                (
                    ?AdditionalScriptTags = AdditionalScriptTags,
                    ?Description = Description
                )


    // Applies the styles to Font()
    static member style
        (    
            ?AdditionalScriptTags:seq<string>,
            ?Description:ChartDescription
        ) =
            (fun (displayOptions:DisplayOptions) -> 

                AdditionalScriptTags    |> DynObj.setValueOpt displayOptions "AdditionalScriptTags"
                Description             |> DynObj.setValueOpt displayOptions "Description"

                displayOptions
            )


    static member getReplacements (displayOptions:DisplayOptions) =
        [
            "[ADDITIONAL_SCRIPT_TAGS]", 
                (displayOptions.TryGetTypedValue<seq<string>>("AdditionalScriptTags") 
                |> Option.map (String.concat "\r\n")
                |> Option.defaultValue "")
            "[DESCRIPTION]", 
                (displayOptions.TryGetTypedValue<ChartDescription>("Description") 
                |> Option.map ChartDescription.toHtml
                |> Option.defaultValue "")
        ]

    static member replaceHtmlPlaceholders (displayOptions:DisplayOptions) (html:string) =
        displayOptions
        |> DisplayOptions.getReplacements
        |> List.fold (fun (html:string) (placeholder,replacement) ->
            printfn $"replacing {placeholder} {replacement}"
            html.Replace(placeholder,replacement)
        ) html


