namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type UpdateMenuButton() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Args: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Args2: seq<string>,
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
            [<Optional; DefaultParameterValue(null)>] ?Args: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Args2: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Execute: bool,
            [<Optional; DefaultParameterValue(null)>] ?Label: string,
            [<Optional; DefaultParameterValue(null)>] ?Method: StyleParam.UpdateMethod,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        (fun (updateMenuButton: UpdateMenuButton) ->

            ++? ("args", Args )
            ++? ("args2", Args2 )
            ++? ("execute", Execute )
            ++? ("label", Label )
            Method |> DynObj.setValueOptBy updateMenuButton "method" StyleParam.UpdateMethod.convert
            ++? ("name", Name )
            ++? ("templateitemname", TemplateItemName )
            ++? ("visible", Visible )


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

            ++? ("active", Active )
            ++? ("bgcolor", BGColor )
            ++? ("bordercolor", BorderColor )
            ++? ("buttons", Buttons )
            Direction |> DynObj.setValueOptBy updateMenu "direction" StyleParam.UpdateMenuDirection.convert
            ++? ("font", Font )
            ++? ("name", Name )
            ++? ("pad", Pad )
            ++? ("showactive", ShowActive )
            ++? ("templateitemname", TemplateItemName )
            Type |> DynObj.setValueOptBy updateMenu "type" StyleParam.UpdateMenuType.convert
            ++? ("visible", Visible )
            ++? ("x", X )
            XAnchor |> DynObj.setValueOptBy updateMenu "xanchor" StyleParam.XAnchorPosition.convert
            ++? ("y", Y )
            YAnchor |> DynObj.setValueOptBy updateMenu "yanchor" StyleParam.YAnchorPosition.convert

            updateMenu)
