// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NextPlatform.Abstractions;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Abstractions.Components;
using System.Linq;
using NextPlatform.Components;

namespace NextPlatform
{
    public class ComponentTree : IComponentTree
    {
        IComponent rootComponent;
        IList<IComponent> allComponents;
        IList<IComponent> leafComponents;

        public ComponentTree()
        {
            ComponentFactory = new ComponentFactory(this);
            allComponents = new List<IComponent>();
            leafComponents = new List<IComponent>();
        }

        public IComponentFactory ComponentFactory { get; }
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

                Restructure();
            }
        }

        public void Restructure()
        {
            allComponents.Clear();
            leafComponents.Clear();
            setAllAndLeafComponents(rootComponent);
        }

        private void setAllAndLeafComponents(IComponent component)
        {
            allComponents.Append(component);
            if (!component.Components.Any()) leafComponents.Append(component);
            else
            {
                foreach (var child in component.Components)
                    setAllAndLeafComponents(child);
            }
        }
    }
}
