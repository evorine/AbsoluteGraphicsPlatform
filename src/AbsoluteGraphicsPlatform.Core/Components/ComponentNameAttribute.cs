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
        }

        public string ComponentName { get; }
    }
}
