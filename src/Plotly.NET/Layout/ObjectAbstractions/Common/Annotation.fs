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
                
                ++? ("x", X                   )
                ++? ("y", Y                   )
                Align               |> DynObj.setValueOptBy ann "align" StyleParam.AnnotationAlignment.convert
                ++? ("arrowcolor", ArrowColor          )
                ArrowHead           |> DynObj.setValueOptBy ann "arrowhead" StyleParam.ArrowHead.convert
                ArrowSide           |> DynObj.setValueOptBy ann "arrowside" StyleParam.ArrowSide.convert
                ++? ("arrowsize", ArrowSize           )
                ++? ("ax", AX                  )
                ++? ("axref", AXRef               )
                ++? ("ay", AY                  )
                ++? ("ayref", AYRef               )
                ++? ("bgcolor", BGColor             )
                ++? ("bordercolor", BorderColor         )
                ++? ("borderpad", BorderPad           )
                ++? ("borderwidth", BorderWidth         )
                ++? ("captureevents", CaptureEvents       )
                ClickToShow         |> DynObj.setValueOptBy ann "clicktoshow" StyleParam.ClickToShow.convert
                ++? ("font", Font                )
                ++? ("height", Height              )
                ++? ("hoverlabel", HoverLabel          )
                ++? ("hovertext", HoverText           )
                ++? ("name", Name                )
                ++? ("opacity", Opacity             )
                ++? ("showarrow", ShowArrow           )
                ++? ("standoff", StandOff            )
                ++? ("startarrowhead", StartArrowHead      )
                ++? ("startarrowsize", StartArrowSize      )
                ++? ("startstandoff", StartStandOff       )
                ++? ("templateitemname", TemplateItemName    )
                ++? ("text", Text                )
                ++? ("textangle", TextAngle           )
                VAlign              |> DynObj.setValueOptBy ann "valign" StyleParam.VerticalAlign.convert
                ++? ("visible", Visible             )
                ++? ("width", Width               )
                XAnchor             |> DynObj.setValueOptBy ann "xanchor" StyleParam.XAnchorPosition.convert
                ++? ("xclick", XClick              )
                ++? ("xref", XRef                )
                ++? ("xshift", XShift              )
                YAnchor             |> DynObj.setValueOptBy ann "yanchor" StyleParam.YAnchorPosition.convert
                ++? ("yclick", YClick              )
                ++? ("yref", YRef                )
                ++? ("yshift", YShift              )

                ann
            )