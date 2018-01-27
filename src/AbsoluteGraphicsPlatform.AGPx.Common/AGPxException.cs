// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace AbsoluteGraphicsPlatform
{
    public class AGPxException : Exception
    {
        readonly int line;

        public AGPxException(string message)
            : this(message, -1, "NOT_IMPLEMENTED")
        {

        }
        public AGPxException(string message, int line, string source)
            : base(message)
        {
            this.line = line;
            Source = source;
        }

        public int Line => line;
    }
}
