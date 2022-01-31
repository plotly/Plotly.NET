[<AutoOpen>]
module internal InternalUtils

open DynamicObj
open System.Runtime.InteropServices

[<AutoOpen>]
module DynObj =

    let setSingleOrMultiOpt (dyn: #DynamicObj) (propName: string) (single: 'A option, multi: seq<'A> option) =
        if multi.IsSome then
            multi |> DynObj.setValueOpt dyn propName
        else
            single |> DynObj.setValueOpt dyn propName

    let setSingleOrMultiOptBy
        (dyn: #DynamicObj)
        (propName: string)
        (f: 'A -> 'B)
        (single: 'A option, multi: seq<'A> option)
        =
        if multi.IsSome then
            multi |> DynObj.setValueOptBy dyn propName (Seq.map f)
        else
            single |> DynObj.setValueOptBy dyn propName f

    let setSingleOrAnyOpt (dyn: #DynamicObj) (propName: string) (single: 'A option, any: 'B option) =
        if any.IsSome then
            any |> DynObj.setValueOpt dyn propName
        else
            single |> DynObj.setValueOpt dyn propName

    let setSingleOrAnyOptBy
        (dyn: #DynamicObj)
        (propName: string)
        (singleF: 'A -> 'C)
        (anyF: 'B -> 'D)
        (single: 'A option, any: 'B option)
        =
        if any.IsSome then
            any |> DynObj.setValueOptBy dyn propName anyF
        else
            single |> DynObj.setValueOptBy dyn propName singleF

// Copied from FSharp.Care.Collections to remove dependencies
[<AutoOpen>]
module internal Seq =

    /// Splits a sequence of pairs into two sequences
    let unzip (input: seq<_>) =
        let (lstA, lstB) =
            Seq.foldBack (fun (a, b) (accA, accB) -> a :: accA, b :: accB) input ([], [])

        (Seq.ofList lstA, Seq.ofList lstB)

    /// Splits a sequence of triples into three sequences
    let unzip3 (input: seq<_>) =
        let (lstA, lstB, lstC) =
            Seq.foldBack (fun (a, b, c) (accA, accB, accC) -> a :: accA, b :: accB, c :: accC) input ([], [], [])

        (Seq.ofList lstA, Seq.ofList lstB, Seq.ofList lstC)

[<AutoOpen>]
module internal ChartIO =

    ///Choose process to open plots with depending on OS. Thanks to @zyzhu for hinting at a solution (https://github.com/plotly/Plotly.NET/issues/31)
    let openOsSpecificFile path =
        if RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
            let psi =
                new System.Diagnostics.ProcessStartInfo(FileName = path, UseShellExecute = true)

            System.Diagnostics.Process.Start(psi) |> ignore
        elif RuntimeInformation.IsOSPlatform(OSPlatform.Linux) then
            System.Diagnostics.Process.Start("xdg-open", path) |> ignore
        elif RuntimeInformation.IsOSPlatform(OSPlatform.OSX) then
            System.Diagnostics.Process.Start("open", path) |> ignore
        else
            invalidOp "Not supported OS platform"
