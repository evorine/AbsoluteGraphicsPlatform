// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.AGPx.Internal;
using AbsoluteGraphicsPlatform.AGPx.Models;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class AsignmentVisitor : DssParserBaseVisitor<AsignmentStatement>
    {
        public override AsignmentStatement VisitAsignmentStatement([NotNull] Internal.DssParser.AsignmentStatementContext context)
        {
            var variableName = context.variable().IDENTIFIER().GetText();

            var expressionVisitor = new ExpressionVisitor();
            var expressions = context.propertyValue().expression().Select(x => x.Accept(expressionVisitor));

            var asignment = new AsignmentStatement(variableName, expressions.ToArray());
            return asignment;
        }
    }
}
