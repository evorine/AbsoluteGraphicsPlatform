// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.Components
{
    public class Component : Element, IComponent
    {
        public Component()
        {
            ElementTree = new ElementTree(this);
        }


        /// <summary>
        /// Gets metadata of the component type
        /// </summary>
        public ComponentMetaInfo ComponentMetaInfo { get; internal set; }

        /// <summary>
        /// Gets the own element tree of this component instance.
        /// </summary>
        public IElementTree ElementTree { get; }

        public virtual bool UseTemplate => false;


        /// <summary>
        /// Emits an event to it's parent.
        /// </summary>
        /// <param name="payload">The payload to send.</param>
        public virtual void Emit(object payload)
        {
            Console.WriteLine("Emit: {0}", payload);
        }

        protected virtual void PropertyChanged(PropertyInfo property, object value)
        {
            Console.WriteLine("PropertyChanged: {0} = {1}", property.Name, value);
        }


        public override string ToString() => $"Component: '{ComponentMetaInfo.ComponentType.Name}'";
    }
}
