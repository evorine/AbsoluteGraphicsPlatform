// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq;
using AbsoluteGraphicsPlatform.DSS.Internal;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class StatementVisitor : DSSParserBaseVisitor<Statement>
    {
        public override Statement VisitStatement([NotNull] Internal.DSSParser.StatementContext context)
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
