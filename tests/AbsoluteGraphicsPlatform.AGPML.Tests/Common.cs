// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Tests.Common;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public static class Common
    {
        public static Component ParseComponentCode(string code)
        {
            var appOptions = OptionsMocks.CreateApplicationOptions();
            var componentFactory = new ComponentFactory();
            var propertySetter = new PropertySetter(appOptions);
            var agpmlParser = new AGPMLParser(componentFactory, propertySetter);

            var sourceInfo = new SourceCodeInfo("TestCode", code);
            return agpmlParser.ParseComponent(sourceInfo);
        }
    }
}
