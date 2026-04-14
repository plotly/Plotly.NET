namespace Plotly.NET

open DynamicObj
open System

/// Data type tag for encoded typed arrays accepted by plotly.js (>= 2.28.0).
/// Serializes to the shorthand strings documented in the plotly.js release notes
/// (e.g. "f8" for Float64, "u1c" for UInt8Clamped).
[<RequireQualifiedAccess>]
type TypedArrayDType =
    | Float64
    | Float32
    | Int32
    | UInt32
    | Int16
    | UInt16
    | Int8
    | UInt8
    | UInt8Clamped

    static member toString =
        function
        | Float64      -> "f8"
        | Float32      -> "f4"
        | Int32        -> "i4"
        | UInt32       -> "u4"
        | Int16        -> "i2"
        | UInt16       -> "u2"
        | Int8         -> "i1"
        | UInt8        -> "u1"
        | UInt8Clamped -> "u1c"

    static member convert = TypedArrayDType.toString >> box
    override this.ToString() = this |> TypedArrayDType.toString
    member this.Convert() = this |> TypedArrayDType.convert


/// <summary>
/// Base64-encoded typed array representation accepted by plotly.js (>= 2.28.0) for trace data_array fields.
///
/// Carries a base64-encoded byte payload (<c>bdata</c>), the underlying value data type (<c>dtype</c>),
/// and an optional <c>shape</c> for multi-dimensional arrays. See the plotly.js v2.28.0 release notes.
/// </summary>
type EncodedTypedArray() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new EncodedTypedArray with the given base64 payload, dtype tag, and optional shape.
    /// Use this overload when you already own the base64 encoding (e.g. from numpy-style pipelines).
    /// </summary>
    /// <param name="bdata">The base64-encoded contents of the typed array.</param>
    /// <param name="dtype">The data type of individual values in the payload.</param>
    /// <param name="shape">Optional array shape. Required for multi-dimensional arrays, omittable for 1-D. Serialized as a comma-separated string.</param>
    static member init
        (
            bdata: string,
            dtype: TypedArrayDType,
            ?shape: seq<int>
        ) =
            EncodedTypedArray()
            |> EncodedTypedArray.style (
                bdata = bdata,
                dtype = dtype,
                ?shape = shape
            )

    /// <summary>
    /// Returns a function that applies the given bdata/dtype/shape to an existing EncodedTypedArray.
    /// </summary>
    static member style
        (
            bdata: string,
            dtype: TypedArrayDType,
            ?shape: seq<int>
        ) =
            fun (eta: EncodedTypedArray) ->
                eta
                |> DynObj.withProperty "bdata" bdata
                |> DynObj.withProperty "dtype" (TypedArrayDType.convert dtype)
                |> DynObj.withOptionalPropertyBy "shape" shape (fun s -> String.Join(",", s |> Seq.map string))

    /// <summary>
    /// Creates an EncodedTypedArray from a 1-D Float64 array, base64-encoding the underlying bytes.
    /// Pass <paramref name="shape"/> to declare a multi-dimensional layout over the flat data.
    /// </summary>
    static member ofFloat64Array (data: float[], ?shape: seq<int>) =
        let bytes = Array.zeroCreate<byte> (data.Length * sizeof<float>)
        Buffer.BlockCopy(data, 0, bytes, 0, bytes.Length)
        EncodedTypedArray.init (Convert.ToBase64String bytes, TypedArrayDType.Float64, ?shape = shape)

    /// <summary>
    /// Creates an EncodedTypedArray from a 1-D Float32 array.
    /// </summary>
    static member ofFloat32Array (data: single[], ?shape: seq<int>) =
        let bytes = Array.zeroCreate<byte> (data.Length * sizeof<single>)
        Buffer.BlockCopy(data, 0, bytes, 0, bytes.Length)
        EncodedTypedArray.init (Convert.ToBase64String bytes, TypedArrayDType.Float32, ?shape = shape)

    /// <summary>
    /// Creates an EncodedTypedArray from a 1-D Int32 array.
    /// </summary>
    static member ofInt32Array (data: int32[], ?shape: seq<int>) =
        let bytes = Array.zeroCreate<byte> (data.Length * sizeof<int32>)
        Buffer.BlockCopy(data, 0, bytes, 0, bytes.Length)
        EncodedTypedArray.init (Convert.ToBase64String bytes, TypedArrayDType.Int32, ?shape = shape)

    /// <summary>
    /// Creates an EncodedTypedArray from a 1-D UInt32 array.
    /// </summary>
    static member ofUInt32Array (data: uint32[], ?shape: seq<int>) =
        let bytes = Array.zeroCreate<byte> (data.Length * sizeof<uint32>)
        Buffer.BlockCopy(data, 0, bytes, 0, bytes.Length)
        EncodedTypedArray.init (Convert.ToBase64String bytes, TypedArrayDType.UInt32, ?shape = shape)

    /// <summary>
    /// Creates an EncodedTypedArray from a 1-D Int16 array.
    /// </summary>
    static member ofInt16Array (data: int16[], ?shape: seq<int>) =
        let bytes = Array.zeroCreate<byte> (data.Length * sizeof<int16>)
        Buffer.BlockCopy(data, 0, bytes, 0, bytes.Length)
        EncodedTypedArray.init (Convert.ToBase64String bytes, TypedArrayDType.Int16, ?shape = shape)

    /// <summary>
    /// Creates an EncodedTypedArray from a 1-D UInt16 array.
    /// </summary>
    static member ofUInt16Array (data: uint16[], ?shape: seq<int>) =
        let bytes = Array.zeroCreate<byte> (data.Length * sizeof<uint16>)
        Buffer.BlockCopy(data, 0, bytes, 0, bytes.Length)
        EncodedTypedArray.init (Convert.ToBase64String bytes, TypedArrayDType.UInt16, ?shape = shape)

    /// <summary>
    /// Creates an EncodedTypedArray from a 1-D Int8 (signed byte) array.
    /// </summary>
    static member ofInt8Array (data: sbyte[], ?shape: seq<int>) =
        let bytes = Array.zeroCreate<byte> data.Length
        Buffer.BlockCopy(data, 0, bytes, 0, bytes.Length)
        EncodedTypedArray.init (Convert.ToBase64String bytes, TypedArrayDType.Int8, ?shape = shape)

    /// <summary>
    /// Creates an EncodedTypedArray from a 1-D UInt8 (byte) array.
    /// </summary>
    static member ofUInt8Array (data: byte[], ?shape: seq<int>) =
        EncodedTypedArray.init (Convert.ToBase64String data, TypedArrayDType.UInt8, ?shape = shape)

    /// <summary>
    /// Creates an EncodedTypedArray from a byte array, tagged as UInt8Clamped (maps to JS Uint8ClampedArray).
    /// </summary>
    static member ofUInt8ClampedArray (data: byte[], ?shape: seq<int>) =
        EncodedTypedArray.init (Convert.ToBase64String data, TypedArrayDType.UInt8Clamped, ?shape = shape)
