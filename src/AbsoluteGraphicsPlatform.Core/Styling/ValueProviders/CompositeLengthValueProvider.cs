// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Metrics;
using System.Linq;

namespace AbsoluteGraphicsPlatform.Styling.ValueProviders
{
    public class CompositeLengthValueProvider : IStyleValueProvider
    {
        public StyleValueProviderResult GetValue(StyleValueProviderContext context)
        {
            if (context.Property.PropertyType == typeof(CompositeLength))
            {
                if (context.Value is PropertyValue propertyValue)
                    return StyleValueProviderResult.Success(toCompositeLength(propertyValue));
            }
            return StyleValueProviderResult.Fail;
        }

        private static CompositeLength toCompositeLength(PropertyValue value)
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
                case "": return UnitType.Unitless;
                default: throw new NotSupportedException("Unsupported unit type!");
            }
        }
    }
}
