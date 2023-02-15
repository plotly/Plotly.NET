module Globals

open DynamicObj
open System.Runtime.InteropServices
open Newtonsoft.Json
open Giraffe.ViewEngine

/// The plotly js version loaded from cdn in rendered html docs
let [<Literal>] PLOTLYJS_VERSION = "2.18.1"

let [<Literal>] SCRIPT_TEMPLATE ="""var renderPlotly_[SCRIPTID] = function() {
    var data = [DATA];
    var layout = [LAYOUT];
    var config = [CONFIG];
    Plotly.newPlot('[ID]', data, layout, config);
};
renderPlotly_[SCRIPTID]();
"""

let [<Literal>] REQUIREJS_SCRIPT_TEMPLATE ="""
var renderPlotly_[SCRIPTID] = function() {
    var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'[REQUIRE_SRC]'}}) || require;
    fsharpPlotlyRequire(['plotly'], function(Plotly) {
        var data = [DATA];
        var layout = [LAYOUT];
        var config = [CONFIG];
        Plotly.newPlot('[ID]', data, layout, config);
    });
};
if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
    var script = document.createElement("script");
    script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
    script.onload = function(){
        renderPlotly_[SCRIPTID]();
    };
    document.getElementsByTagName("head")[0].appendChild(script);
}
else {
    renderPlotly_[SCRIPTID]();
}
"""

/// 
let internal JSON_CONFIG = 
    JsonSerializerSettings(
        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
    )

/// the mathjax v2 tags to add to html docs for rendering latex
let internal MATHJAX_V2_TAGS =
    [
        script [_type "text/x-mathjax-config;executed=true"] [rawText """MathJax.Hub.Config({tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']], processEscapes: true}});"""]
        script [_type "text/javascript"; _src """https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-AMS-MML_HTMLorMML%2CSafe.js&ver=4.1"""] []
    ]

/// the mathjax v3 tags to add to html docs for rendering latex
let internal MATHJAX_V3_TAGS =
    [
        script [] [rawText """MathJax = {tex: {inlineMath: [['$', '$'], ['\\(', '\\)']]}};"""]
        script [_src """https://cdn.jsdelivr.net/npm/mathjax@3.2.0/es5/tex-svg.js"""] []
    ]