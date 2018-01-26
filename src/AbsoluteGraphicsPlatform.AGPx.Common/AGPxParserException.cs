// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform
{
    public class AGPxParserException : Exception
    {
        readonly int line;

        public AGPxParserException(string message)
            : this(message, -1, "NOT_IMPLEMENTED")
        {

        }
        public AGPxParserException(string message, int line, string source)
            : base(message)
        {
            this.line = line;
            Source = source;
        }

        public int Line => line;
    }
}
