// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.DynamicProperties;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class ExpressionExecutor
    {
        /// <summary>
        /// Executes an expression and returns the values.
        /// </summary>
        /// <param name="expressions">Expressions to execute.</param>
        /// <returns></returns>
        public IEnumerable<IPropertyValue> GetValues(Expression[] expressions)
        {
            foreach (var expression in expressions)
            {
                if (expression is ConstantExpression constantExpression) yield return (IPropertyValue)constantExpression.Value;
                if (expression is InvocationExpression invocationExpression) yield return (IPropertyValue)GetValueFromInvocation(invocationExpression);

                throw new NotImplementedException($"Unimplemented expression type is passed in: '{expression.GetType().Name}'!");
            }
        }

        private object GetValueFromInvocation(InvocationExpression invocationExpression)
        {
            var lambdaExpression = (LambdaExpression)invocationExpression.Expression;

            var compiled = lambdaExpression.Compile();
            var args = GetValues(invocationExpression.Arguments.ToArray());
            var result = compiled.DynamicInvoke(args);

            return result;
        }
    }
}
