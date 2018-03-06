// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    /// <summary>
    /// Represents an element in the document model.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Parent element in this document model
        /// </summary>
        IElement Parent { get; set; }

        /// <summary>
        /// Scope name of the placeholder of this element.
        /// </summary>
        string ContainerScopeName { get; }
        
        /// <summary>
        /// Children elements in the same document model
        /// </summary>
        IElementCollection Children { get; }
    }
}
