// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public class ComponentParserTests
    {
        [Fact]
        public void Throws_CodeCanNotBeEmpty()
        {
            var code = @" ";
            Assert.Throws<AGPMLException>(() =>
            {
                Common.ParseComponentCode(code);
            });
        }

        [Fact]
        public void Throws_ShouldStartWithComponentTemplate()
        {
            var code = @"
    <Component>
    </Component>
";
            Assert.Throws<AGPMLException>(() =>
            {
                Common.ParseComponentCode(code);
            });
        }


        [Fact]
        public void Throws_ComponentShouldHaveName()
        {
            var code = @"
<component-template>
    <Component>
    </Component>
</component-template>
";
            Assert.Throws<AGPMLException>(() => 
            {
                Common.ParseComponentCode(code);
            });
        }


        [Fact]
        public void ComponentTemplate_ShouldParseSuccessfully()
        {
            var code = @"
<component-template Name=""BasicComponent"">
    <Component>
    </Component>
</component-template>
";
            var component = Common.ParseComponentCode(code);
        }

    }
}
