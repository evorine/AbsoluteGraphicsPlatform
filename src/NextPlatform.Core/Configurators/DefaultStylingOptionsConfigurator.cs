using NextPlatform.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Configurators
{
    public static class DefaultStylingOptionsConfigurator
    {
        public static void Configure(StylingOptions options)
        {
            options.ValueBinders.Add(new Styling.Binders.CompositeLengthValueBinder());
        }
    }
}
