open System.Reflection
open System
open System.IO

open Common
open TemplateStrings

[<EntryPoint>]
let main (args: string []) = 

    //if args.Length <> 1 then
    //    failwith "provide root path plz"

    //let root = args[0]

    let root = @"C:\Users\schne\source\repos\plotly\Plotly.NET\src\Plotly.NET.CSharp"

    // tuple of type to generate bindings for, target namespace, and target filepath
    let core_object_target_types = [
        // to-do problem with generic trace argument: typeof<Plotly.NET.Trace>, "Plotly.NET.CSharp", Path.Combine(root, "")
        typeof<Plotly.NET.Layout>, "Plotly.NET.CSharp", Path.Combine(root, "")
        // to-do (no custom setters/getters in core lib): 
        typeof<Plotly.NET.LayoutObjects.Geo>, "Plotly.NET.CSharp.LayoutObjects", Path.Combine(root, "LayoutObjects")
        // to-do (no custom setters/getters in core lib)
        typeof<Plotly.NET.LayoutObjects.Mapbox>, "Plotly.NET.CSharp.LayoutObjects", Path.Combine(root, "LayoutObjects")
        typeof<Plotly.NET.LayoutObjects.Ternary>, "Plotly.NET.CSharp.LayoutObjects", Path.Combine(root, "LayoutObjects")
        typeof<Plotly.NET.LayoutObjects.Scene>, "Plotly.NET.CSharp.LayoutObjects", Path.Combine(root, "LayoutObjects")
        typeof<Plotly.NET.LayoutObjects.Polar>, "Plotly.NET.CSharp.LayoutObjects", Path.Combine(root, "LayoutObjects")
        typeof<Plotly.NET.LayoutObjects.Smith>, "Plotly.NET.CSharp.LayoutObjects", Path.Combine(root, "LayoutObjects")
    ]

    core_object_target_types
    |> List.iter(fun (coreType, targetNamespace, path) ->
        ensureDirectory path
        let methods = CoreObjects.getBindingMethods coreType
        let static_method_bindings = CoreObjects.generateStaticMethodBindings methods
        let class_binding = CoreObjects.generateClass  targetNamespace coreType.Name static_method_bindings
        let file_name = Path.Combine(path, $"{coreType.Name}.cs")
        File.WriteAllText(file_name, class_binding)
    )

    0