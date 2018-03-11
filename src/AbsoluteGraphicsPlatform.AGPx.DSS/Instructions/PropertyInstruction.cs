// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.AGPx.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AbsoluteGraphicsPlatform.AGPx.Instructions
{
    public class PropertyInstruction : IInstruction
    {
        readonly string identifier;
        readonly ValueInstruction value;

        public PropertyInstruction(string identifier, ValueInstruction value)
        {
            this.identifier = identifier;
            this.value = value;
        }

        public string Identifier => identifier;
        public ValueInstruction Value => value;
    }
}
