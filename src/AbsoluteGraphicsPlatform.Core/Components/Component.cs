// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Reflection;
using AbsoluteGraphicsPlatform.Abstractions.Components;

namespace AbsoluteGraphicsPlatform.Components
{
    public class Component : IComponent
    {
        private IComponent parent;

        public Component()
        {
            Components = new ComponentCollection(this);
        }

        public string Name { get; set; }


        public IComponent Parent
        {
            get => parent;
            set
            {
                parent = value;
                RegisteredComponentTree = parent?.RegisteredComponentTree;
            }
        }
        public IComponentTree RegisteredComponentTree { get; internal set; }

        public virtual void Emit(object payload)
        {
            Console.WriteLine("Emit: {0}", payload);
        }

        protected virtual void PropertyChanged(PropertyInfo property, object value)
        {
            Console.WriteLine("PropertyChanged: {0} = {1}", property.Name, value);
        }

        public IComponentCollection Components { get; }

        public ComponentMetaInfo ComponentMetaInfo { get; internal set; }

        public virtual bool EnableCustomRender => true;
    }
}
