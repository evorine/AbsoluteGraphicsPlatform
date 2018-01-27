// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.AGPx;
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
        <component-placeholder />
    </Component>
</component-template>
";

            var componentTemplateCompiler = Common.MockComponentTemplateCompiler();
            var fooTemplate = Common.ParseComponentTemplateCode(fooTemplateCode);

            var foo = componentTemplateCompiler.ProcessTemplate(fooTemplate);

            Assert.True(foo is FooComponent);
            Assert.True(foo.Components[0] is TemplateComponent);
            Assert.True(foo.Components[0].Components[0] is Component);
            Assert.True(foo.Components[0].Components[0].Components[0] is TemplateComponent);
            Assert.True(foo.Components[0].Components[0].Components[0].Components[0] is ComponentPlaceholderComponent);
        }


        [Fact]
        public void ProcessTemplateWithProperties()
        {
            var fooTemplateCode = @"
<component-template Name=""Foo"">
    <Component Name=""container"">
        <component-placeholder />
    </Component>
</component-template>
";

            var componentTemplateCompiler = Common.MockComponentTemplateCompiler();
            var fooTemplate = Common.ParseComponentTemplateCode(fooTemplateCode);

            var foo = componentTemplateCompiler.ProcessTemplate(fooTemplate);
            Assert.Equal("container", foo.Components[0].Components[0].Name);
        }
    }
}