// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace NextPlatform.Styling.Models
{
    public abstract class Block
    {
        public abstract BlockType BlockType { get; }

        public int Line { get; set; }
    }
}
