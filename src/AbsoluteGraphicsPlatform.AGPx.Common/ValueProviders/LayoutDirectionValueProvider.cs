// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.Abstractions.Layout;

namespace AbsoluteGraphicsPlatform.ValueProviders
{
    public class LayoutDirectionValueProvider : IStyleValueProvider
    {
        public StyleValueProviderResult GetValue(StyleValueProviderContext context)
        {
            if (context.Property.PropertyType == typeof(LayoutDirection))
            {
                if (context.Values.Length == 1 && context.Values[0] is StringPropertyValue propertyValue)
                {
                    if (Enum.TryParse(propertyValue.Value, out LayoutDirection layoutDirection))
                        return StyleValueProviderResult.Success(layoutDirection);
                }
            }
            return StyleValueProviderResult.Fail;
        }
    }
}
