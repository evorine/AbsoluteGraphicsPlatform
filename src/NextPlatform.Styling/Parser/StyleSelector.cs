// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

namespace NextPlatform.Styling.Models
{
    public class StyleSelector
    {
        public StyleSelector(SelectorType selectorType, string identifier)
        {
            SelectorType = selectorType;
            Identifier = identifier;
        }

        public SelectorType SelectorType { get; }

        public string Identifier { get; }
    }
}
