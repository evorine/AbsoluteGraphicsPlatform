// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentCollection : IComponentCollection
    {
        IList<IComponent> childrenComponentList;

        public ComponentCollection()
        {
            childrenComponentList = new List<IComponent>();
        }

        public IComponent this[int index] => childrenComponentList[index];

        public int Count => childrenComponentList.Count;

        public void Add(IComponent component)
        {
            childrenComponentList.Add(component);
            component.Parent = component;
        }

        public void Insert(int index, IComponent component)
        {
            childrenComponentList.Insert(index, component);
            component.Parent = component;
        }

        public void Clear()
        {
            foreach (var component in childrenComponentList)
                component.Parent = null;
            childrenComponentList.Clear();
        }

        public bool Contains(IComponent item) => childrenComponentList.Contains(item);

        public bool Remove(IComponent item)
        {
            if (childrenComponentList.Remove(item))
            {
                item.Parent = null;
                return true;
            }
            else return false;
        }

        public IEnumerator<IComponent> GetEnumerator() => childrenComponentList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)childrenComponentList).GetEnumerator();

        public override string ToString() => $"ComponentCollection: {Count} item{(Count > 1 ? "s" : "")}";
    }
}
