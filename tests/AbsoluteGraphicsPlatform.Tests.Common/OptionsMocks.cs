using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Styling;
using AbsoluteGraphicsPlatform.DSS;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using Moq;

namespace AbsoluteGraphicsPlatform.Tests.Common
{
    public static class OptionsMocks
    {
        public static IOptions<TOptions> WrapOptions<TOptions>(TOptions options) where TOptions : class, new()
        {
            var mock = new Mock<IOptions<TOptions>>();
            mock.Setup(x => x.Value).Returns(options);
            return mock.Object;
        }

        public static DSSOptions CreateDSSOptions()
        {
            var styleOptions = new DSSOptions();
            Configurators.DefaultStylingOptionsConfigurator.Configure(styleOptions);
            return styleOptions;
        }
        

        public static IStyle GetStyle(string filename)
        {
            var fileProvider = AbsoluteGraphicsPlatform.Tests.Common.IO.GetTestFileProvider();
            var dssParser = new StyleParser();

            using (var stream = fileProvider.GetFileInfo(filename).CreateReadStream())
            {
                var style = dssParser.Parse(filename, stream);
                return style;
            }
        }
    }
}
