namespace Plotly.NET

/// Dimensions type inherits from dynamic object
type Button () =
    inherit DynamicObj ()

    static member init
        (
            ?Visible            : bool,
            ?Step               : StyleParam.TimeStep,
            ?StepMode           : StyleParam.TimeStepMode,
            ?Count              : int,
            ?Label              : string,
            ?Name               : string,
            ?TemplateItemName   : string
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
            ?Visible            : bool,
            ?Step               : StyleParam.TimeStep,
            ?StepMode           : StyleParam.TimeStepMode,
            ?Count              : int,
            ?Label              : string,
            ?Name               : string,
            ?TemplateItemName   : string
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