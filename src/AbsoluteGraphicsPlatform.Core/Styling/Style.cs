// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using AbsoluteGraphicsPlatform.Styling;

namespace AbsoluteGraphicsPlatform.Styling
{
    public class Style
    {
        readonly RuleSet[] ruleSets;

        public Style()
        {
            ruleSets = new RuleSet[0];
        }
        public Style(RuleSet[] ruleSets)
        {
            this.ruleSets = ruleSets;
        }

        public IEnumerable<RuleSet> RuleSets
        {
            get { return RuleSets.AsEnumerable(); }
        }
    }
}
