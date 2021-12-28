[<AutoOpen>]
module internal InternalUtils

open DynamicObj
open DynamicObj.Operators

[<AutoOpen>]
module DynObj =

    let setSingleOrMultiOpt (propName: string) (single: 'A option, multi: seq<'A> option) (dyn: #ImmutableDynamicObj) =
        
        if multi.IsSome then
            dyn ++ (propName, multi)
        else
            dyn ++ (propName, single)

    let setSingleOrMultiOptBy
        (propName: string)
        (f: 'A -> 'B)
        (single: 'A option, multi: seq<'A> option)
        (dyn: #ImmutableDynamicObj)
        =
        if multi.IsSome then
            dyn ++?? (propName, multi, (Seq.map f))
        else
            dyn ++?? (propName, single, f)

    let setSingleOrAnyOpt  (propName: string) (single: 'A option, any: 'B option)  (dyn: #ImmutableDynamicObj) =
        if any.IsSome then
            dyn ++? (propName, any)
        else
            dyn ++? (propName, single)

    let setSingleOrAnyOptBy
        (propName: string)
        (singleF: 'A -> 'C)
        (anyF: 'B -> 'D)
        (single: 'A option, any: 'B option)
        (dyn: #ImmutableDynamicObj)
        =
        if any.IsSome then
            dyn ++?? (propName, any, anyF)
        else
            dyn ++?? (propName, single, singleF)
