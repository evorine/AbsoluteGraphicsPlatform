// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class ComponentTemplateExecutor
    {
        readonly IComponentFactory componentFactory;
        readonly StyleSetter styleSetter;
        readonly PropertySetter propertySetter;
        readonly AgpxOptions agpxOptions;

        public ComponentTemplateExecutor(IComponentFactory componentFactory, IStyleSetter styleSetter, PropertySetter propertySetter, IOptions<AgpxOptions> agpxOptions)
        {
            this.componentFactory = componentFactory;
            this.styleSetter = (StyleSetter)styleSetter;
            this.propertySetter = propertySetter;
            this.agpxOptions = agpxOptions.Value;
        }

        public IComponent ExecuteTemplate(ComponentTemplate rootTemplate)
        {
            var component = CreateComponent(rootTemplate);
            return component;
        }

        private IComponent CreateComponent(ComponentTemplate componentTemplate)
        {
            var component = componentFactory.CreateComponent(componentTemplate.ComponentType);
            
            // Iterate virtual template components
            foreach (var childComponentTemplate in componentTemplate.Templates)
            {
                var child = CreateComponent(childComponentTemplate);
                component.Children.Add(child);
                child.Parent = component;
            }

            styleSetter.ApplyStyle(component);
            foreach(var property in componentTemplate.PropertySetters)
                styleSetter.ApplyProperty(component, property);

            return component;
        }
    }
}
