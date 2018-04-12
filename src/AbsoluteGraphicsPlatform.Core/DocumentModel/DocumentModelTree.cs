// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class DocumentModelTree : IDocumentModelTree
    {
        readonly IDocumentModelEngine documentModelEngine;

        public DocumentModelTree(IDocumentModelEngine documentModelEngine)
        {
            this.documentModelEngine = documentModelEngine;
        }

        /// <summary>
        /// Gets or sets the owner of this document model.
        /// </summary>
        public IComponent OwnerComponent { get; set; }

        /// <summary>
        /// Gets or sets the root document object.
        /// </summary>
        public IDocumentObject RootDocumentObject { get; set; }

        /// <summary>
        /// Gets or sets the all document objects recursively under this document model.
        /// </summary>
        public IEnumerable<IDocumentObject> AllDocumentObjects => throw new NotImplementedException();

        /// <summary>
        /// Recalculates the structure of the document model.
        /// </summary>
        public void Restructure() => documentModelEngine.Restructure(this);
    }
}
