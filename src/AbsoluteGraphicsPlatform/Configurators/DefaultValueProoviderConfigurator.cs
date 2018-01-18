// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.ValueProviders;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Styling;

namespace AbsoluteGraphicsPlatform.Configurators
{
    public static class DefaultValueProoviderConfigurator
    {
        public static void AddDefaultValueProviders(IList<IStyleValueProvider> valueProviders)
        {
            valueProviders.Add(new CompositeLengthValueProvider());
        }
    }
}
