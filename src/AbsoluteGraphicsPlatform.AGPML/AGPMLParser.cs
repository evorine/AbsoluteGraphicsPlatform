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
        readonly IComponentFactory componentFactory;
        readonly PropertySetter propertySetter;

        public AGPMLParser(IComponentFactory componentFactory, PropertySetter propertySetter)
        {
            this.componentFactory = componentFactory;
            this.propertySetter = propertySetter;
        }

        public Component Parse(SourceCodeInfo sourceInfo)
        {
            if (sourceInfo == null) throw new ArgumentNullException(nameof(sourceInfo));

            var xml = new XmlDocument();
            using (var stream = sourceInfo.GetStream())
                xml.Load(stream);

            if (xml.DocumentElement.Name != "component-template")
                throw new AGPMLException("All elements must be inserted into root element 'template'!");

            var componentName = xml.DocumentElement.Attributes["Name"];
            if (componentName == null)
                throw new AGPMLException("'component-template' must have 'Name' attribute!");

            var rootComponentType = ComponentTypeResolver.FindComponentType(componentName.Value);
            var rootComponent = (Component)componentFactory.CreateComponent(rootComponentType);

            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                rootComponent.Components.Append(ParseComponent(node));

            return rootComponent;
        }

        private Component ParseComponent(XmlNode node)
        {
            var componentType = ComponentTypeResolver.FindComponentType(node.Name);
            var component = (Component)componentFactory.CreateComponent(componentType);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                var childComponent = ParseComponent(childNode);
                component.Components.Append(childComponent);
            }

            return component;
        }

        private void SetProperties(IComponent component, XmlNode node)
        {
            foreach(XmlAttribute attribute in node.Attributes)
            {
                //propertySetter.SetValue(component, attribute.Name)
            }
        }
    }
}
