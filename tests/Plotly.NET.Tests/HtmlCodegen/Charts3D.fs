module Tests.Charts3D

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open System

let scatterChart =
    let x = [19; 26; 55;]
    let y = [19; 26; 55;]
    let z = [19; 26; 55;]

    Chart.Scatter3d(x,y,z,StyleParam.Mode.Markers)
    |> Chart.withX_AxisStyle("my x-axis")
    |> Chart.withY_AxisStyle("my y-axis")
    |> Chart.withZ_AxisStyle("my z-axis")
    |> Chart.withSize(800.,800.)

[<Tests>]
let ``3D Scatter charts`` =
    testList "Charts3D.3D Scatter charts" [
        testCase "3D Scatter charts data" ( fun () ->
            "var data = [{\"type\":\"scatter3d\",\"x\":[19,26,55],\"y\":[19,26,55],\"z\":[19,26,55],\"mode\":\"markers\",\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains scatterChart
        );
        testCase "3D Scatter charts layout" ( fun () ->
            "var layout = {\"scene\":{\"xaxis\":{\"title\":\"my x-axis\"},\"yaxis\":{\"title\":\"my y-axis\"},\"zaxis\":{\"title\":\"my z-axis\"}},\"width\":800.0,\"height\":800.0};"
            |> chartGeneratedContains scatterChart
        );
    ]

let lineChart =
    let c = [0. .. 0.5 .. 15.]
    
    let x, y, z =  
        c
        |> List.map (fun i ->
            let i' = float i 
            let r = 10. * Math.Cos (i' / 10.)
            (r * Math.Cos i', r * Math.Sin i', i')
        )
        |> List.unzip3

    Chart.Scatter3d(x, y, z, StyleParam.Mode.Lines_Markers)
    |> Chart.withX_AxisStyle("x-axis")
    |> Chart.withY_AxisStyle("y-axis")
    |> Chart.withZ_AxisStyle("z-axis")
    |> Chart.withSize(800., 800.)


[<Tests>]
let ``Line charts`` =
    testList "Charts3D.Bar and column charts" [
        testCase " data" ( fun () ->
            "var data = [{\"type\":\"scatter3d\",\"x\":[10.0,8.764858122060915,5.3760304484812105,0.699428991431538,-4.078516059742164,-7.762380006776013,-9.457759559629629,-8.796818588044248,-6.020456431562834,-1.8981046678556164,2.4893698743024015,6.041583606256742,7.924627339505819,7.774455867055686,5.766162492106399,2.5362920361842747,-1.0137084976470045,-3.9731770939413367,-5.663676531805762,-5.800381805436716,-4.533522819483132,-2.3661340757417872,0.020074794419808174,1.9742392407015044,3.0577702559255746,3.1462811058452385,2.427409510770794,1.302916035546942,0.23240834306912295,-0.42769357063721014,-0.5373819709641076],\"y\":[0.0,4.788263815209447,8.372671348444594,9.862941931402888,8.911720173488927,5.798670944701264,1.3481709304529075,-3.2951619221615798,-6.970612585921842,-8.802141619140079,-8.415352216177444,-6.014904288506064,-2.306115620213046,1.7125353726077581,5.024910671806752,6.86324142009979,6.892925283704576,5.269880365378672,2.561769585348826,-0.43714135926897707,-2.9393586065447344,-4.37711141115013,-4.535916791549611,-3.576112184549465,-1.9443135767963393,-0.2091277735131711,1.123941901777903,1.7603416439605064,1.6837070198341995,1.1265744325858227,0.4599954209124893],\"z\":[0.0,0.5,1.0,1.5,2.0,2.5,3.0,3.5,4.0,4.5,5.0,5.5,6.0,6.5,7.0,7.5,8.0,8.5,9.0,9.5,10.0,10.5,11.0,11.5,12.0,12.5,13.0,13.5,14.0,14.5,15.0],\"mode\":\"lines+markers\",\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains lineChart
        );
        testCase " layout" ( fun () ->
            "var layout = {\"scene\":{\"xaxis\":{\"title\":\"x-axis\"},\"yaxis\":{\"title\":\"y-axis\"},\"zaxis\":{\"title\":\"z-axis\"}},\"width\":800.0,\"height\":800.0};"
            |> chartGeneratedContains lineChart
        );
    ]