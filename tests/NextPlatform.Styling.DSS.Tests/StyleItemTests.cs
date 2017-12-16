// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NextPlatform.Styling.Parser;
using NextPlatform.Tests.Common;

namespace NextPlatform.Styling.DSS.Tests
{
    public class StyleItemTests
    {
        [Fact]
        public void TestConversion()
        {
            var element = ComponentMocks.CreateSimpleVisualElement();
            var widthStyleItem = new StylePropertySetter("Width", "hey");

            widthStyleItem.Apply(element);
            //Assert.Equal("hey", element.DummyThing);
        }
    }
}
