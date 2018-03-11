// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq.Expressions;

namespace AbsoluteGraphicsPlatform.Templating
{
    /// <summary>
    /// Stores the information for a style declaration.
    /// </summary>
    public class PropertySetterInfo
    {
        public PropertySetterInfo(string propertyName, IPropertyValue value, int line, string source)
        {
            PropertyName = propertyName;
            Value = value;
            Line = line;
            Source = source;
        }

        /// <summary>
        /// Gets the property name of the style declaration.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the value of the property setter.
        /// </summary>
        public IPropertyValue Value { get; }
        
        /// <summary>
        /// Gets the line number of the statement.
        /// </summary>
        public int Line { get; }

        /// <summary>
        /// Gets the source of this statement.
        /// </summary>
        public string Source { get; }
    }
}
