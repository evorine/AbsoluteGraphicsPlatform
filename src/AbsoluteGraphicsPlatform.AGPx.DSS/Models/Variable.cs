// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx.Models
{
    public class Variable
    {
        public Variable(string name, IPropertyValue value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public IPropertyValue Value { get; }
    }
}
