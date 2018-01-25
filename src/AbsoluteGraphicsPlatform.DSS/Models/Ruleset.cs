// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    public class Ruleset : Statement
    {
        public Ruleset()
        {
            PropertySetters = new PropertySetterInfoCollection();
        }
        public Ruleset(PropertySetterInfo[] declarations)
        {
            PropertySetters = new PropertySetterInfoCollection(declarations);
        }

        public PropertySetterInfoCollection PropertySetters { get; }

        public RuleSelector Selector { get; set; }
    }
}
