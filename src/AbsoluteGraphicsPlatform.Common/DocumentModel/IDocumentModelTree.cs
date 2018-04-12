// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public interface IDocumentModelTree
    {
        /// <summary>
        /// Gets the owner of this document model.
        /// </summary>
        IComponent OwnerComponent { get; }

        /// <summary>
        /// Gets the root document object.
        /// </summary>
        IDocumentObject RootDocumentObject { get; }

        /// <summary>
        /// Gets the all document objects recursively under this document model.
        /// </summary>
        IEnumerable<IDocumentObject> AllDocumentObjects { get; }

        /// <summary>
        /// Recalculates the structure of the document model.
        /// </summary>
        void Restructure();
    }
}
