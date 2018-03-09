// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Collections.Generic;
using Antlr4.Runtime;

namespace AbsoluteGraphicsPlatform.AGPx
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
                throw new AGPxException($"Unexpected token '{noViableAlt.OffendingToken.Text}' found after '{noViableAlt.StartToken.Text}'.", line, stylesheetSourceName);
#warning TODO: Customize message
            if (e is InputMismatchException inputMismatch)
                throw new AGPxException(msg, line, stylesheetSourceName); // TODO: Customize error message
            else
                throw new NotImplementedException(e?.GetType()?.Name ?? msg);
        }
    }
}
