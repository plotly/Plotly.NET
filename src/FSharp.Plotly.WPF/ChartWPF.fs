namespace FSharp.Plotly.WPF


[<AutoOpen>]
module ChartWPF =


    open System
    open System.IO

    open FSharp.Plotly
    open StyleGramar
    open ChartArea
    open GenericChart



    type Chart with  


        static member ShowWPF (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toHTML ch
            ViewContainer.showHTML html

