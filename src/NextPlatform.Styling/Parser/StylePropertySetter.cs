// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextPlatform.Styling.Parser
{
    public class StylePropertySetter
    {
        public StylePropertySetter(string property, string rawValue)
        {
            Property = property;
            RawValue = rawValue;
        }

        public string Property { get; }
        public string RawValue { get; }

        public virtual void Apply(IComponent component)
        {
            var property = component.GetType().GetProperty(Property);
            if (property != null)
            {
                var attributes = Attribute.GetCustomAttributes(property, typeof(ComponentPropertyAttribute), true);
                if (attributes.Any())
                {
                    property.SetValue(component, RawValue);
                }
            }
        }
    }
}
