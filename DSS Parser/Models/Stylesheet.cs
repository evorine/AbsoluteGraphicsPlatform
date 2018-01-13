// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    public class Stylesheet
    {
        readonly IList<Ruleset> rulesets;

        public Stylesheet()
        {
            rulesets = new List<Ruleset>();
        }

        public IEnumerable<Ruleset> Rulesets => rulesets.AsEnumerable();

        public void AddRuleset(Ruleset ruleset) => rulesets.Add(ruleset);
    }
}
