// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.AGPx.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx.Instructions
{
    public class AsignmentInstruction : IInstruction
    {
        readonly string variableName;
        readonly ValueInstruction value;

        public AsignmentInstruction(string variableName, ValueInstruction value)
        {
            this.variableName = variableName;
            this.value = value;
        }
    }
}
