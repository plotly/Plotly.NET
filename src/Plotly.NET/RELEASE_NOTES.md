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