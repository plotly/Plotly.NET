namespace Plotly.NET

open Plotly.NET.LayoutObjects

open DynamicObj
open System.Runtime.InteropServices


type Template() = 
    inherit DynamicObj ()

    static member init
        (
            layoutTemplate: Layout   ,
            [<Optional;DefaultParameterValue(null)>] ?TraceTemplates: #Trace []  
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
            [<Optional;DefaultParameterValue(null)>] ?TraceTemplates: #Trace []  
        ) =
            (fun (template:Template) -> 
                layoutTemplate   |> DynObj.setValue template "layout"
                TraceTemplates   |> DynObj.setValueOpt template "data"
                
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

    static member withColorWay (colorway:string []) (template:Template) =
        template
        |> Template.mapLayoutTemplate (fun l ->
            colorway |> DynObj.setValue l "colorway"
            l
        )

module ChartTemplates =
    
    /// A colorway is an array of colors that contains the default colors for traces
    module ColorWays = 
        
        let plotly = [|
            "#636efa"
            "#EF553B" 
            "#00cc96"
            "#ab63fa"
            "#FFA15A"
            "#19d3f3"
            "#FF6692"
            "#B6E880"
            "#FF97FF"
            "#FECB52"
        |]

        let fslab = [|
            "#A00975" // darkmagenta
            "#D12F67" // rose
            "#44d57f" // green
            "#438AFE" // aquamarine
            "#d59a1b" // dark yellow
            "#F99BDE" // lightmagenta
            "#ff9b9b" // light rose
            "#c6ffdd" // light green
            "#00d4ff" // light aquamarine
            "#d2c572" // yellow
        |]

    let light = 
        let initLightAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = "white",
                PlotBGColor =  "white"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initLightAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initLightAxisTemplate()))

        Template.init(defaultLayout)

    let lightMirrored = 
        let initLightAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true,
                Mirror   =      StyleParam.Mirror.All,
                Ticks    =      StyleParam.TickOptions.Inside
                //Showgrid =      false
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = "white",
                PlotBGColor =  "white"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initLightAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initLightAxisTemplate()))

        Template.init(defaultLayout)

    let dark = 

        let initDarkAxisTemplate() =
            LinearAxis.init(
                LineColor = "rgb(204, 204, 204)", 
                ZeroLineColor = "rgb(204, 204, 204)",
                GridColor = "rgba(204, 204, 204, 0.3)",
                TickColor = "rgba(204, 204, 204, 0.5)",
                Ticks     = StyleParam.TickOptions.Inside,
                ShowLine  = true,
                ZeroLine  = true
            )

        let darkLayoutTemplate =
            Layout.init(
                PaperBGColor = "rgb(55, 55, 61)",
                PlotBGColor= "rgb(55, 55, 61)",
                Font = Font.init(Color = "rgb(204, 204, 204)")
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initDarkAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initDarkAxisTemplate()))

        Template.init(darkLayoutTemplate)

    let darkMirrored =
        dark
        |> Template.mapLayoutTemplate (fun l ->
            l.TryGetTypedValue<LinearAxis>("xaxis")
            |> Option.map (LinearAxis.style (Mirror=StyleParam.Mirror.AllTicks))
            |> DynObj.setValueOpt l "xaxis"

            l.TryGetTypedValue<LinearAxis>("yaxis")
            |> Option.map (LinearAxis.style (Mirror=StyleParam.Mirror.AllTicks))
            |> DynObj.setValueOpt l "yaxis"

            l
        )

    let fslab = 

        let initFslabAxisTemplate() =
            LinearAxis.init(
                LineColor = "white", 
                ZeroLineColor = "rgba(67, 138, 254, 0.5)",
                GridColor = "rgba(67, 138, 254, 0.5)",
                TickColor = "rgba(67, 138, 254, 0.5)",
                Ticks     = StyleParam.TickOptions.Inside,
                ShowLine  = true,
                ZeroLine  = true
            )

        let fslabLayoutTemplate =
            Layout.init(
                PaperBGColor = "#200117",
                PlotBGColor= "#200117",
                Font = Font.init(Color = "white")
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initFslabAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initFslabAxisTemplate()))

        Template.init(fslabLayoutTemplate)
        |> Template.withColorWay ColorWays.fslab


    let transparent = 
        let initTransparentAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = "rgba(255, 255, 255, 0)",
                PlotBGColor =  "rgba(255, 255, 255, 0)"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initTransparentAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initTransparentAxisTemplate()))

        Template.init(defaultLayout)

    let transparentMirrored = 
        let initTransparentAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true,
                Mirror   =      StyleParam.Mirror.All,
                Ticks    =      StyleParam.TickOptions.Inside
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = "rgba(255, 255, 255, 0)",
                PlotBGColor =  "rgba(255, 255, 255, 0)"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initTransparentAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initTransparentAxisTemplate()))

        Template.init(defaultLayout)