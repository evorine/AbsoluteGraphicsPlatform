// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq.Expressions;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    /// <summary>
    /// Stores the information for a style declaration.
    /// </summary>
    public class StylePropertySetter : Statement
    {
        public StylePropertySetter(string property, Expression rawValue)
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
        public Expression RawValue { get; }
    }
}
