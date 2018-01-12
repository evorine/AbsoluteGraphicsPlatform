// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    public class StylePropertySetterCollection : ICollection<StylePropertySetter>
    {
        readonly ICollection<StylePropertySetter> declarations;

        public StylePropertySetterCollection()
        {
            declarations = new Collection<StylePropertySetter>();
        }
        public StylePropertySetterCollection(StylePropertySetter[] declarations)
        {
            this.declarations = new Collection<StylePropertySetter>(declarations.ToList());
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
        public void Add(StylePropertySetter declaration)
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
        public bool Remove(StylePropertySetter declaration)
        {
            return declarations.Remove(declaration);
        }

        bool ICollection<StylePropertySetter>.Contains(StylePropertySetter item) => declarations.Contains(item);
        void ICollection<StylePropertySetter>.CopyTo(StylePropertySetter[] array, int arrayIndex) => declarations.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)declarations).GetEnumerator();
        public IEnumerator<StylePropertySetter> GetEnumerator() => declarations.GetEnumerator();
    }
}
