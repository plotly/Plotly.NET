namespace FSharp.Plotly

open System



module ApplyHelper =
    
    open System.Reflection
    
    // Gets public properties including interface propterties
    let getPublicProperties (t:Type) =
        if (not (t.IsInterface)) then
            (t.GetProperties())
        else
            t.GetInterfaces()           
            |> Array.collect (fun i -> i.GetProperties())
    


    /// Creates an instance of the Object according to applyStyle and applies the function..
    let buildApply (applyStyle:'a -> 'a) =
        let instance =
            System.Activator.CreateInstance<'a>()
        applyStyle instance

    /// Applies 'applyStyle' to item option. If None it creates a new instance.
    let optBuildApply (applyStyle:'a -> 'a) (item:'a option) =
        match item with
        | Some item' -> applyStyle item'
        | None       -> buildApply applyStyle

    /// Applies Some 'applyStyle' to item. If None it returns 'item' unchanged.
    let optApply (applyStyle:('a -> 'a)  option) (item:'a ) =
        match applyStyle with
        | Some apply -> apply item
        | None       -> item

    /// Returns the proptery name from quotation expression
    let tryGetPropertyName (expr : Microsoft.FSharp.Quotations.Expr) =
        match expr with
        | Microsoft.FSharp.Quotations.Patterns.PropertyGet (_,pInfo,_) -> Some pInfo.Name
        | _ -> None
    
    /// Sets property value using reflection
    let trySetPropertyValue (o:obj) (propName:string) (value:obj) =
        //let property = o.GetType().GetProperty(propName,BindingFlags.FlattenHierarchy)
        let property = 
            getPublicProperties (o.GetType())
            |> Array.find (fun n -> n.Name = propName)
        //printfn "%s" property.Name
        try 
            property.SetValue(o, value, null)
            Some o
        with
        | :? System.ArgumentException -> None
        | :? System.NullReferenceException -> None
    
    /// Gets property value as option using reflection
    let tryGetPropertyValue (o:obj) (propName:string) =
        try 
            Some (o.GetType().GetProperty(propName,BindingFlags.FlattenHierarchy).GetValue(o, null))
        with 
        | :? System.Reflection.TargetInvocationException -> None
        | :? System.NullReferenceException -> None
    
    /// Gets property value as 'a option using reflection. Cast to 'a
    let tryGetPropertyValueAs<'a> (o:obj) (propName:string) =
        try 
            //let v = (o.GetType().GetProperty(propName,BindingFlags.FlattenHierarchy).GetValue(o, null))
            let propInfo =
                getPublicProperties (o.GetType()) 
                |> Array.tryFind (fun p -> p.Name  = propName)
            match propInfo with
            | Some v -> Some (v.GetValue(o,null) :?> 'a)
            | None -> None
            //Some (v :?> 'a)
        with 
        | :? System.Reflection.TargetInvocationException -> None
        | :? System.NullReferenceException -> None

    /// Updates property value by given function
    let tryUpdatePropertyValueFromName (o:obj) (propName:string) (f: 'a -> 'a) =
        let v = optBuildApply f (tryGetPropertyValueAs<'a> o propName)
        trySetPropertyValue o propName v 
        //o

    /// Updates property value by given function
    let tryUpdatePropertyValue (o:obj) (expr : Microsoft.FSharp.Quotations.Expr) (f: 'a -> 'a) =
        let propName = tryGetPropertyName expr
        let g = (tryGetPropertyValueAs<'a> o propName.Value)
        let v = optBuildApply f g
        trySetPropertyValue o propName.Value v 
        //o

    let updatePropertyValueAndIgnore (o:obj) (expr : Microsoft.FSharp.Quotations.Expr) (f: 'a -> 'a) = 
        tryUpdatePropertyValue o expr f |> ignore

