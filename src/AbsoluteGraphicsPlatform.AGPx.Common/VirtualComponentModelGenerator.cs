// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class VirtualComponentModelGenerator
    {
        public VirtualComponentModelGenerator(ComponentTemplate[] componentTemplates)
        {
            AllComponentTemplates = componentTemplates;
        }

        public ComponentTemplate[] AllComponentTemplates { get; }

        public IVirtualComponentModel ProcessTemplate(ComponentTemplate template)
        {
            return null;
        }
    }
}
