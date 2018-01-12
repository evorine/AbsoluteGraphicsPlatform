// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    /// <summary>
    /// Stores the information for a style declaration.
    /// </summary>
    public class StylePropertySetter
    {
        public StylePropertySetter(string property, string rawValue)
        {
            Property = property;
            RawValue = rawValue;
        }

        /// <summary>
        /// Gets the property name of the style declaration.
        /// </summary>
        public string Property { get; }

        /// <summary>
        /// Gets the value of the style declaration.
        /// </summary>
        public string RawValue { get; }
    }
}
