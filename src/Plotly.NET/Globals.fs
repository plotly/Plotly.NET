module Globals

open DynamicObj
open System.Runtime.InteropServices
open Newtonsoft.Json
open Giraffe.ViewEngine

/// The plotly js version loaded from cdn in rendered html docs
let [<Literal>] PLOTLYJS_VERSION = "2.18.1"

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