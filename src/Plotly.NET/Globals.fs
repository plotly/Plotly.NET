module Globals

open DynamicObj
open System.Runtime.InteropServices
open Newtonsoft.Json
open Giraffe.ViewEngine

/// The plotly js version loaded from cdn in rendered html docs
let [<Literal>] PLOTLYJS_VERSION = "2.18.1"
let PLOTLY_CDN = $"""https://cdn.plot.ly/plotly-{PLOTLYJS_VERSION}.min.js"""
let PLOTLY_REQUIRE_CDN = $"""https://cdn.plot.ly/plotly-{PLOTLYJS_VERSION}.min"""

/// 
let internal JSON_CONFIG = 
    JsonSerializerSettings(
        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
    )

let [<Literal>] MATHJAX_V2_CDN = """https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-AMS-MML_HTMLorMML%2CSafe.js&ver=4.1"""
let [<Literal>] MATHJAX_V2_REQUIRE_CDN = """https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-AMS-MML_HTMLorMML%2CSafe.js&ver=4.1"""
let [<Literal>] MATHJAX_V2_CONFIG = """MathJax.Hub.Config({tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']], processEscapes: true}});"""

let [<Literal>] MATHJAX_V3_CDN = """https://cdn.jsdelivr.net/npm/mathjax@3.2.0/es5/tex-svg.js"""
let [<Literal>] MATHJAX_V3_REQUIRE_CDN = """https://cdn.jsdelivr.net/npm/mathjax@3.2.0/es5/tex-svg"""
let [<Literal>] MATHJAX_V3_CONFIG = """MathJax = {tex: {inlineMath: [['$', '$'], ['\\(', '\\)']]}};"""

/// the mathjax v2 tags to add to html docs for rendering latex
let internal MATHJAX_V2_TAGS =
    [
        script [_type "text/x-mathjax-config;executed=true"] [rawText MATHJAX_V2_CONFIG]
        script [_type "text/javascript"; _src MATHJAX_V2_CDN] []
    ]

/// the mathjax v3 tags to add to html docs for rendering latex
let internal MATHJAX_V3_TAGS =
    [
        script [] [rawText MATHJAX_V3_CONFIG]
        script [_src MATHJAX_V3_CDN] []
    ]