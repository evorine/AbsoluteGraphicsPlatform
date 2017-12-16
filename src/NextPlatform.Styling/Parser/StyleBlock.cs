﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace NextPlatform.Styling.Parser
{
    public class StyleBlock : Block
    {
        public StyleBlock()
        {

        }

        public override BlockType BlockType => BlockType.Style;

        public IEnumerable<StylePropertySetter> Items { get; set; }

        public StyleSelector Selector { get; set; }
    }
}
