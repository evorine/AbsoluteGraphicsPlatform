// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.Tests.Common;
using AbsoluteGraphicsPlatform.Metrics;

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

            var setter = new StyleSetter(wrappedOptions);

            var component = ComponentMocks.CreateSimpleVisualElement();
            component.Name = "TestComponent";

            setter.ApplyStyle(component);

            Assert.Equal(new CompositeLength(5, UnitType.Pixel), component.Height);
            Assert.Equal(new CompositeLength((3, UnitType.Pixel), (6, UnitType.Percentage)), component.Width);
        }
    }
}
