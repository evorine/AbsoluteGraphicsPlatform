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
        public Stylesheet Parse(SourceCodeInfo sourceInfo)
        {
            DSSLexer lexer;
            using (var stream = sourceInfo.GetStream())
                lexer = new DSSLexer(new AntlrInputStream(stream));

            var tokens = new CommonTokenStream(lexer);
            var parser = new DSSParser(tokens);

            var errorListener = new ErrorListener(sourceInfo.SourceName);
            //parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            var visitor = new StylesheetVisitor(sourceInfo.SourceName);
            var stylesheet = visitor.Visit(parser.stylesheet());
            return stylesheet;
        }
    }
}
