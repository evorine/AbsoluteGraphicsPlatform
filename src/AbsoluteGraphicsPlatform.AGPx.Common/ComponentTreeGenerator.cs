// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.ComponentModel;
using AbsoluteGraphicsPlatform.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class ComponentTreeGenerator
    {
        readonly IComponentFactory componentFactory;
        readonly StyleSetter styleSetter;
        readonly PropertySetter propertySetter;

        public ComponentTreeGenerator(IComponentFactory componentFactory, IStyleSetter styleSetter, PropertySetter propertySetter)
        {
            this.componentFactory = componentFactory;
            this.styleSetter = (StyleSetter)styleSetter;
            this.propertySetter = propertySetter;
        }

        public IComponent CreateComponentTree(ComponentTemplate rootTemplate)
        {
            var component = CreateComponent(rootTemplate);
            return component;
        }

        public IComponent ProcessTemplate(ComponentTemplate rootTemplate)
        {
            var component = CreateComponent(rootTemplate);
            return component;
        }

        private IComponent CreateComponent(ComponentTemplate componentTemplate)
        {
            var component = componentFactory.CreateComponent(componentTemplate.ComponentType);

            // Iterate virtual template components
            foreach (var templateComponentTemplate in componentTemplate.TemplateScopes)
            {
                // Create template components and assign scope name
                var templateComponent = (TemplateComponent)componentFactory.CreateComponent(typeof(TemplateComponent));
                templateComponent.Scope = templateComponentTemplate.ScopeName;
                component.Components.Append(templateComponent);

                // Iterate and create actual child components. Append them to the current virtual template
                foreach(var childComponentTemplate in templateComponentTemplate)
                    templateComponent.Components.Append(CreateComponent(childComponentTemplate));
            }

            styleSetter.ApplyStyle(component);
            foreach(var property in componentTemplate.PropertySetters)
                styleSetter.ApplyProperty(component, property);

            return component;
        }
    }
}
