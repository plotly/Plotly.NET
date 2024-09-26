namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type ModeBar() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?ActiveColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Add: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?Remove: string,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        ModeBar()
        |> ModeBar.style (
            ?ActiveColor = ActiveColor,
            ?Add = Add,
            ?BGColor = BGColor,
            ?Color = Color,
            ?Orientation = Orientation,
            ?Remove = Remove,
            ?UIRevision = UIRevision
        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?ActiveColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Add: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Orientation: StyleParam.Orientation,
            [<Optional; DefaultParameterValue(null)>] ?Remove: string,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (modeBar: ModeBar) ->

            ActiveColor |> DynObj.setOptionalProperty modeBar "activecolor"
            Add |> DynObj.setOptionalProperty modeBar "add"
            BGColor |> DynObj.setOptionalProperty modeBar "bgcolor"
            Color |> DynObj.setOptionalProperty modeBar "color"
            Orientation |> DynObj.setOptionalPropertyBy modeBar "orientation" StyleParam.Orientation.convert
            Remove |> DynObj.setOptionalProperty modeBar "remove"
            UIRevision |> DynObj.setOptionalProperty modeBar "uirevision "

            modeBar)
