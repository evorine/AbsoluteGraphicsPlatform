﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Styling;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform
{
    public class AgpxOptions
    {
        public AgpxOptions()
        {
            Styles = new StyleCollection();
            ComponentTemplates = new ComponentTemplateCollection();
        }

        public StyleCollection Styles { get; }
        public ComponentTemplateCollection ComponentTemplates { get; }
    }
}
