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
    public class StylesheetVisitor : DSSParserBaseVisitor<Stylesheet>
    {
        readonly string stylesheetSourceName;

        public StylesheetVisitor(string stylesheetSourceName)
        {
            this.stylesheetSourceName = stylesheetSourceName;
        }

        public override Stylesheet VisitStylesheet([NotNull] Internal.DSSParser.StylesheetContext context)
        {
            var statementVisitor = new StatementVisitor();
            var statements = context.statement().Select(x => x.Accept(statementVisitor)).ToArray();

            var stylesheet = new Stylesheet();
            foreach (var statement in statements)
                if (statement is Ruleset ruleset)
                stylesheet.AddRuleset(ruleset);

            return stylesheet;
        }
    }
}
