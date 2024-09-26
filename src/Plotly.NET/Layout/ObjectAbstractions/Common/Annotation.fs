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

            X |> DynObj.setOptionalProperty ann "x"
            Y |> DynObj.setOptionalProperty ann "y"
            Align |> DynObj.setOptionalPropertyBy ann "align" StyleParam.AnnotationAlignment.convert
            ArrowColor |> DynObj.setOptionalProperty ann "arrowcolor"
            ArrowHead |> DynObj.setOptionalPropertyBy ann "arrowhead" StyleParam.ArrowHead.convert
            ArrowSide |> DynObj.setOptionalPropertyBy ann "arrowside" StyleParam.ArrowSide.convert
            ArrowSize |> DynObj.setOptionalProperty ann "arrowsize"
            AX |> DynObj.setOptionalProperty ann "ax"
            AXRef |> DynObj.setOptionalProperty ann "axref"
            AY |> DynObj.setOptionalProperty ann "ay"
            AYRef |> DynObj.setOptionalProperty ann "ayref"
            BGColor |> DynObj.setOptionalProperty ann "bgcolor"
            BorderColor |> DynObj.setOptionalProperty ann "bordercolor"
            BorderPad |> DynObj.setOptionalProperty ann "borderpad"
            BorderWidth |> DynObj.setOptionalProperty ann "borderwidth"
            CaptureEvents |> DynObj.setOptionalProperty ann "captureevents"
            ClickToShow |> DynObj.setOptionalPropertyBy ann "clicktoshow" StyleParam.ClickToShow.convert
            Font |> DynObj.setOptionalProperty ann "font"
            Height |> DynObj.setOptionalProperty ann "height"
            HoverLabel |> DynObj.setOptionalProperty ann "hoverlabel"
            HoverText |> DynObj.setOptionalProperty ann "hovertext"
            Name |> DynObj.setOptionalProperty ann "name"
            Opacity |> DynObj.setOptionalProperty ann "opacity"
            ShowArrow |> DynObj.setOptionalProperty ann "showarrow"
            StandOff |> DynObj.setOptionalProperty ann "standoff"
            StartArrowHead |> DynObj.setOptionalProperty ann "startarrowhead"
            StartArrowSize |> DynObj.setOptionalProperty ann "startarrowsize"
            StartStandOff |> DynObj.setOptionalProperty ann "startstandoff"
            TemplateItemName |> DynObj.setOptionalProperty ann "templateitemname"
            Text |> DynObj.setOptionalProperty ann "text"
            TextAngle |> DynObj.setOptionalProperty ann "textangle"
            VAlign |> DynObj.setOptionalPropertyBy ann "valign" StyleParam.VerticalAlign.convert
            Visible |> DynObj.setOptionalProperty ann "visible"
            Width |> DynObj.setOptionalProperty ann "width"
            XAnchor |> DynObj.setOptionalPropertyBy ann "xanchor" StyleParam.XAnchorPosition.convert
            XClick |> DynObj.setOptionalProperty ann "xclick"
            XRef |> DynObj.setOptionalProperty ann "xref"
            XShift |> DynObj.setOptionalProperty ann "xshift"
            YAnchor |> DynObj.setOptionalPropertyBy ann "yanchor" StyleParam.YAnchorPosition.convert
            YClick |> DynObj.setOptionalProperty ann "yclick"
            YRef |> DynObj.setOptionalProperty ann "yref"
            YShift |> DynObj.setOptionalProperty ann "yshift"

            ann)
