// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentNameAttribute : Attribute
    {
        public ComponentNameAttribute(string componentName)
        {
            ComponentName = componentName;
            HasNamespace = true;
        }

        public ComponentNameAttribute(string componentName, bool hasNamespace)
        {
            ComponentName = componentName;
            HasNamespace = hasNamespace;
        }

        public string ComponentName { get; }
        public bool HasNamespace { get; }
    }
}
