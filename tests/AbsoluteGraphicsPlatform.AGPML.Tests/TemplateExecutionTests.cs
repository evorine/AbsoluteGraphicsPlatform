// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.Tests.Common.Components;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public class TemplateExecutionTests
    {
        [Fact]
        public void ProcessBasicTemplate()
        {
            var fooTemplateCode = @"
<component-template Name=""Foo"">
    <Component>
        <placeholder />
    </Component>
</component-template>
";

            var virtualComponentModelGenerator = Common.MockVirtualComponentModelGenerator();
            var fooTemplate = Common.ParseComponentTemplateCode(fooTemplateCode);

            var foo = virtualComponentModelGenerator.ProcessTemplate(fooTemplate);

            Assert.True(foo is FooComponent);
            Assert.True(foo.Components[0] is TemplateComponent);
            Assert.True(foo.Components[0].Components[0] is Component);
            Assert.True(foo.Components[0].Components[0].Components[0] is TemplateComponent);
            Assert.True(foo.Components[0].Components[0].Components[0].Components[0] is PlaceholderComponent);
        }
    }
}