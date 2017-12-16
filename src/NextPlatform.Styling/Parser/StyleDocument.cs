// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Styling.Parser
{
    public class StyleDocument
    {
        public string Filename { get; set; }

        public IEnumerable<Block> Blocks { get; set; }
    }
}
