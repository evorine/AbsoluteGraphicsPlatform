// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.AGPx.Models;
using AbsoluteGraphicsPlatform.AGPx.Instructions;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class BasicParserTests
    {
        [Fact]
        public void EmptyCode_ShouldNotCreateAnyInstructions()
        {
            var instructions = Common.ParseCode(" ");

            Assert.Empty(instructions);
        }

        [Fact]
        public void EmtyRuleset_ShouldCreateRulesetWithtoutInstructions()
        {
            var instructions = Common.ParseCode(".rule { }");

            var ruleset = (RulesetInstruction)instructions.Single();
            Assert.Empty(ruleset.Instructions);
        }

        [Fact]
        public void EmtyRuleset_ShouldParseBasicSelector()
        {
            var instructions = Common.ParseCode(".rule { }");

            var ruleset = (RulesetInstruction)instructions.Single();

            // Check selector is realy '.rule'
            Assert.Equal("rule", ruleset.Selector.Identifier);
            Assert.Equal(SelectorType.Class, ruleset.Selector.SelectorType);
            Assert.Null(ruleset.Selector.Parent);
        }

        [Fact]
        public void Setter_ShouldCreatePropertyInstructionWithValueNone()
        {
            var instructions = Common.ParseCode(".rule { property: none; }");
            var expressionExecutor = new ExpressionExecutor();

            var ruleset = (RulesetInstruction)instructions.Single();
            var property = (PropertyInstruction)ruleset.Instructions.Single();

            Assert.Equal("property", property.Identifier);
            Assert.Single(property.Value.Values);
            Assert.Equal(PropertyValue.None, expressionExecutor.GetValues(property.Value.Values));
        }

        [Fact]
        public void MathOperation_ShouldCalculateBasicOperations()
        {
            var instructions = Common.ParseCode(".rule { property: 1 + 7 * (3 + 5); }");
            var expressionExecutor = new ExpressionExecutor();

            var ruleset = (RulesetInstruction)instructions.Single();
            var property = (PropertyInstruction)ruleset.Instructions.Single();

            Assert.Equal(new ScalarPropertyValue(57), expressionExecutor.GetValues(property.Value.Values));
        }
    }
}
