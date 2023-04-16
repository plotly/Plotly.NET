module Chart3DTestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open System

open TestUtils.DataGeneration

module Scatter3D = 

    let ``Simple scatter3d chart with axis titles`` =
        let x = [19; 26; 55;]
        let y = [19; 26; 55;]
        let z = [19; 26; 55;]

        Chart.Scatter3D(x = x,y = y,z = z, mode = StyleParam.Mode.Markers, UseDefaults = false)
        |> Chart.withXAxisStyle("my x-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withYAxisStyle("my y-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withZAxisStyle("my z-axis")
        |> Chart.withSize(800,800)

module Point3D =
    
    let ``Simple Point3D chart with axis titles`` =
        let x = [19; 26; 55;]
        let y = [19; 26; 55;]
        let z = [19; 26; 55;]

        Chart.Point3D(x = x,y = y,z = z, UseDefaults = false)
        |> Chart.withXAxisStyle("my x-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withYAxisStyle("my y-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withZAxisStyle("my z-axis")
        |> Chart.withSize(800,800)



module Line3D = 
    let ``Upwards spiral line 3D chart with markers`` =
        let c = [0. .. 0.5 .. 15.]
    
        let x, y, z =  
            c
            |> List.map (fun i ->
                let i' = float i 
                let r = 10. * Math.Cos (i' / 10.)
                (r * Math.Cos i', r * Math.Sin i', i')
                |> fun (x,y,z) -> 
                    Math.Round(x,3),
                    Math.Round(y,3),
                    Math.Round(z,3)
            )
            |> List.unzip3

        Chart.Line3D(x = x, y = y, z = z, ShowMarkers=true, UseDefaults = false)
        |> Chart.withXAxisStyle("x-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withYAxisStyle("y-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withZAxisStyle("z-axis")
        |> Chart.withSize(800, 800)


module Bubble3D = 
    
    let ``Simple Bubble3D chart with axis titles`` =
        Chart.Bubble3D(
            xyz = [1,3,2; 6,5,4; 7,9,8],
            sizes = [20; 40; 30],
            MultiText = ["A"; "B"; "C"],
            TextPosition = StyleParam.TextPosition.TopLeft, 
            UseDefaults = false 
        )
        |> Chart.withXAxisStyle("x-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withYAxisStyle("y-axis", Id=StyleParam.SubPlotId.Scene 1)
        |> Chart.withZAxisStyle("z-axis")

module Surface = 

    let ``Peak and sink surface plot`` =

        //---------------------- Create example data ----------------------
        let size = 100
        let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
        let y = linspace(-2. * Math.PI, 2. * Math.PI, size)
    
        let f x y = - (5. * x / (x**2. + y**2. + 1.) )
    
        let z = 
            Array.init size (fun i -> 
                Array.init size (fun j -> f x.[j] y.[i] )
                            )
    
        Chart.Surface(zData = z, UseDefaults = false)

    let ``Surface plot with x/y indices mapping to z matrix with contours`` =
        let x' = [0.;2.5]
        let y' = [0.;2.5]
        let z' = [
            [1.;1.;]; // row wise (length x)
            [1.;2.;];
            ] // column (length y)
    
        Chart.Surface(zData = z', X = x', Y = y', Opacity=0.5, Contours=Contours.initXyz(Show=true), UseDefaults = false)


module Mesh3D = 

    let ``Mesh3D chart with random x/x/z data`` =
    
        let rnd = System.Random(5)
        let x = Array.init 50 (fun _ -> rnd.NextDouble())
        let y = Array.init 50 (fun _ -> rnd.NextDouble())
        let z = Array.init 50 (fun _ -> rnd.NextDouble())
    
        Chart.Mesh3D(
            x = x,
            y = y,
            z = z,
            FlatShading = true,
            Contour = Contour.init(Show = true),
            UseDefaults = false
        )

module Cone = 

    let ``Simple cone chart`` =
        Chart.Cone(
            x = [1; 1; 1],
            y = [1; 2; 3],
            z = [1; 1; 1],
            u = [1; 2; 3],
            v = [1; 1; 2],
            w = [4; 4; 1],
            ColorScale = StyleParam.Colorscale.Viridis, 
            UseDefaults = false
    )

module StreamTube = 

    let ``Simple StreamTube chart `` =
        Chart.StreamTube(
            x = [0; 0; 0],
            y = [0; 1; 2],
            z = [0; 0; 0],
            u = [0; 0; 0],
            v = [1; 1; 1],
            w = [0; 0; 0],
            ColorScale = StyleParam.Colorscale.Viridis, 
            UseDefaults = false
        )

module Volume = 

    let ``Fancy mgrid based volume chart`` =
        let x,y,z = mgrid(1.,2.,4)
        Chart.Volume(
            x = (x |> Array.concat |> Array.concat |> Array.map (fun x -> Math.Round(x,3))),
            y = (y |> Array.concat |> Array.concat |> Array.map (fun x -> Math.Round(x,3))),
            z = (z |> Array.concat |> Array.concat |> Array.map (fun x -> Math.Round(x,3))),
            value = (z |> Array.concat |> Array.concat |> Array.map (fun x -> Math.Round(x,3))),
            ColorScale = StyleParam.Colorscale.Viridis, 
            UseDefaults = false
        )

module IsoSurface =

    let ``Fancy mgrid based isosurface chart`` =
        let x,y,z = mgrid(1.,2.,4)
        Chart.IsoSurface(
            x = (x |> Array.concat |> Array.concat |> Array.map (fun x -> Math.Round(x,3))),
            y = (y |> Array.concat |> Array.concat |> Array.map (fun x -> Math.Round(x,3))),
            z = (z |> Array.concat |> Array.concat |> Array.map (fun x -> Math.Round(x,3))),
            value = (z |> Array.concat |> Array.concat |> Array.map (fun x -> Math.Round(x,3))),
            ColorScale = StyleParam.Colorscale.Viridis, 
            UseDefaults = false
        )