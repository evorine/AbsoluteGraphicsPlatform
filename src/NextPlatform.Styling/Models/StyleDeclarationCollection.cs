// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NextPlatform.Styling
{
    public class StyleDeclarationCollection : ICollection<StyleDeclaration>
    {
        readonly ICollection<StyleDeclaration> declarations;

        public StyleDeclarationCollection()
        {
            declarations = new Collection<StyleDeclaration>();
        }

        /// <summary>
        /// Gets the number of declarations defined in the collection.
        /// </summary>
        public int Count => declarations.Count;

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds a new style declaration to the collection.
        /// </summary>
        /// <param name="declaration">The declaration to add.</param>
        public void Add(StyleDeclaration declaration)
        {
            declarations.Add(declaration);
        }

        /// <summary>
        /// Removes all declarations from the collection.
        /// </summary>
        public void Clear()
        {
            declarations.Clear();
        }

        /// <summary>
        /// Removes a declaration from the collection.
        /// </summary>
        /// <param name="declaration">The declaration to remove from the collection.</param>
        /// <returns>
        /// true if <paramref name="declaration">item</paramref> was successfully removed from the collection; otherwise, false.
        /// This method also returns false if <paramref name="declaration">item</paramref> is not found in the collection.
        /// </returns>
        public bool Remove(StyleDeclaration declaration)
        {
            return declarations.Remove(declaration);
        }

        bool ICollection<StyleDeclaration>.Contains(StyleDeclaration item) => declarations.Contains(item);
        void ICollection<StyleDeclaration>.CopyTo(StyleDeclaration[] array, int arrayIndex) => declarations.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)declarations).GetEnumerator();
        public IEnumerator<StyleDeclaration> GetEnumerator() => declarations.GetEnumerator();
    }
}
