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
    public class LiteralVisitor : DssParserVisitor<ConstantExpression>
    {
        static string[] lengthUnits = { "%", "px", "x", "u" };

        public LiteralVisitor(DssRuntime dssRuntime) : base(dssRuntime)
        {
        }

        public override ConstantExpression VisitLiteral([NotNull] Internal.DssParser.LiteralContext context)
        {
            var number = context.NUMBER();
            var unit = context.UNIT();
            var color = context.color();
            var list = context.list();
            var none = context.NONE();
            var other = context.IDENTIFIER();


            if (number != null)
            {
                float value;
                if (!float.TryParse(number.GetText(), out value))
                    throw new Exception("Invalid number");

                if (unit == null) return Expression.Constant(new ScalarPropertyValue(value));
                else
                {
                    // Timespan
                    string rawUnit = unit.GetText();
                    if (rawUnit.Equals("s", StringComparison.InvariantCulture))
                        return Expression.Constant(new TimeSpanPropertyValue(value));

                    // Length
                    if (!lengthUnits.Contains(rawUnit))
                        throw new Exception("Unexpected unit type!");

                    return Expression.Constant(new LengthPropertyValue(rawUnit, value));
                }
            }
            else if (color != null)
            {
                var characters = color.HEXADECIMAL();
                var rawRed = characters[0].GetText() + characters[1].GetText();
                var rawGreen = characters[2].GetText() + characters[3].GetText();
                var rawBlue = characters[4].GetText() + characters[5].GetText();

                if (!byte.TryParse(rawRed, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out byte red))
                    throw new Exception("Unexpected color code!");
                if (!byte.TryParse(rawGreen, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out byte green))
                    throw new Exception("Unexpected color code!");
                if (!byte.TryParse(rawBlue, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out byte blue))
                    throw new Exception("Unexpected color code!");

                return Expression.Constant(new ColorPropertyValue(red, green, blue, 1));
            }
            else if (list != null)
            {
                var listRanged = list.listRanged();
                if (listRanged != null)
                {
                    if (!int.TryParse(listRanged.FROM.Text, out int from)) throw new Exception("Invalid number");
                    if (!int.TryParse(listRanged.TO.Text, out int to)) throw new Exception("Invalid number");

                    var listValues = Enumerable.Range(from, to - from + 1).ToArray();
                    return Expression.Constant(listValues);
                }

                var listWithValues = list.listWithValues();
                if (listWithValues != null)
                {
                    var listValues = listWithValues.literal().Select(x => x.Accept(this)).ToArray();
                    return Expression.Constant(listValues);
                }
            }
            else if (none != null)
            {
                return Expression.Constant(PropertyValue.None);
            }
            else if (other != null)
            {
                return Expression.Constant(new StringPropertyValue(other.GetText()));
            }

            throw new Exception("Unexpected literal expression!");
        }
    }
}
