// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.DSS.Models;
using AbsoluteGraphicsPlatform.DSS.Visitors;
using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class StyleParser
    {
        public Stylesheet Parse(string stylesheetSourceName, Stream dssStream)
        {
            var lexer = new DSSLexer(new AntlrInputStream(dssStream));
            var tokens = new CommonTokenStream(lexer);
            var parser = new DSSParser(tokens);

            var errorListener = new ErrorListener(stylesheetSourceName);
            //parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            var visitor = new StylesheetVisitor(stylesheetSourceName);
            var stylesheet = visitor.Visit(parser.stylesheet());
            return stylesheet;
        }
    }
}
