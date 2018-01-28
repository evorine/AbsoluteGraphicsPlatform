// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Templating;
using AbsoluteGraphicsPlatform.Tests.Common;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public static class Common
    {
        public static ComponentTemplate ParseComponentTemplateCode(string code)
        {
            var componentTemplateCollection = new ComponentTemplateCollection();
            var appOptions = OptionsMocks.CreateApplicationOptions();
            var componentFactory = new ComponentFactory(componentTemplateCollection);
            var propertySetter = new PropertySetter(appOptions);
            var dssParser = new DSSParser();
            var agpmlParser = new AGPMLParser(componentFactory, propertySetter, dssParser);

            var sourceInfo = new SourceCodeInfo("TestCode", code);
            return agpmlParser.ParseComponentTemplate(sourceInfo);
        }

        public static ComponentTemplateCompiler MockComponentTemplateCompiler()
        {
            var componentTemplateCollection = new ComponentTemplateCollection();
            var agpxOptions = OptionsMocks.WrapOptions(OptionsMocks.CreateAgpxOptions());
            var componentFactory = new ComponentFactory(componentTemplateCollection);
            var propertySetter = new PropertySetter(OptionsMocks.CreateApplicationOptions());
            var expressionExecutor = new ExpressionExecutor();
            var dssStyleSetter = new DssStyleSetter(agpxOptions, propertySetter, expressionExecutor);

            return new ComponentTemplateCompiler(componentFactory, dssStyleSetter, propertySetter, agpxOptions);
        }
    }
}
