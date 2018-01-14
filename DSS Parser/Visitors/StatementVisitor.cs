using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class StatementVisitor : DSSParserBaseVisitor<Statement>
    {
        public override Statement VisitStatement([NotNull] DSSParser.StatementContext context)
        {
            var rulesetVisitor = new RulesetVisitor();
            var ruleset = context.Accept(rulesetVisitor);
            if (ruleset != null) return ruleset;

            var propertySetterVisitor = new PropertySetterVisitor();
            var propertySetter = context.Accept(propertySetterVisitor);
            if (propertySetter != null) return propertySetter;

            throw new Exception("Unexpected exception!");
        }
    }
}
