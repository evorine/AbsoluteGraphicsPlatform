// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public interface IDocumentObjectCollection : IEnumerable<IDocumentObject>
    {
        /// <summary>
        /// Gets the number of document objects.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds a new document object.
        /// </summary>
        /// <param name="item">The document object to add.</param>
        void Add(IDocumentObject item);

        /// <summary>
        //  Removes all document objects.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines whether the collection contains the document object
        /// </summary>
        /// <param name="item">The document object to locate in the collection</param>
        /// <returns>true if item is found in the collection; otherwise false</returns>
        bool Contains(IDocumentObject item);

        /// <summary>
        /// Removes the document object from the collection.
        /// </summary>
        /// <param name="item">The object to remove</param>
        bool Remove(IDocumentObject item);
    }
}
