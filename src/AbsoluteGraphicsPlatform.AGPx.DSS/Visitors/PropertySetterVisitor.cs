// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.AGPx.Internal;
using AbsoluteGraphicsPlatform.AGPx.Models;
using AbsoluteGraphicsPlatform.AGPx.Instructions;
using System.Linq.Expressions;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class PropertySetterVisitor : DssParserVisitor<PropertyInstruction>
    {
        readonly ExpressionVisitor expressionVisitor;

        public PropertySetterVisitor(DssRuntime dssRuntime) : base(dssRuntime)
        {
            expressionVisitor = new ExpressionVisitor(dssRuntime);
        }

        public override PropertyInstruction VisitPropertyStatement([NotNull] Internal.DssParser.PropertyStatementContext context)
        {
            var propertyKey = context.propertyKey().GetText();
            var expressions = context.propertyValue().expression().Select(x => x.Accept(expressionVisitor));
            
            var setter = new PropertyInstruction(propertyKey, new ValueInstruction(expressions.ToArray()));
            return setter;
        }
    }
}
