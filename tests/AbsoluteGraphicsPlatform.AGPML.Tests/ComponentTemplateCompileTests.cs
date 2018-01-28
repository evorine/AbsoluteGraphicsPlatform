// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public class ComponentTemplateCompileTests
    {
        [Fact]
        public void CompilesBasicComponentTemplate()
        {
            var code = @"
<component-template Name=""BasicComponent"">
    <Component>
    </Component>
</component-template>
";
            Assert.Throws<AGPxException>(() =>
            {
                Common.ParseComponentTemplateCode(code);
            });
        }
    }
}