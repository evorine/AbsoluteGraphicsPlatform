// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Components;
using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public interface IDocumentModelEngine
    {
        /// <summary>
        /// Creates a new <see cref="IDocumentModelTree"/> for specified component.
        /// </summary>
        /// <param name="ownerComponent">Owner of the newly created <see cref="IDocumentModelTree"/></param>
        IDocumentModelTree CreateNewTree(IComponent ownerComponent);

        /// <summary>
        /// Calculates the structure of the document model.
        /// </summary>
        /// <param name="documentModel">Document model to recalculate</param>
        void Restructure(IDocumentModelTree documentModel);
    }
}
