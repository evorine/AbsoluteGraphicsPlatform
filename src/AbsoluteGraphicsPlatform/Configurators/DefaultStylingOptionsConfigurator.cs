// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Styling;
using System;
using System.Collections.Generic;
using System.Text;

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
