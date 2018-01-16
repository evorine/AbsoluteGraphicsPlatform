// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq.Expressions;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class PropertySetterVisitor : DSSParserBaseVisitor<StylePropertySetter>
    {
        public override StylePropertySetter VisitPropertyStatement([NotNull] DSSParser.PropertyStatementContext context)
        {
            var expressionVisitor = new ExpressionVisitor();
            var expression = context.EXPRESSION.Accept(expressionVisitor);

            var setter = new StylePropertySetter(context.PROPERTY_NAME.GetText(), expression, context.Start.Line, "unknown source! fix here");
            return setter;
        }
    }
}
