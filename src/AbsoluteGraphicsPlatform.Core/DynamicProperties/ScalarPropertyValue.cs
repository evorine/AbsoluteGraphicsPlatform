// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DynamicProperties
{
    public sealed class ScalarPropertyValue : IPropertyValue
    {
        public ScalarPropertyValue(float value)
        {
            Value = value;
        }

        public float Value { get; }
    }
}
