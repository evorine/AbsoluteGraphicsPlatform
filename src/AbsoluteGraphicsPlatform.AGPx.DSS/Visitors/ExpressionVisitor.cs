// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.AGPx.Internal;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class ExpressionVisitor : DSSParserBaseVisitor<Expression>
    {
        LiteralVisitor literalVisitor = new LiteralVisitor();

        static Expression<Func<IPropertyValue, IPropertyValue, IPropertyValue>> multiplyExpression = (left, right) => operationMultiply(left, right);
        static Expression<Func<IPropertyValue, IPropertyValue, IPropertyValue>> divideExpression = (left, right) => operationDivide(left, right);
        static Expression<Func<IPropertyValue, IPropertyValue, IPropertyValue>> moduloExpression = (left, right) => operationModulo(left, right);

        static Expression<Func<IPropertyValue, IPropertyValue, IPropertyValue>> addExpression = (left, right) => operationAdd(left, right);
        static Expression<Func<IPropertyValue, IPropertyValue, IPropertyValue>> subtractExpression = (left, right) => operationSubtract(left, right);

        static Expression<Func<IPropertyValue, IPropertyValue, bool>> equalsExpression = (left, right) => operatorEquals(left, right);
        static Expression<Func<IPropertyValue, IPropertyValue, bool>> notEqualsExpression = (left, right) => operatorNotEquals(left, right);


        public override Expression VisitExpression([NotNull] Internal.DSSParser.ExpressionContext context)
        {
            var literal = context.literal();
            if (literal != null) return literal.Accept(literalVisitor);

            if (context.OP != null)
            {
                var left = context.LEFT.Accept(this);
                var right = context.RIGHT.Accept(this);

                switch (context.OP.Text)
                {
                    case "*": return Expression.Invoke(multiplyExpression, left, right);
                    case "/": return Expression.Invoke(divideExpression, left, right);
                    case "%": return Expression.Invoke(moduloExpression, left, right);

                    case "+": return Expression.Invoke(addExpression, left, right);
                    case "-": return Expression.Invoke(subtractExpression, left, right);

                    //case "<=": return Expression.Invoke(lesserEqualsExpression, left, right);
                    //case ">=": return Expression.Invoke(greaterEqualsExpression, left, right);
                    //case ">": return Expression.Invoke(greaterExpression, left, right);
                    //case "<": return Expression.Invoke(lesserExpression, left, right);

                    case "==": return Expression.Invoke(equalsExpression, left, right);
                    case "!=": return Expression.Invoke(notEqualsExpression, left, right);
                }
            }
            else
            {
                var expressions = context.expression();
                foreach (var expression in expressions)
                {
#warning Check here! Seems like a bug!
                    var result = expression.Accept(this);
                    return result;
                }
            }
            throw new Exception("Unexpected expression!");
        }


        static private IPropertyValue operationMultiply(IPropertyValue left, IPropertyValue right)
        {
            // scalar * scalar
            if (left is ScalarPropertyValue && right is ScalarPropertyValue) return ((ScalarPropertyValue)left) * ((ScalarPropertyValue)right);

            // scalar * length
            if (left is ScalarPropertyValue && right is LengthPropertyValue) return ((ScalarPropertyValue)left) * ((LengthPropertyValue)right);

            // length * scalar
            if (left is LengthPropertyValue && right is ScalarPropertyValue) return ((LengthPropertyValue)left) * ((ScalarPropertyValue)right);

            // scalar * time
            if (left is ScalarPropertyValue && right is TimeSpanPropertyValue) return ((ScalarPropertyValue)left) * ((TimeSpanPropertyValue)right);

            // time * scalar
            if (left is TimeSpanPropertyValue && right is ScalarPropertyValue) return ((TimeSpanPropertyValue)left) * ((ScalarPropertyValue)right);

            throw new Exception("Invalid operation!");
        }
        static private IPropertyValue operationDivide(IPropertyValue left, IPropertyValue right)
        {
            // scalar / scalar
            if (left is ScalarPropertyValue && right is ScalarPropertyValue) return ((ScalarPropertyValue)left) / ((ScalarPropertyValue)right);

            // length / scalar
            if (left is LengthPropertyValue && right is ScalarPropertyValue) return ((LengthPropertyValue)left) / ((ScalarPropertyValue)right);

            // time / scalar
            if (left is TimeSpanPropertyValue && right is ScalarPropertyValue) return ((TimeSpanPropertyValue)left) / ((ScalarPropertyValue)right);

            throw new Exception("Invalid operation!");
        }
        static private IPropertyValue operationModulo(IPropertyValue left, IPropertyValue right)
        {
            // scalar % scalar
            if (left is ScalarPropertyValue && right is ScalarPropertyValue) return ((ScalarPropertyValue)left) % ((ScalarPropertyValue)right);

            // length % scalar
            if (left is LengthPropertyValue && right is ScalarPropertyValue) return ((LengthPropertyValue)left) % ((ScalarPropertyValue)right);

            // time % scalar
            if (left is TimeSpanPropertyValue && right is ScalarPropertyValue) return ((TimeSpanPropertyValue)left) % ((ScalarPropertyValue)right);

            throw new Exception("Invalid operation!");
        }
        static private IPropertyValue operationAdd(IPropertyValue left, IPropertyValue right)
        {
            // scalar + scalar
            if (left is ScalarPropertyValue && right is ScalarPropertyValue) return ((ScalarPropertyValue)left) + ((ScalarPropertyValue)right);

            // length + length
            if (left is LengthPropertyValue && right is LengthPropertyValue) return ((LengthPropertyValue)left) + ((LengthPropertyValue)right);

            // time + time
            if (left is TimeSpanPropertyValue && right is TimeSpanPropertyValue) return ((TimeSpanPropertyValue)left) + ((TimeSpanPropertyValue)right);

            throw new Exception("Invalid operation!");
        }
        static private IPropertyValue operationSubtract(IPropertyValue left, IPropertyValue right)
        {
            // scalar - scalar
            if (left is ScalarPropertyValue && right is ScalarPropertyValue) return ((ScalarPropertyValue)left) - ((ScalarPropertyValue)right);

            // length - length
            if (left is LengthPropertyValue && right is LengthPropertyValue) return ((LengthPropertyValue)left) - ((LengthPropertyValue)right);

            // time - time
            if (left is TimeSpanPropertyValue && right is TimeSpanPropertyValue) return ((TimeSpanPropertyValue)left) - ((TimeSpanPropertyValue)right);

            throw new Exception("Invalid operation!");
        }

        static private bool operatorEquals(IPropertyValue left, IPropertyValue right)
        {
            // scalar == scalar
            if (left is ScalarPropertyValue && right is ScalarPropertyValue) return ((ScalarPropertyValue)left).Equals(((ScalarPropertyValue)right));

            // length == length
            if (left is LengthPropertyValue && right is LengthPropertyValue) return ((LengthPropertyValue)left).Equals(((LengthPropertyValue)right));

            // time == time
            if (left is TimeSpanPropertyValue && right is TimeSpanPropertyValue) return ((TimeSpanPropertyValue)left).Equals(((TimeSpanPropertyValue)right));

            throw new Exception("Invalid operation!");
        }
        static private bool operatorNotEquals(IPropertyValue left, IPropertyValue right)
        {
            // scalar != scalar
            if (left is ScalarPropertyValue && right is ScalarPropertyValue) return ((ScalarPropertyValue)left).Equals(((ScalarPropertyValue)right));

            // length != length
            if (left is LengthPropertyValue && right is LengthPropertyValue) return ((LengthPropertyValue)left).Equals(((LengthPropertyValue)right));

            // time != time
            if (left is TimeSpanPropertyValue && right is TimeSpanPropertyValue) return ((TimeSpanPropertyValue)left).Equals(((TimeSpanPropertyValue)right));

            throw new Exception("Invalid operation!");
        }
    }
}
