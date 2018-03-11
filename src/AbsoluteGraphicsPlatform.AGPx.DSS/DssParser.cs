// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq.Expressions;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using AbsoluteGraphicsPlatform.AGPx.Models;
using AbsoluteGraphicsPlatform.AGPx.Visitors;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class DssParser
    {
        public DssParser()
        {
        }

        public DssInstructions Parse(SourceCodeInfo sourceInfo)
        {
            var instructions = new DssInstructions();
            ParseInto(instructions, sourceInfo);
            return instructions;
        }
        public void ParseInto(DssInstructions dssInstructions, SourceCodeInfo sourceInfo)
        {
            if (sourceInfo == null) throw new ArgumentNullException(nameof(sourceInfo));

            Internal.DssLexer lexer;
            using (var stream = sourceInfo.GetStream())
                lexer = new Internal.DssLexer(new AntlrInputStream(stream));

            var tokens = new CommonTokenStream(lexer);
            var parser = new Internal.DssParser(tokens);
            
            var errorListener = new ErrorListener(sourceInfo.SourceName);
            //parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            var listener = new StylesheetListener(sourceInfo.SourceName, dssInstructions);
            listener.EnterStylesheet(parser.stylesheet());
        }

        public Expression ParseExpression(string expressionCode, string sourceName = null)
        {
            if (expressionCode == null) throw new ArgumentNullException(nameof(expressionCode));

            Internal.DssLexer lexer;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(expressionCode)))
                lexer = new Internal.DssLexer(new AntlrInputStream(stream));

            var tokens = new CommonTokenStream(lexer);
            var parser = new Internal.DssParser(tokens);

            var errorListener = new ErrorListener(sourceName);
            parser.AddErrorListener(errorListener);

            var visitor = new Visitors.ExpressionVisitor(null);
            var expression = visitor.Visit(parser.expression());
            return expression;
        }
    }
}
