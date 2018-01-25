﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.DynamicProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    public class Variable
    {
        public string Name { get; }
        public IPropertyValue Value { get; }
    }
}
