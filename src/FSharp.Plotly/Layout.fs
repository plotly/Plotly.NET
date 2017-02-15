namespace FSharp.Plotly

/// Layout 
type Layout() = inherit DynamicObj ()

[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Layout =
    

    /// Legend 
    type Legend() = inherit DynamicObj ()

    /// Margin 
    type Margin() = inherit DynamicObj ()

    /// Margin 
    type Annotation() = inherit DynamicObj ()

    /// Init Layout type
    let init (applyStyle:Layout->Layout) = 
        Layout() |> applyStyle

    /// Init Legend type
    let initLegend (applyStyle:Legend->Legend) = 
        Legend() |> applyStyle

    /// Init Margin type
    let initMargin (applyStyle:Margin->Margin) = 
        Margin() |> applyStyle

    /// Init Annotation type
    let initAnnotation (applyStyle:Annotation->Annotation) = 
        Annotation() |> applyStyle


    /// 
    type LayoutStyle =

        // Applies the styles to Layout()
        static member Apply
            (   
                ?Title,
                ?Titlefont:Font,
                ?Font:Font,
                ?Showlegend:bool,
                ?Autosize:bool,
                ?Width,
                ?Height,
                ?xAxis:Axis.LinearAxis,?xAxis2:Axis.LinearAxis,
                ?yAxis:Axis.LinearAxis,?yAxis2:Axis.LinearAxis,
                ?Legend:Legend,
                // TODO: annotations
                ?Annotations,
                ?Margin:Margin,
                
                ?Paper_bgcolor,
                ?Plot_bgcolor,
                ?Hovermode:StyleParam.Hovermode,
                ?Dragmode:StyleParam.Dragmode,
                
                ?Separators,
                ?Barmode:StyleParam.Barmode,
                ?Bargap, // Some bar.. /box... is missing
                // bargroupgap
                //
                ?Radialaxis:Axis.RadialAxis,
                ?Angularaxis:Axis.AngularAxis,
                ?Scene:Scene3d.Scene,
                ?Direction:StyleParam.Direction,
                ?Orientation,
                ?Shapes:Shape seq,
                
                ?Hidesources,?Smith,?Geo

            ) =
                (fun (layout:Layout) -> 
                    Title           |> DynObj.setValueOpt layout "title"
                    Autosize        |> DynObj.setValueOpt layout "autosize"
                    Width           |> DynObj.setValueOpt layout "width"
                    Height          |> DynObj.setValueOpt layout "height"
                
                    Paper_bgcolor   |> DynObj.setValueOpt layout "paper_bgcolor"
                    Plot_bgcolor    |> DynObj.setValueOpt layout "plot_bgcolor"
                    Separators      |> DynObj.setValueOpt layout "separators"
                    Hidesources     |> DynObj.setValueOpt layout "hidesources"
                    Smith           |> DynObj.setValueOpt layout "smith"
                    Showlegend      |> DynObj.setValueOpt layout "showlegend"
                    Hovermode       |> DynObj.setValueOptBy layout "hovermode" StyleParam.Hovermode.toString
                    Dragmode        |> DynObj.setValueOptBy layout "dragmode" StyleParam.Dragmode.toString
                
                    Geo             |> DynObj.setValueOpt layout "geo"
                
                    Annotations     |> DynObj.setValueOpt layout "annotations"
                

                    Direction       |> DynObj.setValueOptBy layout "direction" StyleParam.Direction.toString
                    Orientation     |> DynObj.setValueOpt layout "orientation"
                    Barmode         |> DynObj.setValueOptBy layout "barmode" StyleParam.Barmode.toString
                    Bargap          |> DynObj.setValueOpt layout "bargap"
                    Shapes          |> DynObj.setValueOpt layout "shapes"

                    // Update
                    Font        |> DynObj.setValueOpt layout "font"
                    Titlefont   |> DynObj.setValueOpt layout "titlefont"
                    Margin      |> DynObj.setValueOpt layout "margin"
                    xAxis       |> DynObj.setValueOpt layout "xaxis"
                    xAxis2      |> DynObj.setValueOpt layout "xaxis2"
                    yAxis       |> DynObj.setValueOpt layout "yaxis"
                    yAxis2      |> DynObj.setValueOpt layout "yaxis2"
                    Legend      |> DynObj.setValueOpt layout "legend"
                    Radialaxis  |> DynObj.setValueOpt layout "radialaxis"
                    Angularaxis |> DynObj.setValueOpt layout "angularaxis"
                    Scene       |> DynObj.setValueOpt layout "scene"
                    //Shapes      |> Option.iter (updatePropertyValueAndIgnore layout <@ layout.shapes @>)

                    layout
                )


        // Applies the styles to Margin()
        static member Margin
            (
                ?Left,
                ?Right,
                ?Top,
                ?Bottom,
                ?Pad,
                ?Autoexpand
            ) =
                (fun (margin:Margin) -> 
                    Left   |> DynObj.setValueOpt margin "l"
                    Right  |> DynObj.setValueOpt margin "r"
                    Top    |> DynObj.setValueOpt margin "t"
                    Bottom |> DynObj.setValueOpt margin "b"

                    Pad        |> DynObj.setValueOpt margin "pad"
                    Autoexpand |> DynObj.setValueOpt margin "autoexpand"

                    margin
                )

