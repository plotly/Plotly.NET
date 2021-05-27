namespace Plotly.NET

/// Text annotations inside a plot 
type Annotation() = 
    inherit DynamicObj ()

    /// Init Annotation type
    static member init 
        (
            X               : System.IConvertible,
            Y               : System.IConvertible,
            ?XRef           : System.IConvertible,
            ?YRef           : System.IConvertible,
            ?ArrowTailX     : float,
            ?ArrowTailY     : float,
            ?ShowArrow      : bool,
            ?ArrowColor     : string,
            ?ArrowHead      : StyleParam.ArrowHead,
            ?ArrowSize      : float,
            ?ArrowWidth     : float,
            ?Z              : float,
            ?Text           : string,
            ?TextAngle      : float,
            ?Font           : Font,
            ?Width          : float,
            ?Height         : float,
            ?Opacity        : float,
            ?HorizontalAlign: StyleParam.HorizontalAlign,
            ?VerticalAlign  : StyleParam.VerticalAlign,
            ?BGColor        : string,
            ?BorderColor    : string,
            ?Visible        : bool
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
            ?XRef           : System.IConvertible,
            ?YRef           : System.IConvertible,
            ?ArrowTailX     : float,
            ?ArrowTailY     : float,
            ?ShowArrow      : bool,
            ?ArrowColor     : string,
            ?ArrowHead      : StyleParam.ArrowHead,
            ?ArrowSize      : float,
            ?ArrowWidth     : float,
            ?Z              : float,
            ?Text           : string,
            ?TextAngle      : float,
            ?Font           : Font,
            ?Width          : float,
            ?Height         : float,
            ?Opacity        : float,
            ?HorizontalAlign: StyleParam.HorizontalAlign,
            ?VerticalAlign  : StyleParam.VerticalAlign,
            ?BGColor        : string,
            ?BorderColor    : string,
            ?Visible        : bool

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