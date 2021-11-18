// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    
    let scatterChart =
        let x = [19; 26; 55;]
        let y = [19; 26; 55;]
        let z = [19; 26; 55;]
    
        Chart.Scatter3D(x,y,z,StyleParam.Mode.Markers)
        |> Chart.withXAxisStyle("my x-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withYAxisStyle("my y-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withZAxisStyle("my z-axis")
        |> Chart.withMarker(Marker.init(Size=5))
        |> Chart.withLine(Line.init(Color=Color.fromString "red"))
        |> Chart.withSize(800,800)
    
    let rec printObj (d:DynamicObj) =
    
        let members = d.GetDynamicMemberNames() |> Seq.cast<string> |> List.ofSeq

        let rec loop (object:DynamicObj) (identationLevel:int) (membersLeft:string list) (acc:string list) =
            let ident = [for i in 0 .. identationLevel do yield "    "] |> String.concat ""
            match membersLeft with
            | [] -> acc |> List.rev |> String.concat "\r\n"
            | m::rest ->
                let item = object?(``m``)
                match item with
                | :? DynamicObj as item -> 
                    let innerMembers = item.GetDynamicMemberNames() |> Seq.cast<string> |> List.ofSeq
                    let innerPrint = (loop item (identationLevel + 1) innerMembers [])
                    loop object identationLevel rest ($"{ident}{m}:\r\n{innerPrint}" :: acc)
                | _ -> 
                    loop d identationLevel rest ($"{ident}{m}: {item}"::acc)
    
        loop d 0 members []
    

    scatterChart
    |> GenericChart.getTraces
    |> Seq.exactlyOne
    |> printObj
    |> printfn "%s"
    
    scatterChart
    |> Chart.show
    
    0