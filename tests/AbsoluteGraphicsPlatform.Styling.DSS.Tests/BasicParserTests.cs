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
        private static Stylesheet ParseCode(string code)
        {
            var dssParser = new StyleParser();
            var sourceInfo = new SourceCodeInfo("TestCode", code);
            return dssParser.Parse(sourceInfo);
        }
        

        [Fact]
        public void EmptyCode_ShouldNotCreateAnyRulesets()
        {
            var style = ParseCode(" ");

            Assert.Empty(style.Rulesets);
        }

        [Fact]
        public void EmtyRuleset_ShouldCreateRulesetWithtoutSetter()
        {
            var style = ParseCode(".rule { }");

            var ruleset = style.Rulesets.Single();
            Assert.Empty(style.Rulesets.First().PropertySetters);
        }

        [Fact]
        public void EmtyRuleset_ShouldParseBasicSelector()
        {
            var style = ParseCode(".rule { }");

            var ruleset = style.Rulesets.First();

            // Check selector is realy '.rule'
            Assert.Equal("rule", ruleset.Selector.Identifier);
            Assert.Equal(SelectorType.Class, ruleset.Selector.SelectorType);
            Assert.Null(ruleset.Selector.Parent);
        }

        [Fact]
        public void EmtyRuleset_ShouldCreateBasicSetterWithValueNone()
        {
            var style = ParseCode(".rule { property: none; }");
            var expressionExecutor = new ExpressionExecutor();

            var ruleset = style.Rulesets.Single();
            var setter = ruleset.PropertySetters.Single();

            Assert.Equal("property", setter.Property);
            Assert.Single(setter.Values);
            Assert.Equal(PropertyValue.None, expressionExecutor.GetValues(setter.Values).Single());
        }
    }
}
