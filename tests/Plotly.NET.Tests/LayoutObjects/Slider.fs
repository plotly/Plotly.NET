module Tests.LayoutObjects.Slider

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects

open TestUtils.Objects

let slider =
    Slider.init(
        Active=1,
        ActiveBgColor=Color.fromRGB 1 2 3,
        BgColor=Color.fromRGB 2 3 4,
        BorderColor=Color.fromRGB 3 4 5,
        BorderWidth=2,
        CurrentValue=SliderCurrentValue.init(
            Font=Font.init(StyleParam.FontFamily.Arial, Size=1., Color=Color.fromRGB 4 5 6),
            Offset=1,
            Prefix="prefix",
            Suffix="suffix",
            Visible=false,
            XAnchor=StyleParam.XAnchorPosition.Center
        ),
        Font=Font.init(StyleParam.FontFamily.Balto, Size=2., Color=Color.fromRGB 5 6 7),
        Len=0.4,
        LenMode=StyleParam.UnitMode.Fraction,
        MinorTickLen=6,
        Name="SliderName",
        Padding=Padding.init(1, 2, 3, 4),
        Steps=
            [SliderStep.init(
                Args=["visible", box(false); "title", box("stepTitle")],
                Execute=true,
                Label="stepLabel",
                Method=StyleParam.Method.Update,
                Name="stepName",
                TemplateItemName="stepTemplateItemName",
                Value="stepValue",
                Visible=true
            )],
        TemplateItemName="TemplateItemName",
        TickColor=Color.fromRGB 6 7 8,
        TickLen=7,
        TickWidth=8,
        Transition=Transition.init(        
            Duration=1,
            Easing=StyleParam.TransitionEasing.Back,
            Ordering=StyleParam.TransitionOrdering.LayoutFirst
        ),
        Visible=true,
        X=9,
        XAnchor=StyleParam.XAnchorPosition.Left,
        Y=10,
        YAnchor=StyleParam.YAnchorPosition.Middle
    )

[<Tests>]
let ``Slider tests`` =
    testList "LayoutObjects.Slider JSON field tests" [
        testCase "active" (fun _ -> slider |> jsonFieldIsSetWith "active" "1"  )
        testCase "activebgcolor" (fun _ -> slider |> jsonFieldIsSetWith "activebgcolor" "\"rgba(1, 2, 3, 1.0)\"" )
        testCase "bgcolor" (fun _ -> slider |> jsonFieldIsSetWith "bgcolor" "\"rgba(2, 3, 4, 1.0)\"" )
        testCase "bordercolor" (fun _ -> slider |> jsonFieldIsSetWith "bordercolor" "\"rgba(3, 4, 5, 1.0)\"" )
        testCase "borderwidth" (fun _ -> slider |> jsonFieldIsSetWith "borderwidth" "2" )
        testCase "currentvalue" (fun _ -> slider |> jsonFieldIsSetWith "currentvalue" "{\"font\":{\"family\":\"Arial\",\"size\":1.0,\"color\":\"rgba(4, 5, 6, 1.0)\"},\"offset\":1,\"prefix\":\"prefix\",\"suffix\":\"suffix\",\"visible\":false,\"xanchor\":\"center\"}" )
        testCase "font" (fun _ -> slider |> jsonFieldIsSetWith "font" "{\"family\":\"Balto\",\"size\":2.0,\"color\":\"rgba(5, 6, 7, 1.0)\"}" )
        testCase "len" (fun _ -> slider |> jsonFieldIsSetWith "len" "0.4" )
        testCase "lenmode" (fun _ -> slider |> jsonFieldIsSetWith "lenmode" "\"fraction\"" )
        testCase "minorticklen" (fun _ -> slider |> jsonFieldIsSetWith "minorticklen" "6" )
        testCase "name" (fun _ -> slider |> jsonFieldIsSetWith "name" "\"SliderName\"" )
        testCase "pad" (fun _ -> slider |> jsonFieldIsSetWith "pad" "{\"b\":1,\"l\":2,\"r\":3,\"t\":4}" )
        testCase "templateitemname" (fun _ -> slider |> jsonFieldIsSetWith "templateitemname" "\"TemplateItemName\"" )
        testCase "tickcolor" (fun _ -> slider |> jsonFieldIsSetWith "tickcolor" "\"rgba(6, 7, 8, 1.0)\"" )
        testCase "ticklen" (fun _ -> slider |> jsonFieldIsSetWith "ticklen" "7" )
        testCase "tickwidth" (fun _ -> slider |> jsonFieldIsSetWith "tickwidth" "8" )
        testCase "transition" (fun _ -> slider |> jsonFieldIsSetWith "transition" "{\"duration\":1,\"easing\":\"back\",\"ordering\":\"layout first\"}" )
        testCase "visible" (fun _ -> slider |> jsonFieldIsSetWith "visible" "true" )
        testCase "x" (fun _ -> slider |> jsonFieldIsSetWith "x" "9" )
        testCase "xanchor" (fun _ -> slider |> jsonFieldIsSetWith "xanchor" "\"left\"" )
        testCase "y" (fun _ -> slider |> jsonFieldIsSetWith "y" "10" )
        testCase "yanchor" (fun _ -> slider |> jsonFieldIsSetWith "yanchor" "\"middle\"" )
        testCase "steps" (fun _ -> slider |> jsonFieldIsSetWith "steps" "[{\"args\":[{\"visible\":false},{\"title\":\"stepTitle\"}],\"execute\":true,\"label\":\"stepLabel\",\"method\":\"update\",\"name\":\"stepName\",\"templateitemname\":\"stepTemplateItemName\",\"value\":\"stepValue\",\"visible\":true}]" )
    ]