namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type Button () =
    inherit DynamicObj ()

    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?Visible            : bool,
            [<Optional;DefaultParameterValue(null)>] ?Step               : StyleParam.TimeStep,
            [<Optional;DefaultParameterValue(null)>] ?StepMode           : StyleParam.TimeStepMode,
            [<Optional;DefaultParameterValue(null)>] ?Count              : int,
            [<Optional;DefaultParameterValue(null)>] ?Label              : string,
            [<Optional;DefaultParameterValue(null)>] ?Name               : string,
            [<Optional;DefaultParameterValue(null)>] ?TemplateItemName   : string
        ) =
            Button () 
            |> Button.style
                (
                    ?Visible          = Visible         ,
                    ?Step             = Step            ,
                    ?StepMode         = StepMode        ,
                    ?Count            = Count           ,
                    ?Label            = Label           ,
                    ?Name             = Name            ,
                    ?TemplateItemName = TemplateItemName
                )

    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Visible            : bool,
            [<Optional;DefaultParameterValue(null)>] ?Step               : StyleParam.TimeStep,
            [<Optional;DefaultParameterValue(null)>] ?StepMode           : StyleParam.TimeStepMode,
            [<Optional;DefaultParameterValue(null)>] ?Count              : int,
            [<Optional;DefaultParameterValue(null)>] ?Label              : string,
            [<Optional;DefaultParameterValue(null)>] ?Name               : string,
            [<Optional;DefaultParameterValue(null)>] ?TemplateItemName   : string
        ) =
            (fun (button:Button) -> 
                
                Visible             |> DynObj.setValueOpt button "visible"
                Step                |> DynObj.setValueOptBy button "step" StyleParam.TimeStep.convert
                StepMode            |> DynObj.setValueOptBy button "stepmode" StyleParam.TimeStepMode.convert
                Count               |> DynObj.setValueOpt button "count"
                Label               |> DynObj.setValueOpt button "label"
                Name                |> DynObj.setValueOpt button "name"
                TemplateItemName    |> DynObj.setValueOpt button "templateitemname"

                button
            )