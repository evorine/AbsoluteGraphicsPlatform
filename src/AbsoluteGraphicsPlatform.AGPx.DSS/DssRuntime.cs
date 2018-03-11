// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.AGPx.Instructions;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class DssRuntime
    {
        readonly List<AsignmentInstruction> globalVariables;
        readonly List<RulesetInstruction> rulesets;

        public DssRuntime()
        {
            globalVariables = new List<AsignmentInstruction>();
        }

        public void SetGlobalVariable(AsignmentInstruction variableInstruction)
        {
            globalVariables.Add(variableInstruction);
        }

        public Expression GetVariableValue(string variableName)
        {
            return null;
        }
    }
}
