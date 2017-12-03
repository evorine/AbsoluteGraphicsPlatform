﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Controls.Abstractions;
using NextPlatform.Core;
using System;
using System.Reflection;

namespace NextPlatform.Controls
{
    public class Component : IComponent
    {
        public Component()
        {
            Components = new ComponentCollection();
        }

        public string Name { get; set; }

        public IComponent Parent { get; set; }

        public virtual void Emit(object payload)
        {
            Console.WriteLine("Emit: {0}", payload);
        }

        protected virtual void PropertyChanged(PropertyInfo property, object value)
        {
            Console.WriteLine("PropertyChanged: {0} = {1}", property.Name, value);
        }

        public IComponentCollection Components { get; }
    }
}