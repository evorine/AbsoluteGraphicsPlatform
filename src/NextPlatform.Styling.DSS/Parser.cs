// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Sprache;
using System.Linq;

namespace NextPlatform.Styling.DSS
{
    internal static class Parser
    {
        private const string classSelector = ".";
        private const string idSelector = "#";
        private const string blockBegin = "{";
        private const string blockEnd = "}";
        private const string propertySetter = ":";
        private const string statementEnder = ";";


        static readonly Parser<string> TokenClassSelector = from _ in Parse.String(classSelector) select _.CreateString();
        static readonly Parser<string> TokenIDSelector = from _ in Parse.String(idSelector) select _.CreateString();
        static readonly Parser<string> TokenBlockBegin = from _ in Parse.String(blockBegin) select _.CreateString();
        static readonly Parser<string> TokenBlockEnd = from _ in Parse.String(blockEnd) select _.CreateString();
        static readonly Parser<string> TokenPropertySetter = from _ in Parse.String(propertySetter) select _.CreateString();
        static readonly Parser<string> TokenStatementEnder = from _ in Parse.String(statementEnder) select _.CreateString();


        static readonly Parser<string> Identifier =
            from first in Parse.Letter.Once()
            from rest in Parse.LetterOrDigit.XOr(Parse.Char('-')).Many()
            select new string(first.Concat(rest).ToArray());

        static readonly Parser<StyleSelector> ClassSelector =
            from type in TokenClassSelector
            from identifier in Identifier
            select new StyleSelector(SelectorType.Class, identifier.CreateString());

        static readonly Parser<StyleSelector> IDSelector =
            from type in TokenIDSelector
            from identifier in Identifier
            select new StyleSelector(SelectorType.ID, identifier.CreateString());

        static readonly Parser<StyleSelector> StyleSelector =
            from selector in ClassSelector.Or(IDSelector)
            select selector;

        static readonly Parser<string> PropertyValue =
            from value in Parse.AnyChar.Except(TokenStatementEnder.Or(TokenPropertySetter)).Many()
            select value.CreateString();

        static readonly Parser<StyleDeclaration> StyleProperty =
            from _1 in Parse.WhiteSpace.Many()
            from property in Identifier
            from _2 in Parse.WhiteSpace.Many()
            from _setter in TokenPropertySetter
            from _3 in Parse.WhiteSpace.Many()
            from value in PropertyValue
            from _ender in TokenStatementEnder
            from _4 in Parse.WhiteSpace.Many()
            select new StyleDeclaration(property, value);

        static readonly Parser<StyleDeclaration[]> StyleProperties =
            from _1 in Parse.WhiteSpace.Many()
            from properties in StyleProperty.Many()
            from _2 in Parse.WhiteSpace.Many()
            select properties.ToArray();

        public static Parser<RuleSet> StyleBlock =
            from _1 in Parse.WhiteSpace.Many()
            from selector in StyleSelector
            from _2 in Parse.WhiteSpace.Many()
            from begin in TokenBlockBegin
            from _3 in Parse.WhiteSpace.Many()
            from properties in StyleProperty.Many()
            from _4 in Parse.WhiteSpace.Many()
            from end in TokenBlockEnd
            from _5 in Parse.WhiteSpace.Many()
            select new RuleSet(properties.ToArray()) { Selector = selector };

        static readonly Parser<IStyleObject> StyleObject =
            from _1 in Parse.WhiteSpace.Many()
            from block in StyleBlock
            from _2 in Parse.WhiteSpace.Many()
            select block;

        internal static Parser<Style> Document =
            from _1 in Parse.WhiteSpace.Many()
            from blocks in StyleObject.Many()
            from _2 in Parse.WhiteSpace.Many()
            select new Style(blocks.Where(x => x is RuleSet).Cast<RuleSet>().ToArray());
    }
}
