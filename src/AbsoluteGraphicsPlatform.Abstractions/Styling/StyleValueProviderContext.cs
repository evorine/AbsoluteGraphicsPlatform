// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Components;
using System.Reflection;

namespace AbsoluteGraphicsPlatform.Abstractions.Styling
{
    public class StyleValueProviderContext
    {
        public StyleValueProviderContext(IComponent component, PropertyInfo property, IPropertyValue[] values)
        {
            Component = component;
            Property = property;
            Values = values;
        }

        public IComponent Component { get; }
        public PropertyInfo Property { get; }
        public IPropertyValue[] Values { get; }
    }
}
