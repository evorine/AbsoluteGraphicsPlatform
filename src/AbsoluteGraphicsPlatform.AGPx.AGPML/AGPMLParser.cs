﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Xml;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class AGPMLParser
    {
        const string componentTemplateTag = "component-template";

        readonly IComponentFactory componentFactory;
        readonly PropertySetter propertySetter;
        readonly DSSParser dssParser;

        public AGPMLParser(IComponentFactory componentFactory, PropertySetter propertySetter, DSSParser dssParser)
        {
            this.componentFactory = componentFactory;
            this.propertySetter = propertySetter;
            this.dssParser = dssParser;
        }

        public ComponentTemplate ParseComponentTemplate(SourceCodeInfo sourceInfo)
        {
            if (sourceInfo == null) throw new ArgumentNullException(nameof(sourceInfo));

            var xml = new XmlDocument();
            using (var stream = sourceInfo.GetStream())
                xml.Load(stream);

            if (xml.DocumentElement.Name != componentTemplateTag)
                throw new AGPxException($"All elements must be inserted into root element '{componentTemplateTag}'!");

            var componentName = xml.DocumentElement.Attributes["Name"];
            if (componentName == null)
                throw new AGPxException($"'{componentTemplateTag}' must have 'Name' attribute!");
            
            var rootComponentType = ComponentTypeResolver.FindComponentType(componentName.Value);
            var rootTemplate = new ComponentTemplate(componentName.Value, rootComponentType);

            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                rootTemplate.TemplateScopes.Add("default", ParseNode(node));

            return rootTemplate;
        }

        private ComponentTemplate ParseNode(XmlNode node)
        {
            var componentType = ComponentTypeResolver.FindComponentType(node.Name);
            var template = new ComponentTemplate(node.Name, componentType);
            ParsePropertiesSetters(template, node);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (IsScopeTemplate(childNode, out string scopeName))
                {
                    foreach (XmlNode scopeChildNode in childNode.ChildNodes)
                    {
                        var childTemplate = ParseNode(scopeChildNode);
                        template.TemplateScopes.Add(scopeName, childTemplate);
                    }
                }
                else
                {
                    var childTemplate = ParseNode(childNode);
                    template.TemplateScopes.Add("default", childTemplate);
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
                var propertyType = ComponentTypeResolver.GetPropertyType(template.ComponentType, attribute.Name);
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