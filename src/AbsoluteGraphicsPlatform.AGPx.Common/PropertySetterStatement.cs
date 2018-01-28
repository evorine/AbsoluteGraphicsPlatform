// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.AGPx
{
    /// <summary>
    /// Stores the information for a style declaration.
    /// </summary>
    public class PropertySetterStatement : PropertySetterInfo, IStatement
    {
        public PropertySetterStatement(string propertyName, Expression[] values, int line, string source) 
            : base(propertyName, values, line, source)
        {
        }
    }
}
