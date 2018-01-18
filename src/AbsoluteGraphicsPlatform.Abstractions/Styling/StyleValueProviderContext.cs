// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using System.Reflection;
using AbsoluteGraphicsPlatform.DynamicProperties;

namespace AbsoluteGraphicsPlatform.Abstractions.Styling
{
    public class StyleValueProviderContext
    {
        public StyleValueProviderContext(IComponent component, PropertyInfo property, IPropertyValue value)
        {
            Component = component;
            Property = property;
            Value = value;
        }

        public IComponent Component { get; }
        public PropertyInfo Property { get; }
        public IPropertyValue Value { get; }
    }
}
