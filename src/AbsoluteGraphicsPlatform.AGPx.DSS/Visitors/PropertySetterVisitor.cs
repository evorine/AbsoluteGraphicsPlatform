﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.AGPx.Internal;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class PropertySetterVisitor : DSSParserBaseVisitor<PropertySetterInfo>
    {
        public override PropertySetterInfo VisitPropertyStatement([NotNull] Internal.DSSParser.PropertyStatementContext context)
        {
            var propertyKey = context.propertyKey().GetText();

            
            
            var expressionVisitor = new ExpressionVisitor();
            var expressions = context.propertyValue().expression().Select(x => x.Accept(expressionVisitor));
            
            var setter = new PropertySetterInfo(propertyKey, expressions.ToArray(), context.Start.Line, "unknown source! fix here");
            return setter;
        }
    }
}
