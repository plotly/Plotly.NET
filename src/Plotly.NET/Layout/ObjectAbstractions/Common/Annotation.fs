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
            X               : System.IConvertible,
            Y               : System.IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?XRef           ,
            [<Optional;DefaultParameterValue(null)>] ?YRef           ,
            [<Optional;DefaultParameterValue(null)>] ?ArrowTailX     ,
            [<Optional;DefaultParameterValue(null)>] ?ArrowTailY     ,
            [<Optional;DefaultParameterValue(null)>] ?ShowArrow      ,
            [<Optional;DefaultParameterValue(null)>] ?ArrowColor     ,
            [<Optional;DefaultParameterValue(null)>] ?ArrowHead      ,
            [<Optional;DefaultParameterValue(null)>] ?ArrowSize      ,
            [<Optional;DefaultParameterValue(null)>] ?ArrowWidth     ,
            [<Optional;DefaultParameterValue(null)>] ?Z              ,
            [<Optional;DefaultParameterValue(null)>] ?Text           ,
            [<Optional;DefaultParameterValue(null)>] ?TextAngle      ,
            [<Optional;DefaultParameterValue(null)>] ?Font           ,
            [<Optional;DefaultParameterValue(null)>] ?Width          ,
            [<Optional;DefaultParameterValue(null)>] ?Height         ,
            [<Optional;DefaultParameterValue(null)>] ?Opacity        ,
            [<Optional;DefaultParameterValue(null)>] ?HorizontalAlign,
            [<Optional;DefaultParameterValue(null)>] ?VerticalAlign  ,
            [<Optional;DefaultParameterValue(null)>] ?BGColor        ,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor    ,
            [<Optional;DefaultParameterValue(null)>] ?Visible        
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
            [<Optional;DefaultParameterValue(null)>] ?ArrowColor     : string,
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
                X               |> DynObj.setValue ann "x"
                Y               |> DynObj.setValue ann "y"
                XRef            |> DynObj.setValueOpt ann "xref"
                YRef            |> DynObj.setValueOpt ann "yref"
                ArrowTailX      |> DynObj.setValueOpt ann "ax"
                ArrowTailY      |> DynObj.setValueOpt ann "ay"
                ArrowHead       |> DynObj.setValueOptBy ann "arrowhead" StyleParam.ArrowHead.convert
                ArrowSize       |> DynObj.setValueOpt ann "arrowsize"
                ArrowWidth      |> DynObj.setValueOpt ann "arrowwidth"
                ShowArrow       |> DynObj.setValueOpt ann "showarrow"
                ArrowColor      |> DynObj.setValueOpt ann "arrowcolor"
                Z               |> DynObj.setValueOpt ann "z"
                Text            |> DynObj.setValueOpt ann "text"
                TextAngle       |> DynObj.setValueOpt ann "textangle"
                Font            |> DynObj.setValueOpt ann "font"
                Width           |> DynObj.setValueOpt ann "width"
                Height          |> DynObj.setValueOpt ann "height"
                Opacity         |> DynObj.setValueOpt ann "opacity"
                HorizontalAlign |> DynObj.setValueOptBy ann "align" StyleParam.HorizontalAlign.convert
                VerticalAlign   |> DynObj.setValueOptBy ann "valign" StyleParam.VerticalAlign.convert
                BGColor         |> DynObj.setValueOpt ann "bgcolor"
                BorderColor     |> DynObj.setValueOpt ann "bordercolor"
                Visible         |> DynObj.setValueOpt ann "visible"

                ann
            )