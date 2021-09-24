namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open GenericChart
open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartCarpet =

    [<Extension>]
    type Chart =

        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
        [<Extension>]
        static member Carpet
            (
                carpetId: string,
                [<Optional;DefaultParameterValue(null)>] ?Name              : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,  
                [<Optional;DefaultParameterValue(null)>] ?X                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?MultiX            : seq<#seq<#IConvertible>>,
                [<Optional;DefaultParameterValue(null)>] ?Y                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?MultiY            : seq<#seq<#IConvertible>>,
                [<Optional;DefaultParameterValue(null)>] ?A                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?B                 : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?AAxis             : LinearAxis,
                [<Optional;DefaultParameterValue(null)>] ?BAxis             : LinearAxis,
                [<Optional;DefaultParameterValue(null)>] ?XAxis             : StyleParam.SubPlotId,
                [<Optional;DefaultParameterValue(null)>] ?YAxis             : StyleParam.SubPlotId,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?CheaterSlope      : float
            ) =
                TraceCarpet.initCarpet(
                    TraceCarpetStyle.Carpet(
                        Carpet          = StyleParam.SubPlotId.Carpet carpetId,
                        ?Name           = Name        ,
                        ?ShowLegend     = ShowLegend  ,
                        ?Opacity        = Opacity     ,
                        ?X              = X           ,
                        ?MultiX         = MultiX      ,
                        ?Y              = Y           ,
                        ?MultiY         = MultiY      ,
                        ?A              = A           ,
                        ?B              = B           ,
                        ?AAxis          = AAxis       ,
                        ?BAxis          = BAxis       ,
                        ?XAxis          = XAxis       ,
                        ?YAxis          = YAxis       ,
                        ?Color          = Color       ,
                        ?CheaterSlope   = CheaterSlope
                    )
                )
                |> GenericChart.ofTraceObject