// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    /// <summary>
    /// Represents a collection of document objects.
    /// </summary>
    public class DocumentObjectCollection : IEnumerable<IDocumentObject>
    {
        readonly IList<IDocumentObject> documentObjects;

        public DocumentObjectCollection()
        {
            documentObjects = new List<IDocumentObject>();
        }


        /// <summary>
        /// Gets or sets the document object at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the document object to get or set</param>
        public IDocumentObject this[int index] => documentObjects[index];

        /// <summary>
        /// Gets the number of document objects.
        /// </summary>
        public int Count => documentObjects.Count;

        /// <summary>
        /// Determines whether the collection contains the document object
        /// </summary>
        /// <param name="item">The document object to locate in the collection</param>
        /// <returns>true if item is found in the collection; otherwise false</returns>
        public bool Contains(IDocumentObject item) => documentObjects.Contains(item);

        /// <summary>
        /// Adds a new document object.
        /// </summary>
        /// <param name="item">The document object to add.</param>
        public void Add(IDocumentObject item) => documentObjects.Add(item);

        /// <summary>
        /// Removes the document object from the collection.
        /// </summary>
        /// <param name="item">The object to remove</param>
        public bool Remove(IDocumentObject item) => documentObjects.Remove(item);
        
        /// <summary>
        //  Removes all document objects.
        /// </summary>
        public void Clear() => documentObjects.Clear();


        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        public IEnumerator<IDocumentObject> GetEnumerator() => documentObjects.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)documentObjects).GetEnumerator();
    }
}
