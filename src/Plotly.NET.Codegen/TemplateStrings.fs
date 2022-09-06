module TemplateStrings
open Common 

type MethodTemplates() =

    static member initStaticMethodTemplate (
        identationLevel: int,
        returnType: string,
        capitalizedMethodName: string,
        genericAnnotations: string,
        parameters: string [],
        genericConstraints: string [],
        declaringType: string,
        methodName: string,
        parameterBindings: string []
    ) = 
        [
            ident identationLevel $"public static {returnType} {capitalizedMethodName}{genericAnnotations}("
            parameters |> Array.map (ident (identationLevel + 1)) |> String.concat $",{System.Environment.NewLine}"
            ident identationLevel ")"
            genericConstraints |> Array.map (ident (identationLevel + 1)) |> String.concat $"{System.Environment.NewLine}"
            ident (identationLevel + 1) "=>"
            ident (identationLevel + 2) $"{declaringType}.{methodName}{genericAnnotations}("
            parameterBindings |> Array.map (ident (identationLevel + 3)) |> String.concat $",{System.Environment.NewLine}"
            ident (identationLevel + 2) ");"
        ]
        |> String.concat System.Environment.NewLine

    static member initExtensionMethodTemplate (
        identationLevel: int,
        isFunction: bool,
        returnType: string,
        capitalizedMethodName: string,
        genericAnnotations: string,
        parameters: string [],
        genericConstraints: string [],
        declaringType: string,
        methodName: string,
        parameterBindings: string []
    ) = 
        let invoke = if isFunction then ".Invoke(obj)" else ""

        [
            ident identationLevel $"public static {returnType} {capitalizedMethodName}{genericAnnotations}("
            ident (identationLevel + 1) $"this {declaringType} obj,"
            parameters |> Array.map (ident (identationLevel + 1)) |> String.concat $",{System.Environment.NewLine}"
            ident identationLevel ")"
            genericConstraints |> Array.map (ident (identationLevel + 1)) |> String.concat $"{System.Environment.NewLine}"
            ident (identationLevel + 1) "=>"
            ident (identationLevel + 2) $"{declaringType}.{methodName}{genericAnnotations}("
            parameterBindings |> Array.map (ident (identationLevel + 3)) |> String.concat $",{System.Environment.NewLine}"
            ident (identationLevel + 2) $"){invoke};"
        ]
        |> String.concat System.Environment.NewLine

type ClassTemplates() =

    static member initCoreObjectAbstractionClassTemplate(
        identationLevel: int,
        nameSpace: string,
        className: string,
        staticMethods: string []
    ) = 
        [
            initFileHeader()
            ident identationLevel $"namespace {nameSpace};"
            ""
            $"public static class {className} " + "{"
            yield! staticMethods |> Array.map (ident identationLevel)
            "}"
        ]
        |> String.concat System.Environment.NewLine