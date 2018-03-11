// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Xml;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Templating;
using System.Linq;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class AGPMLParser
    {
        const string componentTemplateTag = "component-template";

        readonly PropertySetter propertySetter;
        readonly DssParser dssParser;
        readonly ComponentTypeResolver componentTypeResolver;

        public AGPMLParser(PropertySetter propertySetter, DssParser dssParser, ComponentTypeResolver componentTypeResolver)
        {
            this.propertySetter = propertySetter;
            this.dssParser = dssParser;
            this.componentTypeResolver = componentTypeResolver;
        }

        public ComponentTemplate ParseComponentTemplate(SourceCodeInfo sourceInfo)
        {
            if (sourceInfo == null) throw new ArgumentNullException(nameof(sourceInfo));

            var xml = new XmlDocument();
            try
            {
                using (var stream = sourceInfo.GetStream())
                    xml.Load(stream);
            }
            catch (XmlException ex)
            {
                throw new AGPxException(ex.Message);
            }

            if (xml.DocumentElement.Name != componentTemplateTag)
                throw new AGPxException($"All elements must be inserted into root element '{componentTemplateTag}'!");

            var namespaces = ParseNamespaces(xml);

            var componentName = xml.DocumentElement.Attributes["Name"];
            if (componentName == null)
                throw new AGPxException($"'{componentTemplateTag}' must have 'Name' attribute!");
            
            var rootComponentType = componentTypeResolver.FindComponentType(componentName.Value, namespaces);
            var rootTemplate = new ComponentTemplate(null, componentName.Value, rootComponentType);

            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                rootTemplate.Templates.Add(ParseNode("default", node, namespaces));

            return rootTemplate;
        }

        private string[] ParseNamespaces(XmlDocument xml)
        {
            var instructions = xml.ChildNodes.Cast<XmlNode>().Where(x => x is XmlProcessingInstruction).Cast<XmlProcessingInstruction>();
            return instructions.Select(x => x.Data.Trim()).ToArray();
        }

        private ComponentTemplate ParseNode(string containerScope, XmlNode node, string[] namespaces)
        {
            var componentType = componentTypeResolver.FindComponentType(node.Name, namespaces);
            var template = new ComponentTemplate(containerScope, node.Name, componentType);
            ParsePropertiesSetters(template, node);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (IsScopeTemplate(childNode, out string scopeName))
                {
                    foreach (XmlNode scopeChildNode in childNode.ChildNodes)
                    {
                        var childTemplate = ParseNode(scopeName, scopeChildNode, namespaces);
                        template.Templates.Add(childTemplate);
                    }
                }
                else
                {
                    var childTemplate = ParseNode("default", childNode, namespaces);
                    template.Templates.Add(childTemplate);
                }
            }

            return template;
        }

        private bool IsScopeTemplate(XmlNode node, out string scopeName)
        {
            if (node.Name == "template")
            {
                var scopeAttribute = node.Attributes["scope"];
                if (scopeAttribute != null)
                {
                    scopeName = scopeAttribute.Value;
                    return true;
                }
            }
            scopeName = null;
            return false;
        }

        private void ParsePropertiesSetters(ComponentTemplate template, XmlNode node)
        {
            foreach(XmlAttribute attribute in node.Attributes)
            {
                var propertyType = componentTypeResolver.GetPropertyType(template.ComponentType, attribute.Name);
                if (propertyType == null)
                    throw new PropertyNotFoundException($"Invalid property: Property '{attribute.Name}' not found!", 0, "");

                var expression = propertyType == typeof(string) ? Expression.Constant(new StringPropertyValue(attribute.Value))
                                                                : dssParser.ParseExpression(attribute.Value, node.OwnerDocument.Name);
                var propertySetterInfo = new PropertySetterInfo(attribute.Name, new Expression[] { expression }, 0, "");

                template.PropertySetters.Add(propertySetterInfo);
            }
        }
    }
}
