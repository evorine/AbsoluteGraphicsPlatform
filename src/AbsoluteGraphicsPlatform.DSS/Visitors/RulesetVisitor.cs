// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class RulesetVisitor : DSSParserBaseVisitor<Ruleset>
    {
        public override Ruleset VisitRuleset([NotNull] DSSParser.RulesetContext context)
        {
            var selector = context.selector().Accept(new RulesetSelectorVisitor());
            var ruleset = context.block().Accept(new RulesetBlockVisitor());
            ruleset.Selector = selector;

            return ruleset;
        }

        public class RulesetSelectorVisitor : DSSParserBaseVisitor<RuleSelector>
        {
            public override RuleSelector VisitSelector([NotNull] DSSParser.SelectorContext context)
            {
                var selectorPart = context.selectorPart();

                if (selectorPart.NAME != null)
                    return new RuleSelector(SelectorType.Name, selectorPart.NAME.GetText());
                else if (selectorPart.CLASS != null)
                    return new RuleSelector(SelectorType.Class, selectorPart.CLASS.GetText());
                else if (selectorPart.COMPONENT != null)
                    return new RuleSelector(SelectorType.Component, selectorPart.COMPONENT.GetText());

                else throw new DSSParserException("Unexpected parsing error", context.Start.Line, null);
            }
        }

        public class RulesetBlockVisitor : DSSParserBaseVisitor<Ruleset>
        {
            public override Ruleset VisitBlock([NotNull] DSSParser.BlockContext context)
            {
                var statementVisitor = new StatementVisitor();
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
