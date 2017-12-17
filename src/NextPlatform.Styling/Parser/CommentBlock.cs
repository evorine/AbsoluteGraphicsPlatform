// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace NextPlatform.Styling.Models
{
    public class CommentBlock : Block
    {
        public override BlockType BlockType => BlockType.Comment;

        public string Content { get; set; }
    }
}
