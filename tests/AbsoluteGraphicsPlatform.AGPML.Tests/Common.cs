// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Templating;
using AbsoluteGraphicsPlatform.Tests.Common;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public static class Common
    {
        public static ComponentTemplateProvider ComponentTemplateProvider = new ComponentTemplateProvider();
        public static ComponentFactory ComponentFactory = new ComponentFactory(ComponentTemplateProvider);

        public static ComponentTemplate ParseComponentTemplateCode(string code)
        {
            var appOptions = OptionsMocks.CreateApplicationOptions();
            var propertySetter = new PropertySetter(appOptions);
            var dssParser = new DSSParser();
            var agpmlParser = new AGPMLParser(propertySetter, dssParser);

            var sourceInfo = new SourceCodeInfo("TestCode", code);
            var template = agpmlParser.ParseComponentTemplate(sourceInfo);

            if(!ComponentTemplateProvider.ComponentTypes.Contains(template.ComponentType))
                ComponentTemplateProvider.Add(template);

            return template;
        }

        public static ComponentTemplateCompiler MockComponentTemplateCompiler()
        {
            var agpxOptions = OptionsMocks.WrapOptions(OptionsMocks.CreateAgpxOptions());
            var propertySetter = new PropertySetter(OptionsMocks.CreateApplicationOptions());
            var expressionExecutor = new ExpressionExecutor();
            var dssStyleSetter = new DssStyleSetter(agpxOptions, propertySetter, expressionExecutor);

            return new ComponentTemplateCompiler(ComponentFactory, dssStyleSetter, propertySetter, agpxOptions);
        }
    }
}
