// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq.Expressions;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class PropertySetterVisitor : DSSParserBaseVisitor<StylePropertySetter>
    {
        public override StylePropertySetter VisitPropertyStatement([NotNull] DSSParser.PropertyStatementContext context)
        {
            var propertyKey = context.propertyKey().GetText();

            
            
            var expressionVisitor = new ExpressionVisitor();
            var expressions = context.propertyValue().expression().Select(x => x.Accept(expressionVisitor));
            
            var setter = new StylePropertySetter(propertyKey, expressions.ToArray(), context.Start.Line, "unknown source! fix here");
            return setter;
        }
    }
}
