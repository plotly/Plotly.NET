namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Hoverlabels that appear while hovering over elements on charts
type Hoverlabel() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Hoverlabel object with the given styles
    /// </summary>
    /// <param name="Align">Sets the horizontal alignment of the text content within hover label box. Has an effect only if the hover label text spans more two or more lines</param>
    /// <param name="BgColor">Sets the background color of all hover labels on graph</param>
    /// <param name="BorderColor">Sets the border color of all hover labels on graph.</param>
    /// <param name="Font">Sets the default hover label font used by all traces on the graph.</param>
    /// <param name="GroupTitleFont">Sets the font for group titles in hover (unified modes). Defaults to `hoverlabel.font`.</param>
    /// <param name="Namelength">Sets the default length (in number of characters) of the trace name in the hover labels for all traces. -1 shows the whole name regardless of length. 0-3 shows the first 0-3 characters, and an integer &gt;3 will show the whole name if it is less than that many characters, but if it is longer, will truncate to `namelength - 3` characters and add an ellipsis.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.Align,
            [<Optional; DefaultParameterValue(null)>] ?BgColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?GroupTitleFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Namelength: int
        ) =
        Hoverlabel()
        |> Hoverlabel.style (
            ?BgColor = BgColor,
            ?BorderColor = BorderColor,
            ?Font = Font,
            ?GroupTitleFont = GroupTitleFont,
            ?Align = Align,
            ?Namelength = Namelength
        )


    /// <summary>
    /// Returns a function that applies the given styles to a Legend object
    /// </summary>
    /// <param name="Align">Sets the horizontal alignment of the text content within hover label box. Has an effect only if the hover label text spans more two or more lines</param>
    /// <param name="BgColor">Sets the background color of all hover labels on graph</param>
    /// <param name="BorderColor">Sets the border color of all hover labels on graph.</param>
    /// <param name="Font">Sets the default hover label font used by all traces on the graph.</param>
    /// <param name="GroupTitleFont">Sets the font for group titles in hover (unified modes). Defaults to `hoverlabel.font`.</param>
    /// <param name="Namelength">Sets the default length (in number of characters) of the trace name in the hover labels for all traces. -1 shows the whole name regardless of length. 0-3 shows the first 0-3 characters, and an integer &gt;3 will show the whole name if it is less than that many characters, but if it is longer, will truncate to `namelength - 3` characters and add an ellipsis.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?BgColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?GroupTitleFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.Align,
            [<Optional; DefaultParameterValue(null)>] ?Namelength: int
        ) =
        (fun (label: Hoverlabel) ->
            BgColor |> DynObj.setValueOpt label "bgcolor"
            BorderColor |> DynObj.setValueOpt label "bordercolor"
            Font |> DynObj.setValueOpt label "font"
            GroupTitleFont |> DynObj.setValueOpt label "grouptitlefont"
            Align |> DynObj.setValueOptBy label "align" StyleParam.Align.convert
            Namelength |> DynObj.setValueOpt label "namelength"

            label)
