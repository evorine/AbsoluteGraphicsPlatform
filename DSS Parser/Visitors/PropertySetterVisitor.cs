using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.DSS.Models;

namespace AbsoluteGraphicsPlatform.DSS.Visitors
{
    public class PropertySetterVisitor : DSSParserBaseVisitor<StylePropertySetter>
    {
        public override StylePropertySetter VisitPropertySetter([NotNull] DSSParser.PropertySetterContext context)
        {
            var setter = new StylePropertySetter(context.PROPERTY_NAME.GetText(), context.EXPRESSION.GetText());
            return setter;
        }
    }
}
