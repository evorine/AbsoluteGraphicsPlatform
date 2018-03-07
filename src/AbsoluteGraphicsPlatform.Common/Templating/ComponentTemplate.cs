// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.Templating
{
    public class ComponentTemplate
    {
        public static ComponentTemplate None { get; } = new ComponentTemplate(null, null, null);

        public ComponentTemplate(string containerScopeName, string componentName, Type componentType)
        {
            ContainerScopeName = containerScopeName;
            ComponentName = componentName;
            ComponentType = componentType;
            PropertySetters = new PropertySetterInfoCollection();
            Templates = new ComponentTemplateCollection();
        }

        public string ContainerScopeName { get; }
        public string ComponentName { get; }
        public Type ComponentType { get; }

        public PropertySetterInfoCollection PropertySetters { get; }

        public ICollection<IComponentDirective> Directives { get; }

        public ComponentTemplateCollection Templates { get; }

        public override string ToString() => this == None ? "None" : $"ComponentTemplate: '{ComponentType.Name}'";
    }
}
