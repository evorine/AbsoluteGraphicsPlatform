using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class StylesheetVisitor : DSSParserBaseVisitor<Stylesheet>
    {
        readonly string stylesheetSourceName;

        public StylesheetVisitor(string stylesheetSourceName)
        {
            this.stylesheetSourceName = stylesheetSourceName;
        }

        public override Stylesheet VisitStylesheet([NotNull] DSSParser.StylesheetContext context)
        {
            var rulesetVisitor = new RulesetVisitor();
            var rulesets = context.statement().Select(x => x.Accept(rulesetVisitor)).ToArray();

            var stylesheet = new Stylesheet();
            foreach (var ruleset in rulesets)
                stylesheet.AddRuleset(ruleset);

            return stylesheet;
        }
    }
}
