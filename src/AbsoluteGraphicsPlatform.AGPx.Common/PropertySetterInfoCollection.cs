// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class PropertySetterInfoCollection : IEnumerable<PropertySetterInfo>
    {
        readonly Dictionary<string, PropertySetterInfo> setterInfos;

        public PropertySetterInfoCollection()
        {
            setterInfos = new Dictionary<string, PropertySetterInfo>();
        }
        public PropertySetterInfoCollection(PropertySetterInfo[] setterInfos)
        {
            this.setterInfos = new Dictionary<string, PropertySetterInfo>();
            foreach (var declaration in setterInfos)
                this.setterInfos[declaration.PropertyName] = declaration;
        }


        public PropertySetterInfo this[string propertyName] => setterInfos[propertyName];

        /// <summary>
        /// Gets the number of declarations defined in the collection.
        /// </summary>
        public int Count => setterInfos.Count;

        /// <summary>
        /// Adds a new style declaration to the collection.
        /// </summary>
        /// <param name="declaration">The declaration to add.</param>
        public void Add(PropertySetterInfo declaration)
        {
            setterInfos.Add(declaration.PropertyName, declaration);
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
            return setterInfos.Remove(declaration.PropertyName);
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)setterInfos.Values).GetEnumerator();
        public IEnumerator<PropertySetterInfo> GetEnumerator() => setterInfos.Values.GetEnumerator();
    }
}
