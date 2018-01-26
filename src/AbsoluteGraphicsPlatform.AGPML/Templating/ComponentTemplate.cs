// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.DSS.Models;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentTemplate
    {
        public ComponentTemplate(Type componentType)
        {
            ComponentType = componentType;
            PropertySetters = new PropertySetterInfoCollection();
            ChildrenTemplates = new ComponentTemplateCollection();
        }

        public Type ComponentType { get; }

        public PropertySetterInfoCollection PropertySetters { get; }

        public ICollection<IComponentDirective> Directives { get; }

        public ComponentTemplateCollection ChildrenTemplates { get; }
    }
}
