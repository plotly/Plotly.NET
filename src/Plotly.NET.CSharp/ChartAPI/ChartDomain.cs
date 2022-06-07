using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;


namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        public static GenericChart.GenericChart Pie<ValuesType, LabelsType, TextType>(
            IEnumerable<ValuesType> values,
            string? Name = null,
            bool? ShowLegend = null,
            double? Opacity = null,
            IEnumerable<double>? MultiOpacity = null,
            IEnumerable<LabelsType>? Labels = null,
            double? Pull = null,
            IEnumerable<double>? MultiPull = null,
            TextType? Text = null,
            IEnumerable<TextType>? MultiText = null,
            StyleParam.TextPosition? TextPosition = null,
            IEnumerable<StyleParam.TextPosition>? MultiTextPosition = null,
            IEnumerable<Color>? SectionColors = null,
            Color? SectionOutlineColor = null,
            double? SectionOutlineWidth = null,
            IEnumerable<double>? SectionOutlineMultiWidth = null,
            Line? SectionOutline = null,
            Marker? Marker = null,
            StyleParam.TextInfo? TextInfo = null,
            StyleParam.Direction? Direction = null,
            double? Hole = null,
            double? Rotation = null,
            bool? Sort = null,
            bool? UseDefaults = null
        )
            where ValuesType : IConvertible
            where LabelsType : IConvertible
            where TextType : class, IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Pie<ValuesType, LabelsType, TextType>(
                    values: values,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOptionV(),
                    Opacity: Opacity.ToOptionV(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Labels: Labels.ToOption(),
                    Pull: Pull.ToOptionV(),
                    MultiPull: MultiPull.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOptionV(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    Direction: Direction.ToOption(),
                    Hole: Hole.ToOptionV(),
                    Rotation: Rotation.ToOptionV(),
                    Sort: Sort.ToOptionV(),
                    UseDefaults: UseDefaults.ToOptionV()
                );

    }
}
