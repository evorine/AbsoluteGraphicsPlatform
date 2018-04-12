// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    /// <summary>
    /// Represents an <see cref="IElement"/> in a <see cref="IDocumentModelTree"/>.
    /// </summary>
    public class DocumentObject : IDocumentObject
    {
        public DocumentObject(IDocumentModelTree ownerDocumentModelTree)
        {
            OwnerDocumentModel = ownerDocumentModelTree;
            Children = new DocumentObjectCollection();
        }

        /// <summary>
        /// Gets the owner document model tree
        /// </summary>
        public IDocumentModelTree OwnerDocumentModel { get; }

        /// <summary>
        /// Gets or sets the owner element of this document object
        /// </summary>
        public IElement Element { get; set; }

        /// <summary>
        /// Gets or sets the parent document object
        /// </summary>
        public IDocumentObject Parent { get; set; }

        /// <summary>
        /// Gets the children document object
        /// </summary>
        public DocumentObjectCollection Children { get; }
    }
}
