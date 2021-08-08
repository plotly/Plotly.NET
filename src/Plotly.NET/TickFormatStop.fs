namespace Plotly.NET

type TickFormatStop() =
    inherit DynamicObj ()

    static member init
        (    
            ?Enabled            : bool,
            ?DTickRange         : seq<string*string>,
            ?Value              : string,
            ?Name               : string,
            ?TemplateItemName   : string
        ) =    
            TickFormatStop()
            |> TickFormatStop.style
                (
                    ?Enabled          = Enabled         ,
                    ?DTickRange       = DTickRange      ,
                    ?Value            = Value           ,
                    ?Name             = Name            ,
                    ?TemplateItemName = TemplateItemName
                )

    static member style
        (    
            ?Enabled            : bool,
            ?DTickRange         : seq<string*string>,
            ?Value              : string,
            ?Name               : string,
            ?TemplateItemName   : string
        ) =
            (fun (tickFormatStop:TickFormatStop) -> 

                Enabled             |> DynObj.setValueOpt tickFormatStop "enabled"
                DTickRange          |> DynObj.setValueOpt tickFormatStop "dtickrange"
                Value               |> DynObj.setValueOpt tickFormatStop "value"
                Name                |> DynObj.setValueOpt tickFormatStop "name"
                TemplateItemName    |> DynObj.setValueOpt tickFormatStop "templateitemname"


                tickFormatStop
            )