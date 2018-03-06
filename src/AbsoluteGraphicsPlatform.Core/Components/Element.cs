// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.Components
{
    /// <summary>
    /// Represents an element in the document model.
    /// </summary>
    public class Element : IElement
    {
        public Element()
        {
            Children = new ElementCollection();
        }


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Parent element in this document model
        /// </summary>
        public IElement Parent { get; set; }
        /// <summary>
        /// Scope name of the placeholder of this element.
        /// </summary>
        public string ContainerScopeName { get; set; }

        /// <summary>
        /// Children elements in the same document model
        /// </summary>
        public IElementCollection Children { get; }
    }
}
