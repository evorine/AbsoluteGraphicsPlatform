// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.AGPx.Internal;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class StatementVisitor : DSSParserBaseVisitor<IStatement>
    {
        public override IStatement VisitStatement([NotNull] Internal.DSSParser.StatementContext context)
        {
            var rulesetVisitor = new RulesetVisitor();
            var ruleset = context.Accept(rulesetVisitor);
            if (ruleset != null) return ruleset;

            var propertySetterVisitor = new PropertySetterVisitor();
            var propertySetter = context.Accept(propertySetterVisitor);
            if (propertySetter != null) return propertySetter;

            var asignmentVisitor = new AsignmentVisitor();
            var asignment = context.Accept(asignmentVisitor);
            if (asignment != null) return asignment;

            throw new Exception("Unexpected exception!");
        }
    }
}
