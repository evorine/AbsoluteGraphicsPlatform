// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.ValueProviders
{
    public class ScalarPropertyValueProvider : IStyleValueProvider
    {
        static Type[] scalarTypes = new Type[] { typeof(int), typeof(float), typeof(double), typeof(decimal), typeof(byte), typeof(long), typeof(short), typeof(uint), typeof(ushort), typeof(ulong) };

        public StyleValueProviderResult GetValue(StyleValueProviderContext context)
        {
            if (scalarTypes.Contains(context.Property.PropertyType))
            {
                if (context.Values.Length == 1)
                    if (context.Values[0] is ScalarPropertyValue propertyValue)
                        return StyleValueProviderResult.Success(propertyValue.Value);

            }
            if (context.Property.PropertyType == typeof(string))
            {
                if (context.Values[0] is StringPropertyValue propertyValue)
                    if(decimal.TryParse(propertyValue.Value, out decimal value))
                        return StyleValueProviderResult.Success(value);
            }
            
            return StyleValueProviderResult.Fail;
        }
    }
}
