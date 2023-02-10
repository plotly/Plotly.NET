### 4.0.0 - TBD

- [Use Giraffe.ViewEngine as html dsl](https://github.com/plotly/Plotly.NET/pull/363)

- Keep up with plotlyjs 2.x incremental updates:
    - v2.17:
        - [Add shift and autoshift to cartesian y axes to help avoid overlapping of multiple axes](https://github.com/plotly/Plotly.NET/commit/9f7edb8281ba87a2c122d99604af32d17efec168)
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