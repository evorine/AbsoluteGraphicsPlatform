// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.ValueProviders
{
    public class CompositeLengthValueProvider : IStyleValueProvider
    {
        public StyleValueProviderResult GetValue(StyleValueProviderContext context)
        {
            if (context.Property.PropertyType == typeof(CompositeLength))
            {
                if (context.Values.Length == 1)
                {
                    if (context.Values[0] is LengthPropertyValue propertyValue)
                        return StyleValueProviderResult.Success(toCompositeLength(propertyValue));
                    if (context.Values[0] is StringPropertyValue stringPropertyValue)
                    {
                        if (stringPropertyValue.Value == "fill") return StyleValueProviderResult.Success(CompositeLength.Fill);
                        if (stringPropertyValue.Value == "shrink") return StyleValueProviderResult.Success(CompositeLength.Shrink);
                    }
                }
            }
            return StyleValueProviderResult.Fail;
        }

        private static CompositeLength toCompositeLength(LengthPropertyValue value)
        {
            var args = value.Units.Select(x => (value[x], toUnitType(x))).ToArray();
            return new CompositeLength(args);
        }

        private static UnitType toUnitType(string unit)
        {
            switch (unit)
            {
                case "%": return UnitType.Percentage;
                case "px": return UnitType.Pixel;
                case "x": return UnitType.Ratio;
                case "u": return UnitType.Unit;
                case "": return UnitType.Scalar;
                default: throw new NotSupportedException("Unsupported unit type!");
            }
        }
    }
}
