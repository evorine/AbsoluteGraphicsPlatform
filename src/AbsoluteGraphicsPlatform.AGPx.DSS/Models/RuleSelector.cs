// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

namespace AbsoluteGraphicsPlatform.AGPx.Models
{
    /// <summary>
    /// Stores the information for a style ruleset's selector (identifier).
    /// </summary>
    public class RuleSelector
    {
        public RuleSelector(SelectorType selectorType, string identifier)
            : this(selectorType, identifier, null)
        {
        }
        public RuleSelector(SelectorType selectorType, string identifier, RuleSelector parentSelector)
        {
            SelectorType = selectorType;
            Identifier = identifier;
            Parent = parentSelector;
        }

        /// <summary>
        /// Gets the type of the selector.
        /// </summary>
        public SelectorType SelectorType { get; }

        /// <summary>
        /// Gets the name of the selector.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gets the parent of the selector if it is declared under another selector. Otherwise <see cref="Parent"/> is null.
        /// </summary>
        public RuleSelector Parent { get; }
    }
}
