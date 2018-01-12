// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    public class Stylesheet
    {
        readonly Ruleset[] rulesets;

        public Stylesheet()
        {
            rulesets = new Ruleset[0];
        }
        public Stylesheet(Ruleset[] rulesets)
        {
            this.rulesets = rulesets;
        }

        public IEnumerable<Ruleset> Rulesets
        {
            get { return Rulesets.AsEnumerable(); }
        }
    }
}
