// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    /// <summary>
    /// Represents a collection of elements.
    /// </summary>
    public interface IElementCollection : IEnumerable<IElement>
    {
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set</param>
        IElement this[int index] { get; }

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds a new element.
        /// </summary>
        /// <param name="element">The element to add.</param>
        void Add(IElement element);

        /// <summary>
        /// Adds a new element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set</param>
        void Insert(int index, IElement element);

        /// <summary>
        /// Removes the element from the collection.
        /// </summary>
        bool Remove(IElement element);
        /// <param name="element">The element to remove</param>

        /// <summary>
        /// Determines whether the collection contains the element
        /// </summary>
        /// <param name="element">The element to locate in the collection</param>
        /// <returns>true if element is found in the collection; otherwise false</returns>
        bool Contains(IElement element);

        /// <summary>
        //  Removes all elements.
        /// </summary>
        void Clear();
    }
}
