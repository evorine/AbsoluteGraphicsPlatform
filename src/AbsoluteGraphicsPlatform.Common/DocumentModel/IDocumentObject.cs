// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    /// <summary>
    /// Represents an <see cref="IElement"/> in a <see cref="IDocumentModelTree"/>.
    /// </summary>
    public interface IDocumentObject
    {
        /// <summary>
        /// Gets the owner document model tree
        /// </summary>
        IDocumentModelTree OwnerDocumentModel { get; }

        /// <summary>
        /// Gets the owner element of this document object
        /// </summary>
        IElement Element { get; }

        /// <summary>
        /// Gets the parent document object
        /// </summary>
        IDocumentObject Parent { get; }

        /// <summary>
        /// Gets the children document object
        /// </summary>
        DocumentObjectCollection Children { get; }
    }
}
