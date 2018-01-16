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
            var fileProvider = IO.GetTestFileProvider();
            var dssParser = new StyleParser();

            var fileInfo = fileProvider.GetFileInfo(filename);
            var sourceInfo = new SourceCodeInfo(fileInfo);
            var style = dssParser.Parse(sourceInfo);
            return style;
        }
    }
}
