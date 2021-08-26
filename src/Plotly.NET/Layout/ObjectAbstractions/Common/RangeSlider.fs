namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

//rangeslider
//Parent: layout.xaxis
//Type: object containing one or more of the keys listed below.
type RangeSlider () = 
    inherit DynamicObj ()

    static member init 
        (
            ///Sets the background color of the range slider.
            ///Sets the border color of the range slider.
            //Sets the border width of the range slider.
            //Determines whether or not the range slider range is computed in relation to the input data. If `range` is provided, then `autorange` is set to "false".
            //Sets the range of the range slider. If not set, defaults to the full xaxis range. If the axis `type` is "log", then you must take the log of your desired range. If the axis `type` is "date", it should be date strings, like date data, though Date objects and unix milliseconds will be accepted and converted to strings. If the axis `type` is "category", it should be numbers, using the scale where each category is assigned a serial number from zero in the order it appears.
            //The height of the range slider as a fraction of the total plot area height.
            //Determines whether or not the range of this axis in the rangeslider use the same value than in the main plot when zooming in/out. If "auto", the autorange will be used. If "fixed", the `range` is used. If "match", the current range of the corresponding y-axis on the main subplot is used. one of ( "auto" | "fixed" | "match" )
            //Sets the range of this axis for the rangeslider.
            [<Optional;DefaultParameterValue(null)>] ?BgColor: string,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor: string,
            [<Optional;DefaultParameterValue(null)>] ?BorderWidth: float,
            [<Optional;DefaultParameterValue(null)>] ?AutoRange : bool ,
            [<Optional;DefaultParameterValue(null)>] ?Range: seq<#IConvertible>  ,
            [<Optional;DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?YAxisRangeMode: StyleParam.RangeMode,
            [<Optional;DefaultParameterValue(null)>] ?YAxisRange: seq<#IConvertible>
        ) = 
            RangeSlider ()
            |> RangeSlider.style (
                ?BgColor        = BgColor          ,
                ?BorderColor    = BorderColor      ,
                ?BorderWidth    = BorderWidth      ,
                ?AutoRange      = AutoRange        ,
                ?Range          = Range            ,
                ?Thickness      = Thickness        ,
                ?Visible        = Visible          ,
                ?YAxisRangeMode = YAxisRangeMode   ,
                ?YAxisRange     = YAxisRange    
            )


    static member style 
        (
            ///Sets the background color of the range slider.
            ///Sets the border color of the range slider.
            //Sets the border width of the range slider.
            //Determines whether or not the range slider range is computed in relation to the input data. If `range` is provided, then `autorange` is set to "false".
            //Sets the range of the range slider. If not set, defaults to the full xaxis range. If the axis `type` is "log", then you must take the log of your desired range. If the axis `type` is "date", it should be date strings, like date data, though Date objects and unix milliseconds will be accepted and converted to strings. If the axis `type` is "category", it should be numbers, using the scale where each category is assigned a serial number from zero in the order it appears.
            //The height of the range slider as a fraction of the total plot area height.
            //Determines whether or not the range of this axis in the rangeslider use the same value than in the main plot when zooming in/out. If "auto", the autorange will be used. If "fixed", the `range` is used. If "match", the current range of the corresponding y-axis on the main subplot is used. one of ( "auto" | "fixed" | "match" )
            //Sets the range of this axis for the rangeslider.
            [<Optional;DefaultParameterValue(null)>] ?BgColor: string,
            [<Optional;DefaultParameterValue(null)>] ?BorderColor: string,
            [<Optional;DefaultParameterValue(null)>] ?BorderWidth: float,
            [<Optional;DefaultParameterValue(null)>] ?AutoRange : bool,
            [<Optional;DefaultParameterValue(null)>] ?Range: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?YAxisRangeMode: StyleParam.RangeMode,
            [<Optional;DefaultParameterValue(null)>] ?YAxisRange: seq<#IConvertible>
        ) = 
            fun (rangeslider : RangeSlider) ->
                BgColor        |> DynObj.setValueOpt rangeslider "bgcolor"
                BorderColor    |> DynObj.setValueOpt rangeslider "BorderColor"
                BorderWidth    |> DynObj.setValueOpt rangeslider "BorderWidth"
                AutoRange      |> DynObj.setValueOpt rangeslider "AutoRange"
                Range          |> DynObj.setValueOpt rangeslider "range"
                Thickness      |> DynObj.setValueOpt rangeslider "thickness"
                Visible        |> DynObj.setValueOpt rangeslider "visible"

                let yAxis = 
                    let tmp = DynamicObj()
                    YAxisRangeMode  |> DynObj.setValueOpt tmp "rangemode" 
                    YAxisRange      |> DynObj.setValueOpt tmp "range" 
                    tmp

                yAxis |> DynObj.setValue rangeslider "yaxis"


                rangeslider