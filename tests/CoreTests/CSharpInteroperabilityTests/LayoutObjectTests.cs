using System;
using Xunit;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Microsoft.FSharp.Core;

namespace Plotly.NET.Tests.CSharp
{
    public class LayoutObjectTests
    {
        [Fact]
        public void OptionalArgumentsAndDynamicSettingAreEqual()
        {
            var actual = LinearAxis.init<IConvertible, IConvertible, IConvertible, IConvertible, IConvertible, IConvertible, IConvertible, IConvertible>(Color: Color.fromString("red"), AxisType: StyleParam.AxisType.Linear);

            var expected = new LinearAxis();
            expected.SetValue("color", Color.fromString("red"));
            expected.SetValue("type", StyleParam.AxisType.Linear.Convert());

            Assert.Equal(expected.GetProperties(true), actual.GetProperties(true));
        }
    }
}
