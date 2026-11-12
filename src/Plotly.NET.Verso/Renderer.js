(function (payload) {
    "use strict";
    var element = document.getElementById(payload.id);
    if (!element) return;
    var registry = window.__plotlyNetVerso || (window.__plotlyNetVerso = { loads: Object.create(null) });
    function available() {
        return window.Plotly && typeof window.Plotly.newPlot === "function";
    }
    function connected() {
        return element.isConnected && document.getElementById(payload.id) === element;
    }
    function fail(error) {
        if (!connected()) return;
        element.setAttribute("data-plotly-state", "error");
        var message = document.createElement("div");
        message.setAttribute("role", "alert");
        message.textContent = "Plotly.NET: " + (error && error.message ? error.message : String(error));
        element.appendChild(message);
    }
    function load() {
        if (payload.mode === "require") {
            return Promise.reject(new Error("RequireJS references are not supported in Verso. Use PlotlyJSReference.CDN or Full."));
        }
        if (available()) return Promise.resolve(window.Plotly);
        if (payload.mode === "none") {
            var pending = Object.keys(registry.loads).map(function (key) { return registry.loads[key]; })
                .find(function (entry) { return entry.pending; });
            return pending ? pending.promise : Promise.reject(new Error("No Plotly library is loaded. Preload Plotly or use PlotlyJSReference.CDN or Full."));
        }
        if (payload.mode === "full") return Promise.reject(new Error("The embedded Plotly library did not initialize."));
        var existing = registry.loads[payload.url];
        if (existing) return existing.promise;
        var entry = { pending: true };
        registry.loads[payload.url] = entry;
        entry.promise = new Promise(function (resolve, reject) {
            var script = document.createElement("script");
            script.charset = "utf-8";
            script.async = true;
            var timer;
            function finish(error) {
                clearTimeout(timer);
                script.onload = script.onerror = null;
                entry.pending = false;
                if (error) {
                    delete registry.loads[payload.url];
                    script.remove();
                    reject(error);
                } else resolve(window.Plotly);
            }
            script.onload = function () {
                finish(available() ? null : new Error("The Plotly script loaded without initializing Plotly: " + payload.url));
            };
            script.onerror = function () {
                finish(new Error("Unable to load Plotly from " + payload.url + ". Check the connection or use PlotlyJSReference.Full for offline rendering."));
            };
            timer = setTimeout(function () { finish(new Error("Timed out loading Plotly from " + payload.url)); }, 30000);
            script.src = payload.url;
            document.head.appendChild(script);
        });
        return entry.promise;
    }
    load().then(function (plotly) {
        if (!connected()) return;
        return Promise.resolve(plotly.newPlot(element, payload.chart.data, payload.chart.layout, payload.chart.config))
            .then(function () {
                if (connected()) element.setAttribute("data-plotly-state", "ready");
            });
    }).catch(fail);
})(/*PAYLOAD*/);
