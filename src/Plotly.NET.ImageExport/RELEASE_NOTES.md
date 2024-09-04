### 6.1.0 - September 04 2024

Remove explicit DynamicObj dependency (use transitive dependency from Plotly.NET)

### 6.0.0 - May 27 2024

- BREAKING: [Add Scale option to all image export extensions](https://github.com/plotly/Plotly.NET/commit/5090570cb0fd8281a4c197421994cec719b82ac9)
- BREAKING:  Update PuppeteerSharp dependency to 12.0.0
- bump version range of Plotly.NET to [5.0.0, 6.0.0)

### 5.0.1 - July 25 2023

- bump version range of Plotly.NET to [4.1.0, 5.0.0)

### 5.0.0 - July 14 2023

- BREAKING: [Fix async function incorrectly not having the 'Async' suffix in compiled name](https://github.com/plotly/Plotly.NET/commit/43b1fcea330460c2ee19ad20f4fca99edfb4beb6), thanks [hdavid333](https://github.com/hdavid333)
- Update PuppeteerSharp dependency to 10.1.0

### 4.0.0 - March 21 2023

- Update package to work with Plotly.NET 4.0
- fix [#377](https://github.com/plotly/Plotly.NET/issues/377) 
- use strict dependency range to prevent major version increases from Plotly.NET from breaking dependent packages.

### 3.0.1 - July 04 2022

(unlisted)

Accidental push without code base change, whoops!

### 3.0.0 - June 15 2020

This release adopts strong assembly naming. 
This might cause backwards incompatibility and therefore results in an early major version increase. 
For more insights why we do this, check out the conversation on this [issue](https://github.com/plotly/Plotly.NET/issues/175)
