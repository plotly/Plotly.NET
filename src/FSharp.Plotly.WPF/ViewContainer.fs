namespace FSharp.Plotly.WPF

module ViewContainer =

//#if INTERACTIVE
//#r "PresentationCore.dll"
//#r "PresentationFramework.dll"
//#r "WindowsBase.dll"
//#r "UIAutomationTypes.dll"
//#r "System.Xaml.dll"
//#r ""
//#endif

    open System
    open System.Windows
    open System.Windows.Threading
    open System.Threading

//open System.Windows.Media.Imaging

///// Creates the bitmap frame used to set the chart's window icon.
//let private bitmapFrame =
//    let uriString = @"pack://application:,,,/FsPlot;component/ChartIcon.ico"
//    let iconUri = Uri(uriString, UriKind.RelativeOrAbsolute)
//    BitmapFrame.Create(iconUri)
//
///// Displays a window containing a browser control.
//let show html =
//    let wnd = Window(Height = 500., Topmost = true, Width = 700.)
//    wnd.Icon <- bitmapFrame
//    wnd.WindowStartupLocation <- WindowStartupLocation.CenterScreen 
//    let browser = new WebBrowser()
//    wnd.Content <- browser
//    wnd.Show()
//    wnd.Topmost <- false
//    wnd, browser


    /// Lazy initalization of the UI thread and application
    let initUI =
        let mk() =
            let wh = new ManualResetEvent(false)
            let application = ref null
            let start() =
                let app = new Application()
                application := app
                ignore(wh.Set())
                app.Run() |> ignore
            let thread = Thread start
            thread.IsBackground <- true
            thread.SetApartmentState ApartmentState.STA
            thread.Start()
            ignore(wh.WaitOne())
            !application, thread
        lazy mk()

    let spawn : ('a -> 'b) -> 'a -> 'b =
        fun f x ->
            let app, thread = initUI.Force()
            let f _ =
                try
                    let f_x = f x
                    fun () -> f_x
                with e ->
                    fun () -> raise e 
            let t = app.Dispatcher.Invoke(DispatcherPriority.Send, System.Func<_,_>(f), null)
            (t :?> unit -> 'b)()


    /// Creates a windows with a given content
    let create_window height width content =
        let wnd = Window(Height = height, Topmost = true, Width = width)
        wnd.Content <- content 
        wnd.Show()
        wnd.Topmost <- false
        wnd

    let createBrowserContainerWith height width () =
        let suppressScriptErrors (wb:System.Windows.Controls.WebBrowser ,  hide:bool) =
            let fi = typeof<Controls.WebBrowser>.GetField("_axIWebBrowser2", Reflection.BindingFlags.Instance ||| Reflection.BindingFlags.NonPublic);
            if (fi <> null) then
                let browser = fi.GetValue(wb)
                if (browser <> null) then
                  browser.GetType().InvokeMember("Silent", Reflection.BindingFlags.SetProperty, null, browser, [|unbox hide|]) |> ignore
        
        
        let browser = new Controls.WebBrowser()        
        browser.Navigating.AddHandler(new System.Windows.Navigation.NavigatingCancelEventHandler((fun (sender:obj) (e:System.Windows.Navigation.NavigatingCancelEventArgs) -> let wb = sender :?> System.Windows.Controls.WebBrowser
                                                                                                                                                                              suppressScriptErrors(wb,true))))        
        let wnd = spawn create_window height width browser
        wnd,browser
    



    

    let createContainerWithBrowser () =
        createBrowserContainerWith 750. 900. ()


    let showHTMLWith height width (html:string) =
        let wnd,browser = createBrowserContainerWith height width ()
        browser.NavigateToString (html)


    let showHTML (html:string) =
        let wnd,browser = createContainerWithBrowser()
        browser.NavigateToString (html)


