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

            Args |> DynObj.setOptionalProperty updateMenuButton "args"
            Args2 |> DynObj.setOptionalProperty updateMenuButton "args2"
            Execute |> DynObj.setOptionalProperty updateMenuButton "execute"
            Label |> DynObj.setOptionalProperty updateMenuButton "label"
            Method |> DynObj.setOptionalPropertyBy updateMenuButton "method" StyleParam.UpdateMethod.convert
            Name |> DynObj.setOptionalProperty updateMenuButton "name"
            TemplateItemName |> DynObj.setOptionalProperty updateMenuButton "templateitemname"
            Visible |> DynObj.setOptionalProperty updateMenuButton "visible"


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

            Active |> DynObj.setOptionalProperty updateMenu "active"
            BGColor |> DynObj.setOptionalProperty updateMenu "bgcolor"
            BorderColor |> DynObj.setOptionalProperty updateMenu "bordercolor"
            Buttons |> DynObj.setOptionalProperty updateMenu "buttons"
            Direction |> DynObj.setOptionalPropertyBy updateMenu "direction" StyleParam.UpdateMenuDirection.convert
            Font |> DynObj.setOptionalProperty updateMenu "font"
            Name |> DynObj.setOptionalProperty updateMenu "name"
            Pad |> DynObj.setOptionalProperty updateMenu "pad"
            ShowActive |> DynObj.setOptionalProperty updateMenu "showactive"
            TemplateItemName |> DynObj.setOptionalProperty updateMenu "templateitemname"
            Type |> DynObj.setOptionalPropertyBy updateMenu "type" StyleParam.UpdateMenuType.convert
            Visible |> DynObj.setOptionalProperty updateMenu "visible"
            X |> DynObj.setOptionalProperty updateMenu "x"
            XAnchor |> DynObj.setOptionalPropertyBy updateMenu "xanchor" StyleParam.XAnchorPosition.convert
            Y |> DynObj.setOptionalProperty updateMenu "y"
            YAnchor |> DynObj.setOptionalPropertyBy updateMenu "yanchor" StyleParam.YAnchorPosition.convert

            updateMenu)
