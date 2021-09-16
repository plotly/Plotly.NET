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
            ?AAxis      : LinearAxis,
            ?BAxis      : LinearAxis,
            ?CAxis      : LinearAxis,
            ?Domain     : Domain,
            ?Sum        : #IConvertible
        ) =    
            Ternary()
            |> Ternary.style
                (
                    ?AAxis  = AAxis ,
                    ?BAxis  = BAxis ,
                    ?CAxis  = CAxis ,
                    ?Domain = Domain,
                    ?Sum    = Sum   
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
            ?AAxis      : LinearAxis,
            ?BAxis      : LinearAxis,
            ?CAxis      : LinearAxis,
            ?Domain     : Domain,
            ?Sum        : #IConvertible
        ) =
            (fun (ternary:Ternary) -> 
               
                ++? ("aaxis", AAxis  )
                ++? ("baxis", BAxis  )
                ++? ("caxis", CAxis  )
                ++? ("domain", Domain )
                ++? ("sum", Sum    )

                ternary
            )