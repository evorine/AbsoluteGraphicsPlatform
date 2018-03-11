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
    public class PropertySetterVisitor : DssParserVisitor<PropertySetterStatement>
    {
        readonly ExpressionVisitor expressionVisitor;

        public PropertySetterVisitor(DssRuntime dssRuntime) : base(dssRuntime)
        {
            expressionVisitor = new ExpressionVisitor(dssRuntime);
        }

        public override PropertySetterStatement VisitPropertyStatement([NotNull] Internal.DssParser.PropertyStatementContext context)
        {
            var propertyKey = context.propertyKey().GetText();
            
            var expressions = context.propertyValue().expression().Select(x => x.Accept(expressionVisitor));
            
            var setter = new PropertySetterStatement(propertyKey, expressions.ToArray(), context.Start.Line, "unknown source! fix here");
            return setter;
        }
    }
}
