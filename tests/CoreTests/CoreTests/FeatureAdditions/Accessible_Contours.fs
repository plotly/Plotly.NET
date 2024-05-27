// https://github.com/plotly/Plotly.NET/issues/426

module CoreTests.Accessible_Contours

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open TestUtils.HtmlCodegen
open Accessible_Contrours_TestCharts
    
module ``Contours should be accessible #426`` = 

    [<Tests>]
    let ``Contours should be accessible #426`` =
        testList "FeatureAddition.Contours should be accessible" [
            test "more contours settings on Contour data" {
                """var data = [{"type":"contour","z":[[5,2,3],[10,2,1],[0,5,1]],"line":{"width":0.0},"contours":{"end":15.0,"showlabels":true,"start":0.0},"coloraxis":"coloraxis"}];"""
                |> chartGeneratedContains ``Contours should be accessible #426``.``Contour chart with more contours settings``
            }
            test "more contours settings on Contour layout" {
                emptyLayout ``Contours should be accessible #426``.``Contour chart with more contours settings``
            }
            test "more contours settings on Histogram2DContour data"  {
                """var data = [{"type":"histogram2dcontour","x":[1,1,2,2,2,2,2,3,4,5],"y":[1,1,2,2,2,2,2,3,4,5],"line":{"width":0.0},"contours":{"end":15.0,"showlabels":true,"start":0.0},"coloraxis":"coloraxis"}];"""
                |> chartGeneratedContains ``Contours should be accessible #426``.``Histogram2DContour chart with more contours settings``
            }
            test "more contours settings on Histogram2DContour layout"  {
                emptyLayout ``Contours should be accessible #426``.``Histogram2DContour chart with more contours settings``
            }
            test "Accessible contours settings on PointDensity data"  {
                """var data = [{"type":"histogram2dcontour","x":[1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,4,5],"y":[1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,4,5],"line":{"width":0.0},"contours":{"coloring":"fill","end":15.0,"showlabels":true,"start":0.0},"coloraxis":"coloraxis"},{"type":"scatter","opacity":0.3,"mode":"markers","x":[1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,4,5],"y":[1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,4,5],"marker":{},"coloraxis":"coloraxis"}];"""
                |> chartGeneratedContains ``Contours should be accessible #426``.``PointDensity chart with accessible contours settings``
            }
            test "Accessible contours settings on PointDensity layout"  {
                emptyLayout ``Contours should be accessible #426``.``PointDensity chart with accessible contours settings``
            }
            test "Chart Grid with shared color axis and corrected contours ranges data" {
                """var data = [{"type":"contour","z":[[5,2,3],[10,2,1],[0,5,1]],"line":{"width":0.0},"contours":{"end":15.0,"showlabels":true,"start":0.0},"coloraxis":"coloraxis","xaxis":"x","yaxis":"y"},{"type":"histogram2dcontour","x":[1,1,2,2,2,2,2,3,4,5],"y":[1,1,2,2,2,2,2,3,4,5],"line":{"width":0.0},"contours":{"end":15.0,"showlabels":true,"start":0.0},"coloraxis":"coloraxis","xaxis":"x2","yaxis":"y2"},{"type":"histogram2dcontour","x":[1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,4,5],"y":[1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,4,5],"line":{"width":0.0},"contours":{"coloring":"fill","end":15.0,"showlabels":true,"start":0.0},"coloraxis":"coloraxis","xaxis":"x3","yaxis":"y3"},{"type":"scatter","opacity":0.3,"mode":"markers","x":[1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,4,5],"y":[1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,4,5],"marker":{},"coloraxis":"coloraxis","xaxis":"x3","yaxis":"y3"}];"""
                |> chartGeneratedContains ``Contours should be accessible #426``.``Contours trace Grid chart with shared color axis and adapted contours ranges``
            }
            test "Chart Grid with shared color axis and corrected contours ranges layout" {
                """var layout = {"xaxis":{},"yaxis":{},"xaxis2":{},"yaxis2":{},"xaxis3":{},"yaxis3":{},"annotations":[],"grid":{"rows":2,"columns":2,"roworder":"top to bottom","pattern":"independent"}};"""
                |> chartGeneratedContains ``Contours should be accessible #426``.``Contours trace Grid chart with shared color axis and adapted contours ranges``
            }
        ]