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
                            Dimension.initSplom(Label = "A", Values = [ 1.0; 2.0; 3.0 ])
                            Dimension.initSplom(Label = "B", Values = [ 4.0; 5.0; 6.0 ])
                        ],
                        IdsEncoded = EncodedTypedArray.ofInt32Array [| 141; 142; 143 |],
                        CustomDataEncoded = EncodedTypedArray.ofFloat64Array [| 151.0; 152.0; 153.0 |],
                        SelectedPointsEncoded = EncodedTypedArray.ofInt32Array [| 2 |],
                        MultiTextEncoded = EncodedTypedArray.ofFloat64Array [| 161.0; 162.0; 163.0 |]
                    )
                )

            let json = serialize trace
            Expect.stringContains json "\"ids\":{\"bdata\":" "splom ids must be encoded"
            Expect.stringContains json "\"customdata\":{\"bdata\":" "splom customdata must be encoded"
            Expect.stringContains json "\"selectedpoints\":{\"bdata\":" "splom selectedpoints must be encoded"
            Expect.stringContains json "\"text\":{\"bdata\":" "splom text must be encoded"
        )
    ]
