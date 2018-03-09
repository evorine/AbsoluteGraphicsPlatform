// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.ValueProviders;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Styling;

namespace AbsoluteGraphicsPlatform.Configurators
{
    public static class DefaultValueProoviderConfigurator
    {
        public static void AddDefaultValueProviders(IList<IStyleValueProvider> valueProviders)
        {
            valueProviders.Add(new LayoutDirectionValueProvider());
            valueProviders.Add(new CompositeLengthValueProvider());
            valueProviders.Add(new StringValueProvider());
            valueProviders.Add(new TimeSpanValueProvider());
            valueProviders.Add(new ScalarPropertyValueProvider());
        }
    }
}
