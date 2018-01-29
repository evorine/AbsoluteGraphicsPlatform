// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Components;
using System.Collections;

namespace AbsoluteGraphicsPlatform
{
    public class ComponentCollection : IComponentCollection
    {
        bool isDirty;
        IList<IComponent> childrenComponentList;

        public ComponentCollection(IComponent component)
        {
            Component = component;
            childrenComponentList = new List<IComponent>();
            isDirty = true;
        }

        /// <summary>
        /// Finds and returns all components recursively.
        /// </summary>
        public IEnumerable<IComponent> FindAllComponents() => throw new NotImplementedException();

        /// <summary>
        /// Gets the instance of the root component: The owner of the component template.
        /// </summary>
        public IComponent RootComponent => Parent == null ? Component : Parent.Components.RootComponent;

        /// <summary>
        /// Gets the parent instance of <see cref="Component"/> in the component template.
        /// </summary>
        public IComponent Parent { get; set; }

        /// <summary>
        /// Gets the component instance of which this tree targets.
        /// </summary>
        public IComponent Component { get; }

        
        public IComponent this[int index] => childrenComponentList[index];

        public int Count => childrenComponentList.Count;

        public void Add(IComponent component)
        {
            childrenComponentList.Add(component);
            component.Parent = component;
            MarkAsDirty();
        }

        public void Insert(int index, IComponent component)
        {
            childrenComponentList.Insert(index, component);
            component.Parent = component;
            MarkAsDirty();
        }

        public void Clear()
        {
            foreach (var component in childrenComponentList)
                component.Parent = null;
            childrenComponentList.Clear();
            MarkAsDirty();
        }

        public bool Contains(IComponent item) => childrenComponentList.Contains(item);

        public bool Remove(IComponent item)
        {
            if (childrenComponentList.Remove(item))
            {
                item.Parent = null;
                MarkAsDirty();
                return true;
            }
            else return false;
        }


        public void Restructure()
        {
            if (isDirty)
            {
                isDirty = false;
            }
        }

        public void MarkAsDirty()
        {
            isDirty = true;
        }

        public IEnumerator<IComponent> GetEnumerator() => childrenComponentList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)childrenComponentList).GetEnumerator();
    }
}
