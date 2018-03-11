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

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class RulesetVisitor : DssParserVisitor<Ruleset>
    {
        readonly RulesetSelectorVisitor rulesetSelectorVisitor;
        readonly RulesetBlockVisitor rulesetBlockVisitor;

        public RulesetVisitor(DssRuntime dssRuntime) : base(dssRuntime)
        {
            rulesetSelectorVisitor = new RulesetSelectorVisitor(dssRuntime);
            rulesetBlockVisitor = new RulesetBlockVisitor(dssRuntime);
        }

        public override Ruleset VisitRuleset([NotNull] Internal.DssParser.RulesetContext context)
        {
            var selector = context.selector().Accept(rulesetSelectorVisitor);
            var ruleset = context.block().Accept(rulesetBlockVisitor);
            ruleset.Selector = selector;

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

        public class RulesetBlockVisitor : DssParserVisitor<Ruleset>
        {
            readonly StatementVisitor statementVisitor;

            public RulesetBlockVisitor(DssRuntime dssRuntime) : base(dssRuntime)
            {
                statementVisitor = new StatementVisitor(dssRuntime);
            }

            public override Ruleset VisitBlock([NotNull] Internal.DssParser.BlockContext context)
            {
                var statements = context.statement().Select(x => x.Accept(statementVisitor)).ToArray();

                var ruleset = new Ruleset();
                foreach (var statement in statements)
                    if (statement is PropertySetterInfo propertySetter)
                        ruleset.PropertySetters.Add(propertySetter);
                    
                return ruleset;
            }
        }
    }
}
