// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.AGPx.Models;
using AbsoluteGraphicsPlatform.AGPx.Internal;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class StylesheetListener : DssParserBaseListener
    {
        readonly string stylesheetSourceName;
        readonly DssInstructions dssInstructions;
        readonly StatementVisitor statementVisitor;

        public StylesheetListener(string stylesheetSourceName, DssInstructions dssInstructions)
        {
            this.stylesheetSourceName = stylesheetSourceName;
            this.dssInstructions = dssInstructions;
            statementVisitor = new StatementVisitor(null);
        }

        public override void EnterStylesheet([NotNull] Internal.DssParser.StylesheetContext context)
        {
            var statements = context.statement().Select(x => x.Accept(statementVisitor)).ToArray();

            foreach (var statement in statements)
            {
                dssInstructions.Add(statement);
            }
        }
    }
}
