// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Components;

namespace AbsoluteGraphicsPlatform
{
    public class ComponentCollection : IComponentCollection
    {
        private readonly IComponent owner;
        private readonly List<IComponent> componentList;

        public ComponentCollection(IComponent owner)
        {
            this.owner = owner;
            componentList = new List<IComponent>();
        }

        public int Count => componentList.Count;

        public void Append(IComponent component)
        {
            componentList.Add(component);
            component.Parent = owner;
            owner.RegisteredComponentTree.MarkAsDirty();
        }

        public void Clear()
        {
            foreach (var component in componentList)
                component.Parent = null;
            componentList.Clear();
            owner.RegisteredComponentTree.MarkAsDirty();
        }

        public bool Contains(IComponent item)
        {
            return componentList.Contains(item);
        }

        public bool Remove(IComponent item)
        {
            if (componentList.Remove(item))
            {
                item.Parent = null;
                owner.RegisteredComponentTree.MarkAsDirty();
                return true;
            }
            else return false;
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
