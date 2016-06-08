namespace FSharp.Plotly

[<AutoOpen>]
module ChartExtensions =


    open System
    open System.IO

    open StyleGramar
    open ChartArea

    open GenericChart



    type Chart with   
        
        static member withMarker(marker:Marker) =
            (fun (ch:GenericChart) ->  
                ch 
                |> GenericChart.mapTrace (fun gc -> 
                                            gc.set_marker marker
                                            gc)
            )
               
        static member withMarkerStyle(?Size,?Color,?Symbol,?Opacity) = 
            let marker = 
                Marker()                
                |> Helpers.ApplyMarkerStyles(?size=Size,?color=Color,?symbol=Symbol,?opacity=Opacity)
            
            Chart.withMarker(marker)         
            
               
        static member withLine(line:Line) =
            (fun (ch:GenericChart) ->  
                ch 
                |> GenericChart.mapTrace (fun gc -> 
                                            gc.set_line line
                                            gc)
            )
               
        static member withLineStyle(?Width,?Color,?Shape,?Dash,?Smoothing,?ColorScale) =
            let line = 
                Line()                
                |> Helpers.ApplyLineStyles(?width=Width,?color=Color,?shape=Shape,?dash=Dash,?smoothing=Smoothing,?colorScale=ColorScale)
            
            Chart.withLine(line)  

        
        static member withX_AxisStyle(title) =
            (fun (ch:GenericChart) ->             
                let xaxis = 
                    Xaxis()                
                    |> Helpers.ApplyAxisStyles(title=title)
                let layout =
                    GenericChart.getLayout ch
                    |> Helpers.ApplyLayoutStyles(xaxis=xaxis)
                
                GenericChart.setLayout layout ch)   

        static member withY_AxisStyle(title) =
            (fun (ch:GenericChart) ->             
                let yaxis = 
                    Yaxis()                
                    |> Helpers.ApplyAxisStyles(title=title)
                let layout =
                    GenericChart.getLayout ch
                    |> Helpers.ApplyLayoutStyles(yaxis=yaxis)
                
                GenericChart.setLayout layout ch)               


        // -------------
        // with Layout
        static member withLayout(layout:Layout) =
            (fun (ch:GenericChart) -> 
                GenericChart.setLayout layout ch)         

        static member withSize(width,heigth) =            
            (fun (ch:GenericChart) -> 
                let layout =
                    GenericChart.getLayout ch
                    |> Helpers.ApplyLayoutStyles(width=width,height=heigth)
                
                GenericChart.setLayout layout ch)   


        static member withMarginSize(?left,?right,?top,?bottom,?pad,?autoexpand) =        
            (fun (ch:GenericChart) ->                 
                let margin = 
                    (GenericChart.getLayout ch)
                        .marginOption                    
                    |> GenericChart.optOrDefault (Margin())                    
                    |> Helpers.ApplyMarginStyles(?left=left,?right=right,?top=top,?bottom=bottom,?pad=pad,?autoexpand=autoexpand)
                let layout =
                    GenericChart.getLayout ch
                    |> Helpers.ApplyLayoutStyles(margin=margin)
                
                GenericChart.setLayout layout ch)   

                



        // with Layout
        static member withError(layout:Layout) =
            (fun (ch:GenericChart) -> 
                GenericChart.setLayout layout ch)   
            
        static member Show (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toHTML ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            System.Diagnostics.Process.Start(path) |> ignore

