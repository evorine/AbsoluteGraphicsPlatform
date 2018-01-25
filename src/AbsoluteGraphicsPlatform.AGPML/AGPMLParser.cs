// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Xml;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.AGPML
{
    public class AGPMLParser
    {
        const string componentTemplateTag = "component-template";

        readonly IComponentFactory componentFactory;
        readonly PropertySetter propertySetter;

        public AGPMLParser(IComponentFactory componentFactory, PropertySetter propertySetter)
        {
            this.componentFactory = componentFactory;
            this.propertySetter = propertySetter;
        }

        public ComponentTemplate ParseComponentTemplate(SourceCodeInfo sourceInfo)
        {
            if (sourceInfo == null) throw new ArgumentNullException(nameof(sourceInfo));

            var xml = new XmlDocument();
            using (var stream = sourceInfo.GetStream())
                xml.Load(stream);

            if (xml.DocumentElement.Name != componentTemplateTag)
                throw new AGPMLException($"All elements must be inserted into root element '{componentTemplateTag}'!");

            var componentName = xml.DocumentElement.Attributes["Name"];
            if (componentName == null)
                throw new AGPMLException($"'{componentTemplateTag}' must have 'Name' attribute!");

            var rootComponentType = ComponentTypeResolver.FindComponentType(componentName.Value);
            var rootTemplate = new ComponentTemplate(rootComponentType);

            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                rootTemplate.ChildrenTemplates.Append(ParseComponent(node));

            return rootTemplate;
        }

        private ComponentTemplate ParseComponent(XmlNode node)
        {
            var componentType = ComponentTypeResolver.FindComponentType(node.Name);
            var template = new ComponentTemplate(componentType);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                var childTemplate = ParseComponent(childNode);
                template.ChildrenTemplates.Append(childTemplate);
            }

            return template;
        }

        private void SetProperties(ComponentTemplate template, XmlNode node)
        {
            foreach(XmlAttribute attribute in node.Attributes)
            {
                //propertySetter.SetValue(component, attribute.Name)
            }
        }
    }
}
