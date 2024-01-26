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

            Args |> DynObj.setValueOpt updateMenuButton "args"
            Args2 |> DynObj.setValueOpt updateMenuButton "args2"
            Execute |> DynObj.setValueOpt updateMenuButton "execute"
            Label |> DynObj.setValueOpt updateMenuButton "label"
            Method |> DynObj.setValueOptBy updateMenuButton "method" StyleParam.UpdateMethod.convert
            Name |> DynObj.setValueOpt updateMenuButton "name"
            TemplateItemName |> DynObj.setValueOpt updateMenuButton "templateitemname"
            Visible |> DynObj.setValueOpt updateMenuButton "visible"


            updateMenuButton)

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

            Active |> DynObj.setValueOpt updateMenu "active"
            BGColor |> DynObj.setValueOpt updateMenu "bgcolor"
            BorderColor |> DynObj.setValueOpt updateMenu "bordercolor"
            Buttons |> DynObj.setValueOpt updateMenu "buttons"
            Direction |> DynObj.setValueOptBy updateMenu "direction" StyleParam.UpdateMenuDirection.convert
            Font |> DynObj.setValueOpt updateMenu "font"
            Name |> DynObj.setValueOpt updateMenu "name"
            Pad |> DynObj.setValueOpt updateMenu "pad"
            ShowActive |> DynObj.setValueOpt updateMenu "showactive"
            TemplateItemName |> DynObj.setValueOpt updateMenu "templateitemname"
            Type |> DynObj.setValueOptBy updateMenu "type" StyleParam.UpdateMenuType.convert
            Visible |> DynObj.setValueOpt updateMenu "visible"
            X |> DynObj.setValueOpt updateMenu "x"
            XAnchor |> DynObj.setValueOptBy updateMenu "xanchor" StyleParam.XAnchorPosition.convert
            Y |> DynObj.setValueOpt updateMenu "y"
            YAnchor |> DynObj.setValueOptBy updateMenu "yanchor" StyleParam.YAnchorPosition.convert

            updateMenu)
