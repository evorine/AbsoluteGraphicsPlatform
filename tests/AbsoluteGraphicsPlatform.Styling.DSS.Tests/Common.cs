// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.AGPx.Models;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public static class Common
    {
        public static Stylesheet ParseCode(string code)
        {
            var dssParser = new DSSParser();
            var sourceInfo = new SourceCodeInfo("TestCode", code);
            return dssParser.Parse(sourceInfo);
        }
    }
}
