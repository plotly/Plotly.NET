namespace FSharp.Plotly

module StyleOption =
    
    type Boxpoints =
    | All 

    let stringBoxpoints (b:Boxpoints) =
        match b with
        | All -> "all"

