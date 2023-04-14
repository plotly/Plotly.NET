namespace  Plotly.NET.Tests.TestCharts.Chart2D

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open Plotly.NET.StyleParam

/// Test charts created with Chart2D.Chart.Spline
module Spline = 
    
    let ``Simple spline chart`` = 
        let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
        let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
        Chart.Spline(x = x, y = y, Name="spline", UseDefaults = false)   
