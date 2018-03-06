// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform
{
    public class ComponentNotFoundException : Exception
    {
        public ComponentNotFoundException(string componentName)
            : base($"Component '{componentName}' is not found!")
        {
        }
    }
}
