namespace Plotly.NET

open Plotly.NET.LayoutObjects

open DynamicObj
open DynamicObj.Operators
open System.Runtime.InteropServices


type Template() =
    inherit ImmutableDynamicObj()

    static member init(layoutTemplate: Layout, [<Optional; DefaultParameterValue(null)>] ?TraceTemplates: seq<#Trace>) =
        Template() |> Template.style (layoutTemplate, ?TraceTemplates = TraceTemplates)

    static member style
        (
            layoutTemplate: Layout,
            [<Optional; DefaultParameterValue(null)>] ?TraceTemplates: seq<#Trace>
        ) =
        (fun (template: Template) ->
            let traceTemplates =
                TraceTemplates
                |> Option.map
                    (fun traceTemplates ->
                        traceTemplates
                        |> Seq.groupBy (fun t -> t.``type``)
                        |> (fun groupedTemplates ->
                            groupedTemplates
                            |> Seq.map
                                (fun (id, templates) ->
                                    id,
                                    templates
                                    |> Seq.map
                                        (fun t ->
                                            let tmp = ImmutableDynamicObj()
                                            tmp)

                                    )))
                |> fun traceTemplates ->
                    let mutable tmp = ImmutableDynamicObj()

                    match traceTemplates with
                    | Some templates ->
                        for (id, traceTemplate) in templates do
                            tmp <- tmp ++ (id, traceTemplate)
                    | None -> ()

                    tmp

            template


            ++ ("layout", layoutTemplate )
            ++ ("data", traceTemplates ))

    static member mapLayoutTemplate (styleF: Layout -> Layout) (template: Template) =
        template
        ++? ("layout", template.TryGetTypedValue<Layout>("layout") |> Option.map (styleF) )

    static member mapTraceTemplates (styleF: #Trace [] -> #Trace []) (template: Template) =
        template
        ++? ("data", template.TryGetTypedValue<#Trace []>("data") |> Option.map (styleF) )

    static member withColorWay (colorway: Color) (template: Template) =
        template
        |> Template.mapLayoutTemplate
            (fun l ->
                l
                ++ ("colorway", colorway ))
