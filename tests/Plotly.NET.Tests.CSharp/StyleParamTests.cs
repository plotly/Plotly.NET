using System;
using Xunit;
using Plotly.NET;

namespace Plotly.NET.Tests.CSharp
{
    public class StyleParamTests
    {
        [Fact]
        public void CanUseToString()
        {
            var actual = StyleParam.Fill.ToSelf.ToString();
            Assert.Equal("toself", actual);
        }        
        [Fact]
        public void CanUseConvert()
        {
            var actual = StyleParam.Fill.ToNext.Convert();
            object expected = "tonext";
            Assert.Equal(expected, actual);
        }
    }
}
