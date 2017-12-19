// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;

namespace AbsoluteGraphicsPlatform.Metrics.Tests
{
    public class LengthTests
    {
        [Fact]
        public void MustParseStringValue_12u() => Assert.Equal(new CompositeLength(12, UnitType.Unit), CompositeLength.Parse("12u"));

        [Fact]
        public void MustParseStringValue_12px() => Assert.Equal(new CompositeLength(12, UnitType.Pixel), CompositeLength.Parse("12px"));

        [Fact]
        public void MustParseStringValue_12percentage() => Assert.Equal(new CompositeLength(12, UnitType.Percentage), CompositeLength.Parse("12%"));

        [Fact]
        public void MustParseStringValue_12ratio() => Assert.Equal(new CompositeLength(12, UnitType.Ratio), CompositeLength.Parse("x12"));
    }
}
