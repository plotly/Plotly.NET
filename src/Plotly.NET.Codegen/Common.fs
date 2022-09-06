module Common

open Plotly.NET
open System
open System.Reflection
open System.IO
open System.Text
open System.Text.RegularExpressions

let typeNumbers = [|for n in 1 .. 100 -> $"`{n}"|]

let cleanTypeName (typeName:string) = 
    let typeName' =
        typeNumbers
        |> Array.fold (fun (acc: string) number -> acc.Replace(number,"")) typeName
    typeName'
        .Replace("+",".")
        .Replace("[","<")
        .Replace("]",">")

let mapFSharpType (typeName:string) =
    typeName
        .Replace("float","double")
        .Replace("seq","IEnumerable")

let ident (level:int) (str: string) =
    let identation = [for i in 0 .. level - 1 -> "    "] |> String.concat ""
    $"{identation}{str}"

let capitalize (methodName:string) = 
    if methodName.Length > 0 then
        $"{Char.ToUpper methodName[0]}{methodName[1..]}"
    else    
        methodName

let ensureDirectory path =
    if not (Directory.Exists(path)) then Directory.CreateDirectory(path) |> ignore

let plotlyVersion = typeof<Plotly.NET.Layout>.Assembly

let initFileHeader() = $"""// this file was auto-generated using Plotly.NET.Codegen on {System.DateTime.Now.ToShortDateString()} targeting {plotlyVersion}.
// Do not edit this, as it will most likely be overwritten on the next codegen run.
// Instead, file an issue or target the codegen with your changes directly.
// Bugs that are not caused by wrong codegen are most likely not found in this file, but in the F# source this file is generated from.
"""