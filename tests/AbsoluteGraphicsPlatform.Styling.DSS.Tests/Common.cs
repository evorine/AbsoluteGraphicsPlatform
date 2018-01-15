using System;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.DSS;
using Microsoft.Extensions.Options;
using Moq;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public static class Common
    {
        public static IOptions<StylingOptions> MoqOptions(IStyle style)
        {
            var options = new StylingOptions();
            options.Styles.Add(style);

            var mock = new Mock<IOptions<StylingOptions>>();
            mock.Setup(x => x.Value).Returns(options);

            return mock.Object;
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
