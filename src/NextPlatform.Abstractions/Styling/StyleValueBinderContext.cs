// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Abstractions.Components;
using System.Reflection;

namespace NextPlatform.Abstractions.Styling
{
    public class StyleValueBinderContext
    {
        public StyleValueBinderContext(IComponent component, PropertyInfo property, string rawValue)
        {
            Component = component;
            Property = property;
            RawValue = rawValue;
        }

        public IComponent Component { get; }
        public PropertyInfo Property { get; }
        public string RawValue { get; }
    }
}
