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

    static member withColorWay (colorway:Color) (template:Template) =
        template
        |> Template.mapLayoutTemplate (fun l ->
            colorway |> DynObj.setValue l "colorway"
            l
        )

module ChartTemplates =
    
    /// A colorway is an array of colors that contains the default colors for traces
    module ColorWays = 
        
        let plotly = Color.fromColors[|
            Color.fromHex "#636efa"
            Color.fromHex "#EF553B" 
            Color.fromHex "#00cc96"
            Color.fromHex "#ab63fa"
            Color.fromHex "#FFA15A"
            Color.fromHex "#19d3f3"
            Color.fromHex "#FF6692"
            Color.fromHex "#B6E880"
            Color.fromHex "#FF97FF"
            Color.fromHex "#FECB52"
        |]

        let fslab = Color.fromColors[|
            Color.fromHex "#A00975" // darkmagenta
            Color.fromHex "#D12F67" // rose
            Color.fromHex "#44d57f" // green
            Color.fromHex "#438AFE" // aquamarine
            Color.fromHex "#d59a1b" // dark yellow
            Color.fromHex "#F99BDE" // lightmagenta
            Color.fromHex "#ff9b9b" // light rose
            Color.fromHex "#c6ffdd" // light green
            Color.fromHex "#00d4ff" // light aquamarine
            Color.fromHex "#d2c572" // yellow
        |]

    let light = 
        let initLightAxisTemplate() =
            LinearAxis.init(
                ShowLine =      true,
                ZeroLine =      true
            )

        let defaultLayout = 
            Layout.init (
                PaperBGColor = Color.fromString "white",
                PlotBGColor =  Color.fromString "white"
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
                PaperBGColor = Color.fromString "white",
                PlotBGColor =  Color.fromString "white"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initLightAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initLightAxisTemplate()))

        Template.init(defaultLayout)

    let dark = 

        let initDarkAxisTemplate() =
            LinearAxis.init(
                LineColor = Color.fromString "rgb(204, 204, 204)", 
                ZeroLineColor = Color.fromString "rgb(204, 204, 204)",
                GridColor = Color.fromString "rgba(204, 204, 204, 0.3)",
                TickColor = Color.fromString"rgba(204, 204, 204, 0.5)",
                Ticks     = StyleParam.TickOptions.Inside,
                ShowLine  = true,
                ZeroLine  = true
            )

        let darkLayoutTemplate =
            Layout.init(
                PaperBGColor = Color.fromString "rgb(55, 55, 61)",
                PlotBGColor= Color.fromString "rgb(55, 55, 61)",
                Font = Font.init(Color = Color.fromString "rgb(204, 204, 204)")
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
                LineColor = Color.fromString "white", 
                ZeroLineColor = Color.fromString"rgba(67, 138, 254, 0.5)",
                GridColor = Color.fromString "rgba(67, 138, 254, 0.5)",
                TickColor = Color.fromString "rgba(67, 138, 254, 0.5)",
                Ticks     = StyleParam.TickOptions.Inside,
                ShowLine  = true,
                ZeroLine  = true
            )

        let fslabLayoutTemplate =
            Layout.init(
                PaperBGColor = Color.fromString "#200117",
                PlotBGColor  = Color.fromString "#200117",
                Font = Font.init(Color = Color.fromString "white")
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
                PaperBGColor = Color.fromString "rgba(255, 255, 255, 0)",
                PlotBGColor =  Color.fromString "rgba(255, 255, 255, 0)"
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
                PaperBGColor = Color.fromString "rgba(255, 255, 255, 0)",
                PlotBGColor =  Color.fromString "rgba(255, 255, 255, 0)"
            )
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.XAxis 1),(initTransparentAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.SubPlotId.YAxis 1),(initTransparentAxisTemplate()))

        Template.init(defaultLayout)