//#I "./bin/Debug"
#r "./bin/Debug/Newtonsoft.Json.dll"
#r "./bin/Debug/FSharp.Plotly.dll"


open FSharp.Plotly


let xValues = seq [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ] // 9.; 8.; 7.; 6.; 5.; 4.; 3.; 2.; 1.]
let yValues = seq [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
let yValues' = seq [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]



Chart.Point(xValues,yValues,Name="scattern")
//|> Chart.withX_AxisStyle("x axis title") 
//|> Chart.withY_AxisStyle("y axis title") 
|> Chart.Show




//let inline (|HasMarker|_|) (a:^T) : option< 'a >  =
//    (^T : (member marker : Marker) (a))

let inline name (x : ^T) = (^T : (member marker : Marker) (x))







open System.Reflection

let tryGetPropertyName (expr : Microsoft.FSharp.Quotations.Expr) =
    match expr with
    | Microsoft.FSharp.Quotations.Patterns.PropertyGet (_,pInfo,_) -> Some pInfo.Name
    | _ -> None

let trySetPropertyValue (o:obj) (propName:string) (value:obj) =
    let property = o.GetType().GetProperty(propName)
    try 
        property.SetValue(o, value, null)
        Some o
    with
    | :? System.ArgumentException -> None
    | :? System.NullReferenceException -> None
    

let tryGetPropertyValue (o:obj) (propName:string) =
    try 
        Some (o.GetType().GetProperty(propName).GetValue(o, null))
    with 
    | :? System.Reflection.TargetInvocationException -> None
    | :? System.NullReferenceException -> None

let tryGetPropertyValueAs<'a> (o:obj) (propName:string) =
    try 
        let v = (o.GetType().GetProperty(propName).GetValue(o, null))
        Some (v :?> 'a)
    with 
    | :? System.Reflection.TargetInvocationException -> None
    | :? System.NullReferenceException -> None

let updatePropertyValue (o:obj) (expr : Microsoft.FSharp.Quotations.Expr) (f: 'a option -> 'a) =
    let propName = tryGetPropertyName expr
    let v = f (tryGetPropertyValueAs<'a> o propName.Value)
    trySetPropertyValue o propName.Value v |> ignore
    o


let m1 = Marker(size=1)

let oldt = Scatter(opacity=0.4,marker=m1)
let newt = Scatter(opacity=0.7)


tryGetPropertyValue m1 "sie"




















