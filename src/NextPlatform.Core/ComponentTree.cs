// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NextPlatform.Abstractions;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Controls.Abstractions;
using System.Linq;

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

        // TODO: Fix
        public IComponentFactory ComponentFactory { get; }
        public IEnumerable<IComponent> AllComponents => allComponents.AsEnumerable();
        public IEnumerable<IComponent> LeafComponents => leafComponents.AsEnumerable();
        public IComponent RootComponent
        {
            get => rootComponent;
            set
            {
                rootComponent = value;
                reStructure();
            }
        }

        
        private void reStructure()
        {
            allComponents.Clear();
            leafComponents.Clear();
            setAllAndLeafComponents(rootComponent);
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
    }
}
