// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.DSS.Models;
using AbsoluteGraphicsPlatform.DSS.Visitors;
using Antlr4.Runtime;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class StyleParser
    {
        public Stylesheet Parse(SourceCodeInfo sourceInfo)
        {
            if (sourceInfo == null) throw new ArgumentNullException(nameof(sourceInfo));

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

        public Expression ParseExpression(string expressionCode, string sourceName = null)
        {
            if (expressionCode == null) throw new ArgumentNullException(nameof(expressionCode));

            DSSLexer lexer;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(expressionCode)))
                lexer = new DSSLexer(new AntlrInputStream(stream));

            var tokens = new CommonTokenStream(lexer);
            var parser = new DSSParser(tokens);

            var errorListener = new ErrorListener(sourceName);
            parser.AddErrorListener(errorListener);

            var visitor = new Visitors.ExpressionVisitor();
            var expression = visitor.Visit(parser.expression());
            return expression;
        }
    }
}
