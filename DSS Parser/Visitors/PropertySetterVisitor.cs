using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class PropertySetterVisitor : DSSParserBaseVisitor<StylePropertySetter>
    {
        public override StylePropertySetter VisitPropertyStatement([NotNull] DSSParser.PropertyStatementContext context)
        {
            var expressionVisitor = new ExpressionVisitor();
            var expression = context.EXPRESSION.Accept(expressionVisitor);

            var setter = new StylePropertySetter(context.PROPERTY_NAME.GetText(), expression);
            return setter;
        }
    }
}
