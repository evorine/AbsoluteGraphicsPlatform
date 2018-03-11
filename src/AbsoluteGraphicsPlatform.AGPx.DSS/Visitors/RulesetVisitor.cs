// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.AGPx.Models;
using AbsoluteGraphicsPlatform.AGPx.Internal;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.Templating;
using AbsoluteGraphicsPlatform.AGPx.Instructions;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class RulesetVisitor : DssParserVisitor<RulesetInstruction>
    {
        readonly RulesetSelectorVisitor rulesetSelectorVisitor;
        readonly StatementVisitor statementVisitor;

        public RulesetVisitor(DssRuntime dssRuntime, StatementVisitor statementVisitor) : base(dssRuntime)
        {
            rulesetSelectorVisitor = new RulesetSelectorVisitor(dssRuntime);
            this.statementVisitor = statementVisitor;
        }

        public override RulesetInstruction VisitRuleset([NotNull] Internal.DssParser.RulesetContext context)
        {
            var block = context.block();
            var selector = context.selector().Accept(rulesetSelectorVisitor);

            var ruleset = new RulesetInstruction();
            ruleset.Selector = selector;

            var statements = block.statement().Select(x => x.Accept(statementVisitor)).ToArray();
            foreach (var statement in statements)
                ruleset.Instructions.Add(statement);

            return ruleset;
        }

        public class RulesetSelectorVisitor : DssParserVisitor<RuleSelector>
        {
            public RulesetSelectorVisitor(DssRuntime dssRuntime) : base(dssRuntime)
            {
            }

            public override RuleSelector VisitSelector([NotNull] Internal.DssParser.SelectorContext context)
            {
                var selectorPart = context.selectorPart();

                if (selectorPart.NAME != null)
                    return new RuleSelector(SelectorType.Name, selectorPart.NAME.GetText());
                else if (selectorPart.CLASS != null)
                    return new RuleSelector(SelectorType.Class, selectorPart.CLASS.GetText());
                else if (selectorPart.COMPONENT != null)
                    return new RuleSelector(SelectorType.Component, selectorPart.COMPONENT.GetText());

                else throw new AGPxException("Unexpected parsing error", context.Start.Line, null);
            }
        }
    }
}
