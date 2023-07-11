namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type Ternary() =
    inherit DynamicObj()

    /// <summary>
    /// Initializes a ternary object
    /// </summary>
    /// <param name="AAxis">Sets the ternary A Axis</param>
    /// <param name="BAxis">Sets the ternary B Axis</param>
    /// <param name="CAxis">Sets the ternary C Axis</param>
    /// <param name="Domain">Sets the ternary domain</param>
    /// <param name="Sum">The number each triplet should sum to, and the maximum range of each axis</param>
    /// <param name="BGColor">Sets the background color of the ternary layout.</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?AAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?BAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?CAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Sum: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color
        ) =
        Ternary()
        |> Ternary.style (
            ?AAxis = AAxis,
            ?BAxis = BAxis,
            ?CAxis = CAxis,
            ?Domain = Domain,
            ?Sum = Sum,
            ?BGColor = BGColor
        )

    /// <summary>
    /// Creates a function that applies the given style parameters to a Ternary object.
    /// </summary>
    /// <param name="AAxis">Sets the ternary A Axis</param>
    /// <param name="BAxis">Sets the ternary B Axis</param>
    /// <param name="CAxis">Sets the ternary C Axis</param>
    /// <param name="Domain">Sets the ternary domain</param>
    /// <param name="Sum">The number each triplet should sum to, and the maximum range of each axis</param>
    /// <param name="BGColor">Sets the background color of the ternary layout.</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?AAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?BAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?CAxis: LinearAxis,
            [<Optional; DefaultParameterValue(null)>] ?Domain: Domain,
            [<Optional; DefaultParameterValue(null)>] ?Sum: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?BGColor: Color
        ) =
        (fun (ternary: Ternary) ->

            AAxis |> DynObj.setValueOpt ternary "aaxis"
            BAxis |> DynObj.setValueOpt ternary "baxis"
            CAxis |> DynObj.setValueOpt ternary "caxis"
            Domain |> DynObj.setValueOpt ternary "domain"
            Sum |> DynObj.setValueOpt ternary "sum"
            BGColor |> DynObj.setValueOpt ternary "bgcolor"

            ternary)


    /// <summary>
    /// Returns Some(dynamic member value) of the object's underlying DynamicObj when a dynamic member with the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="ternary">The object to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (ternary: Ternary) = ternary.TryGetTypedValue<'T>(propName)

    /// <summary>
    /// Returns the a axis of the given ternary object.
    ///
    /// If there is no a axis set, returns an empty LinearAxis object.
    /// </summary>
    /// <param name="ternary">The ternary object to get the a axis from</param>
    static member getAAxis(ternary: Ternary) =
        ternary |> Ternary.tryGetTypedMember<LinearAxis> "aaxis" |> Option.defaultValue (LinearAxis.init ())

    /// <summary>
    /// Returns a function that sets the a axis object of the given ternary object.
    /// </summary>
    /// <param name="aAxis">The new a axis object</param>
    static member setAAxis(aAxis: LinearAxis) =
        (fun (ternary: Ternary) ->
            ternary.SetValue("aaxis", aAxis)
            ternary)

    /// <summary>
    /// Returns the b axis of the given ternary object.
    ///
    /// If there is no b axis set, returns an empty LinearAxis object.
    /// </summary>
    /// <param name="ternary">The ternary object to get the b axis from</param>
    static member getBAxis(ternary: Ternary) =
        ternary |> Ternary.tryGetTypedMember<LinearAxis> "baxis" |> Option.defaultValue (LinearAxis.init ())

    /// <summary>
    /// Returns a function that sets the b axis object of the given ternary object.
    /// </summary>
    /// <param name="bAxis">The new b axis object</param>
    static member setBAxis(bAxis: LinearAxis) =
        (fun (ternary: Ternary) ->
            ternary.SetValue("baxis", bAxis)
            ternary)

    /// <summary>
    /// Returns the c axis of the given ternary object.
    ///
    /// If there is no c axis set, returns an empty LinearAxis object.
    /// </summary>
    /// <param name="ternary">The ternary object to get the c axis from</param>
    static member getCAxis(ternary: Ternary) =
        ternary |> Ternary.tryGetTypedMember<LinearAxis> "caxis" |> Option.defaultValue (LinearAxis.init ())

    /// <summary>
    /// Returns a function that sets the c axis object of the given ternary object.
    /// </summary>
    /// <param name="cAxis">The new c axis object</param>
    static member setCAxis(cAxis: LinearAxis) =
        (fun (ternary: Ternary) ->
            ternary.SetValue("caxis", cAxis)
            ternary)
