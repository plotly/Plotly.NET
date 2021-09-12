namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Text annotations inside a plot 
type Annotation() = 
    inherit ImmutableDynamicObj ()

    /// Init Annotation type
    static member init 
        (
            X               : System.IConvertible,
            Y               : System.IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?XRef           : System.IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?YRef           : System.IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?ArrowTailX     : float,
            [<Optional;DefaultParameterValue(null)>] ?ArrowTailY     : float,
            [<Optional;DefaultParameterValue(null)>] ?ShowArrow      : bool,
            [<Optional;DefaultParameterValue(null)>] ?ArrowColor     : Color,
            [<Optional;DefaultParameterValue(null)>] ?ArrowHead      : StyleParam.ArrowHead,
            [<Optional;DefaultParameterValue(null)>] ?ArrowSize      : float,
            [<Optional;DefaultParameterValue(null)>] ?ArrowWidth     : float,
            [<Optional;DefaultParameterValue(null)>] ?Z              : float,
            [<Optional;DefaultParameterValue(null)>] ?Text           : string,
            [<Optional;DefaultParameterValue(null)>] ?TextAngle      : float,
            [<Optional;DefaultParameterValue(null)>] ?Font           : Font,
            [<Optional;DefaultParameterValue(null)>] ?Width          : float,
            [<Optional;DefaultParameterValue(null)>] ?Height         : float,
            [<Optional;DefaultParameterValue(null)>] ?Opacity        : float,
            [<Optional;DefaultParameterValue(null)>] ?HorizontalAlign: StyleParam.HorizontalAlign,
            [<Optional;DefaultParameterValue(null)>] ?VerticalAlign  : StyleParam.VerticalAlign,
            [<Optional;DefaultParameterValue(null)>] ?BGColor        : Color,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor    : Color,
            [<Optional;DefaultParameterValue(null)>] ?Visible        : bool
        ) =
            Annotation()
            |> Annotation.style
                (
                    X                = X               ,
                    Y                = Y               ,
                    ?XRef            = XRef            ,
                    ?YRef            = YRef            ,
                    ?ArrowTailX      = ArrowTailX      ,
                    ?ArrowTailY      = ArrowTailY      ,
                    ?ShowArrow       = ShowArrow       ,
                    ?ArrowColor      = ArrowColor      ,
                    ?ArrowHead       = ArrowHead       ,
                    ?ArrowSize       = ArrowSize       ,
                    ?ArrowWidth      = ArrowWidth      ,
                    ?Z               = Z               ,
                    ?Text            = Text            ,
                    ?TextAngle       = TextAngle       ,
                    ?Font            = Font            ,
                    ?Width           = Width           ,
                    ?Height          = Height          ,
                    ?Opacity         = Opacity         ,
                    ?HorizontalAlign = HorizontalAlign ,
                    ?VerticalAlign   = VerticalAlign   ,
                    ?BGColor         = BGColor         ,
                    ?BorderColor     = BorderColor     ,
                    ?Visible         = Visible        
                )

    static member style 
        (
            X               : System.IConvertible,
            Y               : System.IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?XRef           : System.IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?YRef           : System.IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?ArrowTailX     : float,
            [<Optional;DefaultParameterValue(null)>] ?ArrowTailY     : float,
            [<Optional;DefaultParameterValue(null)>] ?ShowArrow      : bool,
            [<Optional;DefaultParameterValue(null)>] ?ArrowColor     : Color,
            [<Optional;DefaultParameterValue(null)>] ?ArrowHead      : StyleParam.ArrowHead,
            [<Optional;DefaultParameterValue(null)>] ?ArrowSize      : float,
            [<Optional;DefaultParameterValue(null)>] ?ArrowWidth     : float,
            [<Optional;DefaultParameterValue(null)>] ?Z              : float,
            [<Optional;DefaultParameterValue(null)>] ?Text           : string,
            [<Optional;DefaultParameterValue(null)>] ?TextAngle      : float,
            [<Optional;DefaultParameterValue(null)>] ?Font           : Font,
            [<Optional;DefaultParameterValue(null)>] ?Width          : float,
            [<Optional;DefaultParameterValue(null)>] ?Height         : float,
            [<Optional;DefaultParameterValue(null)>] ?Opacity        : float,
            [<Optional;DefaultParameterValue(null)>] ?HorizontalAlign: StyleParam.HorizontalAlign,
            [<Optional;DefaultParameterValue(null)>] ?VerticalAlign  : StyleParam.VerticalAlign,
            [<Optional;DefaultParameterValue(null)>] ?BGColor        : Color,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor    : Color,
            [<Optional;DefaultParameterValue(null)>] ?Visible        : bool

        ) =
            (fun (ann:Annotation) ->

                ann
                ++? ("x", X)
                ++? ("y", Y)
                ++? ("xref", XRef)
                ++? ("yref", YRef)
                ++? ("ax", ArrowTailX)
                ++? ("ay", ArrowTailY)
                ++?? ("arrowhead", ArrowHead, StyleParam.ArrowHead.convert)
                ++? ("arrowsize", ArrowSize)
                ++? ("arrowwidth", ArrowWidth)
                ++? ("showarrow", ShowArrow)
                ++? ("arrowcolor", ArrowColor)
                ++? ("z", Z)
                ++? ("text", Text)
                ++? ("textangle", TextAngle)
                ++? ("font", Font)
                ++? ("width", Width)
                ++? ("height", Height)
                ++? ("opacity", Opacity)
                ++?? ("align", HorizontalAlign, StyleParam.HorizontalAlign.convert)
                ++?? ("valign", VerticalAlign, StyleParam.VerticalAlign.convert)
                ++? ("bgcolor", BGColor)
                ++? ("bordercolor", BorderColor)
                ++? ("visible", Visible)
            )