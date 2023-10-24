module PlotlyJS_2_24_TestCharts

open Plotly.NET
open Plotly.NET.TraceObjects
open Plotly.NET.LayoutObjects


module ``Marker pattern for pie, funnelarea, sunburst, icicle and treemap traces`` = 

    let ``Pie chart with section patterns`` = 
        Chart.Pie(
            valuesLabels = [
                20, "yes"
                30, "nope"
            ],
            MultiMarkerPatternShape = [
                StyleParam.PatternShape.Checked
                StyleParam.PatternShape.Dots
            ],
            UseDefaults = false
        )

    let ``Donut chart with section patterns`` = 
        Chart.Doughnut(
            valuesLabels = [
                20, "yes"
                30, "nope"
            ],
            MultiMarkerPatternShape = [
                StyleParam.PatternShape.Checked
                StyleParam.PatternShape.Dots
            ],
            UseDefaults = false
        )

    let ``FunnelArea chart with section patterns`` = 
        Chart.FunnelArea(
            valuesLabels = [
                20, "yes"
                30, "nope"
            ],
            MultiMarkerPatternShape = [
                StyleParam.PatternShape.Checked
                StyleParam.PatternShape.Dots
            ],
            UseDefaults = false
        )

    let ``Sunburst chart with section patterns`` = 
        Chart.Sunburst(
            labels = [ "A"; "B"; "C"; "D"; "E" ],
            parents = [ ""; ""; "B"; "B"; "" ],
            Values = [ 5.; 0.; 3.; 2.; 3. ],
            MultiText = [ "At"; "Bt"; "Ct"; "Dt"; "Et" ],
            MultiMarkerPatternShape = [
                StyleParam.PatternShape.Checked
                StyleParam.PatternShape.Dots
                StyleParam.PatternShape.DiagonalChecked
                StyleParam.PatternShape.HorizontalLines
                StyleParam.PatternShape.None
            ],
            UseDefaults = false
        )

    let ``Treemap chart with section patterns`` = 
        Chart.Treemap(
            labels = [ "A"; "B"; "C"; "D"; "E" ],
            parents = [ ""; ""; "B"; "B"; "" ],
            Values = [ 5.; 0.; 3.; 2.; 3. ],
            MultiText = [ "At"; "Bt"; "Ct"; "Dt"; "Et" ],
            MultiMarkerPatternShape = [
                StyleParam.PatternShape.Checked
                StyleParam.PatternShape.Dots
                StyleParam.PatternShape.DiagonalChecked
                StyleParam.PatternShape.HorizontalLines
                StyleParam.PatternShape.None
            ],
            UseDefaults = false
        )

    let ``Icicle chart with section patterns`` = 
        Chart.Icicle(
            labels = [ "A"; "B"; "C"; "D"; "E" ],
            parents = [ ""; ""; "B"; "B"; "" ],
            Values = [ 5.; 0.; 3.; 2.; 3. ],
            MultiText = [ "At"; "Bt"; "Ct"; "Dt"; "Et" ],
            MultiMarkerPatternShape = [
                StyleParam.PatternShape.Checked
                StyleParam.PatternShape.Dots
                StyleParam.PatternShape.DiagonalChecked
                StyleParam.PatternShape.HorizontalLines
                StyleParam.PatternShape.None
            ],
            UseDefaults = false
        )