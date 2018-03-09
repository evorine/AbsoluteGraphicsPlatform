// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.ValueProviders
{
    public class TimeSpanValueProvider : IStyleValueProvider
    {
        public StyleValueProviderResult GetValue(StyleValueProviderContext context)
        {
            if (context.Property.PropertyType == typeof(TimeSpan))
            {
                if (context.Values.Length == 1)
                {
                    if (context.Values[0] is TimeSpanPropertyValue propertyValue)
                        return StyleValueProviderResult.Success(TimeSpan.FromSeconds(propertyValue.Seconds));
                }
            }
            return StyleValueProviderResult.Fail;
        }
    }
}
