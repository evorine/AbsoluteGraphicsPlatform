// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.DSS.ValueProviders;

namespace AbsoluteGraphicsPlatform.Configurators
{
    public static class DefaultStylingOptionsConfigurator
    {
        public static void Configure(DSSOptions options)
        {
            options.ValueBinders.Add(new CompositeLengthValueProvider());
        }
    }
}
