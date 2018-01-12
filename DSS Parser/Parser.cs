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
        public Stylesheet Parse(Stream dssStream)
        {
            var lexer = new DSSLexer(new AntlrInputStream(dssStream));
            var tokens = new CommonTokenStream(lexer);
            var parser = new DSSParser(tokens);

            var visitor = new StylesheetVisitor();
            return visitor.Visit(parser.stylesheet());
        }
    }
}
