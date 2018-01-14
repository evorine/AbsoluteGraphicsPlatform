using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class ExpressionVisitor : DSSParserBaseVisitor<Expression>
    {
        LiteralVisitor literalVisitor = new LiteralVisitor();

        static Expression<Func<DSSValue, DSSValue, DSSValue>> multiplyExpression = (left, right) => left * right;
        static Expression<Func<DSSValue, DSSValue, DSSValue>> divideExpression = (left, right) => left / right;
        static Expression<Func<DSSValue, DSSValue, DSSValue>> moduloExpression = (left, right) => left % right;

        static Expression<Func<DSSValue, DSSValue, DSSValue>> addExpression = (left, right) => left + right;
        static Expression<Func<DSSValue, DSSValue, DSSValue>> subtractExpression = (left, right) => left - right;

        static Expression<Func<DSSValue, DSSValue, bool>> equalsExpression = (left, right) => left == right;
        static Expression<Func<DSSValue, DSSValue, bool>> notEqualsExpression = (left, right) => left != right;

        static Expression<Func<DSSValue, DSSValue, bool>> lesserExpression = (left, right) => left < right;
        static Expression<Func<DSSValue, DSSValue, bool>> greaterExpression = (left, right) => left > right;
        static Expression<Func<DSSValue, DSSValue, bool>> lesserEqualsExpression = (left, right) => left <= right;
        static Expression<Func<DSSValue, DSSValue, bool>> greaterEqualsExpression = (left, right) => left >= right;


        public override Expression VisitExpression([NotNull] DSSParser.ExpressionContext context)
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

                    case "<=": return Expression.Invoke(lesserEqualsExpression, left, right);
                    case ">=": return Expression.Invoke(greaterEqualsExpression, left, right);
                    case ">": return Expression.Invoke(greaterExpression, left, right);
                    case "<": return Expression.Invoke(lesserExpression, left, right);

                    case "==": return Expression.Invoke(equalsExpression, left, right);
                    case "!=": return Expression.Invoke(notEqualsExpression, left, right);
                }
            }
            else
            {
                var expressions = context.expression();
                foreach (var expression in expressions)
                {
                    var result = expression.Accept(this);
                    return result;
                }
            }
            throw new Exception("Unexpected expression!");
        }

        public class LiteralVisitor : DSSParserBaseVisitor<ConstantExpression>
        {
            public override ConstantExpression VisitLiteral([NotNull] DSSParser.LiteralContext context)
            {
                var number = context.NUMBER();
                var unit = context.UNIT();

                if (number != null && unit != null)
                {
                    float value;
                    if (!float.TryParse(number.GetText(), out value))
                        throw new Exception("Invalid number");
                    
                    UnitType unitType;
                    string rawUnit = unit.GetText();
                    if (rawUnit == "%") unitType = UnitType.Percentage;
                    else if (rawUnit == "px") unitType = UnitType.Pixel;
                    else if (rawUnit == "x") unitType = UnitType.Ratio;
                    else if (rawUnit == "u") unitType = UnitType.Unit;
                    else throw new Exception("Unexpected unit type!");

                    return Expression.Constant(new DSSValue(value));
                    //return Expression.Constant(new CompositeLength(value, unitType));
                }
                else if (number != null)
                {
                    float value;
                    if (!float.TryParse(number.GetText(), out value))
                        throw new Exception("Invalid number");
                    
                    return Expression.Constant(new DSSValue(value));
                }

                throw new Exception("Unexpected literal expression!");
            }
        }
    }
}
