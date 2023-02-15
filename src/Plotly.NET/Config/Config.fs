namespace Plotly.NET

open Plotly.NET.ConfigObjects
open DynamicObj
open System.Runtime.InteropServices

//missing:

//var configAttributes = {
//    plotlyServerURL: {
//        valType: 'string',
//        dflt: '',
//        description: [
//            'When set it determines base URL for',
//            'the \'Edit in Chart Studio\' `showEditInChartStudio`/`showSendToCloud` mode bar button',
//            'and the showLink/sendData on-graph link.',
//            'To enable sending your data to Chart Studio Cloud, you need to',
//            'set both `plotlyServerURL` to \'https://chart-studio.plotly.com\' and',
//            'also set `showSendToCloud` to true.'
//        ].join(' ')
//    },
//    fillFrame: {
//        valType: 'boolean',
//        dflt: false,
//        description: [
//            'When `layout.autosize` is turned on, determines whether the graph',
//            'fills the container (the default) or the screen (if set to *true*).'
//        ].join(' ')
//    },
//    frameMargins: {
//        valType: 'number',
//        dflt: 0,
//        min: 0,
//        max: 0.5,
//        description: [
//            'When `layout.autosize` is turned on, set the frame margins',
//            'in fraction of the graph size.'
//        ].join(' ')
//    },

//    scrollZoom: {
//        valType: 'flaglist',
//        flags: ['cartesian', 'gl3d', 'geo', 'mapbox'],
//        extras: [true, false],
//        dflt: 'gl3d+geo+mapbox',
//        description: [
//            'Determines whether mouse wheel or two-finger scroll zooms is enable.',
//            'Turned on by default for gl3d, geo and mapbox subplots',
//            '(as these subplot types do not have zoombox via pan),',
//            'but turned off by default for cartesian subplots.',
//            'Set `scrollZoom` to *false* to disable scrolling for all subplots.'
//        ].join(' ')
//    },
//    doubleClick: {
//        valType: 'enumerated',
//        values: [false, 'reset', 'autosize', 'reset+autosize'],
//        dflt: 'reset+autosize',
//        description: [
//            'Sets the double click interaction mode.',
//            'Has an effect only in cartesian plots.',
//            'If *false*, double click is disable.',
//            'If *reset*, double click resets the axis ranges to their initial values.',
//            'If *autosize*, double click set the axis ranges to their autorange values.',
//            'If *reset+autosize*, the odd double clicks resets the axis ranges',
//            'to their initial values and even double clicks set the axis ranges',
//            'to their autorange values.'
//        ].join(' ')
//    },
//    doubleClickDelay: {
//        valType: 'number',
//        dflt: 300,
//        min: 0,
//        description: [
//            'Sets the delay for registering a double-click in ms.',
//            'This is the time interval (in ms) between first mousedown and',
//            '2nd mouseup to constitute a double-click.',
//            'This setting propagates to all on-subplot double clicks',
//            '(except for geo and mapbox) and on-legend double clicks.'
//        ].join(' ')
//    },

//    showAxisDragHandles: {
//        valType: 'boolean',
//        dflt: true,
//        description: [
//            'Set to *false* to omit cartesian axis pan/zoom drag handles.'
//        ].join(' ')
//    },
//    showAxisRangeEntryBoxes: {
//        valType: 'boolean',
//        dflt: true,
//        description: [
//            'Set to *false* to omit direct range entry at the pan/zoom drag points,',
//            'note that `showAxisDragHandles` must be enabled to have an effect.'
//        ].join(' ')
//    },

//    showTips: {
//        valType: 'boolean',
//        dflt: true,
//        description: [
//            'Determines whether or not tips are shown while interacting',
//            'with the resulting graphs.'
//        ].join(' ')
//    },

//    showLink: {
//        valType: 'boolean',
//        dflt: false,
//        description: [
//            'Determines whether a link to Chart Studio Cloud is displayed',
//            'at the bottom right corner of resulting graphs.',
//            'Use with `sendData` and `linkText`.'
//        ].join(' ')
//    },
//    linkText: {
//        valType: 'string',
//        dflt: 'Edit chart',
//        noBlank: true,
//        description: [
//            'Sets the text appearing in the `showLink` link.'
//        ].join(' ')
//    },
//    sendData: {
//        valType: 'boolean',
//        dflt: true,
//        description: [
//            'If *showLink* is true, does it contain data',
//            'just link to a Chart Studio Cloud file?'
//        ].join(' ')
//    },
//    showSources: {
//        valType: 'any',
//        dflt: false,
//        description: [
//            'Adds a source-displaying function to show sources on',
//            'the resulting graphs.'
//        ].join(' ')
//    },

//    displayModeBar: {
//        valType: 'enumerated',
//        values: ['hover', true, false],
//        dflt: 'hover',
//        description: [
//            'Determines the mode bar display mode.',
//            'If *true*, the mode bar is always visible.',
//            'If *false*, the mode bar is always hidden.',
//            'If *hover*, the mode bar is visible while the mouse cursor',
//            'is on the graph container.'
//        ].join(' ')
//    },
//    showSendToCloud: {
//        valType: 'boolean',
//        dflt: false,
//        description: [
//            'Should we include a ModeBar button, labeled "Edit in Chart Studio",',
//            'that sends this chart to chart-studio.plotly.com (formerly plot.ly) or another plotly server',
//            'as specified by `plotlyServerURL` for editing, export, etc? Prior to version 1.43.0',
//            'this button was included by default, now it is opt-in using this flag.',
//            'Note that this button can (depending on `plotlyServerURL` being set) send your data',
//            'to an external server. However that server does not persist your data',
//            'until you arrive at the Chart Studio and explicitly click "Save".'
//        ].join(' ')
//    },
//    showEditInChartStudio: {
//        valType: 'boolean',
//        dflt: false,
//        description: [
//            'Same as `showSendToCloud`, but use a pencil icon instead of a floppy-disk.',
//            'Note that if both `showSendToCloud` and `showEditInChartStudio` are turned,',
//            'only `showEditInChartStudio` will be honored.'
//        ].join(' ')
//    },
//    modeBarButtonsToRemove: {
//        valType: 'any',
//        dflt: [],
//        description: [
//            'Remove mode bar buttons by name.',
//            'See ./components/modebar/buttons.js for the list of names.'
//        ].join(' ')
//    },
//    modeBarButtons: {
//        valType: 'any',
//        dflt: false,
//        description: [
//            'Define fully custom mode bar buttons as nested array,',
//            'where the outer arrays represents button groups, and',
//            'the inner arrays have buttons config objects or names of default buttons',
//            'See ./components/modebar/buttons.js for more info.'
//        ].join(' ')
//    },
//    displaylogo: {
//        valType: 'boolean',
//        dflt: true,
//        description: [
//            'Determines whether or not the plotly logo is displayed',
//            'on the end of the mode bar.'
//        ].join(' ')
//    },
//    watermark: {
//        valType: 'boolean',
//        dflt: false,
//        description: 'watermark the images with the company\'s logo'
//    },

//    plotGlPixelRatio: {
//        valType: 'number',
//        dflt: 2,
//        min: 1,
//        max: 4,
//        description: [
//            'Set the pixel ratio during WebGL image export.',
//            'This config option was formerly named `plot3dPixelRatio`',
//            'which is now deprecated.'
//        ].join(' ')
//    },

//    setBackground: {
//        valType: 'any',
//        dflt: 'transparent',
//        description: [
//            'Set function to add the background color (i.e. `layout.paper_color`)',
//            'to a different container.',
//            'This function take the graph div as first argument and the current background',
//            'color as second argument.',
//            'Alternatively, set to string *opaque* to ensure there is white behind it.'
//        ].join(' ')
//    },

//    topojsonURL: {
//        valType: 'string',
//        noBlank: true,
//        dflt: 'https://cdn.plot.ly/',
//        description: [
//            'Set the URL to topojson used in geo charts.',
//            'By default, the topojson files are fetched from cdn.plot.ly.',
//            'For example, set this option to:',
//            '<path-to-plotly.js>/dist/topojson/',
//            'to render geographical feature using the topojson files',
//            'that ship with the plotly.js module.'
//        ].join(' ')
//    },

//    mapboxAccessToken: {
//        valType: 'string',
//        dflt: null,
//        description: [
//            'Mapbox access token (required to plot mapbox trace types)',
//            'If using an Mapbox Atlas server, set this option to \'\'',
//            'so that plotly.js won\'t attempt to authenticate to the public Mapbox server.'
//        ].join(' ')
//    },

//    logging: {
//        valType: 'integer',
//        min: 0,
//        max: 2,
//        dflt: 1,
//        description: [
//            'Turn all console logging on or off (errors will be thrown)',
//            'This should ONLY be set via Plotly.setPlotConfig',
//            'Available levels:',
//            '0: no logs',
//            '1: warnings and errors, but not informational messages',
//            '2: verbose logs'
//        ].join(' ')
//    },

//    notifyOnLogging: {
//        valType: 'integer',
//        min: 0,
//        max: 2,
//        dflt: 0,
//        description: [
//            'Set on-graph logging (notifier) level',
//            'This should ONLY be set via Plotly.setPlotConfig',
//            'Available levels:',
//            '0: no on-graph logs',
//            '1: warnings and errors, but not informational messages',
//            '2: verbose logs'
//        ].join(' ')
//    },

//    queueLength: {
//        valType: 'integer',
//        min: 0,
//        dflt: 0,
//        description: 'Sets the length of the undo/redo queue.'
//    },

//    globalTransforms: {
//        valType: 'any',
//        dflt: [],
//        description: [
//            'Set global transform to be applied to all traces with no',
//            'specification needed'
//        ].join(' ')
//    },

//    locale: {
//        valType: 'string',
//        dflt: 'en-US',
//        description: [
//            'Which localization should we use?',
//            'Should be a string like \'en\' or \'en-US\'.'
//        ].join(' ')
//    },

//    locales: {
//        valType: 'any',
//        dflt: {},
//        description: [
//            'Localization definitions',
//            'Locales can be provided either here (specific to one chart) or globally',
//            'by registering them as modules.',
//            'Should be an object of objects {locale: {dictionary: {...}, format: {...}}}',
//            '{',
//            '  da: {',
//            '      dictionary: {\'Reset axes\': \'Nulstil aksler\', ...},',
//            '      format: {months: [...], shortMonths: [...]}',
//            '  },',
//            '  ...',
//            '}',
//            'All parts are optional. When looking for translation or format fields, we',
//            'look first for an exact match in a config locale, then in a registered',
//            'module. If those fail, we strip off any regionalization (\'en-US\' -> \'en\')',
//            'and try each (config, registry) again. The final fallback for translation',
//            'is untranslated (which is US English) and for formats is the base English',
//            '(the only consequence being the last fallback date format %x is DD/MM/YYYY',
//            'instead of MM/DD/YYYY). Currently `grouping` and `currency` are ignored',
//            'for our automatic number formatting, but can be used in custom formats.'
//        ].join(' ')
//    }
//};

/// The Config object gets passed to the plotly renderer and contains render-specific options.
type Config() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Config Object with the given styling.
    /// </summary>
    /// <param name="StaticPlot">Determines whether the plot is interactive or not. (default: false)</param>
    /// <param name="PlotlyServerUrl">When set it determines base URL for the 'Edit in Chart Studio'/`showEditInChartStudio`/`showSendToCloud` mode bar button', and the showLink/sendData on-graph link. To enable sending your data to Chart Studio Cloud, you need to' set both `plotlyServerURL` to \'https://chart-studio.plotly.com\' and also set `showSendToCloud` to true.</param>
    /// <param name="Editable">Determines whether the graph is editable or not. Sets all pieces of `edits` unless a separate `edits` config item overrides individual parts.</param>
    /// <param name="Edits">Object holding individual editable pieces of the graph.</param>
    /// <param name="EditSelection">Enables moving selections.</param>
    /// <param name="Autosizable">Determines whether the graphs are plotted with respect to layout.autosize:true and infer its container size. (default: false)</param>
    /// <param name="Responsive">Determines whether to change the layout size when window is resized.</param>
    /// <param name="ShowSendToCloud">Should we include a ModeBar button, labeled "Edit in Chart Studio",that sends this chart to chart-studio.plotly.com (formerly plot.ly) or another plotly server as specified by `plotlyServerURL` for editing, export, etc? Note that this button can (depending on `plotlyServerURL` being set) send your data to an external server. However that server does not persist your data until you arrive at the Chart Studio and explicitly click "Save".</param>
    /// <param name="ShowEditInChartStudio">Same as `showSendToCloud`, but use a pencil icon instead of a floppy-disk. Note that if both `showSendToCloud` and `showEditInChartStudio` are turned,  only `showEditInChartStudio` will be honored.</param>
    /// <param name="ToImageButtonOptions">Statically override options for toImage modebar button</param>
    /// <param name="ModeBarButtonsToAdd">ModeBar buttons to add to the graph.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?StaticPlot: bool,
            [<Optional; DefaultParameterValue(null)>] ?TypesetMath: bool,
            [<Optional; DefaultParameterValue(null)>] ?PlotlyServerUrl: string,
            [<Optional; DefaultParameterValue(null)>] ?Autosizable: bool,
            [<Optional; DefaultParameterValue(null)>] ?Editable: bool,
            [<Optional; DefaultParameterValue(null)>] ?Edits: Edits,
            [<Optional; DefaultParameterValue(null)>] ?EditSelection: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowSendToCloud: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowEditInChartStudio: bool,
            [<Optional; DefaultParameterValue(null)>] ?Responsive: bool,
            [<Optional; DefaultParameterValue(null)>] ?ToImageButtonOptions: ToImageButtonOptions,
            [<Optional; DefaultParameterValue(null)>] ?ModeBarButtonsToAdd: seq<StyleParam.ModeBarButton>
        ) =
        Config()
        |> Config.style (
            ?StaticPlot = StaticPlot,
            ?TypesetMath = TypesetMath,
            ?PlotlyServerUrl = PlotlyServerUrl,
            ?Autosizable = Autosizable,
            ?Responsive = Responsive,
            ?ToImageButtonOptions = ToImageButtonOptions,
            ?ShowSendToCloud = ShowSendToCloud,
            ?ShowEditInChartStudio = ShowEditInChartStudio,
            ?Editable = Editable,
            ?Edits = Edits,
            ?EditSelection = EditSelection,
            ?ModeBarButtonsToAdd = ModeBarButtonsToAdd
        )


    /// <summary>
    /// Returns a function that applies the given styles to a Config object.
    /// </summary>
    /// <param name="StaticPlot">Determines whether the plot is interactive or not. (default: false)</param>
    /// <param name="PlotlyServerUrl">When set it determines base URL for the 'Edit in Chart Studio'/`showEditInChartStudio`/`showSendToCloud` mode bar button', and the showLink/sendData on-graph link. To enable sending your data to Chart Studio Cloud, you need to' set both `plotlyServerURL` to \'https://chart-studio.plotly.com\' and also set `showSendToCloud` to true.</param>
    /// <param name="Editable">Determines whether the graph is editable or not. Sets all pieces of `edits` unless a separate `edits` config item overrides individual parts.</param>
    /// <param name="Edits">Object holding individual editable pieces of the graph.</param>
    /// <param name="EditSelection">Enables moving selections.</param>
    /// <param name="Autosizable">Determines whether the graphs are plotted with respect to layout.autosize:true and infer its container size. (default: false)</param>
    /// <param name="Responsive">Determines whether to change the layout size when window is resized.</param>
    /// <param name="ShowSendToCloud">Should we include a ModeBar button, labeled "Edit in Chart Studio",that sends this chart to chart-studio.plotly.com (formerly plot.ly) or another plotly server as specified by `plotlyServerURL` for editing, export, etc? Note that this button can (depending on `plotlyServerURL` being set) send your data to an external server. However that server does not persist your data until you arrive at the Chart Studio and explicitly click "Save".</param>
    /// <param name="ShowEditInChartStudio">Same as `showSendToCloud`, but use a pencil icon instead of a floppy-disk. Note that if both `showSendToCloud` and `showEditInChartStudio` are turned,  only `showEditInChartStudio` will be honored.</param>
    /// <param name="ToImageButtonOptions">Statically override options for toImage modebar button</param>
    /// <param name="ModeBarButtonsToAdd">ModeBar buttons to add to the graph.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?StaticPlot: bool,
            [<Optional; DefaultParameterValue(null)>] ?TypesetMath: bool,
            [<Optional; DefaultParameterValue(null)>] ?PlotlyServerUrl: string,
            [<Optional; DefaultParameterValue(null)>] ?Autosizable: bool,
            [<Optional; DefaultParameterValue(null)>] ?Editable: bool,
            [<Optional; DefaultParameterValue(null)>] ?Edits: Edits,
            [<Optional; DefaultParameterValue(null)>] ?EditSelection: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowSendToCloud: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowEditInChartStudio: bool,
            [<Optional; DefaultParameterValue(null)>] ?Responsive: bool,
            [<Optional; DefaultParameterValue(null)>] ?ToImageButtonOptions: ToImageButtonOptions,
            [<Optional; DefaultParameterValue(null)>] ?ModeBarButtonsToAdd: seq<StyleParam.ModeBarButton>
        ) =
        fun (config: Config) ->
            StaticPlot |> DynObj.setValueOpt config "staticPlot"
            TypesetMath |> DynObj.setValueOpt config "typesetMath"
            PlotlyServerUrl |> DynObj.setValueOpt config "plotlyServerURL"
            Autosizable |> DynObj.setValueOpt config "autosizable"
            Editable |> DynObj.setValueOpt config "editable"
            Edits |> DynObj.setValueOpt config "edits"
            EditSelection |> DynObj.setValueOpt config "editSelection"
            ShowSendToCloud |> DynObj.setValueOpt config "showSendToCloud"
            ShowEditInChartStudio |> DynObj.setValueOpt config "showEditInChartStudio"
            Responsive |> DynObj.setValueOpt config "responsive"
            ToImageButtonOptions |> DynObj.setValueOpt config "toImageButtonOptions"

            ModeBarButtonsToAdd
            |> DynObj.setValueOptBy config "modeBarButtonsToAdd" (fun x ->
                x |> Seq.map StyleParam.ModeBarButton.toString)

            config

    /// <summary>
    /// Combines two Config objects.
    ///
    /// In case of duplicate dynamic member values, the values of the second Config are used.
    ///
    /// For the collections used for the dynamic members
    ///
    /// modeBarButtonsToAdd
    ///
    /// the values from the second Config are appended to those of the first instead.
    /// </summary>
    /// <param name="first">The first Config to combine with the second</param>
    /// <param name="second">The second Config to combine with the first</param>
    static member combine (first: Config) (second: Config) =

        let modeBarButtonsToAdd =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedValue<seq<string>>("modeBarButtonsToAdd"))
                (second.TryGetTypedValue<seq<string>>("modeBarButtonsToAdd"))

        DynObj.combine first second
        |> unbox
        |> Config.style (
            ?ModeBarButtonsToAdd = (modeBarButtonsToAdd |> Option.map (Seq.map StyleParam.ModeBarButton.ofString))
        )