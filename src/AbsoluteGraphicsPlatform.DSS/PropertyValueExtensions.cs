// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DSS
{
    public static class PropertyValueExtensions
    {
        public static CompositeLength ToCompositeLength(this PropertyValue value)
        {
            var args = value.Units.Select(x => (value[x], toUnitType(x))).ToArray();
            return new CompositeLength(args);
        }

        private static UnitType toUnitType(string unit)
        {
            switch(unit)
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
