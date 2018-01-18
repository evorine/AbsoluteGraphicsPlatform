﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq.Expressions;

namespace AbsoluteGraphicsPlatform.DSS.Models
{
    /// <summary>
    /// Stores the information for a style declaration.
    /// </summary>
    public class StylePropertySetter : Statement
    {
        public StylePropertySetter(string property, Expression[] values, int line, string source)
        {
            Property = property;
            Values = values;
            Line = line;
            Source = source;
        }

        /// <summary>
        /// Gets the property name of the style declaration.
        /// </summary>
        public string Property { get; }

        /// <summary>
        /// Gets the values of the style declaration.
        /// </summary>
        public Expression[] Values { get; }

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
