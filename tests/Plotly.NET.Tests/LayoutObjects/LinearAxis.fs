module Tests.LayoutObjects.LinearAxis

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart

open TestUtils.LayoutObjects

let fullAxis =
    LinearAxis.init(
        Visible            = true,
        Color              = "red",
        Title              = Title.init("Hi"),
        AxisType           = StyleParam.AxisType.Log,
        AutoTypeNumbers    = StyleParam.AutoTypeNumbers.Strict,
        AutoRange          = StyleParam.AutoRange.True,
        RangeMode          = StyleParam.RangeMode.Normal,
        Range              = StyleParam.Range.MinMax (-1.,1.),    
        FixedRange         = true ,
        ScaleAnchor        = StyleParam.LinearAxisId.X 1,
        ScaleRatio         = 6.9,
        Constrain          = StyleParam.AxisConstraint.Range,
        ConstrainToward    = StyleParam.AxisConstraintDirection.Bottom,
        Matches            = StyleParam.LinearAxisId.X 1,
        Rangebreaks        = [Rangebreak.init(false)],
        TickMode           = StyleParam.TickMode.Auto
        // TO-DO: set all other fields and add tests for each one (i am currently too tired for that :D)
        //NTicks             = int,           
        //Tick0              = #IConvertible,            
        //DTick              = #IConvertible,            
        //TickVals           = seq<#IConvertible>,         
        //TickText           = seq<#IConvertible>,         
        //Ticks              = StyleParam.TickOptions,            
        //TicksOn            = StyleParam.CategoryTickAnchor,
        //TickLabelMode      = StyleParam.TickLabelMode,
        //TickLabelPosition  = StyleParam.TickLabelPosition,
        //TickLabelOverflow  = StyleParam.TickLabelOverflow,
        //Mirror             = StyleParam.Mirror,           
        //TickLen            = float,
        //TickWidth          = float,        
        //TickColor          = string,        
        //ShowTickLabels     = bool,   
        //AutoMargin         = bool,
        //ShowSpikes         = bool,       
        //SpikeColor         = string,       
        //SpikeThickness     = int,   
        //SpikeDash          = StyleParam.DrawingStyle,
        //SpikeMode          = StyleParam.SpikeMode,
        //SpikeSnap          = StyleParam.SpikeSnap,
        //TickFont           = Font,         
        //TickAngle          = int,        
        //ShowTickPrefix     = StyleParam.ShowTickOption,   
        //TickPrefix         = string,
        //ShowTickSuffix     = StyleParam.ShowTickOption,
        //TickSuffix         = string,
        //ShowExponent       = StyleParam.ShowExponent,
        //ExponentFormat     = StyleParam.ExponentFormat,
        //MinExponent        = float,
        //SeparateThousands  = bool,
        //TickFormat         = string,       
        //TickFormatStops    = seq<TickFormatStop>,
        //HoverFormat        = string,
        //ShowLine           = bool,         
        //LineColor          = string,        
        //LineWidth          = float,        
        //ShowGrid           = bool,         
        //GridColor          = string,        
        //GridWidth          = float,        
        //ZeroLine           = bool,         
        //ZeroLineColor      = string,    
        //ZeroLineWidth      = float,    
        //ShowDividers       = bool,
        //DividerColor       = string,
        //DividerWidth       = int,
        //Anchor             = StyleParam.LinearAxisId,
        //Side               = StyleParam.Side,
        //Overlaying         = StyleParam.LinearAxisId,
        //Layer              = StyleParam.Layer,
        //Domain             = StyleParam.Range,
        //Position           = float,         
        //CategoryOrder      = StyleParam.CategoryOrder,
        //CategoryArray      = seq<#IConvertible>,
        //UIRevision         = #IConvertible,
        //RangeSlider        = RangeSlider,
        //RangeSelector      = RangeSelector,
        //Calendar           = StyleParam.Calendar
    )

[<Tests>]
let ``LinearAxis tests`` =
    testList "LayoutObjects.LinearAxis JSON field tests" [
        fullAxis |> createJsonFieldTest "visible" "true" 
        fullAxis |> createJsonFieldTest "color" "\"red\""
        fullAxis |> createJsonFieldTest "title" "{\"text\":\"Hi\"}"
        fullAxis |> createJsonFieldTest "type" "\"log\""
        fullAxis |> createJsonFieldTest "autotypenumbers" "\"strict\""
        fullAxis |> createJsonFieldTest "autorange" "\"true\""
        fullAxis |> createJsonFieldTest "rangemode" "\"normal\""
        fullAxis |> createJsonFieldTest "range" "[-1.0,1.0]"
        fullAxis |> createJsonFieldTest "fixedrange" "true"
        fullAxis |> createJsonFieldTest "scaleanchor" "\"x\""
        fullAxis |> createJsonFieldTest "scaleratio" "6.9"
        fullAxis |> createJsonFieldTest "constrain" "\"range\""
        fullAxis |> createJsonFieldTest "constraintoward" "\"bottom\""
        fullAxis |> createJsonFieldTest "matches" "\"x\""
        fullAxis |> createJsonFieldTest "rangebreaks" "[{\"enabled\":false}]"
        fullAxis |> createJsonFieldTest "tickmode" "\"auto\""
    ]