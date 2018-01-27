// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.ValueProviders
{
    public class StringValueProvider : IStyleValueProvider
    {
        public StyleValueProviderResult GetValue(StyleValueProviderContext context)
        {
            if (context.Property.PropertyType == typeof(string))
            {
                if (context.Values.Length == 1 && context.Values[0] is StringPropertyValue propertyValue)
                    return StyleValueProviderResult.Success(propertyValue.Value);
            }
            return StyleValueProviderResult.Fail;
        }
    }
}
