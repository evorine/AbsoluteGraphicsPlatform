// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;

namespace NextPlatform.Styling.DSS.Tests
{
    public class BasicParserTests
    {
        [Fact]
        public void Test1()
        {
            var fileProvider = NextPlatform.Tests.Common.IO.GetTestFileProvider();
            var dssParser = new DSSParser();
            using (var stream = fileProvider.GetFileInfo("BasicStyle.dss").CreateReadStream())
            {
                var style = dssParser.Parse(stream);
            }
        }
    }
}
