namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Text annotations inside a plot 
type Annotation() = 
    inherit DynamicObj ()

    /// Init Annotation type
    static member init 
        (
            ?X                  : #IConvertible,
            ?Y                  : #IConvertible,
            ?Align              : StyleParam.AnnotationAlignment,
            ?ArrowColor         : Color,
            ?ArrowHead          : StyleParam.ArrowHead,
            ?ArrowSide          : StyleParam.ArrowSide,
            ?ArrowSize          : float,
            ?AX                 : #IConvertible,
            ?AXRef              : #IConvertible,            
            ?AY                 : #IConvertible,
            ?AYRef              : #IConvertible,
            ?BGColor            : Color,
            ?BorderColor        : Color,
            ?BorderPad          : int,
            ?BorderWidth        : int,
            ?CaptureEvents      : bool,
            ?ClickToShow        : StyleParam.ClickToShow,
            ?Font               : Font,
            ?Height             : int,
            ?HoverLabel         : Hoverlabel,
            ?HoverText          : string,
            ?Name               : string,
            ?Opacity            : float,
            ?ShowArrow          : bool,
            ?StandOff           : int,
            ?StartArrowHead     : int,
            ?StartArrowSize     : float,
            ?StartStandOff      : int,
            ?TemplateItemName   : string,
            ?Text               : string,
            ?TextAngle          : float,
            ?VAlign             : StyleParam.VerticalAlign,
            ?Visible            : bool,
            ?Width              : int,
            ?XAnchor            : StyleParam.XAnchorPosition,
            ?XClick             : #IConvertible,
            ?XRef               : #IConvertible,
            ?XShift             : int,
            ?YAnchor            : StyleParam.YAnchorPosition,
            ?YClick             : #IConvertible,
            ?YRef               : #IConvertible,
            ?YShift             : int
        ) =
            Annotation()
            |> Annotation.style
                (
                    ?Align               = Align               ,
                    ?ArrowColor          = ArrowColor          ,
                    ?ArrowHead           = ArrowHead           ,
                    ?ArrowSide           = ArrowSide           ,
                    ?ArrowSize           = ArrowSize           ,
                    ?AX                  = AX                  ,
                    ?AXRef               = AXRef               ,
                    ?AY                  = AY                  ,
                    ?AYRef               = AYRef               ,
                    ?BGColor             = BGColor             ,
                    ?BorderColor         = BorderColor         ,
                    ?BorderPad           = BorderPad           ,
                    ?BorderWidth         = BorderWidth         ,
                    ?CaptureEvents       = CaptureEvents       ,
                    ?ClickToShow         = ClickToShow         ,
                    ?Font                = Font                ,
                    ?Height              = Height              ,
                    ?HoverLabel          = HoverLabel          ,
                    ?HoverText           = HoverText           ,
                    ?Name                = Name                ,
                    ?Opacity             = Opacity             ,
                    ?ShowArrow           = ShowArrow           ,
                    ?StandOff            = StandOff            ,
                    ?StartArrowHead      = StartArrowHead      ,
                    ?StartArrowSize      = StartArrowSize      ,
                    ?StartStandOff       = StartStandOff       ,
                    ?TemplateItemName    = TemplateItemName    ,
                    ?Text                = Text                ,
                    ?TextAngle           = TextAngle           ,
                    ?VAlign              = VAlign              ,
                    ?Visible             = Visible             ,
                    ?Width               = Width               ,
                    ?X                   = X                   ,
                    ?XAnchor             = XAnchor             ,
                    ?XClick              = XClick              ,
                    ?XRef                = XRef                ,
                    ?XShift              = XShift              ,
                    ?Y                   = Y                   ,
                    ?YAnchor             = YAnchor             ,
                    ?YClick              = YClick              ,
                    ?YRef                = YRef                ,
                    ?YShift              = YShift              
                )

    static member style 
        (
            ?X                  : #IConvertible,
            ?Y                  : #IConvertible,
            ?Align              : StyleParam.AnnotationAlignment,
            ?ArrowColor         : Color,
            ?ArrowHead          : StyleParam.ArrowHead,
            ?ArrowSide          : StyleParam.ArrowSide,
            ?ArrowSize          : float,
            ?AX                 : #IConvertible,
            ?AXRef              : #IConvertible,            
            ?AY                 : #IConvertible,
            ?AYRef              : #IConvertible,
            ?BGColor            : Color,
            ?BorderColor        : Color,
            ?BorderPad          : int,
            ?BorderWidth        : int,
            ?CaptureEvents      : bool,
            ?ClickToShow        : StyleParam.ClickToShow,
            ?Font               : Font,
            ?Height             : int,
            ?HoverLabel         : Hoverlabel,
            ?HoverText          : string,
            ?Name               : string,
            ?Opacity            : float,
            ?ShowArrow          : bool,
            ?StandOff           : int,
            ?StartArrowHead     : int,
            ?StartArrowSize     : float,
            ?StartStandOff      : int,
            ?TemplateItemName   : string,
            ?Text               : string,
            ?TextAngle          : float,
            ?VAlign             : StyleParam.VerticalAlign,
            ?Visible            : bool,
            ?Width              : int,
            ?XAnchor            : StyleParam.XAnchorPosition,
            ?XClick             : #IConvertible,
            ?XRef               : #IConvertible,
            ?XShift             : int,
            ?YAnchor            : StyleParam.YAnchorPosition,
            ?YClick             : #IConvertible,
            ?YRef               : #IConvertible,
            ?YShift             : int
        ) =
            (fun (ann:Annotation) ->
                
                X                   |> DynObj.setValueOpt ann "x"
                Y                   |> DynObj.setValueOpt ann "y"
                Align               |> DynObj.setValueOptBy ann "align" StyleParam.AnnotationAlignment.convert
                ArrowColor          |> DynObj.setValueOpt ann "arrowcolor"
                ArrowHead           |> DynObj.setValueOptBy ann "arrowhead" StyleParam.ArrowHead.convert
                ArrowSide           |> DynObj.setValueOptBy ann "arrowside" StyleParam.ArrowSide.convert
                ArrowSize           |> DynObj.setValueOpt ann "arrowsize"
                AX                  |> DynObj.setValueOpt ann "ax"
                AXRef               |> DynObj.setValueOpt ann "axref"
                AY                  |> DynObj.setValueOpt ann "ay"
                AYRef               |> DynObj.setValueOpt ann "ayref"
                BGColor             |> DynObj.setValueOpt ann "bgcolor"
                BorderColor         |> DynObj.setValueOpt ann "bordercolor"
                BorderPad           |> DynObj.setValueOpt ann "borderpad"
                BorderWidth         |> DynObj.setValueOpt ann "borderwidth"
                CaptureEvents       |> DynObj.setValueOpt ann "captureevents"
                ClickToShow         |> DynObj.setValueOptBy ann "clicktoshow" StyleParam.ClickToShow.convert
                Font                |> DynObj.setValueOpt ann "font"
                Height              |> DynObj.setValueOpt ann "height"
                HoverLabel          |> DynObj.setValueOpt ann "hoverlabel"
                HoverText           |> DynObj.setValueOpt ann "hovertext"
                Name                |> DynObj.setValueOpt ann "name"
                Opacity             |> DynObj.setValueOpt ann "opacity"
                ShowArrow           |> DynObj.setValueOpt ann "showarrow"
                StandOff            |> DynObj.setValueOpt ann "standoff"
                StartArrowHead      |> DynObj.setValueOpt ann "startarrowhead"
                StartArrowSize      |> DynObj.setValueOpt ann "startarrowsize"
                StartStandOff       |> DynObj.setValueOpt ann "startstandoff"
                TemplateItemName    |> DynObj.setValueOpt ann "templateitemname"
                Text                |> DynObj.setValueOpt ann "text"
                TextAngle           |> DynObj.setValueOpt ann "textangle"
                VAlign              |> DynObj.setValueOptBy ann "valign" StyleParam.VerticalAlign.convert
                Visible             |> DynObj.setValueOpt ann "visible"
                Width               |> DynObj.setValueOpt ann "width"
                XAnchor             |> DynObj.setValueOptBy ann "xanchor" StyleParam.XAnchorPosition.convert
                XClick              |> DynObj.setValueOpt ann "xclick"
                XRef                |> DynObj.setValueOpt ann "xref"
                XShift              |> DynObj.setValueOpt ann "xshift"
                YAnchor             |> DynObj.setValueOptBy ann "yanchor" StyleParam.YAnchorPosition.convert
                YClick              |> DynObj.setValueOpt ann "yclick"
                YRef                |> DynObj.setValueOpt ann "yref"
                YShift              |> DynObj.setValueOpt ann "yshift"

                ann
            )