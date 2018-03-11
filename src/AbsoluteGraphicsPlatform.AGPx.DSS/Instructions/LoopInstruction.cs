// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.AGPx.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx.Instructions
{
    public class LoopInstruction : IInstruction
    {
        readonly string valueVariableName;
        readonly string indexVariableName;
        readonly ValueInstruction listValue;

        public LoopInstruction(string valueVariableName, string indexVariableName, ValueInstruction listValue)
        {
            this.valueVariableName = valueVariableName;
            this.indexVariableName = indexVariableName;
            this.listValue = listValue;
        }
    }
}
