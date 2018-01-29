// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.Components
{
    public class Component : IComponent
    {
        public Component()
        {
            Children = new ComponentCollection();
            ComponentTree = new ComponentTree(this);
        }

        public string Name { get; set; }
        public ComponentMetaInfo ComponentMetaInfo { get; internal set; }
        public IComponent Parent { get; set; }



        public string ContainerScope { get; set; }
        public IComponentCollection Children { get; }

        public IComponentTree ComponentTree { get; }

        public virtual bool UseTemplate => false;


        protected virtual void PropertyChanged(PropertyInfo property, object value)
        {
            Console.WriteLine("PropertyChanged: {0} = {1}", property.Name, value);
        }


        public virtual void Emit(object payload)
        {
            Console.WriteLine("Emit: {0}", payload);
        }

        public override string ToString() => $"Component: '{ComponentMetaInfo.ComponentType.Name}'";
    }
}
