// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    public class Ruleset
    {
        public Ruleset()
        {
            PropertySetters = new StylePropertySetterCollection();
        }
        public Ruleset(StylePropertySetter[] declarations)
        {
            PropertySetters = new StylePropertySetterCollection(declarations);
        }

        public StylePropertySetterCollection PropertySetters { get; }

        public RuleSelector Selector { get; set; }
    }
}
