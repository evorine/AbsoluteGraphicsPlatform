// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Styling;
using AbsoluteGraphicsPlatform.DSS;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using Moq;
using AbsoluteGraphicsPlatform.Abstractions;

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

        public static ApplicationOptions CreateApplicationOptions()
        {
            var applicationOptions = new ApplicationOptions();
            Configurators.DefaultValueProoviderConfigurator.AddDefaultValueProviders(applicationOptions.ValueProviders);
            return applicationOptions;
        }

        public static AgpxOptions CreateAgpxOptions()
        {
            var agpxOptions = new AgpxOptions();
            return agpxOptions;
        }


        public static IStyle GetStyle(string filename)
        {
            var fileProvider = IO.GetTestFileProvider();
            var dssParser = new DSSParser();

            var fileInfo = fileProvider.GetFileInfo(filename);
            var sourceInfo = new SourceCodeInfo(fileInfo);
            var style = dssParser.Parse(sourceInfo);
            return style;
        }
    }
}
