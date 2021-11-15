namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj

/// <summary>
/// The layout object for custom slider implementation
/// </summary>
type Slider() =
    inherit DynamicObj ()

    /// <summary>
    /// Initializes the slider with style parameters
    /// </summary>
    /// <param name="Active">Determines which button (by index starting from 0) is considered active</param>
    /// <param name="ActiveBgColor">Sets the background color of the slider grip while dragging</param>
    /// <param name="BgColor">Sets the background color of the slider</param>
    /// <param name="BorderColor">Sets the background color of the slider</param>
    /// <param name="BorderWidth">Sets the color of the border enclosing the slider</param>
    /// <param name="CurrentValue">Object containing the current slider value style</param>
    /// <param name="Font">Sets the font of the slider step labels</param>
    /// <param name="Len">
    /// Sets the length of the slider This measure excludes the padding of both ends.
    /// That is, the slider's length is this length minus the padding on both ends
    /// </param>
    /// <param name="LenMode">
    /// Determines whether this slider length is set in units of plot "fraction" or in "pixels.
    /// Use `len` to set the value
    /// </param>
    /// <param name="MinorTickLen">Sets the length in pixels of minor step tick marks</param>
    /// <param name="Name">
    /// When used in a template, named items are created in the output figure in addition
    /// to any items the figure already has in this array.
    /// You can modify these items in the output figure by making your own item with `templateitemname`
    /// matching this `name` alongside your modifications (including `visible: false` or `enabled: false` to hide it).
    /// Has no effect outside of a template.
    /// </param>
    /// <param name="Padding">Set the padding of the slider component along each side</param>
    /// <param name="Steps">The steps of the slider including step arguments</param>
    /// <param name="TemplateItemName">
    /// Used to refer to a named item in this array in the template.
    /// Named items from the template will be created even without a matching item
    /// in the input figure, but you can modify one by making an item with
    /// `templateitemname` matching its `name`, alongside your modifications
    /// (including `visible: false` or `enabled: false` to hide it).
    /// If there is no template or no matching item, this item will be hidden unless
    /// you explicitly show it with `visible: true`.
    /// </param>
    /// <param name="TickColor">Sets the color of the border enclosing the slider</param>
    /// <param name="TickLen">Sets the length in pixels of step tick marks</param>
    /// <param name="TickWidth">Sets the tick width (in px)</param>
    /// <param name="Transition">Object containing the information about steps transition</param>
    /// <param name="Visible">Determines whether or not the slider is visible</param>
    /// <param name="X">Sets the x position (in normalized coordinates) of the slider</param>
    /// <param name="XAnchor">
    /// Sets the slider's horizontal position anchor.
    /// This anchor binds the `x` position to the "left", "center" or "right" of the range selector
    /// </param>
    /// <param name="Y">Sets the y position (in normalized coordinates) of the slider</param>
    /// <param name="YAnchor">
    /// Sets the slider's vertical position anchor.
    /// This anchor binds the `y` position to the "top", "middle" or "bottom" of the range selector
    /// </param>
    static member init
        (
            ?Active : int,
            ?ActiveBgColor : Color,
            ?BgColor : Color,
            ?BorderColor : Color,
            ?BorderWidth : int,
            ?CurrentValue : SliderCurrentValue,
            ?Font : Font,
            ?Len : float,
            ?LenMode : StyleParam.UnitMode,
            ?MinorTickLen : int,
            ?Name : string,
            ?Padding : Padding,
            ?Steps : seq<SliderStep>,
            ?TemplateItemName : string,
            ?TickColor : Color,
            ?TickLen : int,
            ?TickWidth : int,
            ?Transition : Transition,
            ?Visible : bool,
            ?X : int,
            ?XAnchor : StyleParam.XAnchorPosition,
            ?Y : int,
            ?YAnchor : StyleParam.YAnchorPosition
        ) =
        Slider() |> Slider.style
            (
                ?Active=Active,
                ?ActiveBgColor=ActiveBgColor,
                ?BgColor=BgColor,
                ?BorderColor=BorderColor,
                ?BorderWidth=BorderWidth,
                ?CurrentValue=CurrentValue,
                ?Font=Font,
                ?Len=Len,
                ?LenMode=LenMode,
                ?MinorTickLen=MinorTickLen,
                ?Name=Name,
                ?Padding=Padding,
                ?Steps=Steps,
                ?TemplateItemName=TemplateItemName,
                ?TickColor=TickColor,
                ?TickLen=TickLen,
                ?TickWidth=TickWidth,
                ?Transition=Transition,
                ?Visible=Visible,
                ?X=X,
                ?XAnchor=XAnchor,
                ?Y=Y,
                ?YAnchor=YAnchor
            )

    static member style
        (
            ?Active : int,
            ?ActiveBgColor : Color,
            ?BgColor : Color,
            ?BorderColor : Color,
            ?BorderWidth : int,
            ?CurrentValue : SliderCurrentValue,
            ?Font : Font,
            ?Len : float,
            ?LenMode : StyleParam.UnitMode,
            ?MinorTickLen : int,
            ?Name : string,
            ?Padding : Padding,
            ?Steps : seq<SliderStep>,            
            ?TemplateItemName : string,
            ?TickColor : Color,
            ?TickLen : int,
            ?TickWidth : int,
            ?Transition : Transition,
            ?Visible : bool,
            ?X : int,
            ?XAnchor : StyleParam.XAnchorPosition,
            ?Y : int,
            ?YAnchor : StyleParam.YAnchorPosition
        ) =
            (fun (slider : Slider) ->
                Active           |> DynObj.setValueOpt   slider "active"
                ActiveBgColor    |> DynObj.setValueOpt   slider "activebgcolor"
                BgColor          |> DynObj.setValueOpt   slider "bgcolor"
                BorderColor      |> DynObj.setValueOpt   slider "bordercolor"
                BorderWidth      |> DynObj.setValueOpt   slider "borderwidth"
                CurrentValue     |> DynObj.setValueOpt   slider "currentvalue"
                Font             |> DynObj.setValueOpt   slider "font"
                Len              |> DynObj.setValueOpt   slider "len"
                LenMode          |> DynObj.setValueOptBy slider "lenmode"          StyleParam.UnitMode.convert
                MinorTickLen     |> DynObj.setValueOpt   slider "minorticklen"
                Name             |> DynObj.setValueOpt   slider "name"
                Padding          |> DynObj.setValueOpt   slider "pad"
                Steps            |> DynObj.setValueOpt   slider "steps"
                TemplateItemName |> DynObj.setValueOpt   slider "templateitemname"
                TickColor        |> DynObj.setValueOpt   slider "tickcolor"
                TickLen          |> DynObj.setValueOpt   slider "ticklen"
                TickWidth        |> DynObj.setValueOpt   slider "tickwidth"
                Transition       |> DynObj.setValueOpt   slider "transition"
                Visible          |> DynObj.setValueOpt   slider "visible"
                X                |> DynObj.setValueOpt   slider "x"
                XAnchor          |> DynObj.setValueOptBy slider "xanchor"          StyleParam.XAnchorPosition.convert
                Y                |> DynObj.setValueOpt   slider "y"
                YAnchor          |> DynObj.setValueOptBy slider "yanchor"          StyleParam.YAnchorPosition.convert

                slider
            )