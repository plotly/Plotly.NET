namespace Plotly.NET

open Plotly.NET.LayoutObjects

open DynamicObj
open System.Runtime.InteropServices


type Template() = 
    inherit DynamicObj ()

    static member init
        (
            layoutTemplate: Layout   ,
            [<Optional;DefaultParameterValue(null)>] ?TraceTemplates: seq<#Trace>
        ) =
            Template()
            |> Template.style
                (
                    layoutTemplate,
                    ?TraceTemplates = TraceTemplates
                )

    static member style
        (
            layoutTemplate: Layout   ,
            [<Optional;DefaultParameterValue(null)>] ?TraceTemplates: seq<#Trace>
        ) =
            (fun (template:Template) -> 

                let traceTemplates =
                    TraceTemplates
                    |> Option.map (fun traceTemplates ->
                        traceTemplates
                        |> Seq.groupBy (fun t -> t.``type``)
                        |> (fun groupedTemplates ->
                            groupedTemplates
                            |> Seq.map (fun (id, templates) ->
                                id,
                                templates 
                                |> Seq.map (fun t ->
                                    let tmp = DynamicObj()
                                    t.CopyDynamicPropertiesTo(tmp)
                                    tmp
                                )

                            )
                        )
                    )
                    |> fun traceTemplates ->
                        let tmp = DynamicObj()
                        traceTemplates 
                        |> Option.iter (Seq.iter (fun (id,traceTemplate) ->
                            traceTemplate  |> DynObj.setValue tmp id
                            )
                        )
                        tmp


                layoutTemplate   |> DynObj.setValue template "layout"
                traceTemplates   |> DynObj.setValue template "data"
                
                template
                )
            
    static member mapLayoutTemplate (styleF: Layout -> Layout) (template:Template) =
        template.TryGetTypedValue<Layout>("layout")
        |> Option.map (styleF)
        |> DynObj.setValueOpt template "layout"
        template

    static member mapTraceTemplates (styleF: #Trace [] -> #Trace []) (template:Template) =
        template.TryGetTypedValue<#Trace []>("data")
        |> Option.map (styleF)
        |> DynObj.setValueOpt template "data"
        template

    static member withColorWay (colorway:Color) (template:Template) =
        template
        |> Template.mapLayoutTemplate (fun l ->
            colorway |> DynObj.setValue l "colorway"
            l
        )