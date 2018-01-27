// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentTemplate
    {
        public ComponentTemplate(Type componentType)
        {
            ComponentType = componentType;
            PropertySetters = new PropertySetterInfoCollection();
            TemplateScopes = new ComponentTemplateScopeCollection();
        }

        public Type ComponentType { get; }

        public PropertySetterInfoCollection PropertySetters { get; }

        public ICollection<IComponentDirective> Directives { get; }

        public ComponentTemplateScopeCollection TemplateScopes { get; }
    }
}
