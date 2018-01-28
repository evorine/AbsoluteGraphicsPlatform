// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform
{
    public class TemplateNotFoundException : Exception
    {
        public TemplateNotFoundException(Type componentType)
            : base($"Component template for component with type '{componentType.Name}' is not found!")
        {
        }
    }
}
