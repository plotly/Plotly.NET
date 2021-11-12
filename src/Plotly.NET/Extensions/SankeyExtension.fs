namespace Plotly.NET

open DynamicObj
open System.Runtime.InteropServices

type Node = 
    {
        Label           : string
        Groups          : string[] option
        XRank           : int option
        YRank           : int option
        Color           : obj option
        LineColor       : obj option
        LineWidth       : float option
    }
    with
    static member Create(label,?groups,?xRank,?yRank,?color,?lineColor,?lineWidth) = 
        {
            Label           = label
            Groups          = groups
            XRank           = xRank
            YRank           = yRank
            Color           = color
            LineColor       = lineColor
            LineWidth       = lineWidth
        }

type Link = 
    {
        Source          : Node
        Target          : Node
        Value           : float option
        Label           : string option
        Color           : obj option
        LineColor       : obj option
        LineWidth       : float option

    }
    with
    static member Create(src,tgt,?value,?label,?color,?lineColor,?lineWidth) = 
        {
            Source          = src
            Target          = tgt
            Value           = value
            Label           = label
            Color           = color
            LineColor       = lineColor
            LineWidth   = lineWidth
        }

[<AutoOpen>]
module SankeyExtension =

    type TraceDomainStyle with
        [<CompiledName("Sankey")>]
        static member Sankey
            (
                nodes:Node seq, 
                links:Link seq, 
                ?nodePadding:float,
                ?nodeThickness:float,
                ?nodeColor:obj,
                ?nodeLineColor:obj,
                ?nodeLineWidth:float,
                ?linkColor:obj, 
                ?linkLineColor: obj,
                ?linkLineWidth:float
            ) =
            (fun (trace:('T :> Trace)) ->
                let nonUniqueLabels = nodes |> Seq.countBy (fun x->x.Label) |> Seq.filter (fun (_,c) -> c > 1)
                if  nonUniqueLabels |> Seq.length > 0 then failwithf "duplicated label names %A" (nonUniqueLabels |> Seq.map fst)
                let lblMap = nodes |> Seq.mapi(fun i x->x.Label,i) |> Map.ofSeq // give each node an index

                let link = 
                    let linkClrs =  
                        links 
                        |> Seq.map (fun x->x.Color)
                        |> Seq.map (function Some x -> x | None -> linkColor |> Option.defaultValue null)
                        |> fun xs -> if xs |> Seq.exists (fun x-> x <> null) then  xs |> Seq.toArray |> Some else None

                    let linkLineClrs =  
                        links 
                        |> Seq.map (fun x->x.LineColor)
                        |> Seq.map (function Some x -> x | None -> linkLineColor |> Option.defaultValue null)
                        |> fun xs -> if xs |> Seq.exists (fun x-> x <> null) then  xs |> Seq.toArray |> Some else None

                    let linkLineWidths =  
                        links 
                        |> Seq.map (fun x->x.LineWidth)
                        |> Seq.map (function Some x -> x | None -> linkLineWidth |> Option.defaultValue 0.5)
                        |> fun xs -> if xs |> Seq.exists (fun x-> x <> 0.5) then  xs |> Seq.toArray |> Some else None

                    let values = 
                        links 
                        |> Seq.map (fun x->x.Value)
                        |> fun xs -> if xs |> Seq.exists Option.isSome then 
                                        xs |> Seq.map(function Some x -> box x | None -> null) |> Seq.toArray |> Some
                                     else 
                                        None

                    let line = 
                        match (linkLineClrs,linkLineWidths) with 
                        | None,None -> None 
                        | cs,ws -> 
                            let ln = new DynamicObj()
                            DynObj.setValueOpt ln "color" cs
                            DynObj.setValueOpt ln "width" ws
                            Some ln

                    let l = new DynamicObj()
                    DynObj.setValue     l "source" (links |> Seq.map (fun x->lblMap.[x.Source.Label]))
                    DynObj.setValue     l "target" (links |> Seq.map (fun x->lblMap.[x.Target.Label]))
                    DynObj.setValueOpt  l "color"  linkClrs
                    DynObj.setValueOpt  l "value"  values
                    DynObj.setValueOpt  l "line"   line

                    l

                let node = 
                    let groups = 
                        nodes 
                        |> Seq.collect(fun x->x.Groups |> Option.defaultValue [||] |> Array.map (fun g-> g,lblMap.[x.Label]))
                        |> Seq.groupBy fst
                        |> Seq.map (fun (g,gs) -> gs |> Seq.map snd)
                        |> fun xs -> if Seq.isEmpty xs then None else Some (xs |> Seq.map Seq.toArray |> Seq.toArray)

                    let xRanks =
                        nodes
                        |> Seq.map (fun x -> x.XRank |> Option.map box |> Option.defaultValue null)
                        |> fun xs -> if xs |> Seq.exists (fun x-> x <> null) then  xs |> Seq.toArray |> Some else None

                    let yRanks =
                        nodes
                        |> Seq.map (fun x -> x.YRank |> Option.map box |> Option.defaultValue null)
                        |> fun xs -> if xs |> Seq.exists (fun x-> x <> null) then  xs |> Seq.toArray |> Some else None

                    let nodeClrs =  
                        nodes 
                        |> Seq.map (fun x->x.Color)
                        |> Seq.map (function Some x -> x | None -> nodeColor |> Option.defaultValue null)
                        |> fun xs -> if xs |> Seq.exists (fun x-> x <> null) then  xs |> Seq.toArray |> Some else None

                    let nodeLineClrs =  
                        nodes 
                        |> Seq.map (fun x->x.LineColor)
                        |> Seq.map (function Some x -> x | None -> nodeLineColor |> Option.defaultValue null)
                        |> fun xs -> if xs |> Seq.exists (fun x-> x <> null) then  xs |> Seq.toArray |> Some else None

                    let nodeLineWidths =  
                        nodes 
                        |> Seq.map (fun x->x.LineWidth)
                        |> Seq.map (function Some x -> x | None -> nodeLineWidth |> Option.defaultValue 0.5)
                        |> fun xs -> if xs |> Seq.exists (fun x-> x <> 0.5) then  xs |> Seq.toArray |> Some else None

                    let line = 
                        match (nodeLineClrs,nodeLineWidths) with 
                        | None,None -> None 
                        | cs,ws -> 
                            let ln = new DynamicObj()
                            DynObj.setValueOpt ln "color" cs
                            DynObj.setValueOpt ln "width" ws
                            Some ln

                    let n = new DynamicObj()
                    DynObj.setValue    n "label" (nodes |> Seq.map (fun  x->x.Label)) 
                    DynObj.setValueOpt n "groups" groups
                    DynObj.setValueOpt n "pad" nodePadding
                    DynObj.setValueOpt n "thickness" nodeThickness
                    DynObj.setValueOpt n "x" xRanks
                    DynObj.setValueOpt n "y" yRanks
                    DynObj.setValueOpt n "color" nodeClrs
                    DynObj.setValueOpt n "line" line
                    n
            
                DynObj.setValue trace "node" node
                DynObj.setValue trace "link" link

                trace
            )

    type Chart with
        [<CompiledName("Sankey")>]
        static member Sankey
            (
                nodes:Node seq, 
                links:Link seq, 
                [<Optional;DefaultParameterValue(null)>] ?nodePadding:float,
                [<Optional;DefaultParameterValue(null)>] ?nodeThickness:float,
                [<Optional;DefaultParameterValue(null)>] ?nodeColor:obj,
                [<Optional;DefaultParameterValue(null)>] ?nodeLineColor:obj,
                [<Optional;DefaultParameterValue(null)>] ?nodeLineWidth:float,
                [<Optional;DefaultParameterValue(null)>] ?linkColor:obj, 
                [<Optional;DefaultParameterValue(null)>] ?linkLineColor: obj,
                [<Optional;DefaultParameterValue(null)>] ?linkLineWidth:float,
                [<Optional;DefaultParameterValue(true)>] ?UseDefaults : bool
            ) = 

                let useDefaults = defaultArg UseDefaults true
                TraceDomain.initSankey(TraceDomainStyle.Sankey
                    (
                        nodes, 
                        links, 
                        ?nodePadding=nodePadding,
                        ?nodeThickness=nodeThickness,
                        ?nodeColor=nodeColor,
                        ?nodeLineColor=nodeLineColor,
                        ?nodeLineWidth=nodeLineWidth,
                        ?linkColor=linkColor,
                        ?linkLineColor=linkLineColor,
                        ?linkLineWidth=linkLineWidth
                    ))
                |> GenericChart.ofTraceObject useDefaults
   

    (*
    #load "SetEnv.fsx"
    open Plotly.NET
    open PlotlyExts
    let testSankey() =
        let n1 = Node.Create("a",color="Black")
        let n2 = Node.Create("b",color="Red")
        let n3 = Node.Create("c",color="Purple")
        let n4 = Node.Create("d",color="Green")
        let n5 = Node.Create("e",color="Orange")
        let link1 = Link.Create(n1,n2,value=1.0)
        let link2 = Link.Create(n2,n3,value=2.0)
        let link3 = Link.Create(n1,n5,value=1.3)
        let link4 = Link.Create(n4,n5,value=1.5)
        let link5 = Link.Create(n3,n5,value=0.5)
        Chart.Sankey([n1;n2;n3;n4;n5],[link1;link2;link3;link4;link5])
        |> Chart.withTitle "Sankey Sample"
        |> Chart.Show

    testSankey()
    *)



      
