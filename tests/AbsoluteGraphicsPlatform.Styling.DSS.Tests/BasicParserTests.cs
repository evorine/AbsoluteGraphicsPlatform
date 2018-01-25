// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using System.IO;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class BasicParserTests
    {
        [Fact]
        public void ParseEmptyCode()
        {
            var code = " ";

            var dssParser = new StyleParser();
            var sourceInfo = new SourceCodeInfo("TestCode", code);

            var style = dssParser.Parse(sourceInfo);

            Assert.Empty(style.Rulesets);
        }

        /*
        [Fact]
        public void Test1()
        {
            var fileProvider = AbsoluteGraphicsPlatform.Tests.Common.IO.GetTestFileProvider();
            var dssParser = new StyleParser();

            var fileInfo = fileProvider.GetFileInfo("BasicStyle.dss");
            var sourceInfo = new SourceCodeInfo(fileInfo);
            var style = dssParser.Parse(sourceInfo);
        }
        */
    }
}
