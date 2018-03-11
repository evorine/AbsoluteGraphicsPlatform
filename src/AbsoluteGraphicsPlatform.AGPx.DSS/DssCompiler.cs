// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.AGPx.Instructions;
using AbsoluteGraphicsPlatform.AGPx.Models;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class DssCompiler
    {
        readonly ExpressionExecutor expressionExecutor;

        public DssCompiler(ExpressionExecutor expressionExecutor)
        {
            this.expressionExecutor = expressionExecutor;
        }

        public Stylesheet Compile(DssInstructions dssInstructions)
        {
            var context = new DssCompilerContext()
            {
                Instructions = dssInstructions,
                Stylesheet = new Stylesheet(),
            };

            foreach(var instruction in dssInstructions)
            {
                if (instruction is RulesetInstruction rulesetInstruction) ProcessRulesetInstruction(context, rulesetInstruction);
            }

            return context.Stylesheet;
        }
        

        private void ProcessRulesetInstruction(DssCompilerContext context, RulesetInstruction rulesetInstruction)
        {
            var ruleset = new Ruleset()
            {
                Selector = new RuleSelector(rulesetInstruction.Selector.SelectorType, rulesetInstruction.Selector.Identifier)
            };
            foreach(var instruction in rulesetInstruction.Instructions)
            {
                if (instruction is PropertyInstruction propertyInstruction) ProcessPropertyInstruction(context, ruleset, propertyInstruction);
            }
            context.Stylesheet.AddRuleset(ruleset);
        }

        private void ProcessPropertyInstruction(DssCompilerContext context, Ruleset ruleset, PropertyInstruction propertyInstruction)
        {
            var propertySetterInfo = new PropertySetterInfo(propertyInstruction.Identifier, expressionExecutor.GetValues(propertyInstruction.Value.Values), 0, null);
            ruleset.PropertySetters.Add(propertySetterInfo);
        }

        public class DssCompilerContext
        {
            public DssInstructions Instructions { get; set; }
            public Stylesheet Stylesheet { get; set; }
        }
    }
}
