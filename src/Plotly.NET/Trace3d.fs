namespace Plotly.NET

open DynamicObj
open System

/// Trace type inherits from dynamic object
type Trace3d (traceTypeName) =
    inherit Trace (traceTypeName)


[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Trace3d = 
    //TO-DO: we need to think about if all subgroups of traces should be seperate, e.g. also "TraceFinance" or leave it at the current separation
    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //3D

    ///initializes a trace of type "scatter3d" applying the givin trace styling function
    let initScatter3d (applyStyle:Trace3d->Trace3d) = 
        Trace3d("scatter3d") |> applyStyle

    ///initializes a trace of type "surface" applying the givin trace styling function
    let initSurface (applyStyle:Trace3d->Trace3d) = 
        Trace3d("surface") |> applyStyle

    ///initializes a trace of type "mesh3d" applying the givin trace styling function
    let initMesh3d (applyStyle:Trace3d->Trace3d) = 
        Trace3d("mesh3d") |> applyStyle

    ///initializes a trace of type "cone" applying the givin trace styling function
    let initCone (applyStyle:Trace3d->Trace3d) = 
        Trace3d("cone") |> applyStyle

    ///initializes a trace of type "streamtube" applying the givin trace styling function
    let initStreamTube (applyStyle:Trace3d->Trace3d) = 
        Trace3d("streamtube") |> applyStyle

    ///initializes a trace of type "volume" applying the givin trace styling function
    let initVolume (applyStyle:Trace3d->Trace3d) = 
        Trace3d("volume") |> applyStyle

    ///initializes a trace of type "isosurface" applying the givin trace styling function
    let initIsoSurface (applyStyle:Trace3d->Trace3d) = 
        Trace3d("isosurface") |> applyStyle


    //-------------------------------------------------------------------------------------------------------------------------------------------------
    /// Functions provide the styling of the Chart objects
    type Trace3dStyle() =

        // ######################## 3d-Charts
        
        static member setScene 
            (
                ?SceneName:string
            ) =
                fun (trace:Trace3d) ->
                    SceneName |> DynObj.setValueOpt trace "scene"
                    trace

        // Applies the styles to Scatter3d()
        static member Scatter3d
            (   
                ?X      : seq<#IConvertible>,
                ?Y      : seq<#IConvertible>,
                ?Z      : seq<#IConvertible>,
                ?Mode   : StyleParam.Mode,             
                ?Surfaceaxis,
                ?Surfacecolor,
                //?Projection : Projection,
                ?Scene  : string,          
                ?Error_y: Error,
                ?Error_x: Error,
                ?Error_z: Error,
                ?Xsrc   : string,
                ?Ysrc   : string,
                ?Zsrc   : string
            ) =
                //(fun (scatter:('T :> Trace3d)) ->
                (fun (scatter: Trace3d) ->
                //scatter.set_type plotType                     
                    X            |> DynObj.setValueOpt scatter "x"
                    Y            |> DynObj.setValueOpt scatter "y"
                    Z            |> DynObj.setValueOpt scatter "z"
                    Mode         |> DynObj.setValueOptBy scatter "mode" StyleParam.Mode.toString
                    
                    Surfaceaxis  |> DynObj.setValueOpt scatter "xsrc"
                    Surfacecolor |> DynObj.setValueOpt scatter "xsrc"                
                    Scene        |> DynObj.setValueOpt scatter "xsrc"
                    Xsrc         |> DynObj.setValueOpt scatter "xsrc"
                    Ysrc         |> DynObj.setValueOpt scatter "ysrc"
                    Zsrc         |> DynObj.setValueOpt scatter "zsrc"
                    
                    // Update
                    Error_x      |> DynObj.setValueOpt scatter "error_x"
                    Error_y      |> DynObj.setValueOpt scatter "error_y"
                    Error_z      |> DynObj.setValueOpt scatter "error_z"
                    //Projection   |> DynObj.setValueOpt scatter "projecton"

                    // out ->
                    scatter
                )



        /// Applies the styles of 3d-surface to TraceObjects 
        static member Surface
            (                
                ?Z : seq<#seq<#IConvertible>>,
                ?X : seq<#IConvertible>,
                ?Y : seq<#IConvertible>,            
                ?cAuto          ,
                ?cMin           ,
                ?cMax           ,
                ?Colorscale     ,
                ?Autocolorscale : bool,
                ?Reversescale   : bool,
                ?Showscale      : bool,
                ?ColorBar       ,
                ?Contours       ,
                ?Hidesurface    ,
                ?Lightposition  ,
                ?Lighting       ,
                ?Xcalendar      ,
                ?Ycalendar      ,
                ?Zcalendar      ,

                ?Zsrc           ,
                ?Xsrc           ,
                ?Ysrc           ,
                ?Surfacecolorsrc

            ) =
                (fun (surface:('T :> Trace)) -> 
                
                    Z              |> DynObj.setValueOpt surface "z"         
                    X              |> DynObj.setValueOpt surface "x"               
                    Y              |> DynObj.setValueOpt surface "y"        
 
                    cAuto          |> DynObj.setValueOpt surface "cauto"     
                    cMin           |> DynObj.setValueOpt surface "cmin"      
                    cMax           |> DynObj.setValueOpt surface "cmax"      
                    Colorscale     |> DynObj.setValueOptBy surface "colorscale" StyleParam.Colorscale.convert 
                    Autocolorscale |> DynObj.setValueOpt surface "autocolorscale"
                    Reversescale   |> DynObj.setValueOpt surface "reversescale"  
                    Showscale      |> DynObj.setValueOpt surface "showscale"
                    ColorBar       |> DynObj.setValueOpt surface "colorbar"    
                    Contours       |> DynObj.setValueOpt surface "contours"  
                    Hidesurface    |> DynObj.setValueOpt surface "Hidesurface"
                    Lightposition  |> DynObj.setValueOpt surface "Lightposition"
                    Lighting       |> DynObj.setValueOpt surface "Lighting"
                    Xcalendar      |> DynObj.setValueOpt surface "Xcalendar"
                    Ycalendar      |> DynObj.setValueOpt surface "Ycalendar"
                    Zcalendar      |> DynObj.setValueOpt surface "Zcalendar"
                    Zsrc           |> DynObj.setValueOpt surface "zsrc"       
                    Xsrc           |> DynObj.setValueOpt surface "xsrc"       
                    Ysrc           |> DynObj.setValueOpt surface "ysrc" 
                    Surfacecolorsrc|> DynObj.setValueOpt surface "surfacecolorsrc"
                    
                    // out ->
                    surface 
                )


        // Applies the styles to Scatter3d()
        static member Mesh3d
            (   
                ?X            : seq<#IConvertible>,
                ?Y            : seq<#IConvertible>,
                ?Z            : seq<#IConvertible>,
                ?I            : seq<#IConvertible>,
                ?J            : seq<#IConvertible>,
                ?K            : seq<#IConvertible>,
                ?Delaunayaxis : StyleParam.Delaunayaxis, 
                ?Alphahull                       ,
                ?Intensity    : seq<#IConvertible>,
                ?Vertexcolor                     ,
                ?Facecolor                       ,
                ?Flatshading                     ,
                ?Contour                         ,
                ?Colorscale     ,
                ?Autocolorscale ,
                ?Reversescale   ,
                ?Showscale      ,
                ?ColorBar       ,
                ?Lightposition  : LightPosition,
                ?Lighting       : Lighting, // Obj
                ?Scene          ,
                ?Xcalendar      , 
                ?Ycalendar      ,
                ?Zcalendar      ,
                ?Xsrc   : string,
                ?Ysrc   : string,
                ?Zsrc   : string,
                ?Isrc   : string,
                ?Jsrc   : string,
                ?Ksrc   : string,
                ?Intensityscr   : string,
                ?Vertexcolorscr : string,
                ?Facecolorscr   : string
                

            ) =
                 //(fun (scatter:('T :> Trace3d)) ->
                 (fun (mesh3d: Trace3d) ->
                    //scatter.set_type plotType                     
                    X              |> DynObj.setValueOpt mesh3d "x"
                    Y              |> DynObj.setValueOpt mesh3d "y"
                    Z              |> DynObj.setValueOpt mesh3d "z"
                    I              |> DynObj.setValueOpt mesh3d "i"
                    J              |> DynObj.setValueOpt mesh3d "j"
                    K              |> DynObj.setValueOpt mesh3d "k"
                    Alphahull      |> DynObj.setValueOpt mesh3d "alphahull  "
                    Intensity      |> DynObj.setValueOpt mesh3d "intensity  "
                    Vertexcolor    |> DynObj.setValueOpt mesh3d "vertexcolor"
                    Facecolor      |> DynObj.setValueOpt mesh3d "facecolor  "
                    Flatshading    |> DynObj.setValueOpt mesh3d "flatshading"
                    Contour        |> DynObj.setValueOpt mesh3d "contour    "

                    Colorscale     |> DynObj.setValueOpt mesh3d "colorscale"
                    Autocolorscale |> DynObj.setValueOpt mesh3d "autocolorscale"
                    Reversescale   |> DynObj.setValueOpt mesh3d "reversescale"
                    Showscale      |> DynObj.setValueOpt mesh3d "showscale"
                    ColorBar       |> DynObj.setValueOpt mesh3d "colorbar"
                    Lightposition  |> DynObj.setValueOpt mesh3d "lightposition"
                    Lighting       |> DynObj.setValueOpt mesh3d "lighting"
                    Scene          |> DynObj.setValueOpt mesh3d "scene"
                    Xcalendar      |> DynObj.setValueOpt mesh3d "xcalendar"
                    Ycalendar      |> DynObj.setValueOpt mesh3d "ycalendar"
                    Zcalendar      |> DynObj.setValueOpt mesh3d "zcalendar"
                    
                    Xsrc           |> DynObj.setValueOpt mesh3d "xsrc"
                    Ysrc           |> DynObj.setValueOpt mesh3d "ysrc"
                    Zsrc           |> DynObj.setValueOpt mesh3d "zsrc"                    
                    Isrc           |> DynObj.setValueOpt mesh3d "isrc"
                    Jsrc           |> DynObj.setValueOpt mesh3d "jsrc"
                    Ksrc           |> DynObj.setValueOpt mesh3d "ksrc"
                    Intensityscr   |> DynObj.setValueOpt mesh3d "intensityscr"
                    Vertexcolorscr |> DynObj.setValueOpt mesh3d "vertexcolorscr"
                    Facecolorscr   |> DynObj.setValueOpt mesh3d "facecolorscr"

                    Delaunayaxis   |> DynObj.setValueOptBy mesh3d "delaunayaxis" StyleParam.Delaunayaxis.convert
                    
                    // out ->
                    mesh3d
                ) 

        /// <summary>
        /// Applies the style parameters of the cone chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
        /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the x coordinates of the vector field and of the displayed cones.</param>
        /// <param name="Y">Sets the y coordinates of the vector field and of the displayed cones.</param>
        /// <param name="Z">Sets the z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="U">Sets the x components of the vector field.</param>
        /// <param name="V">Sets the y components of the vector field.</param>
        /// <param name="W">Sets the z components of the vector field.</param>
        /// <param name="Text">Sets the text elements associated with the cones. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="HoverText">Same as `text`.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
        /// <param name="UHoverFormat">Sets the hover text formatting rulefor `u` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="VHoverFormat">Sets the hover text formatting rulefor `v` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="WHoverFormat">Sets the hover text formatting rulefor `w` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
        /// <param name="ColorBar">Sets the ColorBar object associated with the color scale of the cones</param>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here u/v/w norm) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmin` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as u/v/w norm. Has no effect when `cauto` is `false`.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmax` must be set as well.</param>
        /// <param name="Anchor">Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.</param>
        /// <param name="HoverLabel">Sets the hover labels of this cone trace.</param>
        /// <param name="Lighting">Sets the Lighting of this cone trace.</param>
        /// <param name="LightPosition">Sets the LightPosition of this cone trace.</param>
        /// <param name="SizeMode">Determines whether `sizeref` is set as a "scaled" (i.e unitless) scalar (normalized by the max u/v/w norm in the vector field) or as "absolute" value (in the same units as the vector field).</param>
        /// <param name="SizeRef">Adjusts the cone size scaling. The size of the cones is determined by their u/v/w norm multiplied a factor and `sizeref`. This factor (computed internally) corresponds to the minimum "time" to travel across two successive x/y/z positions at the average velocity of those two successive positions. All cones in a given trace use the same factor. With `sizemode` set to "scaled", `sizeref` is unitless, its default value is "0.5" With `sizemode` set to "absolute", `sizeref` has the same units as the u/v/w vector field, its the default value is half the sample's maximum vector norm.</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member Cone 
            (
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#IConvertible>,
                ?U                  : seq<#IConvertible>,
                ?V                  : seq<#IConvertible>,
                ?W                  : seq<#IConvertible>,
                ?Text               : seq<#IConvertible>,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?UHoverFormat       : string,
                ?VHoverFormat       : string,
                ?WHoverFormat       : string,
                ?Meta               : seq<#IConvertible>,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?ColorAxis          : StyleParam.SubPlotId,
                ?ColorBar           : ColorBar,
                ?AutoColorScale     : bool,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool,
                ?CAuto              : bool,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?Anchor             : StyleParam.ConeAnchor,
                ?HoverLabel         : Hoverlabel,
                ?Lighting           : Lighting,
                ?LightPosition      : LightPosition,
                ?SizeMode           : StyleParam.ConeSizeMode,
                ?SizeRef            : float,
                ?UIRevision         : seq<#IConvertible>

            ) =
                (fun (cone: Trace3d) -> 
                    Name                |> DynObj.setValueOpt cone "name"
                    Visible             |> DynObj.setValueOptBy cone "visible" StyleParam.Visible.convert
                    ShowLegend          |> DynObj.setValueOpt cone "showlegend"
                    LegendRank          |> DynObj.setValueOpt cone "legendrank"
                    LegendGroup         |> DynObj.setValueOpt cone "legendgroup"
                    LegendGroupTitle    |> DynObj.setValueOpt cone "legendgrouptitle"
                    Opacity             |> DynObj.setValueOpt cone "opacity"
                    Ids                 |> DynObj.setValueOpt cone "ids"
                    X                   |> DynObj.setValueOpt cone "x"
                    Y                   |> DynObj.setValueOpt cone "y"
                    Z                   |> DynObj.setValueOpt cone "z"
                    U                   |> DynObj.setValueOpt cone "u"
                    V                   |> DynObj.setValueOpt cone "v"
                    W                   |> DynObj.setValueOpt cone "w"
                    Text                |> DynObj.setValueOpt cone "text"
                    HoverText           |> DynObj.setValueOpt cone "hovertext"
                    HoverInfo           |> DynObj.setValueOpt cone "hoverinfo"
                    HoverTemplate       |> DynObj.setValueOpt cone "hovertemplate"
                    XHoverFormat        |> DynObj.setValueOpt cone "xhoverformat"
                    YHoverFormat        |> DynObj.setValueOpt cone "yhoverformat"
                    ZHoverFormat        |> DynObj.setValueOpt cone "zhoverformat"
                    UHoverFormat        |> DynObj.setValueOpt cone "uhoverformat"
                    VHoverFormat        |> DynObj.setValueOpt cone "vhoverformat"
                    WHoverFormat        |> DynObj.setValueOpt cone "whoverformat"
                    Meta                |> DynObj.setValueOpt cone "meta"
                    CustomData          |> DynObj.setValueOpt cone "customdata"
                    Scene               |> DynObj.setValueOptBy cone "scene" StyleParam.SubPlotId.convert
                    ColorAxis           |> DynObj.setValueOptBy cone "scene" StyleParam.SubPlotId.convert
                    ColorBar            |> DynObj.setValueOpt cone "colorbar"
                    AutoColorScale      |> DynObj.setValueOpt cone "autocolorscale"
                    ColorScale          |> DynObj.setValueOptBy cone "colorscale" StyleParam.Colorscale.convert
                    ShowScale           |> DynObj.setValueOpt cone "showscale"
                    ReverseScale        |> DynObj.setValueOpt cone "reversescale"
                    CAuto               |> DynObj.setValueOpt cone "cauto"
                    CMin                |> DynObj.setValueOpt cone "cmin"
                    CMid                |> DynObj.setValueOpt cone "cmid"
                    CMax                |> DynObj.setValueOpt cone "cmax"
                    Anchor              |> DynObj.setValueOptBy cone "anchor" StyleParam.ConeAnchor.convert
                    HoverLabel          |> DynObj.setValueOpt cone "hoverlabel"
                    Lighting            |> DynObj.setValueOpt cone "lighting"
                    LightPosition       |> DynObj.setValueOpt cone "lightposition"
                    SizeMode            |> DynObj.setValueOptBy cone "sizemode" StyleParam.ConeSizeMode.convert
                    SizeRef             |> DynObj.setValueOpt cone "sizeref"
                    UIRevision          |> DynObj.setValueOpt cone "uirevision"

                    cone
                )
                
        /// <summary>
        /// Applies the style parameters of the streamtube chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
        /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the x coordinates of the vector field.</param>
        /// <param name="Y">Sets the y coordinates of the vector field.</param>
        /// <param name="Z">Sets the z coordinates of the vector field.</param>
        /// <param name="U">Sets the x components of the vector field.</param>
        /// <param name="V">Sets the y components of the vector field.</param>
        /// <param name="W">Sets the z components of the vector field.</param>
        /// <param name="Text">Sets a text element associated with this trace. If trace `hoverinfo` contains a "text" flag, this text element will be seen in all hover labels. Note that streamtube traces do not support array `text` values.</param>
        /// <param name="HoverText">Same as `text`.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
        /// <param name="UHoverFormat">Sets the hover text formatting rulefor `u` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="VHoverFormat">Sets the hover text formatting rulefor `v` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="WHoverFormat">Sets the hover text formatting rulefor `w` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
        /// <param name="ColorBar">Sets the ColorBar object associated with the color scale of the streamtubes</param>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here u/v/w norm) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmin` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as u/v/w norm. Has no effect when `cauto` is `false`.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmax` must be set as well.</param>
        /// <param name="HoverLabel">Sets the hover labels of this streamtube trace.</param>
        /// <param name="Lighting">Sets the Lighting of this streamtube trace.</param>
        /// <param name="LightPosition">Sets the LightPosition of this streamtube trace.</param>
        /// <param name="MaxDisplayed">The maximum number of displayed segments in a streamtube.</param>
        /// <param name="SizeRef">The scaling factor for the streamtubes. The default is 1, which avoids two max divergence tubes from touching at adjacent starting positions.</param>
        /// <param name="Starts">Sets the streamtube starting positions</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member StreamTube 
            (
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#IConvertible>,
                ?U                  : seq<#IConvertible>,
                ?V                  : seq<#IConvertible>,
                ?W                  : seq<#IConvertible>,
                ?Text               : seq<#IConvertible>,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?UHoverFormat       : string,
                ?VHoverFormat       : string,
                ?WHoverFormat       : string,
                ?Meta               : seq<#IConvertible>,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?ColorAxis          : StyleParam.SubPlotId,
                ?ColorBar           : ColorBar,
                ?AutoColorScale     : bool,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool,
                ?CAuto              : bool,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?HoverLabel         : Hoverlabel,
                ?Lighting           : Lighting,
                ?LightPosition      : LightPosition,
                ?MaxDisplayed       : int,
                ?SizeRef            : float,
                ?Starts             : StreamTubeStarts,
                ?UIRevision         : seq<#IConvertible>

            ) =
                (fun (streamTube: Trace3d) -> 
                    Name                |> DynObj.setValueOpt streamTube "name"
                    Visible             |> DynObj.setValueOptBy streamTube "visible" StyleParam.Visible.convert
                    ShowLegend          |> DynObj.setValueOpt streamTube "showlegend"
                    LegendRank          |> DynObj.setValueOpt streamTube "legendrank"
                    LegendGroup         |> DynObj.setValueOpt streamTube "legendgroup"
                    LegendGroupTitle    |> DynObj.setValueOpt streamTube "legendgrouptitle"
                    Opacity             |> DynObj.setValueOpt streamTube "opacity"
                    Ids                 |> DynObj.setValueOpt streamTube "ids"
                    X                   |> DynObj.setValueOpt streamTube "x"
                    Y                   |> DynObj.setValueOpt streamTube "y"
                    Z                   |> DynObj.setValueOpt streamTube "z"
                    U                   |> DynObj.setValueOpt streamTube "u"
                    V                   |> DynObj.setValueOpt streamTube "v"
                    W                   |> DynObj.setValueOpt streamTube "w"
                    Text                |> DynObj.setValueOpt streamTube "text"
                    HoverText           |> DynObj.setValueOpt streamTube "hovertext"
                    HoverInfo           |> DynObj.setValueOpt streamTube "hoverinfo"
                    HoverTemplate       |> DynObj.setValueOpt streamTube "hovertemplate"
                    XHoverFormat        |> DynObj.setValueOpt streamTube "xhoverformat"
                    YHoverFormat        |> DynObj.setValueOpt streamTube "yhoverformat"
                    ZHoverFormat        |> DynObj.setValueOpt streamTube "zhoverformat"
                    UHoverFormat        |> DynObj.setValueOpt streamTube "uhoverformat"
                    VHoverFormat        |> DynObj.setValueOpt streamTube "vhoverformat"
                    WHoverFormat        |> DynObj.setValueOpt streamTube "whoverformat"
                    Meta                |> DynObj.setValueOpt streamTube "meta"
                    CustomData          |> DynObj.setValueOpt streamTube "customdata"
                    Scene               |> DynObj.setValueOptBy streamTube "scene" StyleParam.SubPlotId.convert
                    ColorAxis           |> DynObj.setValueOptBy streamTube "scene" StyleParam.SubPlotId.convert
                    ColorBar            |> DynObj.setValueOpt streamTube "colorbar"
                    AutoColorScale      |> DynObj.setValueOpt streamTube "autocolorscale"
                    ColorScale          |> DynObj.setValueOptBy streamTube "colorscale" StyleParam.Colorscale.convert
                    ShowScale           |> DynObj.setValueOpt streamTube "showscale"
                    ReverseScale        |> DynObj.setValueOpt streamTube "reversescale"
                    CAuto               |> DynObj.setValueOpt streamTube "cauto"
                    CMin                |> DynObj.setValueOpt streamTube "cmin"
                    CMid                |> DynObj.setValueOpt streamTube "cmid"
                    CMax                |> DynObj.setValueOpt streamTube "cmax"
                    HoverLabel          |> DynObj.setValueOpt streamTube "hoverlabel"
                    Lighting            |> DynObj.setValueOpt streamTube "lighting"
                    LightPosition       |> DynObj.setValueOpt streamTube "lightposition"
                    MaxDisplayed        |> DynObj.setValueOpt streamTube "maxdisplayed"
                    SizeRef             |> DynObj.setValueOpt streamTube "sizeref"
                    Starts              |> DynObj.setValueOpt streamTube "starts"
                    UIRevision          |> DynObj.setValueOpt streamTube "uirevision"

                    streamTube
                )