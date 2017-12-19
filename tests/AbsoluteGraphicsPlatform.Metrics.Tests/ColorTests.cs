// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;

namespace AbsoluteGraphicsPlatform.Metrics.Tests
{
    public class ColorTests
    {
        [Theory]
        [InlineData("4cAF50")]
        [InlineData("4CAF50aF")]
        [InlineData("#4cAF50")]
        [InlineData("#4CAF50aF")]
        public void MustParseHexColorWithoutError(string hex)
        {
            new Color(hex);
        }

        [Theory]
        [InlineData("")]
        [InlineData("4cF5")]
        [InlineData("#4cF5")]
        [InlineData("#4cAF500")]
        [InlineData("#ZZ0000")]
        [InlineData("# A0000")]
        [InlineData("#000000ZZ")]
        public void ThrowErrorForInvalidHexColor(string hex)
        {
            Assert.Throws<ArgumentException>(() => { new Color(hex); });
        }

        [Fact]
        public void MustParseHexStringAppropriately()
        {
            var color1 = new Color("#4cAF50");
            Assert.Equal(76, color1.Red);
            Assert.Equal(175, color1.Green);
            Assert.Equal(80, color1.Blue);
            Assert.Equal(255, color1.Alpha);
        }

        [Fact]
        public void MustParseHexStringWithAlphaAppropriately()
        { 
            var color2 = new Color("#4CAF50aF");
            Assert.Equal(76, color2.Red);
            Assert.Equal(175, color2.Green);
            Assert.Equal(80, color2.Blue);
            Assert.Equal(175, color2.Alpha);
        }
    }
}
