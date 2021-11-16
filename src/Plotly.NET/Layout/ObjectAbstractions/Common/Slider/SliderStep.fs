namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj

/// <summary>
/// The object including the slider steps style and update parameters
/// </summary>
type SliderStep() =
    inherit DynamicObj ()

    /// <summary>
    /// Initializes the slider with style parameters 
    /// </summary>
    /// <param name="Args">Sets the arguments values to be passed to the Plotly method set in `method` on slide</param>
    /// <param name="Execute">
    /// When true, the API method is executed. When false, all other behaviors are the same and command execution is skipped.
    /// This may be useful when hooking into, for example, the `plotly_sliderchange` method and executing the API command manually
    /// without losing the benefit of the slider automatically binding to the state of the plot through the specification of `method` and `args`.
    /// </param>
    /// <param name="Label">Sets the text label to appear on the slider</param>
    /// <param name="Method">
    /// Sets the Plotly method to be called when the slider value is changed.
    /// If the `skip` method is used, the API slider will function as normal but
    /// will perform no API calls and will not bind automatically to state updates.
    /// This may be used to create a component interface and attach to slider events manually via JavaScript
    /// </param>
    /// <param name="Name">
    /// When used in a template, named items are created in the output figure in addition to any items the figure already has in this array.
    /// You can modify these items in the output figure by making your own item with `templateitemname` matching this
    /// `name` alongside your modifications (including `visible: false` or `enabled: false` to hide it).
    /// Has no effect outside of a template
    /// </param>
    /// <param name="TemplateItemName">
    /// Used to refer to a named item in this array in the template.
    /// Named items from the template will be created even without a matching item in the input figure,
    /// but you can modify one by making an item with `templateitemname` matching its `name`, alongside your modifications
    /// (including `visible: false` or `enabled: false` to hide it). If there is no template or no matching item,
    /// this item will be hidden unless you explicitly show it with `visible: true`
    /// </param>
    /// <param name="Value">Sets the value of the slider step, used to refer to the step programatically. Defaults to the slider label if not provided</param>
    /// <param name="Visible">Determines whether or not this step is included in the slider</param>
    static member init
        (
            ?Args : seq<(string * obj)>,
            ?Execute : bool,
            ?Label : string,
            ?Method : StyleParam.Method,
            ?Name : string,
            ?TemplateItemName : string,
            ?Value : string,
            ?Visible : bool            
        ) =
            SliderStep() |> SliderStep.style
                (
                    ?Args=Args,
                    ?Execute=Execute,
                    ?Label=Label,
                    ?Method=Method,
                    ?Name=Name,
                    ?TemplateItemName=TemplateItemName,
                    ?Value=Value,
                    ?Visible=Visible
                )

    static member style
        (
            ?Args : seq<(string * obj)>,
            ?Execute : bool,
            ?Label : string,
            ?Method : StyleParam.Method,
            ?Name : string,
            ?TemplateItemName : string,
            ?Value : string,
            ?Visible : bool    
        ) =
            (fun (step : SliderStep) ->
                // A bit strange, that we create a dictionary for an every
                // object, but this is that way the Plotly works
                let argsAsDictionaries =
                    Args
                    |> Option.map (fun args ->
                        args
                        |> Seq.map (fun arg -> [arg] |> dict)
                    )
                argsAsDictionaries |> DynObj.setValueOpt   step "args"
                Execute            |> DynObj.setValueOpt   step "execute"
                Label              |> DynObj.setValueOpt   step "label"
                Method             |> DynObj.setValueOptBy step "method" StyleParam.Method.convert
                Name               |> DynObj.setValueOpt   step "name"
                TemplateItemName   |> DynObj.setValueOpt   step "templateitemname"
                Value              |> DynObj.setValueOpt   step "value"
                Visible            |> DynObj.setValueOpt   step "visible"
                step
            )