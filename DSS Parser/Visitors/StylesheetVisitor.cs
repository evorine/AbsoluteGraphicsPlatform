using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class StylesheetVisitor : DSSParserBaseVisitor<Stylesheet>
    {
        public override Stylesheet VisitStylesheet([NotNull] DSSParser.StylesheetContext context)
        {
            return base.VisitStylesheet(context);
        }
    }
}
