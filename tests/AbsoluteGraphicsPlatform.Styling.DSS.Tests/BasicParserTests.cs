// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.DSS.Models;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class BasicParserTests
    {
        [Fact]
        public void EmptyCode_ShouldNotCreateAnyRulesets()
        {
            var style = Common.ParseCode(" ");

            Assert.Empty(style.Rulesets);
        }

        [Fact]
        public void EmtyRuleset_ShouldCreateRulesetWithtoutSetter()
        {
            var style = Common.ParseCode(".rule { }");

            var ruleset = style.Rulesets.Single();
            Assert.Empty(style.Rulesets.First().PropertySetters);
        }

        [Fact]
        public void EmtyRuleset_ShouldParseBasicSelector()
        {
            var style = Common.ParseCode(".rule { }");

            var ruleset = style.Rulesets.First();

            // Check selector is realy '.rule'
            Assert.Equal("rule", ruleset.Selector.Identifier);
            Assert.Equal(SelectorType.Class, ruleset.Selector.SelectorType);
            Assert.Null(ruleset.Selector.Parent);
        }

        [Fact]
        public void Setter_ShouldCreateBasicSetterWithValueNone()
        {
            var style = Common.ParseCode(".rule { property: none; }");
            var expressionExecutor = new ExpressionExecutor();

            var ruleset = style.Rulesets.Single();
            var setter = ruleset.PropertySetters.Single();

            Assert.Equal("property", setter.PropertyName);
            Assert.Single(setter.Values);
            Assert.Equal(PropertyValue.None, expressionExecutor.GetValues(setter.Values).Single());
        }

        [Fact]
        public void MathOperation_ShouldCalculateBasicOperations()
        {
            var style = Common.ParseCode(".rule { property: 1 + 7 * (3 + 5); }");
            var expressionExecutor = new ExpressionExecutor();

            var ruleset = style.Rulesets.Single();
            var setter = ruleset.PropertySetters.Single();

            Assert.Equal(new ScalarPropertyValue(57), expressionExecutor.GetValues(setter.Values).Single());
        }
    }
}
