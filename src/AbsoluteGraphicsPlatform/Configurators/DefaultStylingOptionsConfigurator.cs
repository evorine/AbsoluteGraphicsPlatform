// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Styling;

namespace AbsoluteGraphicsPlatform.Configurators
{
    public static class DefaultStylingOptionsConfigurator
    {
        public static void Configure(StylingOptions options)
        {
            options.ValueBinders.Add(new ValueProviders.CompositeLengthValueProvider());
        }
    }
}
