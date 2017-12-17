// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace NextPlatform.Styling
{
    public class RuleSet : IStyleObject
    {
        public RuleSet()
        {
            Declarations = new StyleDeclarationCollection();
        }
        public RuleSet(StyleDeclaration[] declarations)
        {
            Declarations = new StyleDeclarationCollection(declarations);
        }

        public StyleDeclarationCollection Declarations { get; }

        public RuleSelector Selector { get; set; }
    }
}
