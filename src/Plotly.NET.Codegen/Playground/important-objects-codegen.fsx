open System.Reflection
open Plotly.NET

let l = typeof<Plotly.NET.Layout>

let methods = 
    l.GetMembers()
    |> Array.filter (fun m -> m.DeclaringType.Name = l.Name)
    |> Array.filter (fun m -> m.MemberType = MemberTypes.Method)
    |> Array.map (fun m -> 
        m.Name,
        l.GetMethod(m.Name)
    )


let generated_methods = 
    methods
    |> Array.map (fun (methodName, method) ->
    
        let return_type = method.ReturnType.ToString()

        let parameters = method.GetParameters()

        let generics= 
            method
                .GetGenericMethodDefinition()
                .GetGenericArguments()
                |> Array.map (fun generic -> generic.Name, generic.GetGenericParameterConstraints())


        let generic_annotations = 
            if generics.Length > 0 then
                generics
                |> Array.map fst
                |> String.concat ", "
                |> fun generics -> $"<{generics}>"
            else 
                ""

        let generic_constraints =
            if generics.Length > 0 then
                generics
                |> Array.map (fun (name,types) -> 
                    if types.Length > 0 then 
                        $"where {name}: {types[0]}"
                    else
                        ""
                )
                |> String.concat $"{System.Environment.NewLine}    "
            else 
                ""

        let parameter_bodies =
            parameters
            |> Array.map (fun p ->
                if p.IsOptional then
                    let annotations =
                        p.ParameterType.GetTypeInfo().GetGenericArguments()
                        |> Array.map (
                            fun t -> 
                                t
                                    .ToString()
                                    .Replace("+",".")
                                    .Replace("[","<")
                                    .Replace("]",">")
                                    .Replace("`1","")
                        )
                    $"Optional<{annotations[0]}> {p.Name} = default"
                else
                    let pType = 
                        p.ParameterType
                            .ToString()
                            .Replace("+",".")
                            .Replace("[","<")
                            .Replace("]",">")
                            .Replace("`1","")

                    $"{pType} {p.Name}"
            )
            |> String.concat $",{System.Environment.NewLine}    "


        let parameter_bindings =
            parameters
            |> Array.map (fun p ->
                $"{p.Name}: {p.Name}"
            )
            |> String.concat $",{System.Environment.NewLine}            "

        $"""public static {return_type} {methodName}{generic_annotations}(
    {parameter_bodies}
)
    {generic_constraints}
    =>
        {method.DeclaringType}.{methodName}{generic_annotations}(
            {parameter_bindings}
        );
"""
    )

generated_methods[0]
|> printfn "%A"