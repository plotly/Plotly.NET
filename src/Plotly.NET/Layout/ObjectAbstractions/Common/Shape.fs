namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Shapes are layers that can be drawn onto a chart layout.
type Shape() =
    inherit DynamicObj()

    /// <summary>
    /// Returns Some(dynamic member value) of the shape object's underlying DynamicObj when a dynamic member with the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="shape">The shape to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (shape:Shape) = shape.TryGetTypedValue<'T>(propName)

    /// <summary>
    /// Returns the Legend anchor of the given shape.
    ///
    /// If there is no Legend set, returns "legend".
    /// </summary>
    /// <param name="shape">The shape to get the Legend anchor from</param>
    static member getLegendAnchor(shape: Shape) =
        let idString =
            shape |> Shape.tryGetTypedMember<string> ("legend") |> Option.defaultValue "legend"

        if idString = "legend" then
            StyleParam.SubPlotId.Legend 1
        else
            StyleParam.SubPlotId.Legend(idString.Replace("legend", "") |> int)

    /// <summary>
    /// Returns a function that sets the Legend anchor of the given shape.
    /// </summary>
    /// <param name="legendId">The new Legend anchor</param>
    static member setLegendAnchor(legendId: int) =
        let id =
            StyleParam.SubPlotId.Legend legendId

        (fun (shape: Shape) ->
            shape.SetValue("legend", StyleParam.SubPlotId.convert id)
            shape)

    /// <summary>
    /// Returns a new Shape object with the given styling.
    /// </summary>
    /// <param name="Editable">Determines whether the shape could be activated for edit or not. Has no effect when the older editable shapes mode is enabled via `config.editable` or `config.edits.shapePosition`.</param>
    /// <param name="FillColor">Sets the color filling the shape's interior. Only applies to closed shapes.</param>
    /// <param name="FillRule">Determines which regions of complex paths constitute the interior. For more info please visit https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule</param>
    /// <param name="Label">The text label of this shape.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this shape is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this shape in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this shape. Items and groups with smaller ranks are presented on top/left side while with "reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items. When having unranked or equal rank items shapes would be displayed after traces i.e. according to their order in data and layout.</param>
    /// <param name="LegendGroup">Sets the legend group for this shape. Traces and shapes part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this shape.</param>
    /// <param name="LegendWidth">Sets the width (in px or fraction) of the legend for this shape.</param>
    /// <param name="Layer">Specifies whether shapes are drawn below or above traces.</param>
    /// <param name="Line">Sets the Shape outline</param>
    /// <param name="Name">When used in a template, named items are created in the output figure in addition to any items the figure already has in this array. You can modify these items in the output figure by making your own item with `templateitemname` matching this `name` alongside your modifications (including `visible: false` or `enabled: false` to hide it). Has no effect outside of a template.</param>
    /// <param name="Opacity">Sets the opacity of the shape.</param>
    /// <param name="Path">For `type` "path" - a valid SVG path with the pixel values replaced by data values in `xsizemode`/`ysizemode` being "scaled" and taken unmodified as pixels relative to `xanchor` and `yanchor` in case of "pixel" size mode. There are a few restrictions / quirks only absolute instructions, not relative. So the allowed segments are: M, L, H, V, Q, C, T, S, and Z arcs (A) are not allowed because radius rx and ry are relative. In the future we could consider supporting relative commands, but we would have to decide on how to handle date and log axes. Note that even as is, Q and C Bezier paths that are smooth on linear axes may not be smooth on log, and vice versa. no chained "polybezier" commands - specify the segment type for each one. On category axes, values are numbers scaled to the serial numbers of categories because using the categories themselves there would be no way to describe fractional positions On data axes: because space and T are both normal components of path strings, we can't use either to separate date from time parts. Therefore we'll use underscore for this purpose: 2015-02-21_13:45:56.789</param>
    /// <param name="TemplateItemName">Used to refer to a named item in this array in the template. Named items from the template will be created even without a matching item in the input figure, but you can modify one by making an item with `templateitemname` matching its `name`, alongside your modifications (including `visible: false` or `enabled: false` to hide it). If there is no template or no matching item, this item will be hidden unless you explicitly show it with `visible: true`.</param>
    /// <param name="ShapeType">Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) with respect to the axes' sizing mode. If "circle", a circle is drawn from ((`x0`+`x1`)/2, (`y0`+`y1`)/2)) with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) with respect to the axes' sizing mode. If "rect", a rectangle is drawn linking (`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`) with respect to the axes' sizing mode. If "path", draw a custom SVG path using `path`. with respect to the axes' sizing mode.</param>
    /// <param name="Visible">Determines whether or not this shape is visible.</param>
    /// <param name="X0">Sets the shape's starting x position. See `type` and `xsizemode` for more info.</param>
    /// <param name="X1">Sets the shape's end x position. See `type` and `xsizemode` for more info.</param>
    /// <param name="XAnchor">Only relevant in conjunction with `xsizemode` set to "pixel". Specifies the anchor point on the x axis to which `x0`, `x1` and x coordinates within `path` are relative to. E.g. useful to attach a pixel sized shape to a certain data value. No effect when `xsizemode` not set to "pixel".</param>
    /// <param name="Xref">Sets the shape's x coordinate axis. If set to a x axis id (e.g. "x" or "x2"), the `x` position refers to a x coordinate. If set to "paper", the `x` position refers to the distance from the left of the plotting area in normalized coordinates where "0" ("1") corresponds to the left (right). If set to a x axis ID followed by "domain" (separated by a space), the position behaves like for "paper", but refers to the distance in fractions of the domain length from the left of the domain of that axis: e.g., "x2 domain" refers to the domain of the second x axis and a x position of 0.5 refers to the point between the left and the right of the domain of the second x axis.</param>
    /// <param name="XSizeMode">Sets the shapes's sizing mode along the x axis. If set to "scaled", `x0`, `x1` and x coordinates within `path` refer to data values on the x axis or a fraction of the plot area's width (`xref` set to "paper"). If set to "pixel", `xanchor` specifies the x position in terms of data or plot fraction but `x0`, `x1` and x coordinates within `path` are pixels relative to `xanchor`. This way, the shape can have a fixed width while maintaining a position relative to data or plot fraction.</param>
    /// <param name="Y0">Sets the shape's starting y position. See `type` and `ysizemode` for more info.</param>
    /// <param name="Y1">Sets the shape's end y position. See `type` and `ysizemode` for more info.</param>
    /// <param name="YAnchor">Only relevant in conjunction with `ysizemode` set to "pixel". Specifies the anchor point on the y axis to which `y0`, `y1` and y coordinates within `path` are relative to. E.g. useful to attach a pixel sized shape to a certain data value. No effect when `ysizemode` not set to "pixel".</param>
    /// <param name="Yref">Sets the shape's y coordinate axis. If set to a y axis id (e.g. "y" or "y2"), the `y` position refers to a y coordinate. If set to "paper", the `y` position refers to the distance from the bottom of the plotting area in normalized coordinates where "0" ("1") corresponds to the bottom (top). If set to a y axis ID followed by "domain" (separated by a space), the position behaves like for "paper", but refers to the distance in fractions of the domain length from the bottom of the domain of that axis: e.g., "y2 domain" refers to the domain of the second y axis and a y position of 0.5 refers to the point between the bottom and the top of the domain of the second y axis.</param>
    /// <param name="YSizeMode">Sets the shapes's sizing mode along the y axis. If set to "scaled", `y0`, `y1` and y coordinates within `path` refer to data values on the y axis or a fraction of the plot area's height (`yref` set to "paper"). If set to "pixel", `yanchor` specifies the y position in terms of data or plot fraction but `y0`, `y1` and y coordinates within `path` are pixels relative to `yanchor`. This way, the shape can have a fixed height while maintaining a position relative to data or plot fraction.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Editable: bool,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?FillRule: StyleParam.FillRule,
            [<Optional; DefaultParameterValue(null)>] ?Label: ShapeLabel,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?LegendWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Path: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?ShapeType: StyleParam.ShapeType,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?X1: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Xref: string,
            [<Optional; DefaultParameterValue(null)>] ?XSizeMode: StyleParam.ShapeSizeMode,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y1: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Yref: string,
            [<Optional; DefaultParameterValue(null)>] ?YSizeMode: StyleParam.ShapeSizeMode
        ) =
        Shape()
        |> Shape.style (
            ?Editable = Editable,
            ?FillColor = FillColor,
            ?FillRule = FillRule,
            ?Label = Label,
            ?ShowLegend = ShowLegend,
            ?Legend = Legend,
            ?LegendRank = LegendRank,
            ?LegendGroup = LegendGroup,
            ?LegendGroupTitle = LegendGroupTitle,
            ?LegendWidth = LegendWidth,
            ?Layer = Layer,
            ?Line = Line,
            ?Name = Name,
            ?Opacity = Opacity,
            ?Path = Path,
            ?TemplateItemName = TemplateItemName,
            ?ShapeType = ShapeType,
            ?Visible = Visible,
            ?X0 = X0,
            ?X1 = X1,
            ?XAnchor = XAnchor,
            ?Xref = Xref,
            ?XSizeMode = XSizeMode,
            ?Y0 = Y0,
            ?Y1 = Y1,
            ?YAnchor = YAnchor,
            ?Yref = Yref,
            ?YSizeMode = YSizeMode
        )

    /// <summary>
    /// Returns a function that applies the given styles to a Shape object
    /// </summary>
    /// <param name="Editable">Determines whether the shape could be activated for edit or not. Has no effect when the older editable shapes mode is enabled via `config.editable` or `config.edits.shapePosition`.</param>
    /// <param name="FillColor">Sets the color filling the shape's interior. Only applies to closed shapes.</param>
    /// <param name="FillRule">Determines which regions of complex paths constitute the interior. For more info please visit https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule</param>
    /// <param name="Label">The text label of this shape.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this shape is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this shape in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this shape. Items and groups with smaller ranks are presented on top/left side while with "reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items. When having unranked or equal rank items shapes would be displayed after traces i.e. according to their order in data and layout.</param>
    /// <param name="LegendGroup">Sets the legend group for this shape. Traces and shapes part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this shape.</param>
    /// <param name="LegendWidth">Sets the width (in px or fraction) of the legend for this shape.</param>
    /// <param name="Layer">Specifies whether shapes are drawn below or above traces.</param>
    /// <param name="Line">Sets the Shape outline</param>
    /// <param name="Name">When used in a template, named items are created in the output figure in addition to any items the figure already has in this array. You can modify these items in the output figure by making your own item with `templateitemname` matching this `name` alongside your modifications (including `visible: false` or `enabled: false` to hide it). Has no effect outside of a template.</param>
    /// <param name="Opacity">Sets the opacity of the shape.</param>
    /// <param name="Path">For `type` "path" - a valid SVG path with the pixel values replaced by data values in `xsizemode`/`ysizemode` being "scaled" and taken unmodified as pixels relative to `xanchor` and `yanchor` in case of "pixel" size mode. There are a few restrictions / quirks only absolute instructions, not relative. So the allowed segments are: M, L, H, V, Q, C, T, S, and Z arcs (A) are not allowed because radius rx and ry are relative. In the future we could consider supporting relative commands, but we would have to decide on how to handle date and log axes. Note that even as is, Q and C Bezier paths that are smooth on linear axes may not be smooth on log, and vice versa. no chained "polybezier" commands - specify the segment type for each one. On category axes, values are numbers scaled to the serial numbers of categories because using the categories themselves there would be no way to describe fractional positions On data axes: because space and T are both normal components of path strings, we can't use either to separate date from time parts. Therefore we'll use underscore for this purpose: 2015-02-21_13:45:56.789</param>
    /// <param name="TemplateItemName">Used to refer to a named item in this array in the template. Named items from the template will be created even without a matching item in the input figure, but you can modify one by making an item with `templateitemname` matching its `name`, alongside your modifications (including `visible: false` or `enabled: false` to hide it). If there is no template or no matching item, this item will be hidden unless you explicitly show it with `visible: true`.</param>
    /// <param name="ShapeType">Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) with respect to the axes' sizing mode. If "circle", a circle is drawn from ((`x0`+`x1`)/2, (`y0`+`y1`)/2)) with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) with respect to the axes' sizing mode. If "rect", a rectangle is drawn linking (`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`) with respect to the axes' sizing mode. If "path", draw a custom SVG path using `path`. with respect to the axes' sizing mode.</param>
    /// <param name="Visible">Determines whether or not this shape is visible.</param>
    /// <param name="X0">Sets the shape's starting x position. See `type` and `xsizemode` for more info.</param>
    /// <param name="X1">Sets the shape's end x position. See `type` and `xsizemode` for more info.</param>
    /// <param name="XAnchor">Only relevant in conjunction with `xsizemode` set to "pixel". Specifies the anchor point on the x axis to which `x0`, `x1` and x coordinates within `path` are relative to. E.g. useful to attach a pixel sized shape to a certain data value. No effect when `xsizemode` not set to "pixel".</param>
    /// <param name="Xref">Sets the shape's x coordinate axis. If set to a x axis id (e.g. "x" or "x2"), the `x` position refers to a x coordinate. If set to "paper", the `x` position refers to the distance from the left of the plotting area in normalized coordinates where "0" ("1") corresponds to the left (right). If set to a x axis ID followed by "domain" (separated by a space), the position behaves like for "paper", but refers to the distance in fractions of the domain length from the left of the domain of that axis: e.g., "x2 domain" refers to the domain of the second x axis and a x position of 0.5 refers to the point between the left and the right of the domain of the second x axis.</param>
    /// <param name="XSizeMode">Sets the shapes's sizing mode along the x axis. If set to "scaled", `x0`, `x1` and x coordinates within `path` refer to data values on the x axis or a fraction of the plot area's width (`xref` set to "paper"). If set to "pixel", `xanchor` specifies the x position in terms of data or plot fraction but `x0`, `x1` and x coordinates within `path` are pixels relative to `xanchor`. This way, the shape can have a fixed width while maintaining a position relative to data or plot fraction.</param>
    /// <param name="Y0">Sets the shape's starting y position. See `type` and `ysizemode` for more info.</param>
    /// <param name="Y1">Sets the shape's end y position. See `type` and `ysizemode` for more info.</param>
    /// <param name="YAnchor">Only relevant in conjunction with `ysizemode` set to "pixel". Specifies the anchor point on the y axis to which `y0`, `y1` and y coordinates within `path` are relative to. E.g. useful to attach a pixel sized shape to a certain data value. No effect when `ysizemode` not set to "pixel".</param>
    /// <param name="Yref">Sets the shape's y coordinate axis. If set to a y axis id (e.g. "y" or "y2"), the `y` position refers to a y coordinate. If set to "paper", the `y` position refers to the distance from the bottom of the plotting area in normalized coordinates where "0" ("1") corresponds to the bottom (top). If set to a y axis ID followed by "domain" (separated by a space), the position behaves like for "paper", but refers to the distance in fractions of the domain length from the bottom of the domain of that axis: e.g., "y2 domain" refers to the domain of the second y axis and a y position of 0.5 refers to the point between the bottom and the top of the domain of the second y axis.</param>
    /// <param name="YSizeMode">Sets the shapes's sizing mode along the y axis. If set to "scaled", `y0`, `y1` and y coordinates within `path` refer to data values on the y axis or a fraction of the plot area's height (`yref` set to "paper"). If set to "pixel", `yanchor` specifies the y position in terms of data or plot fraction but `y0`, `y1` and y coordinates within `path` are pixels relative to `yanchor`. This way, the shape can have a fixed height while maintaining a position relative to data or plot fraction.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Editable: bool,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?FillRule: StyleParam.FillRule,
            [<Optional; DefaultParameterValue(null)>] ?Label: ShapeLabel,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?Legend: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?LegendWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Path: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?ShapeType: StyleParam.ShapeType,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?X0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?X1: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Xref: string,
            [<Optional; DefaultParameterValue(null)>] ?XSizeMode: StyleParam.ShapeSizeMode,
            [<Optional; DefaultParameterValue(null)>] ?Y0: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y1: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.LinearAxisId,
            [<Optional; DefaultParameterValue(null)>] ?Yref: string,
            [<Optional; DefaultParameterValue(null)>] ?YSizeMode: StyleParam.ShapeSizeMode
        ) =
        (fun (shape: Shape) ->

            Editable |> DynObj.setValueOpt shape "editable"
            FillColor |> DynObj.setValueOpt shape "fillcolor"
            FillRule |> DynObj.setValueOptBy shape "fillrule" StyleParam.FillRule.convert
            Label |> DynObj.setValueOpt shape "label"
            ShowLegend |> DynObj.setValueOpt shape "showlegend"
            Legend |> DynObj.setValueOptBy shape "legend" StyleParam.SubPlotId.convert
            LegendRank |> DynObj.setValueOpt shape "legendrank"
            LegendGroup |> DynObj.setValueOpt shape "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt shape "legendgrouptitle"
            LegendWidth |> DynObj.setValueOpt shape "legendwidth"
            Layer |> DynObj.setValueOptBy shape "layer" StyleParam.Layer.convert
            Line |> DynObj.setValueOpt shape "line"
            Name |> DynObj.setValueOpt shape "name"
            Opacity |> DynObj.setValueOpt shape "opacity"
            Path |> DynObj.setValueOpt shape "path"
            TemplateItemName |> DynObj.setValueOpt shape "templateitemname"
            ShapeType |> DynObj.setValueOptBy shape "type" StyleParam.ShapeType.convert
            Visible |> DynObj.setValueOpt shape "visible"
            X0 |> DynObj.setValueOpt shape "x0"
            X1 |> DynObj.setValueOpt shape "x1"
            XAnchor |> DynObj.setValueOptBy shape "xanchor" StyleParam.LinearAxisId.convert
            Xref |> DynObj.setValueOpt shape "xref"
            XSizeMode |> DynObj.setValueOptBy shape "xsizemode" StyleParam.ShapeSizeMode.convert
            Y0 |> DynObj.setValueOpt shape "y0"
            Y1 |> DynObj.setValueOpt shape "y1"
            YAnchor |> DynObj.setValueOptBy shape "yanchor" StyleParam.LinearAxisId.convert
            Yref |> DynObj.setValueOpt shape "yref"
            YSizeMode |> DynObj.setValueOptBy shape "ysizemode" StyleParam.ShapeSizeMode.convert

            shape)
