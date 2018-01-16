// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.Tests.Common;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class SetterTests
    {
        [Fact]
        public void BasicSetterTest()
        {
            var options = OptionsMocks.CreateDSSOptions();
            options.Styles.Add(OptionsMocks.GetStyle("SingleRule.dss"));
            var wrappedOptions = OptionsMocks.WrapOptions(options);
            var applicationOptions = OptionsMocks.CreateApplicationOptions();

            var propertySetter = new PropertySetter(applicationOptions);
            var styleSetter = new StyleSetter(wrappedOptions, propertySetter);

            var component = ComponentMocks.CreateSimpleVisualElement();
            component.Name = "TestComponent";

            styleSetter.ApplyStyle(component);

            Assert.Equal(new CompositeLength(5, UnitType.Pixel), component.Height);
            Assert.Equal(new CompositeLength((3, UnitType.Pixel), (6, UnitType.Percentage)), component.Width);
        }
    }
}
