// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class ExpressionExecutor
    {
        /// <summary>
        /// Executes an expression and returns the values.
        /// </summary>
        /// <param name="expressions">Expressions to execute.</param>
        /// <returns></returns>
        public IPropertyValue GetValue(Expression expression)
        {
            if (expression is ConstantExpression constantExpression) return (IPropertyValue)constantExpression.Value;
            else if (expression is InvocationExpression invocationExpression) return (IPropertyValue)GetValueFromInvocation(invocationExpression);
            else throw new NotImplementedException($"Unimplemented expression type is passed in: '{expression.GetType().Name}'!");
        }

        /// <summary>
        /// Executes an expression and returns the values.
        /// </summary>
        /// <param name="expressions">Expressions to execute.</param>
        /// <returns></returns>
        public IPropertyValue GetValues(Expression[] expressions)
        {
            if (expressions.Length > 1)
            {
                var values = expressions.Select(x => GetValue(x)).ToArray();
                return new TuplePropertyValue(values);
            }
            else
            {
                return GetValue(expressions.First());
            }
        }

        private object GetValueFromInvocation(InvocationExpression invocationExpression)
        {
            var lambdaExpression = (LambdaExpression)invocationExpression.Expression;
            var compiled = lambdaExpression.Compile();
            var args = invocationExpression.Arguments.Select(x => GetValue(x)).ToArray();
            var result = compiled.DynamicInvoke(args);

            return result;
        }
    }
}
