// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Components
{
    [ComponentName("template", false)]
    public class TemplateComponent : Component, ITemplatelessComponent
    {
        [ComponentProperty]
        public string Scope { get; set; }
    }
}
