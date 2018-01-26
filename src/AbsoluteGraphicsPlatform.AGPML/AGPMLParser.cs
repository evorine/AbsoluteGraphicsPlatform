// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Xml;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.AGPML
{
    public class AGPMLParser
    {
        const string componentTemplateTag = "component-template";

        readonly IComponentFactory componentFactory;
        readonly PropertySetter propertySetter;
        readonly StyleParser styleParser;

        public AGPMLParser(IComponentFactory componentFactory, PropertySetter propertySetter, StyleParser styleParser)
        {
            this.componentFactory = componentFactory;
            this.propertySetter = propertySetter;
            this.styleParser = styleParser;
        }

        public ComponentTemplate ParseComponentTemplate(SourceCodeInfo sourceInfo)
        {
            if (sourceInfo == null) throw new ArgumentNullException(nameof(sourceInfo));

            var xml = new XmlDocument();
            using (var stream = sourceInfo.GetStream())
                xml.Load(stream);

            if (xml.DocumentElement.Name != componentTemplateTag)
                throw new AGPxParserException($"All elements must be inserted into root element '{componentTemplateTag}'!");

            var componentName = xml.DocumentElement.Attributes["Name"];
            if (componentName == null)
                throw new AGPxParserException($"'{componentTemplateTag}' must have 'Name' attribute!");
            
            var rootComponentType = ComponentTypeResolver.FindComponentType(componentName.Value);
            var rootTemplate = new ComponentTemplate(rootComponentType);

            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                rootTemplate.ChildrenTemplates.Append(ParseNode(node));

            return rootTemplate;
        }

        private ComponentTemplate ParseNode(XmlNode node)
        {
            var componentType = ComponentTypeResolver.FindComponentType(node.Name);
            var template = new ComponentTemplate(componentType);
            ParsePropertiesSetters(template, node);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                var childTemplate = ParseNode(childNode);
                template.ChildrenTemplates.Append(childTemplate);
            }

            return template;
        }

        private void ParsePropertiesSetters(ComponentTemplate template, XmlNode node)
        {
            foreach(XmlAttribute attribute in node.Attributes)
            {
                var propertyType = ComponentTypeResolver.GetPropertyType(template.ComponentType, attribute.Name);
                if (propertyType == null)
                    throw new PropertyNotFoundException($"Invalid property: Property '{attribute.Name}' not found!", 0, "");

                var expression = propertyType == typeof(string) ? Expression.Constant(new StringPropertyValue(attribute.Value))
                                                                : styleParser.ParseExpression(attribute.Value, node.OwnerDocument.Name);
                var propertySetterInfo = new PropertySetterInfo(attribute.Name, new Expression[] { expression }, 0, "");

                template.PropertySetters.Add(propertySetterInfo);
            }
        }
    }
}
