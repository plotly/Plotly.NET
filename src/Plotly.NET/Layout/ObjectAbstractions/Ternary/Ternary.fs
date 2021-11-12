namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type Ternary() =
    inherit DynamicObj ()

    /// <summary>
    /// Initializes a ternary object
    /// </summary>
    /// <param name="AAxis">Sets the ternary A Axis</param>
    /// <param name="BAxis">Sets the ternary B Axis</param>
    /// <param name="CAxis">Sets the ternary C Axis</param>
    /// <param name="Domain">Sets the ternary domain</param>
    /// <param name="Sum">The number each triplet should sum to, and the maximum range of each axis</param>
    static member init
        (    
            [<Optional;DefaultParameterValue(null)>] ?AAxis      : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?BAxis      : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?CAxis      : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?Domain     : Domain,
            [<Optional;DefaultParameterValue(null)>] ?Sum        : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?BGColor    : Color
        ) =    
            Ternary()
            |> Ternary.style
                (
                    ?AAxis  = AAxis ,
                    ?BAxis  = BAxis ,
                    ?CAxis  = CAxis ,
                    ?Domain = Domain,
                    ?Sum    = Sum   ,
                    ?BGColor= BGColor
                )

    /// <summary>
    /// Creates a function that applies the given style parameters to a Ternary object.
    /// </summary>
    /// <param name="AAxis">Sets the ternary A Axis</param>
    /// <param name="BAxis">Sets the ternary B Axis</param>
    /// <param name="CAxis">Sets the ternary C Axis</param>
    /// <param name="Domain">Sets the ternary domain</param>
    /// <param name="Sum">The number each triplet should sum to, and the maximum range of each axis</param>
    static member style
        (    
            [<Optional;DefaultParameterValue(null)>] ?AAxis      : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?BAxis      : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?CAxis      : LinearAxis,
            [<Optional;DefaultParameterValue(null)>] ?Domain     : Domain,
            [<Optional;DefaultParameterValue(null)>] ?Sum        : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?BGColor    : Color
        ) =
            (fun (ternary:Ternary) -> 
               
                AAxis  |> DynObj.setValueOpt ternary "aaxis"
                BAxis  |> DynObj.setValueOpt ternary "baxis"
                CAxis  |> DynObj.setValueOpt ternary "caxis"
                Domain |> DynObj.setValueOpt ternary "domain"
                Sum    |> DynObj.setValueOpt ternary "sum"
                BGColor|> DynObj.setValueOpt ternary "bgcolor"

                ternary
            )