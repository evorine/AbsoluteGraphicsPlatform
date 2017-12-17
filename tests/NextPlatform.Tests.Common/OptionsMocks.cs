using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Components;
using NextPlatform.Styling;

namespace NextPlatform.Tests.Common
{
    public static class OptionsMocks
    {
        public static StylingOptions CreateStylingOptions()
        {
            var styleOptions = new StylingOptions();
            Configurators.DefaultStylingOptionsConfigurator.Configure(styleOptions);
            return styleOptions;
        }
    }
}
