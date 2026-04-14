module Tests.CommonAbstractions.EncodedTypedArray

open Expecto
open Plotly.NET
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
