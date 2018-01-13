using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class DSSParserException : Exception
    {
        readonly int line;

        public DSSParserException(string message, int line, string source)
            : base(message)
        {
            this.line = line;
            Source = source;
        }

        public int Line => line;
    }
}
