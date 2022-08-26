open System.IO
open System.Text
open System.Text.RegularExpressions

let mapFSharpType (typeName:string) =
    typeName
        .Replace("float","double")
        .Replace("seq","IEnumerable")


let class_template = """public static partial class TraceObjects
{
    public static Plotly.NET.TraceObjects.[OBJECT_NAME] Init[OBJECT_NAME][GENERICS]
        (
[MANDATORY_PARAMS]
[OPTIONAL_PARAMS]
        ) 
[GENERICS_ANNOTATIONS]
            Plotly.NET.TraceObjects.[OBJECT_NAME].init(
[MANDATORY_PARAMS_SETTERS]
[OPTIONAL_PARAMS_SETTERS]
            );
}
"""

type TraceObjectAbstraction = {
    ObjectName: string
    MandatoryParams: (string*string) list
    OptionalParams: (string*string) list
    Generics: string list
} with
    static member create name (m: (string*string) list) (o: (string*string) list) = 
        
        let generics =
            List.concat [m; o]
            |> List.filter (fun (pName, pType) -> pType.Contains("#IConvertible"))
            |> List.map fst
            |> List.map (fun pName -> pName, $"{pName}Type")
            |> Map.ofList

        let csharpMandatoryParams = 
            m 
            |> List.map (fun (pName, pType) -> pName, mapFSharpType pType)
            |> List.map (fun (pName, pType) -> 
                pName, 
                if pType.Contains("#IConvertible") then 
                    pType.Replace("#IConvertible", generics[pName])
                else
                    pType
            )
        let csharpOptionalyParams = 
            o 
            |> List.map (fun (pName, pType) -> pName, mapFSharpType pType)
            |> List.map (fun (pName, pType) -> 
                pName, 
                if pType.Contains("#IConvertible") then 
                    pType.Replace("#IConvertible", generics[pName])
                else
                    pType
            )

        {
            ObjectName = name
            MandatoryParams = csharpMandatoryParams
            OptionalParams = csharpOptionalyParams
            Generics = generics.Values |> List.ofSeq
        }

    static member toClassTemplate (tObj: TraceObjectAbstraction) =

        let mParams =
            tObj.MandatoryParams
            |> List.map (fun (pName, pType) -> $"            {pType} {pName}")
            |> String.concat $",{System.Environment.NewLine}"    

        let mParamSetters =
            tObj.MandatoryParams
            |> List.map (fun (pName, _) -> $"                {pName}: {pName}")
            |> String.concat $",{System.Environment.NewLine}"    

        let optParams =
            tObj.OptionalParams
            |> List.map (fun (pName, pType) -> $"            Optional<{pType}> {pName} = default")
            |> String.concat $",{System.Environment.NewLine}"

        let optParamsSetters =
            tObj.OptionalParams
            |> List.map (fun (pName, pType) -> $"                {pName}: {pName}.ToOption()")
            |> String.concat $",{System.Environment.NewLine}"

        let generics =
            if tObj.Generics.IsEmpty then
                $""
            else
                let g = tObj.Generics |> String.concat ", "
                $"<{g}>"

        let genericsAnnotations =
            if tObj.Generics.IsEmpty then
                $"{System.Environment.NewLine}            =>"
            else
                let g = 
                    tObj.Generics 
                    |> List.map (fun generic -> $"            where {generic}: IConvertible")
                    |> String.concat System.Environment.NewLine
                $"{g}{System.Environment.NewLine}            =>"

        class_template
            .Replace("[OBJECT_NAME]", tObj.ObjectName)
            .Replace("[MANDATORY_PARAMS]", mParams)
            .Replace("[OPTIONAL_PARAMS]", optParams)
            .Replace("[MANDATORY_PARAMS_SETTERS]", mParamSetters)
            .Replace("[OPTIONAL_PARAMS_SETTERS]", optParamsSetters)
            .Replace("[GENERICS]", generics)
            .Replace("[GENERICS_ANNOTATIONS]", genericsAnnotations)

let objectNameRegex = new Regex("type (?<objectName>[A-Za-z]*)()")

let getObjectName (str:string) =
    let m = objectNameRegex.Match(str)
    m.Groups.Item("objectName").Value

let paramRegex = new Regex("(?<pName>\S*):\s*(?<pType>[^,]*)")

let getParam (str:string) =
    let m = paramRegex.Match(str)
    m.Groups.Item("pName").Value,
    m.Groups.Item("pType").Value
    
let optParamRegex = new Regex("\?(?<pName>\S*):\s*(?<pType>[^,]*)")

let getOptParam (str:string) =
    let m = optParamRegex.Match(str)
    m.Groups.Item("pName").Value,
    m.Groups.Item("pType").Value

let parseSourceFile (path:string) =
    let rec loop (lines: string list) (isFirstObj: bool) (isInit: bool) (currentName: string) (mParams: (string*string) list) (oParams: (string*string) list) (acc: TraceObjectAbstraction list) =
        match lines with
        | line::rest ->
            match line with
            | objectName when line.StartsWith("type") ->
                let name = getObjectName objectName
                if isFirstObj then 
                    loop rest false isInit name mParams oParams acc
                else
                    loop rest isFirstObj isInit name [] [] ((TraceObjectAbstraction.create currentName (List.rev mParams) (List.rev oParams)) :: acc)
            
            | init when init.Trim() = "static member init" ->
                printfn "is init"
                loop rest isFirstObj true currentName mParams oParams acc

            | inlineInit when inlineInit.Trim().StartsWith("static member init(") ->

                if inlineInit.Contains("[<Optional; DefaultParameterValue(") then
                    loop rest isFirstObj isInit currentName mParams ((getOptParam inlineInit) :: oParams) acc
                else
                    loop rest isFirstObj isInit currentName ((getParam inlineInit) :: mParams)  oParams acc
                
            
            | otherMember when otherMember.Trim().StartsWith("static member") ->
                printfn "is other member"
                loop rest isFirstObj false currentName mParams oParams acc
                
            | bodyStart when 
                bodyStart.Trim().StartsWith("(") ->
                printfn "is body start"
                loop rest isFirstObj isInit currentName mParams oParams acc

            | bodyEnd when 
                bodyEnd.Trim().StartsWith(") =") ->
                printfn "is body end"
                loop rest isFirstObj false currentName mParams oParams acc

            | optParam when isInit && optParam.Trim().StartsWith("[<Optional; DefaultParameterValue(") ->
                printfn "is opt param"
                loop rest isFirstObj isInit currentName mParams ((getOptParam optParam) :: oParams) acc

            | param when isInit ->

                printfn "is param"
                loop rest isFirstObj isInit currentName ((getParam param) :: mParams)  oParams acc
            
            | _ -> loop rest isFirstObj isInit currentName mParams oParams acc

        | [] -> (TraceObjectAbstraction.create currentName (List.rev mParams) (List.rev oParams))::acc |> List.rev

    loop (File.ReadAllLines path |> List.ofArray) true false "" [] [] []


let file_template = """
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotly.NET.CSharp;

[CLASSES]
"""

let createCSharpSourceFile (objectAbstractions: TraceObjectAbstraction list) =
    let classes = 
        objectAbstractions 
        |> List.map TraceObjectAbstraction.toClassTemplate 
        |> String.concat System.Environment.NewLine
    
    file_template.Replace("[CLASSES]",classes)

let indicator = parseSourceFile @"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET\Traces\ObjectAbstractions\Indicator.fs"

createCSharpSourceFile indicator

let sourceFiles =
    Directory.EnumerateFiles @"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET\Traces\ObjectAbstractions\"
    |> Seq.cast<string>
    |> Array.ofSeq

let targetFiles = 
    sourceFiles
    |> Array.map (fun path -> 
        path
            .Replace(@"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET\Traces\ObjectAbstractions\", @"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET.CSharp\ObjectAbstractions\TraceObjects\")
            .Replace(".fs", ".cs")
    )
Array.zip sourceFiles targetFiles
|> Array.iter (fun (source, target) ->
    let classes = parseSourceFile source
    let targetFile = createCSharpSourceFile classes
    File.WriteAllText(target, targetFile)
)