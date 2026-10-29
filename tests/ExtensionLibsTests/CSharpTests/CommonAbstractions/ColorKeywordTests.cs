using System;
using Newtonsoft.Json;
using Plotly.NET;
using Xunit;

namespace CSharp.Tests.CommonAbstractions;

public class ColorKeywordTests
{
    // RGB values from https://www.w3.org/TR/2011/REC-SVG11-20110816/types.html#ColorKeywords
    [Theory]
    [InlineData(nameof(ColorKeyword.DarkOliveGreen), 85, 107, 47)]
    [InlineData(nameof(ColorKeyword.HoneyDew), 240, 255, 240)]
    [InlineData(nameof(ColorKeyword.HotPink), 255, 105, 180)]
    [InlineData(nameof(ColorKeyword.LightSalmon), 255, 160, 122)]
    [InlineData(nameof(ColorKeyword.LightSeaGreen), 32, 178, 170)]
    [InlineData(nameof(ColorKeyword.LightSkyBlue), 135, 206, 250)]
    [InlineData(nameof(ColorKeyword.LightSlateGray), 119, 136, 153)]
    [InlineData(nameof(ColorKeyword.LightSlateGrey), 119, 136, 153)]
    [InlineData(nameof(ColorKeyword.SkyBlue), 135, 206, 235)]
    public void CorrectedKeywordNamesProduceExpectedColors(string keywordName, int red, int green, int blue)
    {
        var keyword = keywordName switch
        {
            nameof(ColorKeyword.DarkOliveGreen) => ColorKeyword.DarkOliveGreen,
            nameof(ColorKeyword.HoneyDew) => ColorKeyword.HoneyDew,
            nameof(ColorKeyword.HotPink) => ColorKeyword.HotPink,
            nameof(ColorKeyword.LightSalmon) => ColorKeyword.LightSalmon,
            nameof(ColorKeyword.LightSeaGreen) => ColorKeyword.LightSeaGreen,
            nameof(ColorKeyword.LightSkyBlue) => ColorKeyword.LightSkyBlue,
            nameof(ColorKeyword.LightSlateGray) => ColorKeyword.LightSlateGray,
            nameof(ColorKeyword.LightSlateGrey) => ColorKeyword.LightSlateGrey,
            nameof(ColorKeyword.SkyBlue) => ColorKeyword.SkyBlue,
            _ => throw new ArgumentOutOfRangeException(nameof(keywordName), keywordName, null)
        };

        var argb = ARGB.fromKeyword(keyword);
        Assert.Equal((byte)255, argb.A);
        Assert.Equal((byte)red, argb.R);
        Assert.Equal((byte)green, argb.G);
        Assert.Equal((byte)blue, argb.B);

        var json = JsonConvert.SerializeObject(Color.fromKeyword(keyword));
        Assert.Equal($"\"rgba({red}, {green}, {blue}, 1.0)\"", json);
    }
}
