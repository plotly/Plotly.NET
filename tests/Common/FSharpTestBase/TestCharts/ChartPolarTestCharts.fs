module ChartPolarTestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects
open System

open TestUtils.DataGeneration
open Deedle

let internal radial  = [ 1; 2; 3; 4; 5; 6; 7;]
let internal theta  = [0; 45; 90; 135; 200; 320; 184;]

module ScatterPolar = ()

module PointPolar = 

    let ``Simple polar point chart`` = Chart.PointPolar(r = radial,theta = theta, UseDefaults = false)

module LinePolar = 

    let ``Simple polar line chart with line style`` = 
        Chart.LinePolar(r = radial,theta = theta, UseDefaults = false)
        |> Chart.withLineStyle(Color=Color.fromString "purple",Dash=StyleParam.DrawingStyle.DashDot)

module SplinePolar = 
    
    let ``styled polar spline chart`` = 
        Chart.SplinePolar(
            r = radial,
            theta = theta,
            MultiText=["one";"two";"three";"four";"five";"six";"seven"],
            TextPosition=StyleParam.TextPosition.TopCenter,
            ShowMarkers=true, 
            UseDefaults = false
        )

module BubblePolar = ()

module BarPolar = 
    
    let ``Styled windrose chart`` = 
        let r   = [77.5; 72.5; 70.0; 45.0; 22.5; 42.5; 40.0; 62.5]
        let r2  = [57.5; 50.0; 45.0; 35.0; 20.0; 22.5; 37.5; 55.0]
        let r3  = [40.0; 30.0; 30.0; 35.0; 7.5; 7.5; 32.5; 40.0]
        let r4  = [20.0; 7.5; 15.0; 22.5; 2.5; 2.5; 12.5; 22.5]
    
        let t = ["North"; "N-E"; "East"; "S-E"; "South"; "S-W"; "West"; "N-W"]

        [
            Chart.BarPolar (r = r , theta = t, Name="11-14 m/s" , MarkerPatternShape = StyleParam.PatternShape.Checked        , UseDefaults = false)
            Chart.BarPolar (r = r2, theta = t, Name="8-11 m/s"  , MarkerPatternShape = StyleParam.PatternShape.DiagonalChecked, UseDefaults = false)
            Chart.BarPolar (r = r3, theta = t, Name="5-8 m/s"   , MarkerPatternShape = StyleParam.PatternShape.VerticalLines  , UseDefaults = false)
            Chart.BarPolar (r = r4, theta = t, Name="< 5 m/s"   , MarkerPatternShape = StyleParam.PatternShape.HorizontalLines, UseDefaults = false)
        ]
        |> Chart.combine
        |> Chart.withAngularAxis(
            AngularAxis.init(
                CategoryOrder = StyleParam.CategoryOrder.Array,
                CategoryArray = (["East"; "N-E"; "North"; "N-W"; "West"; "S-W"; "South"; "S-E";]) // set the order of the categorical axis
            )
        )