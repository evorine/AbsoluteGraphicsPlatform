// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.AGPx.Models;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class RuntimeTests
    {
        [Fact]
        public void ShouldAcceptVariableAsExpression()
        {
            var style = Common.CompileCode(@"
$variable-1: 1;
$variable-2: $variable-1 + 2");

        }
    }
}
