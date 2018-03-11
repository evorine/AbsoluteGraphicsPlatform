// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Styling;
using System.Linq;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.AGPx.Internal;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class VariableVisitor : DssParserBaseVisitor<InvocationExpression>
    {
        static Expression<Func<DssRuntime, string, Expression>> getVariableValue = (dssRuntime, variableName) => dssRuntime.GetVariableValue(variableName);

        readonly DssRuntime dssRuntime;

        public VariableVisitor(DssRuntime dssRuntime)
        {
            this.dssRuntime = dssRuntime;
        }

        public override InvocationExpression VisitVariable([NotNull] Internal.DssParser.VariableContext context)
        {
            var variableName = context.GetText();
            return Expression.Invoke(getVariableValue, Expression.Constant(dssRuntime), Expression.Constant(variableName));
        }
    }
}
