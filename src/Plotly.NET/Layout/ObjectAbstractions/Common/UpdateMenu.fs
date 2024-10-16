namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type UpdateMenuButton() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Args: seq<DynamicObj>,
            [<Optional; DefaultParameterValue(null)>] ?Args2: seq<DynamicObj>,
            [<Optional; DefaultParameterValue(null)>] ?Execute: bool,
            [<Optional; DefaultParameterValue(null)>] ?Label: string,
            [<Optional; DefaultParameterValue(null)>] ?Method: StyleParam.UpdateMethod,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        UpdateMenuButton()
        |> UpdateMenuButton.style (
            ?Args = Args,
            ?Args2 = Args2,
            ?Execute = Execute,
            ?Label = Label,
            ?Method = Method,
            ?Name = Name,
            ?TemplateItemName = TemplateItemName,
            ?Visible = Visible

        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Args: seq<DynamicObj>,
            [<Optional; DefaultParameterValue(null)>] ?Args2: seq<DynamicObj>,
            [<Optional; DefaultParameterValue(null)>] ?Execute: bool,
            [<Optional; DefaultParameterValue(null)>] ?Label: string,
            [<Optional; DefaultParameterValue(null)>] ?Method: StyleParam.UpdateMethod,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        (fun (updateMenuButton: UpdateMenuButton) ->

            updateMenuButton
            |> DynObj.withOptionalProperty "args" Args
            |> DynObj.withOptionalProperty "args2" Args2
            |> DynObj.withOptionalProperty "execute" Execute
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalPropertyBy "method" Method StyleParam.UpdateMethod.convert
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalProperty "visible" Visible
        )

type UpdateMenu() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Active: int,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Buttons: seq<UpdateMenuButton>,
            [<Optional; DefaultParameterValue(null)>] ?Direction: StyleParam.UpdateMenuDirection,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Pad: Padding,
            [<Optional; DefaultParameterValue(null)>] ?ShowActive: bool,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Type: StyleParam.UpdateMenuType,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition
        ) =
        UpdateMenu()
        |> UpdateMenu.style (
            ?Active = Active,
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?Buttons = Buttons,
            ?Direction = Direction,
            ?Font = Font,
            ?Name = Name,
            ?Pad = Pad,
            ?ShowActive = ShowActive,
            ?TemplateItemName = TemplateItemName,
            ?Type = Type,
            ?Visible = Visible,
            ?X = X,
            ?XAnchor = XAnchor,
            ?Y = Y,
            ?YAnchor = YAnchor

        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Active: int,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Buttons: seq<UpdateMenuButton>,
            [<Optional; DefaultParameterValue(null)>] ?Direction: StyleParam.UpdateMenuDirection,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Pad: Padding,
            [<Optional; DefaultParameterValue(null)>] ?ShowActive: bool,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Type: StyleParam.UpdateMenuType,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?X: float,
            [<Optional; DefaultParameterValue(null)>] ?XAnchor: StyleParam.XAnchorPosition,
            [<Optional; DefaultParameterValue(null)>] ?Y: float,
            [<Optional; DefaultParameterValue(null)>] ?YAnchor: StyleParam.YAnchorPosition
        ) =
        (fun (updateMenu: UpdateMenu) ->

            updateMenu
            |> DynObj.withOptionalProperty "active" Active
            |> DynObj.withOptionalProperty "bgcolor" BGColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "buttons" Buttons
            |> DynObj.withOptionalPropertyBy "direction" Direction StyleParam.UpdateMenuDirection.convert
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "pad" Pad
            |> DynObj.withOptionalProperty "showactive" ShowActive
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalPropertyBy "type" Type StyleParam.UpdateMenuType.convert
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
        )
