module Globals

open DynamicObj
open System.Runtime.InteropServices
open Newtonsoft.Json
open Giraffe.ViewEngine

/// The plotly js version loaded from cdn in rendered html docs
[<Literal>]
let PLOTLYJS_VERSION = "2.27.1"

[<Literal>]
let SCRIPT_TEMPLATE =
    """var renderPlotly_[SCRIPTID] = function() {
    var data = [DATA];
    var layout = [LAYOUT];
    var config = [CONFIG];
    Plotly.newPlot('[ID]', data, layout, config);
};
renderPlotly_[SCRIPTID]();
"""

[<Literal>]
let REQUIREJS_SCRIPT_TEMPLATE =
    """
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
    script.setAttribute("charset", "utf-8");
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

/// base64 encoded favicon logo for generated htmls
[<Literal>]
let LOGO_BASE64 =
    """iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAMAAACdt4HsAAAA1VBMVEVHcEwQnv+gCXURnf+gCXURnf8Rnf+gCXURnf+gCXWgCXURnf+gCHURnf+gCXURnf+gCXURnf+gCXUwke5YVbykBXEijO+gCXURnf8Rnf8Rnf8Rnf8Rnf8Rnf+gCXWIIoygCXUohekRnf8Rnf8Qn/+gCXUQnf8SoP////8ijO+PG4agAnGQLY6gEnrP7f94yP8aof8YwP/DY6jJcrDuz+RlwP/owt0Urv8k/v4e4v9Nr9F1XaSxMoyx3/9rc7Ayq/98UZ3gr9L8+v05rv9Fv9rF5/+7T52h9OprAAAAJHRSTlMAINTUgPmA+gYGNbu7NR9PR/xP/hoh/o74f471R3x8uie60TS1lKLVAAABzUlEQVRYw83X2XKCMBQGYOyK3RdL9x0ChVCkVAHFfXn/RyphKSIBE85Mp8woV/8HOUByIgj/+mg2yb8o1s4/nZHTw2NNobmzf0HOp/d7Ys18Apzv1hHCvJICqIZA8hnAL0T5FYBXiPOrAJ+Q5HMAj5Dm8wC78JtfA1iFLK8oeYBNWM1vvQitltB4QxxCLn8gXD2/NoTjbXZhLX9ypH8c8giFvKJLiEMo5gnALlDyEcAq0PIxwCZQ8wnAItDzKbBZKObNBJDlMCFvEor5YQ8buDfUJdt3kevb1QLl+j2vb4y9OZZ8z0a251feA238uG8qZh/rkmurSLXdqjrQ62eQn5EWsaqS9Dweh3ewDOI7aHdG5ULJ8yM1WE67cQ0604FaJqx/v0leGc6x8aV94+gpWNqiTR3FrShcU68fHqYSA3J47Qwgwnsm3NxtBtR2NVA2BKcbxIC1mFUOoaSIZldzIuDyU+tkAPtjoAMcLwIV4HkVaQDXx0ABOD9HZxIYwcTRJWswQrOBxT8hpBMKIi+xWmdK4pvS4JMqfFqHLyzwpQ2+uMKXd3iDAW9x4E0WvM2DN5rwVhfebMPbffiGA77lgW+64Ns++MYTvvX9m+MHc8vmMWg2fMUAAAAASUVORK5CYII="""

///
let internal JSON_CONFIG =
    JsonSerializerSettings(ReferenceLoopHandling = ReferenceLoopHandling.Serialize)

/// the mathjax v2 tags to add to html docs for rendering latex
let internal MATHJAX_V2_TAGS =
    [
        script
            [
                _type "text/x-mathjax-config;executed=true"
            ]
            [
                rawText
                    """MathJax.Hub.Config({tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']], processEscapes: true}});"""
            ]
        script
            [
                _type "text/javascript"
                _src
                    """https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-AMS-MML_HTMLorMML%2CSafe.js&ver=4.1"""
            ]
            []
    ]

/// the mathjax v3 tags to add to html docs for rendering latex
let internal MATHJAX_V3_TAGS =
    [
        script
            []
            [
                rawText """MathJax = {tex: {inlineMath: [['$', '$'], ['\\(', '\\)']]}};"""
            ]
        script
            [
                _src """https://cdn.jsdelivr.net/npm/mathjax@3.2.0/es5/tex-svg.js"""
            ]
            []
    ]
