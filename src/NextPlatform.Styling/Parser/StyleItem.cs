// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Styling.Parser
{
    public class StyleItem
    {
        public StyleItem(string property, string value)
        {
            Property = property;
            Value = value;
        }

        public string Property { get; }
        public string Value { get; }
    }
}
