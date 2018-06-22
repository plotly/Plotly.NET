namespace FSharp.Plotly.WPF


[<AutoOpen>]
module ChartWPF =


    open System
    open System.IO

    open FSharp.Plotly
    open GenericChart



    type Chart with  


        static member ShowWPF (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedHTML ch
            ViewContainer.showHTML html

        /// Save chart as image
        static member SaveImageAs (format:StyleParam.ImageFormat)  pathName (ch:GenericChart,?Verbose) =                                     
            let html = GenericChart.toEmbeddedImage format ch
            let wnd,browser = ViewContainer.createContainerWithBrowser()
            browser.NavigateToString (html)
            let web = new HtmlAgilityPack.HtmlDocument()            
            web.LoadHtml(browser.Document.ToString())
            let url = web.GetElementbyId("jpg-export")//.GetAttributeValue("src")
            url.Attributes
            //let wc = new  System.Net.WebClient()
            //wc.DownloadFile()