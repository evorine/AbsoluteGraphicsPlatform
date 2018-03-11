// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.AGPx.Instructions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx.Instructions
{
    public class ValueInstruction : IInstruction
    {
        readonly Expression[] values;

        public ValueInstruction(Expression value)
        {
            values = new Expression[] { value };
        }
        public ValueInstruction(Expression[] values)
        {
            this.values = values;
        }


        public Expression[] Values => values;

        public bool IsTuple => values.Length > 1;
    }
}
