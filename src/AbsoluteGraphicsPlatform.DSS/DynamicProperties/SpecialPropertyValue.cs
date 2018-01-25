﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.DynamicProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DynamicProperties
{
    public sealed class PropertyValue : IPropertyValue
    {
        readonly string value;

        public static PropertyValue None = new PropertyValue("none");

        private PropertyValue(string value)
        {
            this.value = value;
        }

        public override string ToString() => value;
    }
}
