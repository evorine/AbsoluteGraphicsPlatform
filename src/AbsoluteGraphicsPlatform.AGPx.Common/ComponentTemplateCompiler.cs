// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class ComponentTemplateCompiler
    {
        readonly IComponentFactory componentFactory;
        readonly StyleSetter styleSetter;
        readonly PropertySetter propertySetter;
        readonly AgpxOptions agpxOptions;

        public ComponentTemplateCompiler(IComponentFactory componentFactory, IStyleSetter styleSetter, PropertySetter propertySetter, IOptions<AgpxOptions> agpxOptions)
        {
            this.componentFactory = componentFactory;
            this.styleSetter = (StyleSetter)styleSetter;
            this.propertySetter = propertySetter;
            this.agpxOptions = agpxOptions.Value;
        }

        public IComponent ProcessTemplate(ComponentTemplate rootTemplate)
        {
            var component = CreateRootComponent(rootTemplate);
            return component;
        }

        private IComponent CreateRootComponent(ComponentTemplate componentTemplate)
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
                    templateComponent.Components.Append(CreateRootComponent(childComponentTemplate));
            }

            styleSetter.ApplyStyle(component);
            foreach(var property in componentTemplate.PropertySetters)
                styleSetter.ApplyProperty(component, property);

            return component;
        }
    }
}
