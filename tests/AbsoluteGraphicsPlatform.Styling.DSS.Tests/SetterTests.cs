// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.Tests.Common;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class SetterTests
    {
        [Fact]
        public void BasicSetterTest()
        {
            var options = OptionsMocks.CreateDSSOptions();
            options.Styles.Add(OptionsMocks.GetStyle("TestStyle1.dss"));
            var wrappedOptions = OptionsMocks.WrapOptions(options);

            var setter = new StyleSetter(wrappedOptions);

            var component = ComponentMocks.CreateSimpleVisualElement();
            component.Name = "DemoComp";

            setter.ApplyStyle(component);
        }
    }
}
