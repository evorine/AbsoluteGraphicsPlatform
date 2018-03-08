// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.Tests.Common.Components;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public class ComponentTemplateExecutionTests
    {
        [Fact]
        public void ProcessBasicTemplate()
        {
            var fooTemplateCode = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""Foo"">
    <primitive>
        <component-placeholder />
    </primitive>
</component-template>
";

            var componentTemplateExecutor = Common.MockComponentTemplateExecutor();
            var fooTemplate = Common.ParseComponentTemplateCode(fooTemplateCode);

            var foo = componentTemplateExecutor.ExecuteTemplate(fooTemplate);

            Assert.True(foo is FooComponent);
            Assert.True(foo.Children[0] is PrimitiveComponent);
            Assert.True(foo.Children[0].Children[0] is ComponentPlaceholderComponent);
        }


        [Fact]
        public void ProcessTemplateWithProperties()
        {
            var fooTemplateCode = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""Foo"">
    <primitive Name=""container"">
        <component-placeholder />
    </primitive>
</component-template>
";

            var componentTemplateExecutor = Common.MockComponentTemplateExecutor();
            var fooTemplate = Common.ParseComponentTemplateCode(fooTemplateCode);

            var foo = componentTemplateExecutor.ExecuteTemplate(fooTemplate);
            Assert.Equal("container", foo.Children[0].Name);
        }
    }
}