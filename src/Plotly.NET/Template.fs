namespace Plotly.NET

/// Margin 
type Template() = 
    inherit DynamicObj ()

    /// Init Margin type
    static member init
        (
            layoutTemplate: Layout   ,
            ?TraceTemplates: Trace []  
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
            ?TraceTemplates: Trace []  
        ) =
            (fun (template:Template) -> 
                layoutTemplate   |> DynObj.setValue template "layout"
                TraceTemplates   |> DynObj.setValueOpt template "data"
                
                template
                )
            
    /// Applies the styles to Margin()
    static member mapLayoutTemplate (styleF: Layout -> Layout) (template:Template) =
        template.TryGetTypedValue<Layout>("layout")
        |> Option.map (styleF)
        |> DynObj.setValueOpt template "layout"
        template

    /// Applies the styles to Margin()
    static member mapTraceTemplates (styleF: Trace [] -> Trace []) (template:Template) =
        template.TryGetTypedValue<Trace []>("data")
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

        let defaultFont = Font.init (Size = 40)

        let defaultLayout = 
            Layout.init (
                Paper_bgcolor = "white",
                Plot_bgcolor= "white",
                Font = defaultFont
            )


        Template.init(defaultLayout, TraceTemplates = [||])

    let dark = 

        let initDarkAxisTemplate() =
            Axis.LinearAxis.init(
                Linecolor = "rgb(204, 204, 204)", 
                Zerolinecolor = "rgb(204, 204, 204)",
                Gridcolor = "rgba(204, 204, 204, 0.3)",
                Tickcolor = "rgba(204, 204, 204, 0.5)",
                Showline= true,
                Zeroline=true
            )

        let darkLayoutTemplate =
            Layout.init(
                Paper_bgcolor = "rgb(55, 55, 61)",
                Plot_bgcolor= "rgb(55, 55, 61)",
                Font = Font.init(Color = "rgb(204, 204, 204)")
            )
            |> Layout.AddLinearAxis((StyleParam.AxisId.X 1),(initDarkAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.AxisId.Y 1),(initDarkAxisTemplate()))

        Template.init(darkLayoutTemplate)

    let darkMirrored =
        dark
        |> Template.mapLayoutTemplate (fun l ->
            l.TryGetTypedValue<Axis.LinearAxis>("xaxis")
            |> Option.map (Axis.LinearAxis.style (Mirror=StyleParam.Mirror.AllTicks))
            |> DynObj.setValueOpt l "xaxis"

            l.TryGetTypedValue<Axis.LinearAxis>("yaxis")
            |> Option.map (Axis.LinearAxis.style (Mirror=StyleParam.Mirror.AllTicks))
            |> DynObj.setValueOpt l "yaxis"

            l
        )

    let fslab = 

        let initFslabAxisTemplate() =
            Axis.LinearAxis.init(
                Linecolor = "#438AFE", 
                Zerolinecolor = "rgba(67, 138, 254, 0.5)",
                Gridcolor = "rgba(67, 138, 254, 0.5)",
                Tickcolor = "rgba(67, 138, 254, 0.5)",
                Showline= true,
                Zeroline=true
            )

        let fslabLayoutTemplate =
            Layout.init(
                Paper_bgcolor = "#2D3E50",
                Plot_bgcolor= "#2D3E50",
                Font = Font.init(Color = "#438AFE")
            )
            |> Layout.AddLinearAxis((StyleParam.AxisId.X 1),(initFslabAxisTemplate()))
            |> Layout.AddLinearAxis((StyleParam.AxisId.Y 1),(initFslabAxisTemplate()))

        Template.init(fslabLayoutTemplate)
        |> Template.withColorWay ColorWays.fslab