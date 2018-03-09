// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions.Styling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.AGPx.Models
{
    public class Stylesheet : IStyle
    {
        readonly IList<Ruleset> rulesets;
        readonly IList<AsignmentStatement> globalVariableStatements;

        public Stylesheet()
        {
            rulesets = new List<Ruleset>();
            globalVariableStatements = new List<AsignmentStatement>();
        }

        public IEnumerable<Ruleset> Rulesets => rulesets.AsEnumerable();

        public IEnumerable<string> GlobalVariables => globalVariableStatements.Select(x => x.VariableName).Distinct();

        public void AddRuleset(Ruleset ruleset) => rulesets.Add(ruleset);
        public void AddGlobalVariable(AsignmentStatement asignment) => globalVariableStatements.Add(asignment);
    }
}
