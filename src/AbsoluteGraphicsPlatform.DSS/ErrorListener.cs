// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class ErrorListener : BaseErrorListener
    {
        private string stylesheetSourceName;

        public ErrorListener(string stylesheetSourceName)
        {
            this.stylesheetSourceName = stylesheetSourceName;
        }

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (e is NoViableAltException noViableAlt)
                throw new DSSParserException($"Unexpected token '{noViableAlt.OffendingToken.Text}' found after '{noViableAlt.StartToken.Text}'.", line, stylesheetSourceName);
            if (e is InputMismatchException inputMismatch)
                throw new DSSParserException(msg, line, stylesheetSourceName); // TODO: Customize error message
            else
                throw new NotImplementedException(e.GetType().Name);
        }
    }
}
