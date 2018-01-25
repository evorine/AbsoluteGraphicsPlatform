// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.Tests.Common;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public static class Common
    {
        public static ComponentTemplate ParseComponentTemplateCode(string code)
        {
            var appOptions = OptionsMocks.CreateApplicationOptions();
            var componentFactory = new ComponentFactory();
            var propertySetter = new PropertySetter(appOptions);
            var dssParser = new StyleParser();
            var agpmlParser = new AGPMLParser(componentFactory, propertySetter, dssParser);

            var sourceInfo = new SourceCodeInfo("TestCode", code);
            return agpmlParser.ParseComponentTemplate(sourceInfo);
        }
    }
}
