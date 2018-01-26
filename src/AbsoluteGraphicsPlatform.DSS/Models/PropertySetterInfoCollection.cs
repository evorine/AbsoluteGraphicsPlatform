// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.DynamicProperties;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    public class PropertySetterInfoCollection : ICollection<PropertySetterInfo>
    {
        readonly Dictionary<string, PropertySetterInfo> declarations;

        public PropertySetterInfoCollection()
        {
            declarations = new Dictionary<string, PropertySetterInfo>();
        }
        public PropertySetterInfoCollection(PropertySetterInfo[] declarations)
        {
            this.declarations = new Dictionary<string, PropertySetterInfo>();
            foreach (var declaration in declarations)
                this.declarations[declaration.PropertyName] = declaration;
        }


        public PropertySetterInfo this[string propertyName] => declarations[propertyName];

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
        public void Add(PropertySetterInfo declaration)
        {
            declarations.Add(declaration.PropertyName, declaration);
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
        public bool Remove(PropertySetterInfo declaration)
        {
            return declarations.Remove(declaration.PropertyName);
        }

        bool ICollection<PropertySetterInfo>.Contains(PropertySetterInfo declaration) => declarations.ContainsValue(declaration);
        void ICollection<PropertySetterInfo>.CopyTo(PropertySetterInfo[] array, int arrayIndex) => declarations.Values.CopyTo(array, arrayIndex);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)declarations.Values).GetEnumerator();
        public IEnumerator<PropertySetterInfo> GetEnumerator() => declarations.Values.GetEnumerator();
    }
}
