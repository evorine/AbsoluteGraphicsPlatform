// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NextPlatform.Abstractions;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Controls.Abstractions;
using System.Linq;

namespace NextPlatform.Core
{
    public class ComponentTree : IComponentTree
    {
        IList<IComponent> rootComponents;
        IList<IComponent> allComponents;
        IList<IComponent> leafComponents;

        public ComponentTree()
        {
            ComponentFactory = new ComponentFactory(this);
            rootComponents = new List<IComponent>();
            allComponents = new List<IComponent>();
            leafComponents = new List<IComponent>();
        }

        // TODO: Fix
        public IComponentFactory ComponentFactory { get; }
        public IEnumerable<IComponent> AllComponents => allComponents.AsEnumerable();
        public IEnumerable<IComponent> RootComponents => rootComponents.AsEnumerable();
        public IEnumerable<IComponent> LeafComponents => leafComponents.AsEnumerable();


        public void AppendRootComponent(IComponent component)
        {
            rootComponents.Add(component);
            Recalculate();
        }

        public void Recalculate()
        {
            allComponents.Clear();
            leafComponents.Clear();
            setAllAndLeafs(rootComponents);
        }

        private void setAllAndLeafs(IEnumerable<IComponent> components)
        {
            foreach(var component in components)
            {
                allComponents.Add(component);
                if (!component.Components.Any())
                    leafComponents.Add(component);
                else
                    setAllAndLeafs(component.Components); 
            }
        }
    }
}
