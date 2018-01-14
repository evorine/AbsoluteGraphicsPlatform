using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class ExpressionVisitor : DSSParserBaseVisitor<Expression>
    {
        public override Expression VisitExpression([NotNull] DSSParser.ExpressionContext context)
        {

            return base.VisitExpression(context);
        }
    }
}
