// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.DSS.Models;
using AbsoluteGraphicsPlatform.DynamicProperties;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class BasicParserTests
    {
        private static Stylesheet parseCode(string code)
        {
            var dssParser = new StyleParser();
            var sourceInfo = new SourceCodeInfo("TestCode", code);
            return dssParser.Parse(sourceInfo);
        }

        [Fact]
        public void EmptyCode_ShouldNotCreateAnyRulesets()
        {
            var style = parseCode(" ");

            Assert.Empty(style.Rulesets);
        }

        [Fact]
        public void EmtyRuleset_ShouldCreateRulesetWithtoutSetter()
        {
            var style = parseCode(".rule { }");

            Assert.Single(style.Rulesets);
            var ruleset = style.Rulesets.First();

            Assert.Empty(style.Rulesets.First().PropertySetters);
        }


        [Fact]
        public void EmtyRuleset_ShouldParseBasicSelector()
        {
            var style = parseCode(".rule { }");

            var ruleset = style.Rulesets.First();

            // Check selector is realy '.rule'
            Assert.Equal("rule", ruleset.Selector.Identifier);
            Assert.Equal(SelectorType.Class, ruleset.Selector.SelectorType);
            Assert.Null(ruleset.Selector.Parent);
        }

        [Fact]
        public void EmtyRuleset_ShouldCreateSetterWithValueNone()
        {
            var style = parseCode(".rule { property: none; }");

            Assert.Single(style.Rulesets);
            var ruleset = style.Rulesets.First();

            Assert.Single(style.Rulesets.First().PropertySetters);
            var setter = style.Rulesets.First().PropertySetters.First();

            Assert.Equal("property", setter.Property);
            Assert.Single(setter.Values);
            Assert.Equal(PropertyValue.None, ((ConstantExpression)setter.Values.First()).Value);
        }
    }
}
