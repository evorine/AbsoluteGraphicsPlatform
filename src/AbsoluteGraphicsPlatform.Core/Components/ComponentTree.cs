// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentTree : ComponentCollection, IComponentTree
    {
        public ComponentTree(IComponent owner)
        {
            Owner = owner;
        }


        /// <summary>
        /// Gets the instance of the owner component.
        /// </summary>
        public IComponent Owner { get; }

        /// <summary>
        /// Finds and returns all components recursively.
        /// </summary>
        public IEnumerable<IComponent> FindAllComponents() => throw new NotImplementedException();
    }
}
