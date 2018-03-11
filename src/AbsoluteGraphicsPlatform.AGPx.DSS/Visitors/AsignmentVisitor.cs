// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.AGPx.Internal;
using AbsoluteGraphicsPlatform.AGPx.Models;
using AbsoluteGraphicsPlatform.AGPx.Instructions;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class AsignmentVisitor : DssParserVisitor<AsignmentInstruction>
    {
        readonly ExpressionVisitor expressionVisitor;

        public AsignmentVisitor(DssRuntime dssRuntime) : base(dssRuntime)
        {
            expressionVisitor = new ExpressionVisitor(dssRuntime);
        }

        public override AsignmentInstruction VisitAsignmentStatement([NotNull] Internal.DssParser.AsignmentStatementContext context)
        {
            var variableName = context.variable().IDENTIFIER().GetText();
            var expressions = context.propertyValue().expression().Select(x => x.Accept(expressionVisitor));

            var asignment = new AsignmentInstruction(variableName, new ValueInstruction(expressions.ToArray()));
            return asignment;
        }
    }
}
