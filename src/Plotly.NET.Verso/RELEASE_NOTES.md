## 1.0.0 - TBD

- Initial release of Plotly.NET.Verso
- Renders GenericChart objects as interactive Plotly charts in Verso notebooks
- Supports online (CDN) and offline (embedded) rendering modes
- Requires Verso 1.2.3; updates Abstractions and Testing to 1.2.3
- Await Plotly loading, share concurrent loads, and report failures with retry on rerun
- Honor CDN, Full and NoReference display options; report unsupported RequireJS mode
- Format charts across isolated notebook/extension assembly contexts
- Respect formatter MIME requests and cancellation; preserve chart values and descriptions
- Add formatter, Chromium and packaged CLI/web-host tests with isolated local caches
