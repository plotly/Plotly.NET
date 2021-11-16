namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj

type SliderCurrentValue() =
    inherit DynamicObj ()

    /// <summary>
    /// Object containing the current slider value style
    /// </summary>
    /// <param name="Font">Sets the font of the current value label text</param>
    /// <param name="Offset">The amount of space, in pixels, between the current value label and the slider</param>
    /// <param name="Prefix">When currentvalue.visible is true, this sets the prefix of the label</param>
    /// <param name="Suffix">When currentvalue.visible is true, this sets the suffix of the label</param>
    /// <param name="Visible">Shows the currently-selected value above the slider</param>
    /// <param name="XAnchor">The alignment of the value readout relative to the length of the slider</param>
    static member init
        (
            ?Font : Font,
            ?Offset : int,
            ?Prefix : string,
            ?Suffix : string,
            ?Visible : bool,
            ?XAnchor : StyleParam.XAnchorPosition

        ) = SliderCurrentValue() |> SliderCurrentValue.style
                (
                    ?Font=Font,
                    ?Offset=Offset,
                    ?Prefix=Prefix,
                    ?Suffix=Suffix,
                    ?Visible=Visible,
                    ?XAnchor=XAnchor
                )

    static member style
        (
            ?Font : Font,
            ?Offset : int,
            ?Prefix : string,
            ?Suffix : string,
            ?Visible : bool,
            ?XAnchor : StyleParam.XAnchorPosition
        ) = (fun (currentValue : SliderCurrentValue) -> 
                let autoValueIsProvided = XAnchor |>
                                            Option.exists (fun xAnchor -> xAnchor = StyleParam.XAnchorPosition.Auto)
                if autoValueIsProvided
                    then printf "The value '%s' is not supported by CurrentValue" (StyleParam.XAnchorPosition.Auto |> string)

                Font    |> DynObj.setValueOpt currentValue "font"
                Offset  |> DynObj.setValueOpt currentValue "offset"
                Prefix  |> DynObj.setValueOpt currentValue "prefix"
                Suffix  |> DynObj.setValueOpt currentValue "suffix"
                Visible |> DynObj.setValueOpt currentValue "visible"
                XAnchor |> DynObj.setValueOptBy currentValue "xanchor" StyleParam.XAnchorPosition.convert
                currentValue
            )