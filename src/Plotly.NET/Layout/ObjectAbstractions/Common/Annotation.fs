namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Text annotations inside a plot
type Annotation() =
    inherit DynamicObj()

    /// Init Annotation type
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.AnnotationAlignment,
            [<Optional; DefaultParameterValue(null)>] ?ArrowColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ArrowHead: StyleParam.ArrowHead,
            [<Optional; DefaultParameterValue(null)>] ?ArrowSide: StyleParam.ArrowSide,
            [<Optional; DefaultParameterValue(null)>] ?ArrowSize: float,
            [<Optional; DefaultParameterValue(null)>] ?AX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?AXRef: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?AY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?AYRef: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderPad: int,
            [<Optional; DefaultParameterValue(null)>] ?BorderWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?CaptureEvents: bool,
            [<Optional; DefaultParameterValue(null)>] ?ClickToShow: StyleParam.ClickToShow,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Height: int,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?ShowArrow: bool,
            [<Optional; DefaultParameterValue(null)>] ?StandOff: int,
            [<Optional; DefaultParameterValue(null)>] ?StartArrowHead: int,
            [<Optional; DefaultParameterValue(null)>] ?StartArrowSize: float,
            [<Optional; DefaultParameterValue(null)>] ?StartStandOff: int,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Text: string,
            [<Optional; DefaultParameterValue(null)>] ?TextAngle: float,
            [<Optional; DefaultParameterValue(null)>] ?VAlign: StyleParam.VerticalAlign,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?Width: int,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?XClick: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XRef: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XShift: int,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?YClick: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YRef: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YShift: int
        ) =
        Annotation()
        |> Annotation.style (
            ?Align = Align,
            ?ArrowColor = ArrowColor,
            ?ArrowHead = ArrowHead,
            ?ArrowSide = ArrowSide,
            ?ArrowSize = ArrowSize,
            ?AX = AX,
            ?AXRef = AXRef,
            ?AY = AY,
            ?AYRef = AYRef,
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?BorderPad = BorderPad,
            ?BorderWidth = BorderWidth,
            ?CaptureEvents = CaptureEvents,
            ?ClickToShow = ClickToShow,
            ?Font = Font,
            ?Height = Height,
            ?HoverLabel = HoverLabel,
            ?HoverText = HoverText,
            ?Name = Name,
            ?Opacity = Opacity,
            ?ShowArrow = ShowArrow,
            ?StandOff = StandOff,
            ?StartArrowHead = StartArrowHead,
            ?StartArrowSize = StartArrowSize,
            ?StartStandOff = StartStandOff,
            ?TemplateItemName = TemplateItemName,
            ?Text = Text,
            ?TextAngle = TextAngle,
            ?VAlign = VAlign,
            ?Visible = Visible,
            ?Width = Width,
            ?X = X,
            ?XAnchor = XAnchor,
            ?XClick = XClick,
            ?XRef = XRef,
            ?XShift = XShift,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?YClick = YClick,
            ?YRef = YRef,
            ?YShift = YShift
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Y: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.AnnotationAlignment,
            [<Optional; DefaultParameterValue(null)>] ?ArrowColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?ArrowHead: StyleParam.ArrowHead,
            [<Optional; DefaultParameterValue(null)>] ?ArrowSide: StyleParam.ArrowSide,
            [<Optional; DefaultParameterValue(null)>] ?ArrowSize: float,
            [<Optional; DefaultParameterValue(null)>] ?AX: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?AXRef: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?AY: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?AYRef: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderPad: int,
            [<Optional; DefaultParameterValue(null)>] ?BorderWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?CaptureEvents: bool,
            [<Optional; DefaultParameterValue(null)>] ?ClickToShow: StyleParam.ClickToShow,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Height: int,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?ShowArrow: bool,
            [<Optional; DefaultParameterValue(null)>] ?StandOff: int,
            [<Optional; DefaultParameterValue(null)>] ?StartArrowHead: int,
            [<Optional; DefaultParameterValue(null)>] ?StartArrowSize: float,
            [<Optional; DefaultParameterValue(null)>] ?StartStandOff: int,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Text: string,
            [<Optional; DefaultParameterValue(null)>] ?TextAngle: float,
            [<Optional; DefaultParameterValue(null)>] ?VAlign: StyleParam.VerticalAlign,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?Width: int,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?XClick: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XRef: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?XShift: int,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?YClick: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YRef: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?YShift: int
        ) =
        (fun (ann: Annotation) ->

            ann
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "align" Align StyleParam.AnnotationAlignment.convert
            |> DynObj.withOptionalProperty "arrowcolor" ArrowColor
            |> DynObj.withOptionalPropertyBy "arrowhead" ArrowHead StyleParam.ArrowHead.convert
            |> DynObj.withOptionalPropertyBy "arrowside" ArrowSide StyleParam.ArrowSide.convert
            |> DynObj.withOptionalProperty "arrowsize" ArrowSize
            |> DynObj.withOptionalProperty "ax" AX
            |> DynObj.withOptionalProperty "axref" AXRef
            |> DynObj.withOptionalProperty "ay" AY
            |> DynObj.withOptionalProperty "ayref" AYRef
            |> DynObj.withOptionalProperty "bgcolor" BGColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "borderpad" BorderPad
            |> DynObj.withOptionalProperty "borderwidth" BorderWidth
            |> DynObj.withOptionalProperty "captureevents" CaptureEvents
            |> DynObj.withOptionalPropertyBy "clicktoshow" ClickToShow StyleParam.ClickToShow.convert
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "height" Height
            |> DynObj.withOptionalProperty "hoverlabel" HoverLabel
            |> DynObj.withOptionalProperty "hovertext" HoverText
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "opacity" Opacity
            |> DynObj.withOptionalProperty "showarrow" ShowArrow
            |> DynObj.withOptionalProperty "standoff" StandOff
            |> DynObj.withOptionalProperty "startarrowhead" StartArrowHead
            |> DynObj.withOptionalProperty "startarrowsize" StartArrowSize
            |> DynObj.withOptionalProperty "startstandoff" StartStandOff
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalProperty "text" Text
            |> DynObj.withOptionalProperty "textangle" TextAngle
            |> DynObj.withOptionalPropertyBy "valign" VAlign StyleParam.VerticalAlign.convert
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "width" Width
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "xclick" XClick
            |> DynObj.withOptionalProperty "xref" XRef
            |> DynObj.withOptionalProperty "xshift" XShift
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
            |> DynObj.withOptionalProperty "yclick" YClick
            |> DynObj.withOptionalProperty "yref" YRef
            |> DynObj.withOptionalProperty "yshift" YShift
        )
