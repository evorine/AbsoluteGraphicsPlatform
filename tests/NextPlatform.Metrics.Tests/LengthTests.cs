using System;
using Xunit;

namespace NextPlatform.Metrics.Tests
{
    public class LengthTests
    {
        [Fact]
        public void MustParseStringValue_12() => Assert.Equal(new Length2(12), new Length2("12"));

        [Fact]
        public void MustParseStringValue_12u() => Assert.Equal(new Length2(12), new Length2("12u"));

        [Fact]
        public void MustParseStringValue_12px() => Assert.Equal(new Length2(12, UnitType.Pixel), new Length2("12px"));

        [Fact]
        public void MustParseStringValue_12percentage() => Assert.Equal(new Length2(12, UnitType.Percentage), new Length2("12%"));

        [Fact]
        public void MustParseStringValue_12ratio() => Assert.Equal(new Length2(12, UnitType.Ratio), new Length2("x12"));
    }
}
