// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using AbsoluteGraphicsPlatform.Abstractions.Components;

namespace AbsoluteGraphicsPlatform.Components
{
    public class Component : IComponent
    {
        readonly ComponentCollection componentTree;

        public Component()
        {
            componentTree = new ComponentCollection(this);
        }

        public string Name { get; set; }


        public IComponent Parent
        {
            get => componentTree.Parent;
            set => componentTree.Parent = value;
        }

        public virtual void Emit(object payload)
        {
            Console.WriteLine("Emit: {0}", payload);
        }

        protected virtual void PropertyChanged(PropertyInfo property, object value)
        {
            Console.WriteLine("PropertyChanged: {0} = {1}", property.Name, value);
        }

        public IComponentCollection Components => componentTree;

        public ComponentMetaInfo ComponentMetaInfo { get; internal set; }

        public virtual bool UseTemplate => false;
    }
}
