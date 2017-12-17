// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NextPlatform.Styling.Parser;
using NextPlatform.Tests.Common;
using System.Linq;
using Microsoft.Extensions.Options;

namespace NextPlatform.Styling.DSS.Tests
{
    public class StyleItemTests
    {
        [Fact]
        public void TestConversion()
        {
            var fileProvider = IO.GetTestFileProvider();
            var dssParser = new DSSParser();
            using (var stream = fileProvider.GetFileInfo("BasicStyle.dss").CreateReadStream())
            {
                var document = dssParser.Parse(stream);

                var element = ComponentMocks.CreateSimpleVisualElement();
                var styleOptions = OptionsMocks.CreateStylingOptions();
                var styleSetter = new StyleSetter(Options.Create(styleOptions));
                var styleBlock = (StyleBlock)document.Blocks.First();

                styleSetter.ApplyStyle(styleBlock, element);
            }
            //Assert.Equal("hey", element.DummyThing);
        }
    }
}
