namespace BioFSharp.BioVisD3

module HtmlScaffold =

    /// Generates the HTML document for common scaffold
    let common js =
        sprintf """<!DOCTYPE html>
                    <html>
                        <head>
                            <meta http-equiv="X-UA-Compatible" content="IE=9" >
                            

                            <style>

                            .node circle {
                              fill: #fff;
                              stroke: steelblue;
                              stroke-width: 1.5px;
                            }

                            .node {
                              font: 10px sans-serif;
                            }

                            .link {
                              fill: none;
                              stroke: #ccc;
                              stroke-width: 1.5px;
                            }

                            </style>

                            
                            <title>FsJVis</title>                                                  
                            <script src="http://code.jquery.com/jquery-1.8.0.js"></script>
                            <script type="text/javascript" src="http://d3js.org/d3.v3.min.js"></script>
                        </head>
                        <body>

                            <div id="container">          
                            </div>

                            <script>
                    %s
                            </script>
                        </body>
                    </html>"""          js


    