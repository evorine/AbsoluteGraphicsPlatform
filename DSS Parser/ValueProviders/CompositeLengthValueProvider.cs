// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.DSS.ValueProviders
{
    public class CompositeLengthValueProvider : IStyleValueProvider
    {
        public StyleValueProviderResult GetValue(StyleValueProviderContext context)
        {
            if (context.Property.PropertyType == typeof(CompositeLength))
            {
                if (context.Value is DSSValue dssValue)
                    return StyleValueProviderResult.Success(dssValue.ToCompositeLength());
            }
            return StyleValueProviderResult.Fail;
        }
    }
}
