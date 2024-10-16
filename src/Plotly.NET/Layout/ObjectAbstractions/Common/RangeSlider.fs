﻿namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

//rangeslider
//Parent: layout.xaxis
//Type: object containing one or more of the keys listed below.
type RangeSlider() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?BgColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?AutoRange: bool,
            [<Optional; DefaultParameterValue(null)>] ?Range: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?YAxisRangeMode: StyleParam.RangesliderRangeMode,
            [<Optional; DefaultParameterValue(null)>] ?YAxisRange: StyleParam.Range
        ) =
        RangeSlider()
        |> RangeSlider.style (
            ?BgColor = BgColor,
            ?BorderColor = BorderColor,
            ?BorderWidth = BorderWidth,
            ?AutoRange = AutoRange,
            ?Range = Range,
            ?Thickness = Thickness,
            ?Visible = Visible,
            ?YAxisRangeMode = YAxisRangeMode,
            ?YAxisRange = YAxisRange
        )


    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?BgColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?AutoRange: bool,
            [<Optional; DefaultParameterValue(null)>] ?Range: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?YAxisRangeMode: StyleParam.RangesliderRangeMode,
            [<Optional; DefaultParameterValue(null)>] ?YAxisRange: StyleParam.Range
        ) =
        fun (rangeslider: RangeSlider) ->

            let yAxis =
                DynamicObj()
                |> DynObj.withOptionalPropertyBy "rangemode" YAxisRangeMode StyleParam.RangesliderRangeMode.convert
                |> DynObj.withOptionalPropertyBy "range" YAxisRange StyleParam.Range.convert

            rangeslider
            |> DynObj.withOptionalProperty "bgcolor" BgColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "borderwidth" BorderWidth
            |> DynObj.withOptionalProperty "autorange" AutoRange
            |> DynObj.withOptionalPropertyBy "range" Range StyleParam.Range.convert
            |> DynObj.withOptionalProperty "thickness" Thickness
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withProperty "yaxis" yAxis

