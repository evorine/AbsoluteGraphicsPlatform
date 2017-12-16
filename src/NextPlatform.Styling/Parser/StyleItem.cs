// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextPlatform.Styling.Parser
{
    public class StyleItem
    {
        public StyleItem(string property, string value)
        {
            Property = property;
            Value = value;
        }

        public string Property { get; }
        public string Value { get; }

        public virtual void Apply(IComponent component)
        {
            var property = component.GetType().GetProperty(Property);
            if (property != null)
            {
                var attributes = Attribute.GetCustomAttributes(property, typeof(ComponentPropertyAttribute), true);
                if (attributes.Any())
                {
                    property.SetValue(component, Value);
                }
            }
        }
    }
}
