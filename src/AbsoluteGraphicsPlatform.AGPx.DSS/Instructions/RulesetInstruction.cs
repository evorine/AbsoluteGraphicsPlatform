// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.AGPx.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx.Instructions
{
    public class RulesetInstruction : IInstruction
    {
        readonly List<IInstruction> instructions;

        public RulesetInstruction()
        {
            instructions = new List<IInstruction>();
        }

        public IList<IInstruction> Instructions => instructions;

        public RuleSelector Selector { get; set; }

        public RulesetInstruction ParentRuleset { get; set; }
    }
}
