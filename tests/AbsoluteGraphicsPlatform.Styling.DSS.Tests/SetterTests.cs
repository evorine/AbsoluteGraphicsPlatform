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
            var options = Common.MoqOptions(Common.GetStyle("TestStyle1.dss"));
            var setter = new StyleSetter(options);

            var component = ComponentMocks.CreateSimpleVisualElement();
            component.Name = "DemoComp";

            setter.ApplyStyle(component);
        }
    }
}
