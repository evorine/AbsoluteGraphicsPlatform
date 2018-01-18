// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.Tests.Common;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.DynamicProperties;
using AbsoluteGraphicsPlatform.Tests.Common.Components;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class SetterTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1.5)]
        [InlineData(5)]
        [InlineData(-5)]
        public void PropertySetter_SetScalar(float value)
        {
            var applicationOptions = OptionsMocks.CreateApplicationOptions();
            var propertySetter = new PropertySetter(applicationOptions);
            var component = ComponentMocks.CreateComponent<BasicComponent>();
            component.Name = "TestComponent";

            var propertyValue = new ScalarPropertyValue(value);
            propertySetter.SetValue(component, nameof(BasicComponent.Length), propertyValue);

            Assert.Equal(value, component.Single);
        }

        [Theory]
        [InlineData("px", 1)]
        [InlineData("px", 5.2)]
        [InlineData("%", 1)]
        [InlineData("x", 1)]
        [InlineData("u", 1)]
        public void PropertySetter_SetLength(string unit, float length)
        {
            var applicationOptions = OptionsMocks.CreateApplicationOptions();
            var propertySetter = new PropertySetter(applicationOptions);
            var component = ComponentMocks.CreateComponent<BasicComponent>();
            component.Name = "TestComponent";

            var propertyValue = new LengthPropertyValue(unit, length);
            propertySetter.SetValue(component, nameof(BasicComponent.Length), propertyValue);

            Assert.Equal(unit == "%", component.Length.HasUnitOf(UnitType.Percentage));
            Assert.Equal(unit == "px", component.Length.HasUnitOf(UnitType.Pixel));
            Assert.Equal(unit == "x", component.Length.HasUnitOf(UnitType.Ratio));
            Assert.Equal(unit == "u", component.Length.HasUnitOf(UnitType.Unit));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0.5)]
        public void PropertySetter_SetTimeSpan(float seconds)
        {
            var applicationOptions = OptionsMocks.CreateApplicationOptions();
            var propertySetter = new PropertySetter(applicationOptions);
            var component = ComponentMocks.CreateComponent<BasicComponent>();
            component.Name = "TestComponent";

            var propertyValue = new TimeSpanPropertyValue(seconds);
            propertySetter.SetValue(component, nameof(BasicComponent.TimeSpan), propertyValue);

            Assert.Equal(TimeSpan.FromSeconds(seconds), component.TimeSpan);
        }

        private static UnitType toUnitType(string unit)
        {
            switch(unit)
            {
                case "%": return UnitType.Percentage;
                case "px": return UnitType.Pixel;
                case "x": return UnitType.Ratio;
                case "u": return UnitType.Unit;
                default: throw new ArgumentException("Invalid unit!");
            }
        }
    }
}
