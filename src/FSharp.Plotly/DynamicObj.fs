namespace FSharp.Plotly

open System
open System.Collections.Generic
open System.Dynamic
//open System.Reflection
// System.Collections.ICollection //in ICollection
open System.Runtime.InteropServices



module ReflectionHelper =
    
    open System.Reflection
    
    // Gets public properties including interface propterties
    let getPublicProperties (t:Type) =
        [|
            for propInfo in t.GetProperties() -> propInfo
            for i in t.GetInterfaces() do yield! i.GetProperties()
        |]

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

    /// Try to get the PropertyInfo by name using reflection
    let tryGetPropertyInfo (o:obj) (propName:string) =
        getPublicProperties (o.GetType())
        |> Array.tryFind (fun n -> n.Name = propName)        

    /// Sets property value using reflection
    let trySetPropertyValue (o:obj) (propName:string) (value:obj) =
        match tryGetPropertyInfo o propName with 
        | Some property ->
            try 
                property.SetValue(o, value, null)
                Some o
            with
            | :? System.ArgumentException -> None
            | :? System.NullReferenceException -> None
        | None -> None

    /// Gets property value as option using reflection
    let tryGetPropertyValue (o:obj) (propName:string) =
        try 
            match tryGetPropertyInfo o propName with 
            | Some v -> Some (v.GetValue(o,null))
            | None -> None
        with 
        | :? System.Reflection.TargetInvocationException -> None
        | :? System.NullReferenceException -> None
    
    /// Gets property value as 'a option using reflection. Cast to 'a
    let tryGetPropertyValueAs<'a> (o:obj) (propName:string) =
        try 
            match tryGetPropertyInfo o propName with 
            | Some v -> Some (v.GetValue(o,null) :?> 'a)
            | None -> None
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


    /// Removes property 
    let removeProperty (o:obj) (propName:string) =        
        match tryGetPropertyInfo o propName with         
        | Some property ->
            try 
                property.SetValue(o, null, null)
                true
            with
            | :? System.ArgumentException -> false
            | :? System.NullReferenceException -> false
        | None -> false



type DynamicObj internal (dict:Dictionary<string, obj>) = 
    
    inherit DynamicObject () 
    
    let properties = dict//new Dictionary<string, obj>()

    /// 
    new () = DynamicObj(new Dictionary<string, obj>())

    /// Gets property value
    member this.TryGetValue name = 
        // first check the Properties collection for member
        match properties.TryGetValue name with
        | true,value ->  Some value
        // Next check for Public properties via Reflection
        | _ -> ReflectionHelper.tryGetPropertyValue this name


    /// Gets property value
    member this.TryGetTypedValue<'a> name = 
        match (this.TryGetValue name) with
        | None -> None
        | Some o -> 
            match o with
            | :? 'a -> o :?> 'a |> Some
            | _ -> None

        
    /// Sets property value, creating a new property if none exists
    member this.SetValue (name,value) = // private
        // first check to see if there's a native property to set

        match ReflectionHelper.tryGetPropertyInfo this name with
        | Some property ->
            try 
                // let t = property.ReflectedType
                // t.InvokeMember(name,Reflection.BindingFlags.SetProperty,null,this,[|value|]) |> ignore

                //let tmp = Convert.ChangeType(this, property.ReflectedType)
                //let tmp = downcast this : (typeof<t.GetType()>)
                property.SetValue(this, value, null)
            with
            | :? System.ArgumentException -> raise (new System.ArgumentException("Readonly property - Property set method not found.")) 
            | :? System.NullReferenceException -> raise (new System.NullReferenceException())
        
        | None -> 
            // Next check the Properties collection for member
            match properties.TryGetValue name with            
            | true,_ -> properties.[name] <- value
            | _      -> properties.Add(name,value)

    member this.Remove name =
        match ReflectionHelper.removeProperty this name with
        | true -> true
        // Maybe in map
        | false -> properties.Remove(name)


    override this.TryGetMember(binder:GetMemberBinder,result:obj byref ) =     
        match this.TryGetValue binder.Name with
        | Some value -> result <- value; true
        | None -> false

    override this.TrySetMember(binder:SetMemberBinder, value:obj) =        
        this.SetValue(binder.Name,value)
        true

    /// Returns and the properties of
    member this.GetProperties includeInstanceProperties =        
        seq [
            if includeInstanceProperties then                
                for prop in ReflectionHelper.getPublicProperties (this.GetType()) -> 
                    new KeyValuePair<string, obj>(prop.Name, prop.GetValue(this, null))
            for key in properties.Keys ->
               new KeyValuePair<string, obj>(key, properties.[key]);
        ]

    /// Return both instance and dynamic names.
    /// Important to return both so JSON serialization with Json.NET works.
    override this.GetDynamicMemberNames() =
        this.GetProperties(true) |> Seq.map (fun pair -> pair.Key)

    static member (?) (lookup:#DynamicObj,name:string) =
        match lookup.TryGetValue name with
        | Some(value) -> value
        | None -> raise (new System.MemberAccessException())        
    static member (?<-) (lookup:#DynamicObj,name:string,value:'v) =
        lookup.SetValue (name,value)

    static member GetValue (lookup:DynamicObj,name) =
        lookup.TryGetValue(name).Value

    static member Remove (lookup:DynamicObj,name) =
        lookup.Remove(name)


// ###############################
// ###############################

module DynObj =

    /// New DynamicObj of Dictionary
    let ofDict dict = new DynamicObj(dict)

    /// New DynamicObj of a sequence of key value
    let ofSeq kv = 
        let dict = new Dictionary<string, obj>()
        kv |> Seq.iter (fun (k,v) -> dict.Add(k,v))
        new DynamicObj(dict)

    /// New DynamicObj of a list of key value
    let ofList kv = 
        let dict = new Dictionary<string, obj>()
        kv |> List.iter (fun (k,v) -> dict.Add(k,v))
        new DynamicObj(dict)


    /// New DynamicObj of an array of key value
    let ofArray kv = 
        let dict = new Dictionary<string, obj>()
        kv |> Array.iter (fun (k,v) -> dict.Add(k,v))
        new DynamicObj(dict)

    
    // 
    // let rec merge (first:#DynamicObj) (second:#DynamicObj) = 
    //     let dict = new Dictionary<string, obj>()

    //     Seq.append (first.GetProperties true) (second.GetProperties true)
    //     |> Seq.iter (fun kv -> 
    //         if dict.ContainsKey(kv.Key) then
    //             match kv.Value with
    //             | :? #DynamicObj as o -> 
    //                 let oo = dict.[kv.Key] :?> #DynamicObj
    //                 dict.[kv.Key] <- merge o oo
    //             | _ -> dict.[kv.Key] <- kv.Value
    //         else 
    //             dict.Add(kv.Key, kv.Value)                
    //             )
    //     new DynamicObj(dict)

    //let rec combine<'t when 't :> DynamicObj > (first:'t) (second:'t) =
    

    /// Merges two DynamicObj (Warning: In case of dublicate property names the second member override the first)
    let rec combine (first:DynamicObj) (second:DynamicObj) =
        //printfn "Type %A" (first.GetType())
        /// Consider deep-copy of first
        for kv in (second.GetProperties true) do 
            match kv.Value with
            | :? DynamicObj as valueS -> 
                // is dynObj in second
                match first.TryGetValue (kv.Key) with
                | Some valueF -> 
                    let tmp = combine (unbox valueF) (unbox valueS)
                    first.SetValue(kv.Key,tmp)
                | None -> first.SetValue(kv.Key,valueS)
            | _ -> first.SetValue(kv.Key,kv.Value)
        first

    let setValue (dyn:DynamicObj) propName o =
        dyn.SetValue(propName,o)

    let setValueOpt (dyn:DynamicObj) propName = 
        function
        | Some o -> 
            dyn.SetValue(propName,o)
        | None -> ()

    let setValueOptBy (dyn:DynamicObj) propName f = 
        function
        | Some o -> 
            dyn.SetValue(propName,f o)
        | None -> ()
    
    let tryGetValue (dyn:DynamicObj) name = 
        match dyn.TryGetMember name with
        | true,value ->  Some value
        | _ -> None

    let remove (dyn:DynamicObj) propName = 
        DynamicObj.Remove (dyn, propName) |> ignore



