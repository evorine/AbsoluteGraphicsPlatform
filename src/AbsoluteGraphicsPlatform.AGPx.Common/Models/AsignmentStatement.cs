// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq.Expressions;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.AGPx.Models
{
    /// <summary>
    /// Stores the information for a style declaration.
    /// </summary>
    public class AsignmentStatement : IStatement
    {
        public AsignmentStatement(string variableName, Expression[] expressions)
        {
            VariableName = variableName;
            Expressions = expressions;
        }

        public string VariableName { get; }
        public Expression[] Expressions { get; }
    }
}
