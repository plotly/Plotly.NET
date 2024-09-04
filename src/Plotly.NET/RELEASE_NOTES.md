### 5.1.0 - September 04 2024

### 5.0.0 - May 27 2024

Major release with lots of bug fixes, improvements, and upstream feature additions from plotly.js. Many changes are backwards-incompatible with previous versions.

[Milestone link with all the fixed/closed issues](https://github.com/plotly/Plotly.NET/milestone/5)

- [Improve Chart.Grid](https://github.com/plotly/Plotly.NET/pull/453):
  - Set individual subplot titles per input chart, fixes [#387](https://github.com/plotly/Plotly.NET/issues/387)
  - Fix positioning issues for some subplot types, fixes [#413](https://github.com/plotly/Plotly.NET/issues/413)

- [Add Chart.Pareto](https://github.com/plotly/Plotly.NET/pull/431). This contribution started with the [fslab hackathon 2023](https://github.com/orgs/fslaborg/projects/6) and was submitted by [@rockfaith75](https://github.com/rockfaith75) and [@smoothdeveloper](https://github.com/smoothdeveloper), thank you!

- Make Contours setting directly accessible on all supported traces, fixes [#426](https://github.com/plotly/Plotly.NET/issues/426)

- Allow DynamicObj for the args properties of update buttons, fixes [#414](https://github.com/plotly/Plotly.NET/issues/414)

- [Expand DisplayOptions](https://github.com/plotly/Plotly.NET/commit/488568c789fa2fa050fc55f5bff26a8780ba216e) to include direct fields for document title, description, charset, and favicon, fixes [#374](https://github.com/plotly/Plotly.NET/issues/374)

- Keep up with plotlyjs 2.x incremental updates. Note that v2.28+ will be on Plotly.NET 6.0, as some major changes are needed for supporting it properly (see [#441](https://github.com/plotly/Plotly.NET/issues/441))
  - v2.22:
    - [Implement multi legend support](https://github.com/plotly/Plotly.NET/issues/406)
  - v2.23:
    - [add `xref` and `yref` attributes for Legend and ColorBar](https://github.com/plotly/Plotly.NET/commit/a3e1abcfda7b316c704d477471be1294860b48b7)
  - v2.24:
    - [add pattern to multiple traces](https://github.com/plotly/Plotly.NET/commit/f75125e7e8514299bc794ddddbaee6370e5b420a)
  - v2.25:
    - [Add "Equal Earth" projection to geo subplots](https://github.com/plotly/Plotly.NET/commit/0ea7d3e0da77937e1b9d31bc4a6552d7499a660a)
    - [Complete bindings for geo projections](https://github.com/plotly/Plotly.NET/commit/0ea7d3e0da77937e1b9d31bc4a6552d7499a660a)
    - [Add options to include legends for shapes and newshape](https://github.com/plotly/Plotly.NET/commit/0ea7d3e0da77937e1b9d31bc4a6552d7499a660a)
  - v2.26:
    - [Add new autorange options](https://github.com/plotly/Plotly.NET/commit/92f92a5c9faef6710ef39438f8145183e3054575)
    - [Add [n]-sigma (std deviations) box plots](https://github.com/plotly/Plotly.NET/commit/d1c63b97eadd8576d649986ba62f1c4951eda137)
    - [Add "top left" & "top center" side options to legend title](https://github.com/plotly/Plotly.NET/commit/bebe507963c4af2a37ec6ad5afd960e1543c161a)
    - [Add "false" option to scaleanchor](https://github.com/plotly/Plotly.NET/commit/bad6d531501e37f27b16b11bf83d8711640a7605)
  - v2.27:
    - [Add insiderange to cartesian axes](https://github.com/plotly/Plotly.NET/commit/f7d24df0e76130a323c52f8f4d57cdbe8622d241)

**Additional extension package releases:**:

- [Plotly.NET.ImageExport (5.0.1 -> 6.0.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.ImageExport/RELEASE_NOTES.md)
- [Plotly.NET.Interactive (4.2.0 -> 5.0.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.Interactive/RELEASE_NOTES.md)
- [Plotly.NET.CSharp (0.11.1 -> 0.12.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.CSharp/RELEASE_NOTES.md)

### 4.2.0 - August 02 2023

This release makes Plotly.NET compatible with [LINQPad](https://www.linqpad.net/). 

Read more about this on the respective [pull request](https://github.com/plotly/Plotly.NET/pull/404).

Thanks a lot to [@Peter-B-](https://github.com/Peter-B-).

### 4.1.0 - July 14 2023

This is a maintenance release that aims to keep up with plotlyjs 2.x incremental updates.

The only major change is the usage of Giraffe.ViewEngine.StrongName instead of Giraffe.ViewEngine as html dsl.
This could be considered as a breaking change, but it's not because the Giraffe.ViewEngine.StrongName package is a drop-in replacement for Giraffe.ViewEngine with the only difference being a signed assembly

- Keep up with plotlyjs 2.x incremental updates:
  - v2.22+ will be on Plotly.NET 5.0, because it introduces breaking changes.
  - v2.21:
    - [Add texttemplate attribute to shape.label](https://github.com/plotly/Plotly.NET/commit/77fc2b0c8a9de28a4745230eddd6196eb818b716)
  - v2.20:
    - [Add automargin support to plot titles](https://github.com/plotly/Plotly.NET/commit/c82633a8ee0de60b5a1558050fc0b411a05686b1)
  - v2.19:
    - [Add labelalias to various axes](https://github.com/plotly/Plotly.NET/commit/f9e14fb616b1815487f002ebc35ad8bbde3b110f)
    - [Add label attribute to shapes](https://github.com/plotly/Plotly.NET/commit/2f94e879d23b0bdd259ec76cff99ae8946b375b2)

- misc fixes and improvements:
  - [Add json generation functions for GenericChart](https://github.com/plotly/Plotly.NET/commit/6a87f86c31f76b05e1b7be00f9034c175e90c72f)

**Additional extension package releases:**:

- [Plotly.NET.ImageExport (4.0.0 -> 5.0.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.ImageExport/RELEASE_NOTES.md)
- [Plotly.NET.Interactive (4.1.0 -> 4.2.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.Interactive/RELEASE_NOTES.md)
- [Plotly.NET.CSharp (0.10.0 -> 0.11.0)](https://github.com/plotly/Plotly.NET/blob/dev/src/Plotly.NET.CSharp/RELEASE_NOTES.md)


### 4.0.0 - February 24 2023

[Milestone link with all the fixed/closed issues](https://github.com/plotly/Plotly.NET/milestone/4)

- [Add high level arg for base layer style to all mapbox charts](https://github.com/plotly/Plotly.NET/commit/5cd6c9966beb9bceebf31dc2d8269ee3b5d5d815)

- [Add ShowXAxisRangeSlider argument for Chart.OHLC and Chart.Candlestick](https://github.com/plotly/Plotly.NET/commit/86a810c1c63410527da740986494590ea3aaee91)

- [Add multicategory data support for 2D traces](https://github.com/plotly/Plotly.NET/commit/197cea162acd445d752837a55e29e5742d59d939)

- [Add high level camera projection args to all 3D chart apis](https://github.com/plotly/Plotly.NET/commit/d60b4540995f4b0a3c67c31464f9403337ff9c50)

- [Add missing Config params](https://github.com/plotly/Plotly.NET/commit/12cd47329fb0c161b386ba07f1e1210eea3e35fe)

- [Refactor DisplayOptions - An object to control the way Charts are displayed in generated HTML files](https://github.com/plotly/Plotly.NET/issues/293):
    - Add various functions to manipulate DisplayOptions, Refactor DisplayOptions as DynamicObj (again)
    - Add `PlotlyJSReference` type and logic to handle various ways of referencing plotly.js in HTML output:
        - `Full`: Include the full plotly.js source code. The currently supported plotly.js version is now included as embedded resource in the package. HTML files using this option are self-contained and can be used offline.
        - `CDN`: The default. uses a script tag in the head of the generated HTML to load plotly.js from a CDN.
        - `Require`: Use requirejs to load plotly. This option is now used in Plotly.NET.Interactive. Unnecessary usage of require.js is now removed from all other options but this.
        - `NoReference`: Don't include any plotly.js reference. Useful if you want to embed the output into another page that already references plotly.

- [Use Giraffe.ViewEngine as html dsl](https://github.com/plotly/Plotly.NET/pull/363)

- Keep up with plotlyjs 2.x incremental updates:
    - v2.18:
        - [Add sync tickmode option](https://github.com/plotly/Plotly.NET/commit/c69a55c534cdd95e9e27bee8a4e5d77b262e338f)
    - v2.17:
        - [Add shift and autoshift to cartesian y axes to help avoid overlapping of multiple axes](https://github.com/plotly/Plotly.NET/commit/9f7edb8281ba87a2c122d99604af32d17efec168)
        - [Introduce group attributes for scatter trace i.e. alignmentgroup, offsetgroup, scattermode and scattergap](https://github.com/plotly/Plotly.NET/commit/67378a3fd8c007cddb2c1e11b545f57e9874fc2d)
        - [Add marker.cornerradius attribute to treemap trace](https://github.com/plotly/Plotly.NET/commit/8ad20db7ae032b2751882fe25d389c39fb327669)
    - v2.16:
        - [Add bounds to mapbox subplots](https://github.com/plotly/Plotly.NET/commit/046e3c472447c720ec7896f2109895028dba471c)
        - [Add clustering options to scattermapbox](https://github.com/plotly/Plotly.NET/commit/0ee67e3e9251515d94a2f40858ed4fdd7398e104)
    - v2.15:
        - [Add entrywidth and entrywidthmode to legend](https://github.com/plotly/Plotly.NET/commit/b9dffc36fe2a3d3da470d82e2bd1ae6ca8d47a8b)
        - [Add minreducedwidth and minreducedheight to layout for increasing control over automargin](https://github.com/plotly/Plotly.NET/commit/9be3f621959593c7b2b16213affe9877449c194c)
        - [Add two new arrow marker symbols](https://github.com/plotly/Plotly.NET/commit/61d70c2565f604a233989eb8c4147e50002745d5)
        - [Add angle, angleref and standoff to marker and add backoff to line](https://github.com/plotly/Plotly.NET/commit/7b8ff1a1983dabff4a631e3de5b25055e14ecdff)
    - v2.14:
        - [Add editSelection option to config](https://github.com/plotly/Plotly.NET/commit/5744e15b14e90007c94c648e2302905fb6dbff19)
        - [Add support for sankey links with arrows](https://github.com/plotly/Plotly.NET/commit/99d635a06e2eb9aaebacfc0703f2449c309e4a63)
    - v2.13:
        - [Add flaglist options including "left", "right", "top", "bottom", "width" and "height" to control the direction of automargin on cartesian axes](https://github.com/plotly/Plotly.NET/commit/5c7cadd4054e09abca58f36389f6bc12cb99f118)
        - [Add selections, newselection and activeselection layout attributes to have persistent and editable selections over cartesian subplots](https://github.com/plotly/Plotly.NET/commit/1042e9ab430e92a0995e52b576cf2bcc7ed6532a)
    - v2.12:
        - [Implement various options to position and style minor ticks and grid lines on cartesian axis types](https://github.com/plotly/Plotly.NET/commit/7ed80ebba4a8d14e387f471f6d489afbf15b6916)
        - [add griddash axis property to cartesian, polar, smith, ternary and geo subplots and add griddash and minorgriddash to carpet trace](https://github.com/plotly/Plotly.NET/commit/6711ecfffd172ce7bbf7ee43b50d1a57f3c19013)
    - v2.10: 
        - [Add support to use version 3 of MathJax and add typesetMath attribute to config](https://github.com/plotly/Plotly.NET/commit/d18345786d69c5b1864948991042a9b06f0121fc)
        - [Add fill pattern to scatter and derived traces / chart APIs](https://github.com/plotly/Plotly.NET/commit/99fcf65fa0515f1a5c65cace2015545ba2980da3)
    - v2.9: 
        - [add ticklabelstep attribute to axes and colorbars](https://github.com/plotly/Plotly.NET/commit/5101dc57a5f43732e642536aedba1289e76d419a)
    - v2.8: 
        - [add horizontal color bar options](https://github.com/plotly/Plotly.NET/commit/f51c61134e1f195edee91a5fcc922d43eb3360e5)

### 3.0.1 - August 26 2022
Minor fixes for Object abstractions:

- Use correct Optional Parameter Attributes everywhere. This affects object abstractions for the following objects, but should be backwards compatible:
    - Annotation
    - LayoutImage
    - Pattern
    - TableCells
- `FontSelectionStyle.init` now correctly returns a FontSelectionStyle instead of unit

### 3.0.0 - June 15 2022

This release adopts strong assembly naming. 
This might cause backwards incompatibility and therefore results in an early major version increase. 
For more insights why we do this, check out the conversation on this [issue](https://github.com/plotly/Plotly.NET/issues/175)

Other additions:

- [fix legend xanchor plotly attribute name](https://github.com/plotly/Plotly.NET/commit/0d612f9c847609c8f676ade0acfada11f137d833) ([#289](https://github.com/plotly/Plotly.NET/issues/289))