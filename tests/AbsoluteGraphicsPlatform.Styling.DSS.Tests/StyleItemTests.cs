// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.Tests.Common;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class StyleItemTests
    {
        [Fact]
        public void TestConversion()
        {
            var fileProvider = IO.GetTestFileProvider();
            //var dssParser = new DSSParser();
            using (var stream = fileProvider.GetFileInfo("BasicStyle.dss").CreateReadStream())
            {
                /*var style = dssParser.Parse(stream);

                var element = ComponentMocks.CreateSimpleVisualElement();
                var styleOptions = OptionsMocks.CreateStylingOptions();
                var styleSetter = new RuleSetSetter(Options.Create(styleOptions));
                var ruleSet = (RuleSet)style.RuleSets.First();

                styleSetter.ApplyRuleSet(ruleSet, element);*/
            }
            //Assert.Equal("hey", element.DummyThing);
        }
    }
}
