// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace AbsoluteGraphicsPlatform.AGPML
{
    public class AGPMLParser
    {
        readonly IComponentFactory componentFactory;
        public AGPMLParser(IComponentFactory componentFactory)
        {
            this.componentFactory = componentFactory;
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
                rootComponent.Components.Append(parseComponent(node));

            return rootComponent;
        }

        private Component parseComponent(XmlNode node)
        {
            var componentType = ComponentTypeResolver.FindComponentType(node.Name);
            var component = (Component)componentFactory.CreateComponent(componentType);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                var childComponent = parseComponent(childNode);
                component.Components.Append(childComponent);
            }

            return component;
        }
    }
}
