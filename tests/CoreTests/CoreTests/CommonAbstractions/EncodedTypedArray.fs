module Tests.CommonAbstractions.EncodedTypedArray

open Expecto
open Plotly.NET
open Plotly.NET.TraceObjects
open Newtonsoft.Json
open System

let private serialize (o: obj) = JsonConvert.SerializeObject o

[<Tests>]
let ``TypedArrayDType tests`` =
    testList "CommonAbstractions.TypedArrayDType" [
        testCase "Float64 shorthand"      (fun () -> Expect.equal (TypedArrayDType.Float64      |> TypedArrayDType.toString) "f8"  "f8 expected")
        testCase "Float32 shorthand"      (fun () -> Expect.equal (TypedArrayDType.Float32      |> TypedArrayDType.toString) "f4"  "f4 expected")
        testCase "Int32 shorthand"        (fun () -> Expect.equal (TypedArrayDType.Int32        |> TypedArrayDType.toString) "i4"  "i4 expected")
        testCase "UInt32 shorthand"       (fun () -> Expect.equal (TypedArrayDType.UInt32       |> TypedArrayDType.toString) "u4"  "u4 expected")
        testCase "Int16 shorthand"        (fun () -> Expect.equal (TypedArrayDType.Int16        |> TypedArrayDType.toString) "i2"  "i2 expected")
        testCase "UInt16 shorthand"       (fun () -> Expect.equal (TypedArrayDType.UInt16       |> TypedArrayDType.toString) "u2"  "u2 expected")
        testCase "Int8 shorthand"         (fun () -> Expect.equal (TypedArrayDType.Int8         |> TypedArrayDType.toString) "i1"  "i1 expected")
        testCase "UInt8 shorthand"        (fun () -> Expect.equal (TypedArrayDType.UInt8        |> TypedArrayDType.toString) "u1"  "u1 expected")
        testCase "UInt8Clamped shorthand" (fun () -> Expect.equal (TypedArrayDType.UInt8Clamped |> TypedArrayDType.toString) "u1c" "u1c expected")
    ]

[<Tests>]
let ``Trace3D family encoded fields`` =
    testList "CommonAbstractions.EncodedTypedArray Trace3D family integration" [

        testCase "Scatter3D encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace3D.initScatter3D (
                    Trace3DStyle.Scatter3D(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 11.0; 12.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 13.0; 14.0; 15.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "scatter3d must contain %s" needle))
        )

        testCase "Scatter3D encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace3D.initScatter3D (
                    Trace3DStyle.Scatter3D(
                        Ids = [ 9; 8; 7 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                        X = [ 10.0; 20.0; 30.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        Y = [ 40.0; 50.0; 60.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        Z = [ 70.0; 80.0; 90.0 ],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                        MultiText = [ 100.0; 200.0; 300.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 11.0; 12.0 |],
                        CustomData = [ 13.0; 14.0; 15.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 16.0; 17.0; 18.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":[9,8,7]"; "\"x\":[10.0,20.0,30.0]"; "\"y\":[40.0,50.0,60.0]"; "\"z\":[70.0,80.0,90.0]"; "\"text\":[100.0,200.0,300.0]"; "\"customdata\":[13.0,14.0,15.0]" ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain scatter3d value must not be present: %s" needle))
        )

        testCase "Surface encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace3D.initSurface (
                    Trace3DStyle.Surface(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 21; 22 |],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0; 33.0; 34.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0 |],
                        OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 1.0; 0.2 |], shape = [ 2; 2 ])
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"shape\":\"2,2\""; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"opacityscale\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "surface must contain %s" needle))
        )

        testCase "Surface encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace3D.initSurface (
                    Trace3DStyle.Surface(
                        Ids = [ 9; 8 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 21; 22 |],
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Y = [ 30.0; 40.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Z = [ [ 50.0; 60.0 ]; [ 70.0; 80.0 ] ],
                        ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0 |],
                        CustomData = [ 41.0; 42.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 43.0; 44.0 |],
                        OpacityScale = [ [ 0.0; 1.0 ]; [ 1.0; 0.2 ] ],
                        OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 1.0; 0.2 |], shape = [ 2; 2 ])
                    )
                )

            let json = serialize trace
            [ "\"ids\":[9,8]"; "\"x\":[10.0,20.0]"; "\"y\":[30.0,40.0]"; "\"z\":[[50.0,60.0],[70.0,80.0]]"; "\"text\":[100.0,200.0]"; "\"customdata\":[41.0,42.0]"; "\"opacityscale\":[[0.0,1.0],[1.0,0.2]]" ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain surface value must not be present: %s" needle))
        )

        testCase "Mesh3D encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace3D.initMesh3D (
                    Trace3DStyle.Mesh3D(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52; 53 |],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 0.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 1.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 0.0 |],
                        IEncoded = EncodedTypedArray.ofInt32Array [| 0 |],
                        JEncoded = EncodedTypedArray.ofInt32Array [| 1 |],
                        KEncoded = EncodedTypedArray.ofInt32Array [| 2 |],
                        IntensityEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0; 73.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"i\":{\"bdata\":"; "\"j\":{\"bdata\":"; "\"k\":{\"bdata\":"; "\"intensity\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "mesh3d must contain %s" needle))
        )

        testCase "Mesh3D encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace3D.initMesh3D (
                    Trace3DStyle.Mesh3D(
                        Ids = [ 9; 8; 7 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52; 53 |],
                        X = [ 10.0; 20.0; 30.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 0.0 |],
                        Y = [ 40.0; 50.0; 60.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 1.0 |],
                        Z = [ 70.0; 80.0; 90.0 ],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 0.0 |],
                        I = [ 9 ],
                        IEncoded = EncodedTypedArray.ofInt32Array [| 0 |],
                        J = [ 8 ],
                        JEncoded = EncodedTypedArray.ofInt32Array [| 1 |],
                        K = [ 7 ],
                        KEncoded = EncodedTypedArray.ofInt32Array [| 2 |],
                        Intensity = [ 0.9; 0.8; 0.7 ],
                        IntensityEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                        MultiText = [ 100.0; 200.0; 300.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0 |],
                        CustomData = [ 71.0; 72.0; 73.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 74.0; 75.0; 76.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":[9,8,7]"; "\"x\":[10.0,20.0,30.0]"; "\"y\":[40.0,50.0,60.0]"; "\"z\":[70.0,80.0,90.0]"; "\"i\":[9]"; "\"j\":[8]"; "\"k\":[7]"; "\"intensity\":[0.9,0.8,0.7]"; "\"text\":[100.0,200.0,300.0]"; "\"customdata\":[71.0,72.0,73.0]" ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain mesh3d value must not be present: %s" needle))
        )

        testCase "Cone encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace3D.initCone (
                    Trace3DStyle.Cone(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 81; 82 |],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                        UEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2 |],
                        VEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                        WEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.6 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 93.0; 94.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"u\":{\"bdata\":"; "\"v\":{\"bdata\":"; "\"w\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "cone must contain %s" needle))
        )

        testCase "StreamTube encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace3D.initStreamTube (
                    Trace3DStyle.StreamTube(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102 |],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                        UEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2 |],
                        VEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                        WEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.6 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 111.0; 112.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 113.0; 114.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"u\":{\"bdata\":"; "\"v\":{\"bdata\":"; "\"w\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "streamtube must contain %s" needle))
        )

        testCase "Volume encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace3D.initVolume (
                    Trace3DStyle.Volume(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 121; 122; 123 |],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                        ValueEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 131.0; 132.0; 133.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 141.0; 142.0; 143.0 |],
                        OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 0.5; 0.2; 1.0; 1.0 |], shape = [ 3; 2 ])
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"value\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"opacityscale\":{\"bdata\":"; "\"shape\":\"3,2\"" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "volume must contain %s" needle))
        )

        testCase "Volume encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace3D.initVolume (
                    Trace3DStyle.Volume(
                        Ids = [ 9; 8; 7 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 121; 122; 123 |],
                        X = [ 10.0; 20.0; 30.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        Y = [ 40.0; 50.0; 60.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        Z = [ 70.0; 80.0; 90.0 ],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                        Value = [ 0.9; 0.8; 0.7 ],
                        ValueEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                        MultiText = [ 100.0; 200.0; 300.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 131.0; 132.0; 133.0 |],
                        CustomData = [ 141.0; 142.0; 143.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 144.0; 145.0; 146.0 |],
                        OpacityScale = [ [ 0.0; 1.0 ]; [ 0.5; 0.2 ]; [ 1.0; 1.0 ] ],
                        OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 0.5; 0.2; 1.0; 1.0 |], shape = [ 3; 2 ])
                    )
                )

            let json = serialize trace
            [ "\"ids\":[9,8,7]"; "\"x\":[10.0,20.0,30.0]"; "\"y\":[40.0,50.0,60.0]"; "\"z\":[70.0,80.0,90.0]"; "\"value\":[0.9,0.8,0.7]"; "\"text\":[100.0,200.0,300.0]"; "\"customdata\":[141.0,142.0,143.0]"; "\"opacityscale\":[[0.0,1.0],[0.5,0.2],[1.0,1.0]]" ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain volume value must not be present: %s" needle))
        )

        testCase "IsoSurface encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace3D.initIsoSurface (
                    Trace3DStyle.IsoSurface(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 151; 152; 153 |],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                        ValueEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 161.0; 162.0; 163.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 171.0; 172.0; 173.0 |],
                        OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 0.5; 0.2; 1.0; 1.0 |], shape = [ 3; 2 ])
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"value\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"opacityscale\":{\"bdata\":"; "\"shape\":\"3,2\"" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "isosurface must contain %s" needle))
        )
    ]

[<Tests>]
let ``EncodedTypedArray init`` =
    testList "CommonAbstractions.EncodedTypedArray.init" [

        testCase "init with user-supplied base64 and no shape (1-D)" (fun () ->
            let eta = EncodedTypedArray.init("AAAA", TypedArrayDType.Float32)
            let json = serialize eta
            Expect.equal json """{"bdata":"AAAA","dtype":"f4"}""" "1-D init must omit shape"
        )

        testCase "init with explicit shape serializes as comma-separated string" (fun () ->
            let eta = EncodedTypedArray.init("AAAA", TypedArrayDType.Float32, shape = [ 2; 3 ])
            let json = serialize eta
            Expect.equal json """{"bdata":"AAAA","dtype":"f4","shape":"2,3"}""" "shape must serialize as comma-separated string"
        )

        testCase "init with single-dim explicit shape still serializes" (fun () ->
            let eta = EncodedTypedArray.init("AAAA", TypedArrayDType.UInt8Clamped, shape = [ 4 ])
            let json = serialize eta
            Expect.equal json """{"bdata":"AAAA","dtype":"u1c","shape":"4"}""" "single-dim explicit shape must be honored"
        )
    ]

[<Tests>]
let ``EncodedTypedArray factories`` =
    testList "CommonAbstractions.EncodedTypedArray factories" [

        testCase "ofFloat64Array round-trips bytes" (fun () ->
            let data = [| 1.0; 2.0; 3.0 |]
            let expectedBytes = Array.zeroCreate<byte> (data.Length * sizeof<float>)
            Buffer.BlockCopy(data, 0, expectedBytes, 0, expectedBytes.Length)
            let expected = Convert.ToBase64String expectedBytes
            let json = EncodedTypedArray.ofFloat64Array data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"f8"}""" expected) "Float64 round-trip mismatch"
        )

        testCase "ofFloat32Array round-trips bytes" (fun () ->
            let data = [| 1.0f; 2.0f; 3.0f |]
            let expectedBytes = Array.zeroCreate<byte> (data.Length * sizeof<single>)
            Buffer.BlockCopy(data, 0, expectedBytes, 0, expectedBytes.Length)
            let expected = Convert.ToBase64String expectedBytes
            let json = EncodedTypedArray.ofFloat32Array data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"f4"}""" expected) "Float32 round-trip mismatch"
        )

        testCase "ofInt32Array round-trips bytes" (fun () ->
            let data = [| 1; 2; 3; 4 |]
            let expectedBytes = Array.zeroCreate<byte> (data.Length * sizeof<int32>)
            Buffer.BlockCopy(data, 0, expectedBytes, 0, expectedBytes.Length)
            let expected = Convert.ToBase64String expectedBytes
            let json = EncodedTypedArray.ofInt32Array data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"i4"}""" expected) "Int32 round-trip mismatch"
        )

        testCase "ofUInt32Array round-trips bytes" (fun () ->
            let data = [| 1u; 2u; 3u |]
            let expectedBytes = Array.zeroCreate<byte> (data.Length * sizeof<uint32>)
            Buffer.BlockCopy(data, 0, expectedBytes, 0, expectedBytes.Length)
            let expected = Convert.ToBase64String expectedBytes
            let json = EncodedTypedArray.ofUInt32Array data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"u4"}""" expected) "UInt32 round-trip mismatch"
        )

        testCase "ofInt16Array round-trips bytes" (fun () ->
            let data = [| 1s; 2s; 3s |]
            let expectedBytes = Array.zeroCreate<byte> (data.Length * sizeof<int16>)
            Buffer.BlockCopy(data, 0, expectedBytes, 0, expectedBytes.Length)
            let expected = Convert.ToBase64String expectedBytes
            let json = EncodedTypedArray.ofInt16Array data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"i2"}""" expected) "Int16 round-trip mismatch"
        )

        testCase "ofUInt16Array round-trips bytes" (fun () ->
            let data = [| 1us; 2us; 3us |]
            let expectedBytes = Array.zeroCreate<byte> (data.Length * sizeof<uint16>)
            Buffer.BlockCopy(data, 0, expectedBytes, 0, expectedBytes.Length)
            let expected = Convert.ToBase64String expectedBytes
            let json = EncodedTypedArray.ofUInt16Array data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"u2"}""" expected) "UInt16 round-trip mismatch"
        )

        testCase "ofInt8Array round-trips bytes" (fun () ->
            let data = [| 1y; 2y; 3y |]
            let expectedBytes = Array.zeroCreate<byte> data.Length
            Buffer.BlockCopy(data, 0, expectedBytes, 0, expectedBytes.Length)
            let expected = Convert.ToBase64String expectedBytes
            let json = EncodedTypedArray.ofInt8Array data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"i1"}""" expected) "Int8 round-trip mismatch"
        )

        testCase "ofUInt8Array round-trips bytes" (fun () ->
            let data = [| 1uy; 2uy; 3uy |]
            let expected = Convert.ToBase64String data
            let json = EncodedTypedArray.ofUInt8Array data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"u1"}""" expected) "UInt8 round-trip mismatch"
        )

        testCase "ofUInt8ClampedArray uses u1c dtype" (fun () ->
            let data = [| 10uy; 20uy; 30uy |]
            let expected = Convert.ToBase64String data
            let json = EncodedTypedArray.ofUInt8ClampedArray data |> serialize
            Expect.equal json (sprintf """{"bdata":"%s","dtype":"u1c"}""" expected) "UInt8Clamped round-trip mismatch"
        )

        testCase "factory with multi-dim shape" (fun () ->
            let data = [| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |]
            let eta = EncodedTypedArray.ofFloat64Array(data, shape = [ 2; 3 ])
            let json = serialize eta
            Expect.stringContains json "\"shape\":\"2,3\"" "multi-dim factory must emit shape"
            Expect.stringContains json "\"dtype\":\"f8\""  "multi-dim factory must emit dtype"
        )

        testCase "Float64 known-value base64 payload" (fun () ->
            // sanity-check little-endian layout: 1.0 as Float64 == 0x3FF0000000000000 little-endian
            let eta = EncodedTypedArray.ofFloat64Array [| 1.0 |]
            let json = serialize eta
            Expect.equal json """{"bdata":"AAAAAAAA8D8=","dtype":"f8"}""" "known Float64 encoding mismatch"
        )
    ]

[<Tests>]
let ``Scatter trace XEncoded/YEncoded`` =
    testList "CommonAbstractions.EncodedTypedArray Scatter integration" [

        testCase "XEncoded/YEncoded land under x/y as encoded objects" (fun () ->
            let xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |]
            let yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |]
            let trace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(XEncoded = xEncoded, YEncoded = yEncoded)
                )
            let json = serialize trace
            Expect.stringContains json "\"x\":{\"bdata\":"    "trace x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":"    "trace y must be an encoded object"
            Expect.stringContains json "\"dtype\":\"f8\""     "dtype must be present"
        )

        testCase "XEncoded overrides X when both provided" (fun () ->
            let xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |]
            let trace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(X = [ 10.0; 20.0 ], XEncoded = xEncoded)
                )
            let json = serialize trace
            Expect.stringContains    json "\"x\":{\"bdata\":" "XEncoded must win over X"
            Expect.isFalse (json.Contains "\"x\":[10.0") "plain X array must not be present"
        )

        testCase "plain X still works when XEncoded is omitted" (fun () ->
            let trace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(X = [ 1.0; 2.0; 3.0 ], Y = [ 4.0; 5.0; 6.0 ])
                )
            let json = serialize trace
            Expect.stringContains json "\"x\":[1.0,2.0,3.0]" "plain X path must still serialize"
            Expect.stringContains json "\"y\":[4.0,5.0,6.0]" "plain Y path must still serialize"
        )
    ]

[<Tests>]
let ``Chart.Scatter XEncoded/YEncoded`` =
    testList "CommonAbstractions.EncodedTypedArray Chart.Scatter integration" [

        testCase "Chart.Scatter serializes XEncoded/YEncoded under x/y as encoded objects" (fun () ->
            let chart =
                Chart.Scatter(
                    XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    Mode = StyleParam.Mode.Lines_Markers,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart scatter x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart scatter y must be an encoded object"
            Expect.stringContains json "\"dtype\":\"f8\"" "chart scatter encoded dtype must be present"
        )

        testCase "Chart.Scatter encoded arrays override the plain x/y path when both are provided" (fun () ->
            let chart =
                Chart.Scatter(
                    X = [ 10.0; 20.0 ],
                    XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                    Y = [ 30.0; 40.0 ],
                    YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                    Mode = StyleParam.Mode.Lines,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart scatter XEncoded must win over X"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart scatter YEncoded must win over Y"
            Expect.isFalse (json.Contains "\"x\":[10.0,20.0]") "plain chart scatter x array must not be present"
            Expect.isFalse (json.Contains "\"y\":[30.0,40.0]") "plain chart scatter y array must not be present"
        )
    ]

[<Tests>]
let ``Chart scatter-derived helpers encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Chart helper integration" [

        testCase "Chart.Point encoded overload serializes x/y as encoded objects" (fun () ->
            let chart =
                Chart.Point(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart point x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart point y must be an encoded object"
            Expect.stringContains json "\"mode\":\"markers\"" "point mode must still be markers"
        )

        testCase "Chart.Line encoded overload serializes x/y as encoded objects" (fun () ->
            let chart =
                Chart.Line(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart line x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart line y must be an encoded object"
            Expect.stringContains json "\"mode\":\"lines\"" "line mode must still be lines"
        )

        testCase "Chart.Bubble encoded overload serializes x/y while keeping bubble sizes" (fun () ->
            let chart =
                Chart.Bubble(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    sizes = [ 11; 22; 33 ],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart bubble x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart bubble y must be an encoded object"
            Expect.stringContains json "\"size\":[11,22,33]" "bubble sizes must still serialize"
        )

        testCase "Chart.Spline encoded overload serializes x/y and keeps spline styling" (fun () ->
            let chart =
                Chart.Spline(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    Smoothing = 0.7,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart spline x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart spline y must be an encoded object"
            Expect.stringContains json "\"shape\":\"spline\"" "spline shape must still be present"
            Expect.stringContains json "\"smoothing\":0.7" "spline smoothing must still serialize"
        )

        testCase "Chart.Area encoded overload serializes x/y and keeps fill styling" (fun () ->
            let chart =
                Chart.Area(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 2.0; 5.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart area x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart area y must be an encoded object"
            Expect.stringContains json "\"fill\":\"tozeroy\"" "area fill must still be present"
        )

        testCase "Chart.SplineArea encoded overload serializes x/y as encoded objects" (fun () ->
            let chart =
                Chart.SplineArea(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart spline area x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart spline area y must be an encoded object"
            Expect.stringContains json "\"fill\":\"tozeroy\"" "spline area fill must still be present"
        )

        testCase "Chart.StackedArea encoded overload serializes x/y and keeps stackgroup" (fun () ->
            let chart =
                Chart.StackedArea(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 2.0; 4.0; 3.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart stacked area x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart stacked area y must be an encoded object"
            Expect.stringContains json "\"fill\":\"tonexty\"" "stacked area fill must still be present"
            Expect.stringContains json "\"stackgroup\":\"stackedarea\"" "stacked area stackgroup must still serialize"
        )

        testCase "Chart.Range encoded overload serializes all encoded arrays across traces" (fun () ->
            let chart =
                Chart.Range(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                    upperEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                    lowerEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0 |],
                    mode = StyleParam.Mode.Lines,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart range x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart range y must be encoded on all traces"
            Expect.stringContains json "\"fill\":\"tonexty\"" "chart range upper trace fill must still be present"
        )
    ]

[<Tests>]
let ``Chart bar-family roots encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Chart bar-family integration" [

        testCase "Chart.Bar encoded overload serializes encoded values and keys" (fun () ->
            let chart =
                Chart.Bar(
                    valuesEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                    KeysEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    MultiWidthEncoded = EncodedTypedArray.ofFloat64Array [| 0.4; 0.5; 0.6 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart bar x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart bar y must be an encoded object"
            Expect.stringContains json "\"width\":{\"bdata\":" "chart bar width must be an encoded object"
            Expect.stringContains json "\"orientation\":\"h\"" "chart bar must stay horizontal"
        )

        testCase "Chart.Funnel encoded overload serializes encoded x/y" (fun () ->
            let chart =
                Chart.Funnel(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 20.0; 10.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart funnel x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart funnel y must be an encoded object"
            Expect.stringContains json "\"type\":\"funnel\"" "chart funnel trace type must still be funnel"
        )

        testCase "Chart.Waterfall encoded overload serializes encoded x/y/width" (fun () ->
            let chart =
                Chart.Waterfall(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; -2.0; 4.0 |],
                    MultiWidthEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4; 0.5 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart waterfall x must be an encoded object"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart waterfall y must be an encoded object"
            Expect.stringContains json "\"width\":{\"bdata\":" "chart waterfall width must be an encoded object"
            Expect.stringContains json "\"type\":\"waterfall\"" "chart waterfall trace type must still be waterfall"
        )
    ]

[<Tests>]
let ``Scatter trace remaining encoded fields`` =
    testList "CommonAbstractions.EncodedTypedArray Scatter additional integration" [

        testCase "IdsEncoded/CustomDataEncoded/SelectedPointsEncoded/MultiTextEncoded land under their trace properties" (fun () ->
            let idsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102; 103 |]
            let customDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |]
            let selectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |]
            let multiTextEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |]

            let trace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        IdsEncoded = idsEncoded,
                        CustomDataEncoded = customDataEncoded,
                        SelectedPointsEncoded = selectedPointsEncoded,
                        MultiTextEncoded = multiTextEncoded
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"ids\":{\"bdata\":" "trace ids must be an encoded object"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "trace customdata must be an encoded object"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "trace selectedpoints must be an encoded object"
            Expect.stringContains json "\"text\":{\"bdata\":" "trace text must be an encoded object"
        )

        testCase "encoded scatter fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |],
                        SelectedPoints = [ 0; 1 ],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2; 3 |],
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 300.0; 400.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"ids\":{\"bdata\":" "IdsEncoded must win over Ids"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "CustomDataEncoded must win over CustomData"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "SelectedPointsEncoded must win over SelectedPoints"
            Expect.stringContains json "\"text\":{\"bdata\":" "MultiTextEncoded must win over MultiText"
            Expect.isFalse (json.Contains "\"ids\":[1,2]") "plain ids array must not be present"
            Expect.isFalse (json.Contains "\"customdata\":[10.0,20.0]") "plain customdata array must not be present"
            Expect.isFalse (json.Contains "\"selectedpoints\":[0,1]") "plain selectedpoints array must not be present"
            Expect.isFalse (json.Contains "\"text\":[100.0,200.0]") "plain text array must not be present"
        )
    ]

[<Tests>]
let ``Chart distribution and finance roots encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Chart distribution and finance integration" [

        testCase "Chart.Histogram encoded overload serializes encoded sample data" (fun () ->
            let chart =
                Chart.Histogram(
                    dataEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 2.0; 3.0 |],
                    orientation = StyleParam.Orientation.Vertical,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart histogram sample data must be encoded"
            Expect.stringContains json "\"orientation\":\"v\"" "chart histogram orientation must stay vertical"
            Expect.stringContains json "\"type\":\"histogram\"" "chart histogram trace type must still be histogram"
        )

        testCase "Chart.BoxPlot encoded overload serializes encoded sample data" (fun () ->
            let chart =
                Chart.BoxPlot(
                    dataEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    orientation = StyleParam.Orientation.Vertical,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"y\":{\"bdata\":" "chart boxplot sample data must be encoded"
            Expect.stringContains json "\"type\":\"box\"" "chart boxplot trace type must still be box"
        )

        testCase "Chart.Violin encoded overload serializes encoded sample data" (fun () ->
            let chart =
                Chart.Violin(
                    dataEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    orientation = StyleParam.Orientation.Vertical,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"y\":{\"bdata\":" "chart violin sample data must be encoded"
            Expect.stringContains json "\"type\":\"violin\"" "chart violin trace type must still be violin"
        )

        testCase "Chart.OHLC encoded overload serializes encoded finance arrays" (fun () ->
            let chart =
                Chart.OHLC(
                    openEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 11.0; 12.0 |],
                    highEncoded = EncodedTypedArray.ofFloat64Array [| 15.0; 16.0; 17.0 |],
                    lowEncoded = EncodedTypedArray.ofFloat64Array [| 8.0; 9.0; 10.0 |],
                    closeEncoded = EncodedTypedArray.ofFloat64Array [| 12.0; 13.0; 14.0 |],
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    ShowXAxisRangeSlider = false,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            [
                "\"x\":{\"bdata\":"
                "\"open\":{\"bdata\":"
                "\"high\":{\"bdata\":"
                "\"low\":{\"bdata\":"
                "\"close\":{\"bdata\":"
                "\"type\":\"ohlc\""
            ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "chart OHLC must contain %s" needle))
        )

        testCase "Chart.Candlestick encoded overload serializes encoded finance arrays" (fun () ->
            let chart =
                Chart.Candlestick(
                    openEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 11.0; 12.0 |],
                    highEncoded = EncodedTypedArray.ofFloat64Array [| 15.0; 16.0; 17.0 |],
                    lowEncoded = EncodedTypedArray.ofFloat64Array [| 8.0; 9.0; 10.0 |],
                    closeEncoded = EncodedTypedArray.ofFloat64Array [| 12.0; 13.0; 14.0 |],
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    ShowXAxisRangeSlider = false,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            [
                "\"x\":{\"bdata\":"
                "\"open\":{\"bdata\":"
                "\"high\":{\"bdata\":"
                "\"low\":{\"bdata\":"
                "\"close\":{\"bdata\":"
                "\"type\":\"candlestick\""
            ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "chart candlestick must contain %s" needle))
        )
    ]

[<Tests>]
let ``Chart splom root encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Chart splom integration" [

        testCase "Chart.Splom encoded overload serializes encoded dimensions" (fun () ->
            let chart =
                Chart.Splom(
                    keyValuesEncoded = [
                        "A", EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |]
                        "B", EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |]
                    ],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"dimensions\":[{\"label\":\"A\",\"values\":{\"bdata\":" "chart splom must encode the first dimension values"
            Expect.stringContains json "\"label\":\"B\",\"values\":{\"bdata\":" "chart splom must encode the second dimension values"
            Expect.stringContains json "\"type\":\"splom\"" "chart splom trace type must still be splom"
        )

        testCase "Chart.Splom encoded overload keeps splom-specific options" (fun () ->
            let chart =
                Chart.Splom(
                    keyValuesEncoded = [
                        "A", EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |]
                        "B", EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |]
                    ],
                    ShowLowerHalf = false,
                    Name = "encoded chart splom",
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"showlowerhalf\":false" "chart splom must keep showlowerhalf"
            Expect.stringContains json "\"name\":\"encoded chart splom\"" "chart splom name must still serialize"
        )
    ]

[<Tests>]
let ``Chart matrix roots encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Chart matrix integration" [

        testCase "Chart.Histogram2D encoded overload serializes encoded x y and z" (fun () ->
            let chart =
                Chart.Histogram2D(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart histogram2d x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart histogram2d y must be encoded"
            Expect.stringContains json "\"z\":{\"bdata\":" "chart histogram2d z must be encoded"
            Expect.stringContains json "\"shape\":\"2,2\"" "chart histogram2d z shape must serialize"
        )

        testCase "Chart.Histogram2DContour encoded overload serializes encoded x y and z" (fun () ->
            let chart =
                Chart.Histogram2DContour(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart histogram2dcontour x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart histogram2dcontour y must be encoded"
            Expect.stringContains json "\"z\":{\"bdata\":" "chart histogram2dcontour z must be encoded"
            Expect.stringContains json "\"type\":\"histogram2dcontour\"" "chart histogram2dcontour trace type must still be correct"
        )

        testCase "Chart.Heatmap encoded overload serializes encoded z and optional axes" (fun () ->
            let chart =
                Chart.Heatmap(
                    zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 100.0; 200.0 |],
                    ReverseYAxis = true,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart heatmap x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart heatmap y must be encoded"
            Expect.stringContains json "\"z\":{\"bdata\":" "chart heatmap z must be encoded"
            Expect.stringContains json "\"autorange\":\"reversed\"" "chart heatmap must preserve reverse y-axis behavior"
        )

        testCase "Chart.Contour encoded overload serializes encoded z and optional axes" (fun () ->
            let chart =
                Chart.Contour(
                    zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 100.0; 200.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart contour x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart contour y must be encoded"
            Expect.stringContains json "\"z\":{\"bdata\":" "chart contour z must be encoded"
            Expect.stringContains json "\"type\":\"contour\"" "chart contour trace type must still be contour"
        )
    ]

[<Tests>]
let ``Chart 3D roots encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Chart 3D integration" [

        testCase "Chart.Scatter3D encoded overload serializes encoded xyz arrays" (fun () ->
            let chart =
                Chart.Scatter3D(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    zEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                    mode = StyleParam.Mode.Markers,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"x\":{\"bdata\":" "chart scatter3d x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart scatter3d y must be encoded"
            Expect.stringContains json "\"z\":{\"bdata\":" "chart scatter3d z must be encoded"
        )

        testCase "Chart.Surface encoded overload serializes encoded z matrix and optional axes" (fun () ->
            let chart =
                Chart.Surface(
                    zEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 100.0; 200.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"z\":{\"bdata\":" "chart surface z must be encoded"
            Expect.stringContains json "\"shape\":\"2,2\"" "chart surface z shape must serialize"
            Expect.stringContains json "\"type\":\"surface\"" "chart surface trace type must still be surface"
        )

        testCase "Chart.Mesh3D encoded overload serializes encoded xyz topology and intensity arrays" (fun () ->
            let chart =
                Chart.Mesh3D(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 0.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 1.0 |],
                    zEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.0; 0.0 |],
                    iEncoded = EncodedTypedArray.ofInt32Array [| 0 |],
                    jEncoded = EncodedTypedArray.ofInt32Array [| 1 |],
                    kEncoded = EncodedTypedArray.ofInt32Array [| 2 |],
                    intensityEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"i\":{\"bdata\":" "chart mesh3d i must be encoded"
            Expect.stringContains json "\"j\":{\"bdata\":" "chart mesh3d j must be encoded"
            Expect.stringContains json "\"k\":{\"bdata\":" "chart mesh3d k must be encoded"
            Expect.stringContains json "\"intensity\":{\"bdata\":" "chart mesh3d intensity must be encoded"
        )

        testCase "Chart.Cone encoded overload serializes encoded vector-field arrays" (fun () ->
            let chart =
                Chart.Cone(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                    zEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                    uEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2 |],
                    vEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                    wEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.6 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"u\":{\"bdata\":" "chart cone u must be encoded"
            Expect.stringContains json "\"v\":{\"bdata\":" "chart cone v must be encoded"
            Expect.stringContains json "\"w\":{\"bdata\":" "chart cone w must be encoded"
        )

        testCase "Chart.StreamTube encoded overload serializes encoded vector-field arrays" (fun () ->
            let chart =
                Chart.StreamTube(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                    zEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                    uEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2 |],
                    vEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                    wEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.6 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"u\":{\"bdata\":" "chart streamtube u must be encoded"
            Expect.stringContains json "\"v\":{\"bdata\":" "chart streamtube v must be encoded"
            Expect.stringContains json "\"w\":{\"bdata\":" "chart streamtube w must be encoded"
        )

        testCase "Chart.Volume encoded overload serializes encoded value and opacityscale arrays" (fun () ->
            let chart =
                Chart.Volume(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    zEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                    valueEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                    OpacityScaleEncoded = EncodedTypedArray.ofFloat64Array([| 0.0; 1.0; 1.0; 0.2 |], shape = [ 2; 2 ]),
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"value\":{\"bdata\":" "chart volume value must be encoded"
            Expect.stringContains json "\"opacityscale\":{\"bdata\":" "chart volume opacityscale must be encoded"
            Expect.stringContains json "\"shape\":\"2,2\"" "chart volume opacityscale shape must serialize"
        )

        testCase "Chart.IsoSurface encoded overload serializes encoded value arrays" (fun () ->
            let chart =
                Chart.IsoSurface(
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                    zEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                    valueEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"value\":{\"bdata\":" "chart isosurface value must be encoded"
            Expect.stringContains json "\"type\":\"isosurface\"" "chart isosurface trace type must still be isosurface"
        )
    ]

[<Tests>]
let ``Chart subplot and domain roots encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Chart subplot/domain integration" [

        testCase "Chart.ScatterPolar encoded overload serializes encoded r/theta arrays" (fun () ->
            let chart =
                Chart.ScatterPolar(
                    rEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    thetaEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 90.0; 180.0 |],
                    mode = StyleParam.Mode.Markers,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"r\":{\"bdata\":" "chart scatterpolar r must be encoded"
            Expect.stringContains json "\"theta\":{\"bdata\":" "chart scatterpolar theta must be encoded"
            Expect.stringContains json "\"type\":\"scatterpolar\"" "chart scatterpolar trace type must still be correct"
        )

        testCase "Chart.ScatterGeo encoded overload serializes encoded lon/lat arrays" (fun () ->
            let chart =
                Chart.ScatterGeo(
                    longitudesEncoded = EncodedTypedArray.ofFloat64Array [| 8.0; 13.0 |],
                    latitudesEncoded = EncodedTypedArray.ofFloat64Array [| 50.0; 52.0 |],
                    mode = StyleParam.Mode.Markers,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"lon\":{\"bdata\":" "chart scattergeo lon must be encoded"
            Expect.stringContains json "\"lat\":{\"bdata\":" "chart scattergeo lat must be encoded"
            Expect.stringContains json "\"type\":\"scattergeo\"" "chart scattergeo trace type must still be correct"
        )

        testCase "Chart.ScatterMapbox encoded overload serializes encoded lon/lat arrays" (fun () ->
            let chart =
                Chart.ScatterMapbox(
                    longitudesEncoded = EncodedTypedArray.ofFloat64Array [| 8.0; 13.0 |],
                    latitudesEncoded = EncodedTypedArray.ofFloat64Array [| 50.0; 52.0 |],
                    mode = StyleParam.Mode.Markers,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"lon\":{\"bdata\":" "chart scattermapbox lon must be encoded"
            Expect.stringContains json "\"lat\":{\"bdata\":" "chart scattermapbox lat must be encoded"
            Expect.stringContains json "\"type\":\"scattermapbox\"" "chart scattermapbox trace type must still be correct"
        )

        testCase "Chart.ScatterTernary encoded overload serializes encoded abc arrays" (fun () ->
            let chart =
                Chart.ScatterTernary(
                    aEncoded = EncodedTypedArray.ofFloat64Array [| 0.2; 0.4 |],
                    bEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                    cEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.2 |],
                    Mode = StyleParam.Mode.Markers,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"a\":{\"bdata\":" "chart scatterternary a must be encoded"
            Expect.stringContains json "\"b\":{\"bdata\":" "chart scatterternary b must be encoded"
            Expect.stringContains json "\"c\":{\"bdata\":" "chart scatterternary c must be encoded"
        )

        testCase "Chart.ScatterSmith encoded overload serializes encoded real/imag arrays" (fun () ->
            let chart =
                Chart.ScatterSmith(
                    realEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                    imagEncoded = EncodedTypedArray.ofFloat64Array [| -0.5; 0.5 |],
                    mode = StyleParam.Mode.Markers,
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"real\":{\"bdata\":" "chart scattersmith real must be encoded"
            Expect.stringContains json "\"imag\":{\"bdata\":" "chart scattersmith imag must be encoded"
            Expect.stringContains json "\"type\":\"scattersmith\"" "chart scattersmith trace type must still be correct"
        )

        testCase "Chart.Carpet encoded overload serializes encoded parameter and axis arrays" (fun () ->
            let chart =
                Chart.Carpet(
                    carpetId = "a",
                    aEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    bEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                    xEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 2.0 |],
                    yEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 0.5; 1.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"a\":{\"bdata\":" "chart carpet a must be encoded"
            Expect.stringContains json "\"b\":{\"bdata\":" "chart carpet b must be encoded"
            Expect.stringContains json "\"x\":{\"bdata\":" "chart carpet x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "chart carpet y must be encoded"
        )

        testCase "Chart.ScatterCarpet encoded overload serializes encoded a/b arrays" (fun () ->
            let chart =
                Chart.ScatterCarpet(
                    aEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    bEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                    mode = StyleParam.Mode.Markers,
                    carpetAnchorId = "a",
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"a\":{\"bdata\":" "chart scattercarpet a must be encoded"
            Expect.stringContains json "\"b\":{\"bdata\":" "chart scattercarpet b must be encoded"
            Expect.stringContains json "\"type\":\"scattercarpet\"" "chart scattercarpet trace type must still be correct"
        )

        testCase "Chart.ContourCarpet encoded overload serializes encoded z/a/b arrays" (fun () ->
            let chart =
                Chart.ContourCarpet(
                    zEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    carpetAnchorId = "a",
                    aEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                    bEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"z\":{\"bdata\":" "chart contourcarpet z must be encoded"
            Expect.stringContains json "\"a\":{\"bdata\":" "chart contourcarpet a must be encoded"
            Expect.stringContains json "\"b\":{\"bdata\":" "chart contourcarpet b must be encoded"
        )

        testCase "Chart.Pie encoded overload serializes encoded values and labels" (fun () ->
            let chart =
                Chart.Pie(
                    valuesEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                    labelsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"values\":{\"bdata\":" "chart pie values must be encoded"
            Expect.stringContains json "\"labels\":{\"bdata\":" "chart pie labels must be encoded"
            Expect.stringContains json "\"type\":\"pie\"" "chart pie trace type must still be correct"
        )

        testCase "Chart.Sunburst encoded overload serializes encoded labels parents and values" (fun () ->
            let chart =
                Chart.Sunburst(
                    labelsEncoded = EncodedTypedArray.ofInt32Array [| 0; 1; 2 |],
                    parentsEncoded = EncodedTypedArray.ofInt32Array [| -1; 0; 0 |],
                    valuesEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 10.0; 20.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"labels\":{\"bdata\":" "chart sunburst labels must be encoded"
            Expect.stringContains json "\"parents\":{\"bdata\":" "chart sunburst parents must be encoded"
            Expect.stringContains json "\"values\":{\"bdata\":" "chart sunburst values must be encoded"
        )

        testCase "Chart.Treemap encoded overload serializes encoded labels parents and values" (fun () ->
            let chart =
                Chart.Treemap(
                    labelsEncoded = EncodedTypedArray.ofInt32Array [| 0; 1; 2 |],
                    parentsEncoded = EncodedTypedArray.ofInt32Array [| -1; 0; 0 |],
                    valuesEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 10.0; 20.0 |],
                    UseDefaults = false
                )

            let json = chart |> GenericChart.toFigureJson
            Expect.stringContains json "\"labels\":{\"bdata\":" "chart treemap labels must be encoded"
            Expect.stringContains json "\"parents\":{\"bdata\":" "chart treemap parents must be encoded"
            Expect.stringContains json "\"values\":{\"bdata\":" "chart treemap values must be encoded"
        )
    ]

[<Tests>]
let ``Dimension encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Dimension integration" [

        testCase "Dimension.ValuesEncoded serializes under values" (fun () ->
            let dim =
                Dimension.initSplom(
                    Label = "A",
                    ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |]
                )

            let json = serialize dim
            Expect.stringContains json "\"values\":{\"bdata\":" "dimension values must be encoded"
            Expect.stringContains json "\"label\":\"A\"" "dimension label must still be serialized"
        )

        testCase "Dimension.ValuesEncoded overrides Values when both are provided" (fun () ->
            let dim =
                Dimension.initSplom(
                    Label = "A",
                    Values = [ 10.0; 20.0 ],
                    ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |]
                )

            let json = serialize dim
            Expect.stringContains json "\"values\":{\"bdata\":" "encoded dimension values must win over plain values"
            Expect.isFalse (json.Contains "\"values\":[10.0,20.0]") "plain dimension values must not be present"
        )
    ]

[<Tests>]
let ``Error object encoded arrays`` =
    testList "CommonAbstractions.EncodedTypedArray Error integration" [

        testCase "ArrayEncoded/ArrayminusEncoded land under array/arrayminus as encoded objects" (fun () ->
            let error =
                Error.init(
                    Type = StyleParam.ErrorType.Data,
                    ArrayEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |],
                    ArrayminusEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.2; 0.1 |]
                )

            let json = serialize error
            Expect.stringContains json "\"array\":{\"bdata\":" "error array must be an encoded object"
            Expect.stringContains json "\"arrayminus\":{\"bdata\":" "error arrayminus must be an encoded object"
            Expect.stringContains json "\"type\":\"data\"" "error type must still be serialized"
        )

        testCase "ArrayEncoded overrides Array when both are provided" (fun () ->
            let error =
                Error.init(
                    Type = StyleParam.ErrorType.Data,
                    Array = [ 1.0; 2.0 ],
                    ArrayEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |]
                )

            let json = serialize error
            Expect.stringContains json "\"array\":{\"bdata\":" "ArrayEncoded must win over Array"
            Expect.isFalse (json.Contains "\"array\":[1.0,2.0]") "plain error array must not be present"
        )

        testCase "ArrayminusEncoded overrides Arrayminus when both are provided" (fun () ->
            let error =
                Error.init(
                    Type = StyleParam.ErrorType.Data,
                    Arrayminus = [ 1.0; 2.0 ],
                    ArrayminusEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |]
                )

            let json = serialize error
            Expect.stringContains json "\"arrayminus\":{\"bdata\":" "ArrayminusEncoded must win over Arrayminus"
            Expect.isFalse (json.Contains "\"arrayminus\":[1.0,2.0]") "plain error arrayminus must not be present"
        )

        testCase "encoded Error objects can be attached to scatter traces" (fun () ->
            let trace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        XError =
                            Error.init(
                                Type = StyleParam.ErrorType.Data,
                                ArrayEncoded = EncodedTypedArray.ofFloat64Array [| 0.1; 0.2; 0.3 |]
                            ),
                        YError =
                            Error.init(
                                Type = StyleParam.ErrorType.Data,
                                ArrayEncoded = EncodedTypedArray.ofFloat64Array [| 0.4; 0.5; 0.6 |],
                                ArrayminusEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.2; 0.1 |]
                            )
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"error_x\":{\"type\":\"data\",\"array\":{\"bdata\":" "trace error_x must contain encoded array"
            Expect.stringContains json "\"error_y\":{\"type\":\"data\",\"array\":{\"bdata\":" "trace error_y must contain encoded array"
            Expect.stringContains json "\"arrayminus\":{\"bdata\":" "trace error_y must contain encoded arrayminus"
        )

        testCase "trace-attached Error uses encoded arrayminus when both arrayminus forms are provided" (fun () ->
            let trace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        YError =
                            Error.init(
                                Type = StyleParam.ErrorType.Data,
                                Arrayminus = [ 9.0; 8.0; 7.0 ],
                                ArrayminusEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.2; 0.1 |]
                            )
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"arrayminus\":{\"bdata\":" "trace error_y arrayminus must use encoded object"
            Expect.isFalse (json.Contains "\"arrayminus\":[9.0,8.0,7.0]") "plain trace error_y arrayminus must not be present"
        )
    ]

[<Tests>]
let ``Bar-family trace encoded fields`` =
    testList "CommonAbstractions.EncodedTypedArray bar-family integration" [

        testCase "Bar encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initBar (
                    Trace2DStyle.Bar(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102; 103 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                        MultiWidthEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4; 0.5 |],
                        MultiOffsetEncoded = EncodedTypedArray.ofFloat64Array [| -0.1; 0.0; 0.1 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"x\":{\"bdata\":" "bar x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "bar y must be encoded"
            Expect.stringContains json "\"ids\":{\"bdata\":" "bar ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "bar customdata must be encoded"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "bar selectedpoints must be encoded"
            Expect.stringContains json "\"text\":{\"bdata\":" "bar text must be encoded"
            Expect.stringContains json "\"width\":{\"bdata\":" "bar width must be encoded"
            Expect.stringContains json "\"offset\":{\"bdata\":" "bar offset must be encoded"
        )

        testCase "Bar encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initBar (
                    Trace2DStyle.Bar(
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Y = [ 30.0; 40.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |],
                        SelectedPoints = [ 0; 1 ],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2; 3 |],
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 300.0; 400.0 |],
                        MultiWidth = [ 0.1; 0.2 ],
                        MultiWidthEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                        MultiOffset = [ -1.0; 1.0 ],
                        MultiOffsetEncoded = EncodedTypedArray.ofFloat64Array [| -0.5; 0.5 |]
                    )
                )

            let json = serialize trace
            Expect.isFalse (json.Contains "\"x\":[10.0,20.0]") "plain bar x array must not be present"
            Expect.isFalse (json.Contains "\"y\":[30.0,40.0]") "plain bar y array must not be present"
            Expect.isFalse (json.Contains "\"ids\":[1,2]") "plain bar ids array must not be present"
            Expect.isFalse (json.Contains "\"customdata\":[10.0,20.0]") "plain bar customdata array must not be present"
            Expect.isFalse (json.Contains "\"selectedpoints\":[0,1]") "plain bar selectedpoints array must not be present"
            Expect.isFalse (json.Contains "\"text\":[100.0,200.0]") "plain bar text array must not be present"
            Expect.isFalse (json.Contains "\"width\":[0.1,0.2]") "plain bar width array must not be present"
            Expect.isFalse (json.Contains "\"offset\":[-1.0,1.0]") "plain bar offset array must not be present"
        )

        testCase "Funnel encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initFunnel (
                    Trace2DStyle.Funnel(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 4.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 11; 12; 13 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0; 23.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0; 33.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"x\":{\"bdata\":" "funnel x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "funnel y must be encoded"
            Expect.stringContains json "\"ids\":{\"bdata\":" "funnel ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "funnel customdata must be encoded"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "funnel selectedpoints must be encoded"
            Expect.stringContains json "\"text\":{\"bdata\":" "funnel text must be encoded"
        )

        testCase "Funnel encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initFunnel (
                    Trace2DStyle.Funnel(
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Y = [ 30.0; 40.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |],
                        SelectedPoints = [ 0; 1 ],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2; 3 |],
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 300.0; 400.0 |]
                    )
                )

            let json = serialize trace
            Expect.isFalse (json.Contains "\"x\":[10.0,20.0]") "plain funnel x array must not be present"
            Expect.isFalse (json.Contains "\"y\":[30.0,40.0]") "plain funnel y array must not be present"
            Expect.isFalse (json.Contains "\"ids\":[1,2]") "plain funnel ids array must not be present"
            Expect.isFalse (json.Contains "\"customdata\":[10.0,20.0]") "plain funnel customdata array must not be present"
            Expect.isFalse (json.Contains "\"selectedpoints\":[0,1]") "plain funnel selectedpoints array must not be present"
            Expect.isFalse (json.Contains "\"text\":[100.0,200.0]") "plain funnel text array must not be present"
        )

        testCase "Waterfall encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initWaterfall (
                    Trace2DStyle.Waterfall(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 101; 102; 103 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                        MultiWidthEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4; 0.5 |],
                        MultiOffsetEncoded = EncodedTypedArray.ofFloat64Array [| -0.1; 0.0; 0.1 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"x\":{\"bdata\":" "waterfall x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "waterfall y must be encoded"
            Expect.stringContains json "\"ids\":{\"bdata\":" "waterfall ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "waterfall customdata must be encoded"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "waterfall selectedpoints must be encoded"
            Expect.stringContains json "\"text\":{\"bdata\":" "waterfall text must be encoded"
            Expect.stringContains json "\"width\":{\"bdata\":" "waterfall width must be encoded"
            Expect.stringContains json "\"offset\":{\"bdata\":" "waterfall offset must be encoded"
        )

        testCase "Waterfall encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initWaterfall (
                    Trace2DStyle.Waterfall(
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Y = [ 30.0; 40.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |],
                        SelectedPoints = [ 0; 1 ],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2; 3 |],
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 300.0; 400.0 |],
                        MultiWidth = [ 1.5; 2.5 ],
                        MultiWidthEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4 |],
                        MultiOffset = [ -1.0; 1.0 ],
                        MultiOffsetEncoded = EncodedTypedArray.ofFloat64Array [| -0.5; 0.5 |]
                    )
                )

            let json = serialize trace
            Expect.isFalse (json.Contains "\"x\":[10.0,20.0]") "plain waterfall x array must not be present"
            Expect.isFalse (json.Contains "\"y\":[30.0,40.0]") "plain waterfall y array must not be present"
            Expect.isFalse (json.Contains "\"ids\":[1,2]") "plain waterfall ids array must not be present"
            Expect.isFalse (json.Contains "\"customdata\":[10.0,20.0]") "plain waterfall customdata array must not be present"
            Expect.isFalse (json.Contains "\"selectedpoints\":[0,1]") "plain waterfall selectedpoints array must not be present"
            Expect.isFalse (json.Contains "\"text\":[100.0,200.0]") "plain waterfall text array must not be present"
            Expect.isFalse (json.Contains "\"width\":[1.5,2.5]") "plain waterfall width array must not be present"
            Expect.isFalse (json.Contains "\"offset\":[-1.0,1.0]") "plain waterfall offset array must not be present"
        )
    ]

[<Tests>]
let ``1-D trace family encoded fields`` =
    testList "CommonAbstractions.EncodedTypedArray 1-D trace family integration" [

        testCase "Histogram encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initHistogram (
                    Trace2DStyle.Histogram(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0; 7.0; 8.0 |],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3; 4 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0; 40.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 3 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 9.0; 8.0; 7.0; 6.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"x\":{\"bdata\":" "histogram x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "histogram y must be encoded"
            Expect.stringContains json "\"ids\":{\"bdata\":" "histogram ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "histogram customdata must be encoded"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "histogram selectedpoints must be encoded"
            Expect.stringContains json "\"text\":{\"bdata\":" "histogram text must be encoded"
        )

        testCase "Histogram encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initHistogram (
                    Trace2DStyle.Histogram(
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Y = [ 30.0; 40.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |],
                        SelectedPoints = [ 0; 1 ],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2; 3 |],
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 300.0; 400.0 |]
                    )
                )

            let json = serialize trace
            Expect.isFalse (json.Contains "\"x\":[10.0,20.0]") "plain histogram x array must not be present"
            Expect.isFalse (json.Contains "\"y\":[30.0,40.0]") "plain histogram y array must not be present"
            Expect.isFalse (json.Contains "\"ids\":[1,2]") "plain histogram ids array must not be present"
            Expect.isFalse (json.Contains "\"customdata\":[10.0,20.0]") "plain histogram customdata array must not be present"
            Expect.isFalse (json.Contains "\"selectedpoints\":[0,1]") "plain histogram selectedpoints array must not be present"
            Expect.isFalse (json.Contains "\"text\":[100.0,200.0]") "plain histogram text array must not be present"
        )

        testCase "BoxPlot encoded standard and computed-stat fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initBoxPlot (
                    Trace2DStyle.BoxPlot(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 21; 22 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0 |],
                        Q1Encoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        MedianEncoded = EncodedTypedArray.ofFloat64Array [| 1.5; 2.5 |],
                        Q3Encoded = EncodedTypedArray.ofFloat64Array [| 2.0; 3.0 |],
                        LowerFenceEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 1.5 |],
                        UpperFenceEncoded = EncodedTypedArray.ofFloat64Array [| 2.5; 3.5 |],
                        NotchSpanEncoded = EncodedTypedArray.ofFloat64Array [| 0.2; 0.3 |],
                        MeanEncoded = EncodedTypedArray.ofFloat64Array [| 1.6; 2.6 |],
                        SDEncoded = EncodedTypedArray.ofFloat64Array [| 0.4; 0.5 |]
                    )
                )

            let json = serialize trace
            [
                "\"x\":{\"bdata\":"
                "\"ids\":{\"bdata\":"
                "\"customdata\":{\"bdata\":"
                "\"selectedpoints\":{\"bdata\":"
                "\"text\":{\"bdata\":"
                "\"q1\":{\"bdata\":"
                "\"median\":{\"bdata\":"
                "\"q3\":{\"bdata\":"
                "\"lowerfence\":{\"bdata\":"
                "\"upperfence\":{\"bdata\":"
                "\"notchspan\":{\"bdata\":"
                "\"mean\":{\"bdata\":"
                "\"sd\":{\"bdata\":"
            ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "boxplot must contain %s" needle))
        )

        testCase "BoxPlot encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initBoxPlot (
                    Trace2DStyle.BoxPlot(
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |],
                        SelectedPoints = [ 0; 1 ],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2; 3 |],
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 300.0; 400.0 |],
                        Q1 = [ 9.0; 10.0 ],
                        Q1Encoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Median = [ 11.0; 12.0 ],
                        MedianEncoded = EncodedTypedArray.ofFloat64Array [| 1.5; 2.5 |],
                        Q3 = [ 13.0; 14.0 ],
                        Q3Encoded = EncodedTypedArray.ofFloat64Array [| 2.0; 3.0 |],
                        LowerFence = [ 7.0; 8.0 ],
                        LowerFenceEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 1.5 |],
                        UpperFence = [ 15.0; 16.0 ],
                        UpperFenceEncoded = EncodedTypedArray.ofFloat64Array [| 2.5; 3.5 |],
                        NotchSpan = [ 0.8; 0.9 ],
                        NotchSpanEncoded = EncodedTypedArray.ofFloat64Array [| 0.2; 0.3 |],
                        Mean = [ 12.0; 13.0 ],
                        MeanEncoded = EncodedTypedArray.ofFloat64Array [| 1.6; 2.6 |],
                        SD = [ 1.2; 1.3 ],
                        SDEncoded = EncodedTypedArray.ofFloat64Array [| 0.4; 0.5 |]
                    )
                )

            let json = serialize trace
            [
                "\"x\":[10.0,20.0]"
                "\"ids\":[1,2]"
                "\"customdata\":[10.0,20.0]"
                "\"selectedpoints\":[0,1]"
                "\"text\":[100.0,200.0]"
                "\"q1\":[9.0,10.0]"
                "\"median\":[11.0,12.0]"
                "\"q3\":[13.0,14.0]"
                "\"lowerfence\":[7.0,8.0]"
                "\"upperfence\":[15.0,16.0]"
                "\"notchspan\":[0.8,0.9]"
                "\"mean\":[12.0,13.0]"
                "\"sd\":[1.2,1.3]"
            ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain boxplot array must not be present: %s" needle))
        )

        testCase "Violin encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initViolin (
                    Trace2DStyle.Violin(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 1.0; 2.0; 2.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0; 5.0; 6.0 |],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52; 53; 54 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0; 64.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0; 73.0; 74.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"x\":{\"bdata\":" "violin x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "violin y must be encoded"
            Expect.stringContains json "\"ids\":{\"bdata\":" "violin ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "violin customdata must be encoded"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "violin selectedpoints must be encoded"
            Expect.stringContains json "\"text\":{\"bdata\":" "violin text must be encoded"
        )

        testCase "OHLC encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initOHLC (
                    Trace2DStyle.OHLC(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 81; 82; 83 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0; 93.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 101.0; 102.0; 103.0 |],
                        OpenEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 11.0; 12.0 |],
                        HighEncoded = EncodedTypedArray.ofFloat64Array [| 15.0; 16.0; 17.0 |],
                        LowEncoded = EncodedTypedArray.ofFloat64Array [| 8.0; 9.0; 10.0 |],
                        CloseEncoded = EncodedTypedArray.ofFloat64Array [| 12.0; 13.0; 14.0 |]
                    )
                )

            let json = serialize trace
            [
                "\"x\":{\"bdata\":"
                "\"ids\":{\"bdata\":"
                "\"customdata\":{\"bdata\":"
                "\"selectedpoints\":{\"bdata\":"
                "\"text\":{\"bdata\":"
                "\"open\":{\"bdata\":"
                "\"high\":{\"bdata\":"
                "\"low\":{\"bdata\":"
                "\"close\":{\"bdata\":"
            ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "ohlc must contain %s" needle))
        )

        testCase "Candlestick encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initCandlestick (
                    Trace2DStyle.Candlestick(
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |],
                        SelectedPoints = [ 0; 1 ],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2; 3 |],
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 300.0; 400.0 |],
                        Open = [ 21.0; 22.0 ],
                        OpenEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        High = [ 23.0; 24.0 ],
                        HighEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Low = [ 19.0; 20.0 ],
                        LowEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                        Close = [ 22.0; 23.0 ],
                        CloseEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0 |]
                    )
                )

            let json = serialize trace
            [
                "\"x\":[10.0,20.0]"
                "\"ids\":[1,2]"
                "\"customdata\":[10.0,20.0]"
                "\"selectedpoints\":[0,1]"
                "\"text\":[100.0,200.0]"
                "\"open\":[21.0,22.0]"
                "\"high\":[23.0,24.0]"
                "\"low\":[19.0,20.0]"
                "\"close\":[22.0,23.0]"
            ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain candlestick array must not be present: %s" needle))
        )

        testCase "Splom encoded metadata fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initSplom (
                    Trace2DStyle.Splom(
                        Dimensions = [
                            Dimension.initSplom(Label = "A", ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |])
                            Dimension.initSplom(Label = "B", ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |])
                        ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 141; 142; 143 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 151.0; 152.0; 153.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 161.0; 162.0; 163.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"dimensions\":[{\"label\":\"A\",\"values\":{\"bdata\":" "splom dimension values must be encoded"
            Expect.stringContains json "\"ids\":{\"bdata\":" "splom ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "splom customdata must be encoded"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "splom selectedpoints must be encoded"
            Expect.stringContains json "\"text\":{\"bdata\":" "splom text must be encoded"
        )
    ]

[<Tests>]
let ``Matrix trace family encoded fields`` =
    testList "CommonAbstractions.EncodedTypedArray matrix trace family integration" [

        testCase "Histogram2D encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initHistogram2D (
                    Trace2DStyle.Histogram2D(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |], shape = [ 2; 3 ]),
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 11; 12; 13 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0; 23.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"x\":{\"bdata\":" "histogram2d x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "histogram2d y must be encoded"
            Expect.stringContains json "\"z\":{\"bdata\":" "histogram2d z must be encoded"
            Expect.stringContains json "\"shape\":\"2,3\"" "histogram2d z shape must be serialized"
            Expect.stringContains json "\"ids\":{\"bdata\":" "histogram2d ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "histogram2d customdata must be encoded"
        )

        testCase "Histogram2D encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initHistogram2D (
                    Trace2DStyle.Histogram2D(
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Y = [ 30.0; 40.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Z = [ [ 50.0; 60.0 ]; [ 70.0; 80.0 ] ],
                        ZEncoded = EncodedTypedArray.ofFloat64Array([| 5.0; 6.0; 7.0; 8.0 |], shape = [ 2; 2 ]),
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |]
                    )
                )

            let json = serialize trace
            Expect.isFalse (json.Contains "\"x\":[10.0,20.0]") "plain histogram2d x array must not be present"
            Expect.isFalse (json.Contains "\"y\":[30.0,40.0]") "plain histogram2d y array must not be present"
            Expect.isFalse (json.Contains "\"z\":[[50.0,60.0],[70.0,80.0]]") "plain histogram2d z matrix must not be present"
            Expect.isFalse (json.Contains "\"ids\":[1,2]") "plain histogram2d ids array must not be present"
            Expect.isFalse (json.Contains "\"customdata\":[10.0,20.0]") "plain histogram2d customdata array must not be present"
        )

        testCase "Histogram2DContour encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initHistogram2DContour (
                    Trace2DStyle.Histogram2DContour(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0 |], shape = [ 2; 2 ]),
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 31; 32; 33 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0; 43.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"x\":{\"bdata\":" "histogram2dcontour x must be encoded"
            Expect.stringContains json "\"y\":{\"bdata\":" "histogram2dcontour y must be encoded"
            Expect.stringContains json "\"z\":{\"bdata\":" "histogram2dcontour z must be encoded"
            Expect.stringContains json "\"shape\":\"2,2\"" "histogram2dcontour z shape must be serialized"
            Expect.stringContains json "\"ids\":{\"bdata\":" "histogram2dcontour ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "histogram2dcontour customdata must be encoded"
        )

        testCase "Heatmap encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initHeatmap (
                    Trace2DStyle.Heatmap(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |], shape = [ 2; 3 ]),
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0; 64.0; 65.0; 66.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0 |]
                    )
                )

            let json = serialize trace
            [
                "\"x\":{\"bdata\":"
                "\"y\":{\"bdata\":"
                "\"z\":{\"bdata\":"
                "\"shape\":\"2,3\""
                "\"ids\":{\"bdata\":"
                "\"text\":{\"bdata\":"
                "\"customdata\":{\"bdata\":"
            ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "heatmap must contain %s" needle))
        )

        testCase "Heatmap encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                Trace2D.initHeatmap (
                    Trace2DStyle.Heatmap(
                        X = [ 10.0; 20.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0 |],
                        Y = [ 30.0; 40.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Z = [ [ 50.0; 60.0 ]; [ 70.0; 80.0 ] ],
                        ZEncoded = EncodedTypedArray.ofFloat64Array([| 5.0; 6.0; 7.0; 8.0 |], shape = [ 2; 2 ]),
                        MultiText = [ 100.0; 200.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 300.0; 400.0 |],
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 5; 6 |],
                        CustomData = [ 10.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 30.0; 40.0 |]
                    )
                )

            let json = serialize trace
            [
                "\"x\":[10.0,20.0]"
                "\"y\":[30.0,40.0]"
                "\"z\":[[50.0,60.0],[70.0,80.0]]"
                "\"ids\":[1,2]"
                "\"customdata\":[10.0,20.0]"
                "\"text\":[100.0,200.0]"
            ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain heatmap value must not be present: %s" needle))
        )

        testCase "Contour encoded fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initContour (
                    Trace2DStyle.Contour(
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array([| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |], shape = [ 2; 3 ]),
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 81; 82 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0; 93.0; 94.0; 95.0; 96.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 101.0; 102.0 |]
                    )
                )

            let json = serialize trace
            [
                "\"x\":{\"bdata\":"
                "\"y\":{\"bdata\":"
                "\"z\":{\"bdata\":"
                "\"shape\":\"2,3\""
                "\"ids\":{\"bdata\":"
                "\"text\":{\"bdata\":"
                "\"customdata\":{\"bdata\":"
            ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "contour must contain %s" needle))
        )

        testCase "Image encoded metadata fields land under the expected properties" (fun () ->
            let trace =
                Trace2D.initImage (
                    Trace2DStyle.Image(
                        Z = [
                            [ [ 255; 0; 0 ]; [ 0; 255; 0 ] ]
                            [ [ 0; 0; 255 ]; [ 255; 255; 0 ] ]
                        ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 111; 112 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 121.0; 122.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 131.0; 132.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"ids\":{\"bdata\":" "image ids must be encoded"
            Expect.stringContains json "\"text\":{\"bdata\":" "image text must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "image customdata must be encoded"
        )
    ]

[<Tests>]
let ``Remaining subplot trace family encoded fields`` =
    testList "CommonAbstractions.EncodedTypedArray remaining subplot trace family integration" [

        testCase "ScatterPolar encoded fields land under the expected properties" (fun () ->
            let trace =
                TracePolar.initScatterPolar (
                    TracePolarStyle.ScatterPolar(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                        REncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 1.5 |],
                        ThetaEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 120.0; 240.0 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 11.0; 12.0; 13.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0; 23.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"r\":{\"bdata\":"; "\"theta\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "scatterpolar must contain %s" needle))
        )

        testCase "ScatterGeo encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceGeo.initScatterGeo (
                    TraceGeoStyle.ScatterGeo(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 11; 12; 13 |],
                        LatEncoded = EncodedTypedArray.ofFloat64Array [| 52.52; 48.85; 41.90 |],
                        LonEncoded = EncodedTypedArray.ofFloat64Array [| 13.40; 2.35; 12.49 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0; 33.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0; 43.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"lat\":{\"bdata\":"; "\"lon\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "scattergeo must contain %s" needle))
        )

        testCase "ScatterMapbox encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceMapbox.initScatterMapbox (
                    TraceMapboxStyle.ScatterMapbox(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 21; 22; 23 |],
                        LatEncoded = EncodedTypedArray.ofFloat64Array [| 37.77; 34.05; 47.61 |],
                        LonEncoded = EncodedTypedArray.ofFloat64Array [| -122.42; -118.24; -122.33 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 51.0; 52.0; 53.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"lat\":{\"bdata\":"; "\"lon\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "scattermapbox must contain %s" needle))
        )

        testCase "ScatterTernary encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceTernary.initScatterTernary (
                    TraceTernaryStyle.ScatterTernary(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 31; 32; 33 |],
                        AEncoded = EncodedTypedArray.ofFloat64Array [| 0.2; 0.3; 0.4 |],
                        BEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 0.3; 0.2 |],
                        CEncoded = EncodedTypedArray.ofFloat64Array [| 0.3; 0.4; 0.4 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0; 73.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 81.0; 82.0; 83.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"a\":{\"bdata\":"; "\"b\":{\"bdata\":"; "\"c\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "scatterternary must contain %s" needle))
        )

        testCase "ScatterSmith encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceSmith.initScatterSmith (
                    TraceSmithStyle.ScatterSmith(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 41; 42; 43 |],
                        RealEncoded = EncodedTypedArray.ofFloat64Array [| 0.5; 1.0; 1.5 |],
                        ImagEncoded = EncodedTypedArray.ofFloat64Array [| -0.2; 0.0; 0.2 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0; 93.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 101.0; 102.0; 103.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 1 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"real\":{\"bdata\":"; "\"imag\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "scattersmith must contain %s" needle))
        )
    ]

[<Tests>]
let ``Carpet and domain trace family encoded fields`` =
    testList "CommonAbstractions.EncodedTypedArray carpet and domain trace family integration" [

        testCase "Carpet encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceCarpet.initCarpet (
                    TraceCarpetStyle.Carpet(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 40.0; 50.0; 60.0 |],
                        AEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 2.0 |],
                        BEncoded = EncodedTypedArray.ofFloat64Array [| 0.0; 1.0; 2.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"x\":{\"bdata\":"; "\"y\":{\"bdata\":"; "\"a\":{\"bdata\":"; "\"b\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "carpet must contain %s" needle))
        )

        testCase "Carpet encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                TraceCarpet.initCarpet (
                    TraceCarpetStyle.Carpet(
                        Ids = [ 10; 20 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2 |],
                        X = [ 1.0; 2.0 ],
                        XEncoded = EncodedTypedArray.ofFloat64Array [| 3.0; 4.0 |],
                        Y = [ 5.0; 6.0 ],
                        YEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0 |],
                        A = [ 9.0; 10.0 ],
                        AEncoded = EncodedTypedArray.ofFloat64Array [| 11.0; 12.0 |],
                        B = [ 13.0; 14.0 ],
                        BEncoded = EncodedTypedArray.ofFloat64Array [| 15.0; 16.0 |],
                        CustomData = [ 17.0; 18.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 19.0; 20.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":[10,20]"; "\"x\":[1.0,2.0]"; "\"y\":[5.0,6.0]"; "\"a\":[9.0,10.0]"; "\"b\":[13.0,14.0]"; "\"customdata\":[17.0,18.0]" ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain carpet array must not be present: %s" needle))
        )

        testCase "ScatterCarpet encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceCarpet.initScatterCarpet (
                    TraceCarpetStyle.ScatterCarpet(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 11; 12; 13 |],
                        AEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        BEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0; 23.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 31.0; 32.0; 33.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 0; 2 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"a\":{\"bdata\":"; "\"b\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "scattercarpet must contain %s" needle))
        )

        testCase "ContourCarpet encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceCarpet.initContourCarpet (
                    TraceCarpetStyle.ContourCarpet(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 21; 22; 23 |],
                        ZEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |],
                        AEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |],
                        BEncoded = EncodedTypedArray.ofFloat64Array [| 7.0; 8.0; 9.0 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 41.0; 42.0; 43.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 51.0; 52.0; 53.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"z\":{\"bdata\":"; "\"a\":{\"bdata\":"; "\"b\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "contourcarpet must contain %s" needle))
        )

        testCase "Pie encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceDomain.initPie (
                    TraceDomainStyle.Pie(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 31; 32; 33 |],
                        ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 20.0; 30.0 |],
                        LabelsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 61.0; 62.0; 63.0 |],
                        MetaEncoded = EncodedTypedArray.ofFloat64Array [| 71.0; 72.0; 73.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 81.0; 82.0; 83.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"values\":{\"bdata\":"; "\"labels\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"meta\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "pie must contain %s" needle))
        )

        testCase "Pie encoded fields override the plain array path when both are provided" (fun () ->
            let trace =
                TraceDomain.initPie (
                    TraceDomainStyle.Pie(
                        Ids = [ 1; 2 ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 11; 12 |],
                        Values = [ 3.0; 4.0 ],
                        ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 5.0; 6.0 |],
                        Labels = [ 7; 8 ],
                        LabelsEncoded = EncodedTypedArray.ofInt32Array [| 9; 10 |],
                        MultiText = [ 11.0; 12.0 ],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 13.0; 14.0 |],
                        Meta = [ 15.0; 16.0 ],
                        MetaEncoded = EncodedTypedArray.ofFloat64Array [| 17.0; 18.0 |],
                        CustomData = [ 19.0; 20.0 ],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 21.0; 22.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":[1,2]"; "\"values\":[3.0,4.0]"; "\"labels\":[7,8]"; "\"text\":[11.0,12.0]"; "\"meta\":[15.0,16.0]"; "\"customdata\":[19.0,20.0]" ]
            |> List.iter (fun needle -> Expect.isFalse (json.Contains needle) (sprintf "plain pie array must not be present: %s" needle))
        )

        testCase "Sunburst encoded fields land under the expected properties" (fun () ->
            let trace =
                TraceDomain.initSunburst (
                    TraceDomainStyle.Sunburst(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 41; 42; 43 |],
                        ParentsEncoded = EncodedTypedArray.ofInt32Array [| 0; 41; 41 |],
                        ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 10.0; 6.0; 4.0 |],
                        LabelsEncoded = EncodedTypedArray.ofInt32Array [| 1; 2; 3 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 91.0; 92.0; 93.0 |],
                        MetaEncoded = EncodedTypedArray.ofFloat64Array [| 101.0; 102.0; 103.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 111.0; 112.0; 113.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"parents\":{\"bdata\":"; "\"values\":{\"bdata\":"; "\"labels\":{\"bdata\":"; "\"text\":{\"bdata\":"; "\"meta\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "sunburst must contain %s" needle))
        )

        testCase "ParallelCoord encoded metadata fields land under the expected properties" (fun () ->
            let trace =
                TraceDomain.initParallelCoord (
                    TraceDomainStyle.ParallelCoord(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 51; 52; 53 |],
                        Dimensions = [
                            Dimension.initParallel(Label = "A", ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 1.0; 2.0; 3.0 |])
                            Dimension.initParallel(Label = "B", ValuesEncoded = EncodedTypedArray.ofFloat64Array [| 4.0; 5.0; 6.0 |])
                        ],
                        MetaEncoded = EncodedTypedArray.ofFloat64Array [| 121.0; 122.0; 123.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 131.0; 132.0; 133.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"dimensions\":[{\"label\":\"A\",\"values\":{\"bdata\":" "parallelcoord dimension values must be encoded"
            [ "\"ids\":{\"bdata\":"; "\"meta\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "parallelcoord must contain %s" needle))
        )

        testCase "Sankey encoded metadata fields land under the expected properties" (fun () ->
            let trace =
                TraceDomain.initSankey (
                    TraceDomainStyle.Sankey(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 61; 62 |],
                        MetaEncoded = EncodedTypedArray.ofFloat64Array [| 141.0; 142.0 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 151.0; 152.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 1 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"meta\":{\"bdata\":"; "\"customdata\":{\"bdata\":"; "\"selectedpoints\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "sankey must contain %s" needle))
        )

        testCase "Indicator encoded metadata fields land under the expected properties" (fun () ->
            let trace =
                TraceDomain.initIndicator (
                    TraceDomainStyle.Indicator(
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 71; 72 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 161.0; 162.0 |]
                    )
                )

            let json = serialize trace
            [ "\"ids\":{\"bdata\":"; "\"customdata\":{\"bdata\":" ]
            |> List.iter (fun needle -> Expect.stringContains json needle (sprintf "indicator must contain %s" needle))
        )
    ]
