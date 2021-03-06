﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.DocumentModel;
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
            var dssParser = new DssParser();
            var expressionExecutor = new ExpressionExecutor();
            var componentTypeResolver = new ComponentTypeResolver();
            var agpmlParser = new AGPMLParser(propertySetter, dssParser, expressionExecutor, componentTypeResolver);

            var sourceInfo = new SourceCodeInfo("TestCode", code);
            var template = agpmlParser.ParseComponentTemplate(sourceInfo);

            if(!ComponentTemplateProvider.ComponentTypes.Contains(template.ComponentType))
                ComponentTemplateProvider.Add(template);

            return template;
        }

        public static IDocumentModelTree CreateDocumentModelTreeFromTemplate(string templateCode)
        {
            var template = ParseComponentTemplateCode(templateCode);
            var documentModelEngine = MockDocumentModelEngine();
            var componentTemplateExecutor = MockComponentTemplateExecutor();

            var component = componentTemplateExecutor.ExecuteTemplate(template);

            var componentModelTree = documentModelEngine.CreateNewTree(component);
            documentModelEngine.Restructure(componentModelTree);
            return componentModelTree;
        }

        public static ComponentTemplateExecutor MockComponentTemplateExecutor()
        {
            var agpxOptions = OptionsMocks.WrapOptions(OptionsMocks.CreateAgpxOptions());
            var propertySetter = new PropertySetter(OptionsMocks.CreateApplicationOptions());
            var expressionExecutor = new ExpressionExecutor();
            var dssStyleSetter = new DssStyleSetter(agpxOptions, propertySetter, expressionExecutor);

            return new ComponentTemplateExecutor(ComponentFactory, dssStyleSetter, propertySetter, agpxOptions);
        }

        public static IDocumentModelEngine MockDocumentModelEngine()
        {
            return new DocumentModelEngine(ComponentTemplateProvider);
        }
    }
}
