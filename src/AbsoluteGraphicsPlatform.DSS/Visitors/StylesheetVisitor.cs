// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq;
using AbsoluteGraphicsPlatform.DSS.Internal;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
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
