// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentMetaInfo
    {
        public ComponentMetaInfo(Type componentType)
        {
            ComponentType = componentType;
        }

        /// <summary>
        /// Gets the type of the component. Use this instead of <see cref="object.GetType"/> because of proxy.
        /// </summary>
        public Type ComponentType { get; }
    }
}
