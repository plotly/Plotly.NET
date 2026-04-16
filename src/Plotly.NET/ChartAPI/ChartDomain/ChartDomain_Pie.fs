namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartDomain_Pie =

    [<Extension>]
    type Chart =
        /// <summary>
        /// Creates a pie chart.
        ///
        /// A pie chart (or a circle chart) is a circular statistical graphic, which is divided into slices to illustrate numerical proportion.
        /// In a pie chart, the arc length of each slice (and consequently its central angle and area), is proportional to the quantity it represents.
        /// </summary>
        /// <param name="values">Sets the values of the sectors</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, the associated `values` are summed.</param>
        /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Pie
            (
                values: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Labels: seq<#IConvertible>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Hole: float,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Colors = SectionColors, ?MultiOpacity = MultiOpacity, Outline = outline, Pattern = pattern)


            TraceDomain.initPie (
                TraceDomainStyle.Pie(
                    Values = values,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Labels = Labels,
                    ?Pull = Pull,
                    ?MultiPull = MultiPull,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    ?Direction = Direction,
                    ?Hole = Hole,
                    ?Rotation = Rotation,
                    ?Sort = Sort

                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a pie chart from encoded values and labels.
        /// </summary>
        /// <param name="valuesEncoded">Sets the values of the sectors as an encoded typed array.</param>
        /// <param name="labelsEncoded">Sets the sector labels as an encoded typed array. If `labels` entries are duplicated, the associated `values` are summed.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Pie
            (
                valuesEncoded: EncodedTypedArray,
                ?labelsEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Hole: float,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Colors = SectionColors, ?MultiOpacity = MultiOpacity, Outline = outline, Pattern = pattern)


            TraceDomain.initPie (
                TraceDomainStyle.Pie(
                    ValuesEncoded = valuesEncoded,
                    ?LabelsEncoded = labelsEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Pull = Pull,
                    ?MultiPull = MultiPull,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    ?Direction = Direction,
                    ?Hole = Hole,
                    ?Rotation = Rotation,
                    ?Sort = Sort

                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a pie chart.
        ///
        /// A pie chart (or a circle chart) is a circular statistical graphic, which is divided into slices to illustrate numerical proportion.
        /// In a pie chart, the arc length of each slice (and consequently its central angle and area), is proportional to the quantity it represents.
        /// </summary>
        /// <param name="valuesLabels">Sets the values and labels of the sectors. If label entries are duplicated, the associated values are summed.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Pie
            (
                valuesLabels: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Hole: float,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let values, labels = Seq.unzip valuesLabels

            Chart.Pie(
                values,
                Labels = labels,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Pull = Pull,
                ?MultiPull = MultiPull,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?Direction = Direction,
                ?Hole = Hole,
                ?Rotation = Rotation,
                ?Sort = Sort,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Creates a doughnut chart.
        ///
        /// A doughnut chart is a variation of the pie chart that has a fraction cut from the center of the slices.
        /// </summary>
        /// <param name="values">Sets the values of the sectors</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, the associated `values` are summed.</param>
        /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Doughnut
            (
                values: seq<#IConvertible>,
                ?Name: string,
                ?Hole: float,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Labels: seq<#IConvertible>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let hole = Option.defaultValue 0.4 Hole

            Chart.Pie(
                values,
                Hole = hole,
                ?Labels = Labels,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?MultiPull = MultiPull,
                ?Pull = Pull,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?Direction = Direction,
                ?Rotation = Rotation,
                ?Sort = Sort,
                ?UseDefaults = UseDefaults
            )

        /// <summary>Creates a doughnut chart from encoded values and labels.</summary>
        [<Extension>]
        static member Doughnut
            (
                valuesEncoded: EncodedTypedArray,
                ?labelsEncoded: EncodedTypedArray,
                ?Hole: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let hole = Option.defaultValue 0.4 Hole

            Chart.Pie(
                valuesEncoded,
                ?labelsEncoded = labelsEncoded,
                Hole = hole,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?MultiPull = MultiPull,
                ?Pull = Pull,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?Direction = Direction,
                ?Rotation = Rotation,
                ?Sort = Sort,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Creates a doughnut chart.
        ///
        /// A doughnut chart is a variation of the pie chart that has a fraction cut from the center of the slices.
        /// </summary>
        /// <param name="valuesLabels">Sets the values and labels of the sectors. If label entries are duplicated, the associated values are summed.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Doughnut
            (
                valuesLabels: seq<#IConvertible * #IConvertible>,
                ?Hole: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =
            let values, labels = Seq.unzip valuesLabels

            Chart.Doughnut(
                values,
                Labels = labels,
                ?Hole = Hole,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Pull = Pull,
                ?MultiPull = MultiPull,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?Direction = Direction,
                ?Rotation = Rotation,
                ?Sort = Sort,
                ?UseDefaults = UseDefaults
            )



        /// <summary>
        /// Creates a FunnelArea chart.
        ///
        /// FunnelArea charts visualize stages in a process using area-encoded trapezoids, which can be used to show data in a part-to-whole representation similar to a piechart,
        /// wherein each item appears in a single stage. See also the "funnel" chart for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="values">Sets the values of the sectors</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, the associated `values` are summed.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="AspectRatio"></param>
        /// <param name="BaseRatio"></param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member FunnelArea
            (
                values: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Labels: seq<#IConvertible>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?AspectRatio: float,
                ?BaseRatio: float,
                ?UseDefaults: bool
            ) =


            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Colors = SectionColors, ?MultiOpacity = MultiOpacity, Outline = outline, Pattern = pattern)


            TraceDomain.initFunnelArea (
                TraceDomainStyle.FunnelArea(
                    Values = values,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Labels = Labels,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    ?AspectRatio = AspectRatio,
                    ?BaseRatio = BaseRatio
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a FunnelArea chart.
        ///
        /// FunnelArea charts visualize stages in a process using area-encoded trapezoids, which can be used to show data in a part-to-whole representation similar to a piechart,
        /// wherein each item appears in a single stage. See also the "funnel" chart for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="valuesLabels">Sets the values and labels of the sectors. If label entries are duplicated, the associated values are summed.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="AspectRatio"></param>
        /// <param name="BaseRatio"></param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member FunnelArea
            (
                valuesLabels: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?AspectRatio: float,
                ?BaseRatio: float,
                ?UseDefaults: bool
            ) =
            let values, labels = Seq.unzip valuesLabels

            Chart.FunnelArea(
                values,
                Labels = labels,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?AspectRatio = AspectRatio,
                ?BaseRatio = BaseRatio,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a FunnelArea chart from encoded values and optional encoded labels.
        ///
        /// FunnelArea charts visualize stages in a process using area-encoded trapezoids, which can be used to show data in a part-to-whole representation similar to a piechart,
        /// wherein each item appears in a single stage. See also the "funnel" chart for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="valuesEncoded">Sets the values of the sectors as an encoded typed array.</param>
        /// <param name="labelsEncoded">Sets the sector labels as an encoded typed array. If label entries are duplicated, the associated values are summed.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="AspectRatio"></param>
        /// <param name="BaseRatio"></param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member FunnelArea
            (
                valuesEncoded: EncodedTypedArray,
                ?labelsEncoded: EncodedTypedArray,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?AspectRatio: float,
                ?BaseRatio: float,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Colors = SectionColors, ?MultiOpacity = MultiOpacity, Outline = outline, Pattern = pattern)

            TraceDomain.initFunnelArea (
                TraceDomainStyle.FunnelArea(
                    ValuesEncoded = valuesEncoded,
                    ?LabelsEncoded = labelsEncoded,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    ?AspectRatio = AspectRatio,
                    ?BaseRatio = BaseRatio
                )
            )
            |> GenericChart.ofTraceObject useDefaults


