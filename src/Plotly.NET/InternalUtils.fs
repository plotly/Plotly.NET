[<AutoOpen>]
module internal InternalUtils

open DynamicObj
open DynamicObj.Operators

[<AutoOpen>]
module DynObj =

    let setSingleOrMultiOpt (dyn: #ImmutableDynamicObj) (propName: string) (single: 'A option, multi: seq<'A> option) =
        if multi.IsSome then
            multi |> DynObj.setValueOpt dyn propName
        else
            single |> DynObj.setValueOpt dyn propName

    let setSingleOrMultiOptBy
        (dyn: #ImmutableDynamicObj)
        (propName: string)
        (f: 'A -> 'B)
        (single: 'A option, multi: seq<'A> option)
        =
        if multi.IsSome then
            multi |> DynObj.setValueOptBy dyn propName (Seq.map f)
        else
            single |> DynObj.setValueOptBy dyn propName f

    let setSingleOrAnyOpt (dyn: #ImmutableDynamicObj) (propName: string) (single: 'A option, any: 'B option) =
        if any.IsSome then
            any |> DynObj.setValueOpt dyn propName
        else
            single |> DynObj.setValueOpt dyn propName

    let setSingleOrAnyOptBy
        (dyn: #ImmutableDynamicObj)
        (propName: string)
        (singleF: 'A -> 'C)
        (anyF: 'B -> 'D)
        (single: 'A option, any: 'B option)
        =
        if any.IsSome then
            any |> DynObj.setValueOptBy dyn propName anyF
        else
            single |> DynObj.setValueOptBy dyn propName singleF
