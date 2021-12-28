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
    
    let rec printObj (d:ImmutableDynamicObj) =
        ImmutableDynamicObj.print d
    

    scatterChart
    |> GenericChart.getTraces
    |> Seq.exactlyOne
    |> printObj
    
    scatterChart
    |> Chart.show
    
    0