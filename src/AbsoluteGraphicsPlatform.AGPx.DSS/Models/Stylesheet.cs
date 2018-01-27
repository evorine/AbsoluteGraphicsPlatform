﻿// Licensed under the MIT license.
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

        public Stylesheet()
        {
            rulesets = new List<Ruleset>();
        }

        public IEnumerable<Ruleset> Rulesets => rulesets.AsEnumerable();

        public IEnumerable<Variable> GlobalVariables => throw new NotImplementedException();

        public void AddRuleset(Ruleset ruleset) => rulesets.Add(ruleset);
    }
}