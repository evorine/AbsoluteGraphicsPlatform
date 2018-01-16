// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform
{
    public class ComponentTree : IComponentTree
    {
        bool isDirty;
        IComponent rootComponent;
        IList<IComponent> allComponents;
        IList<IComponent> leafComponents;

        public ComponentTree()
        {
            allComponents = new List<IComponent>();
            leafComponents = new List<IComponent>();
            isDirty = true;
        }
        
        public IEnumerable<IComponent> AllComponents => allComponents.AsEnumerable();
        public IEnumerable<IComponent> LeafComponents => leafComponents.AsEnumerable();
        public IComponent RootComponent
        {
            get => rootComponent;
            set
            {
                if (rootComponent != null && rootComponent is Component oldComponent)
                    oldComponent.RegisteredComponentTree = null;

                rootComponent = value;
                // Maybe setting RegisteredComponentTree by casting to Compoentn is a bad idea.
                // A custom implementation of IComponent's ComponentTree won't be set automatcally as happening here.
                // This might be unexpected and lead to bug.
                if (rootComponent is Component component)
                    component.RegisteredComponentTree = this;

                isDirty = true;
            }
        }

        public void Restructure()
        {
            if (isDirty)
            {
                allComponents.Clear();
                leafComponents.Clear();
                setAllAndLeafComponents(rootComponent);
                isDirty = false;
            }
        }

        private void setAllAndLeafComponents(IComponent component)
        {
            allComponents.Add(component);
            if (!component.Components.Any()) leafComponents.Add(component);
            else
            {
                foreach (var child in component.Components)
                    setAllAndLeafComponents(child);
            }
        }


        public void MarkAsDirty()
        {
            isDirty = true;
        }
    }
}
