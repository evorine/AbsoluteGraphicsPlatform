// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

namespace NextPlatform.Styling
{
    /// <summary>
    /// Stores the information for a style ruleset's selector (identifier).
    /// </summary>
    public class StyleSelector
    {
        public StyleSelector(SelectorType selectorType, string identifier)
            : this(selectorType, identifier, null)
        {
        }
        public StyleSelector(SelectorType selectorType, string identifier, StyleSelector parentSelector)
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
        public StyleSelector Parent { get; }
    }
}
