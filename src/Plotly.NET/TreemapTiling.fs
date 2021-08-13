namespace Plotly.NET

open DynamicObj
open System

type TreemapTiling () =
    inherit DynamicObj ()

    ///Initializes tiling object (used in Chart.Treemap)
    ///
    ///Parameters:
    ///
    ///Packing      : Determines d3 treemap solver. For more info please refer to https://github.com/d3/d3-hierarchy#treemap-tiling
    ///         
    ///SquarifyRatio: When using "squarify" `packing` algorithm, according to https://github.com/d3/d3-hierarchy/blob/master/README.md#squarify_ratio this option specifies the desired aspect ratio of the generated rectangles. The ratio must be specified as a number greater than or equal to one. Note that the orientation of the generated rectangles (tall or wide) is not implied by the ratio; for example, a ratio of two will attempt to produce a mixture of rectangles whose width:height ratio is either 2:1 or 1:2. When using "squarify", unlike d3 which uses the Golden Ratio i.e. 1.618034, Plotly applies 1 to increase squares in treemap layouts.
    ///         
    ///Flip         : Determines if the positions obtained from solver are flipped on each axis.
    ///         
    ///Pad          : Sets the inner padding (in px).
    static member init 
        (
            ?Packing        : StyleParam.TreemapTilingPacking,
            ?SquarifyRatio  : float,
            ?Flip           : string,
            ?Pad            : float
        ) = 

        TreemapTiling() 
        |> TreemapTiling.style 
            (
                ?Packing        = Packing      ,
                ?SquarifyRatio  = SquarifyRatio,
                ?Flip           = Flip         ,
                ?Pad            = Pad          
            )

    ///Applies the given styles to the given tiling object 
    ///
    ///Parameters:
    ///
    ///Packing      : Determines d3 treemap solver. For more info please refer to https://github.com/d3/d3-hierarchy#treemap-tiling
    ///         
    ///SquarifyRatio: When using "squarify" `packing` algorithm, according to https://github.com/d3/d3-hierarchy/blob/master/README.md#squarify_ratio this option specifies the desired aspect ratio of the generated rectangles. The ratio must be specified as a number greater than or equal to one. Note that the orientation of the generated rectangles (tall or wide) is not implied by the ratio; for example, a ratio of two will attempt to produce a mixture of rectangles whose width:height ratio is either 2:1 or 1:2. When using "squarify", unlike d3 which uses the Golden Ratio i.e. 1.618034, Plotly applies 1 to increase squares in treemap layouts.
    ///         
    ///Flip         : Determines if the positions obtained from solver are flipped on each axis.
    ///         
    ///Pad          : Sets the inner padding (in px).
    static member style 
        (
            ?Packing        : StyleParam.TreemapTilingPacking,
            ?SquarifyRatio  : float,
            ?Flip           : string,
            ?Pad            : float
            
        ) = 
            (fun (tiling:TreemapTiling) -> 
                Packing       |> DynObj.setValueOptBy tiling "packing" StyleParam.TreemapTilingPacking.convert
                SquarifyRatio |> DynObj.setValueOpt   tiling "squarifyRatio"
                Flip          |> DynObj.setValueOpt   tiling "flip"
                Pad           |> DynObj.setValueOpt   tiling "pad"

                tiling
            )