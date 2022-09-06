/// functions for creating core objects
///
/// core objects are abstractions for plotly.js objects which come with more than simple init and style methods, such as custom getters and setters.
/// An example for such an object would be the Layout object. 
/// Non-toplevel can also belong to this type of object abstraction, such as all the subplot types (e.g. Polar or Geo)
///
/// The main difference for these objects is that they need a collection of extension methods in addition to static method abstractions.
module CoreObjects

open Common
open TemplateStrings
open System.Reflection

let getBindingMethods (t:System.Type) =
    t.GetMembers()
    |> Array.filter (fun m -> m.DeclaringType.Name = t.Name)
    |> Array.filter (fun m -> m.MemberType = MemberTypes.Method)
    |> Array.map (fun m -> 
        m.Name,
        t.GetMethod(m.Name)
    )

let generateStaticMethodBindings (methods: (string*MethodInfo)  []) =
    methods
    |> Array.map (fun (methodName, method) ->
        if methodName.Contains("try") then
            None
        else
            let shouldBeExtension = not (methodName.Contains("init"))

            let mutable isFunc = false

            let parameters = method.GetParameters()

            let return_type = 
                if shouldBeExtension then
                    let n = method.ReturnType.Name
                    printfn "%s" n
                    match n with
                    | func when func.Contains("FSharpFunc") ->
                        let func_generics = method.ReturnType.GenericTypeArguments
                        isFunc <- true
                        let funcReturnType = cleanTypeName (func_generics[1].ToString())
                        printfn "func return type: %s" funcReturnType
                        funcReturnType
                    | _ -> cleanTypeName (method.ReturnType.ToString())
                else
                    cleanTypeName (method.ReturnType.ToString())

            let generics= 
                if method.ContainsGenericParameters then 
                    method
                        .GetGenericMethodDefinition()
                        .GetGenericArguments()
                        |> Array.map (fun generic -> generic.Name, generic.GetGenericParameterConstraints())
                else
                    [||]

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
                else 
                    [||]

            let parameter_bodies =
                parameters
                |> Array.map (fun p ->
                    if p.IsOptional then
                        let annotations =
                            p.ParameterType.GetTypeInfo().GetGenericArguments()
                            |> Array.map (fun t -> cleanTypeName (t.ToString()))
                        $"Optional<{annotations[0]}> {p.Name} = default"
                    else
                        let pType = cleanTypeName (p.ParameterType.ToString())
                        $"{pType} {p.Name}"
                )


            let parameter_bindings =
                parameters
                |> Array.map (fun p ->
                    if p.IsOptional then
                        $"{p.Name}: {p.Name}.ToOption()"
                    else    
                        $"{p.Name}: {p.Name}"
                )

            let declaring_type = cleanTypeName (method.DeclaringType.ToString())

            if shouldBeExtension then
                Some(
                    MethodTemplates.initExtensionMethodTemplate( 
                        identationLevel = 1,
                        isFunction = isFunc,
                        returnType = return_type,
                        capitalizedMethodName = capitalize methodName,
                        genericAnnotations = generic_annotations,
                        parameters = parameter_bodies,
                        genericConstraints = generic_constraints,
                        declaringType = declaring_type,
                        methodName = methodName,
                        parameterBindings = parameter_bindings
                    )
                )
            else
                Some(
                    MethodTemplates.initStaticMethodTemplate( 
                        identationLevel = 1,
                        returnType = return_type,
                        capitalizedMethodName = capitalize methodName,
                        genericAnnotations = generic_annotations,
                        parameters = parameter_bodies,
                        genericConstraints = generic_constraints,
                        declaringType = declaring_type,
                        methodName = methodName,
                        parameterBindings = parameter_bindings
                    )
                )
        )
        |> Array.choose id

let generateClass (className:string) (nameSpace:string) (methods: string []) =
    ClassTemplates.initCoreObjectAbstractionClassTemplate(
        identationLevel = 0,
        nameSpace = className,
        className = nameSpace,
        staticMethods = methods
    )

