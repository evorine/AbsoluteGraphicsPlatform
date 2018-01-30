// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public sealed class PropertyValue : IPropertyValue
    {
        readonly string value;

        public static PropertyValue None = new PropertyValue("none");
        public static PropertyValue Fill = new PropertyValue("fill");

        private PropertyValue(string value)
        {
            this.value = value;
        }

        public override string ToString() => value;
    }
}
