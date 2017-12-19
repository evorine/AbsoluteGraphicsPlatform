using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Styling;

namespace AbsoluteGraphicsPlatform.Tests.Common
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
