// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NextPlatform.Abstractions;
using NextPlatform.Abstractions.Components;
using System.Collections;
using System.Collections.Generic;

namespace NextPlatform
{
    public class ComponentCollection : IComponentCollection
    {
        readonly List<IComponent> componentList;

        public ComponentCollection()
        {
            componentList = new List<IComponent>();
        }

        public int Count => componentList.Count;

        public void Append(IComponent component)
        {
            componentList.Add(component);
        }

        public void Clear()
        {
            componentList.Clear();
        }

        public bool Contains(IComponent item)
        {
            return componentList.Contains(item);
        }

        public bool Remove(IComponent item)
        {
            return componentList.Remove(item);
        }

        public IEnumerator<IComponent> GetEnumerator()
        {
            return componentList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)componentList).GetEnumerator();
        }
    }
}
