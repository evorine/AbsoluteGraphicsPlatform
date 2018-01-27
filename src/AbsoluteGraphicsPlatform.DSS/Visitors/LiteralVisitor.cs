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
using AbsoluteGraphicsPlatform.DSS.Internal;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class LiteralVisitor : DSSParserBaseVisitor<ConstantExpression>
    {
        static string[] lengthUnits = { "%", "px", "x", "u" };

        public override ConstantExpression VisitLiteral([NotNull] Internal.DSSParser.LiteralContext context)
        {
            var number = context.NUMBER();
            var unit = context.UNIT();
            var color = context.color();
            var none = context.NONE();

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
            else if (none != null)
            {
                return Expression.Constant(PropertyValue.None);
            }

            throw new Exception("Unexpected literal expression!");
        }
    }
}
