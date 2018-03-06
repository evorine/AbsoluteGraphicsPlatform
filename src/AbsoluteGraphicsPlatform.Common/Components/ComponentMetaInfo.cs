// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Templating;
using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentMetaInfo
    {
        public ComponentMetaInfo(Type componentType, ComponentTemplate componentTemplate)
        {
            ComponentType = componentType;
            ComponentTemplate = componentTemplate;
        }


        /// <summary>
        /// Gets the type of the component. Use this instead of <see cref="object.GetType"/> because of proxy.
        /// </summary>
        public Type ComponentType { get; }

        /// <summary>
        /// Gets the component template of the component.
        /// </summary>
        public ComponentTemplate ComponentTemplate { get; }


        /// <summary>
        /// Gets the property setters for current component model.
        /// </summary>
        public PropertySetterInfoCollection InstancePropertySetters { get; set; }

        /// <summary>
        /// Gets the directives for current component model.
        /// </summary>
        public ICollection<IComponentDirective> InstanceDirectives { get; set; }
    }
}
