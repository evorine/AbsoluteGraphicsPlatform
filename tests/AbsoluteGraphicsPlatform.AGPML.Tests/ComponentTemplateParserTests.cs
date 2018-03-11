// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.AGPML.Tests
{
    public class ComponentTemplateParserTests
    {
        [Fact]
        public void Throws_CodeCanNotBeEmpty()
        {
            var code = @" ";
            Assert.Throws<AGPxException>(() =>
            {
                Common.ParseComponentTemplateCode(code);
            });
        }

        [Fact]
        public void Throws_ShouldStartWithComponentTemplate()
        {
            var code = @"
    <Component>
    </Component>
";
            Assert.Throws<AGPxException>(() =>
            {
                Common.ParseComponentTemplateCode(code);
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
            Assert.Throws<AGPxException>(() =>
            {
                Common.ParseComponentTemplateCode(code);
            });
        }


        [Fact]
        public void ComponentTemplate_ShouldNotFoundComponent()
        {
            var code = @"
<component-template Name=""BasicComponent"">
    <Foo>
    </Foo>
</component-template>
";
            Assert.Throws<AGPxException>(() =>
            {
                Common.ParseComponentTemplateCode(code);
            });
        }


        [Fact]
        public void ComponentTemplate_ShouldParseSuccessfully()
        {
            var code = @"
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""BasicComponent"">
    <Foo>
    </Foo>
</component-template>
";
            var template = Common.ParseComponentTemplateCode(code);
        }


        [Fact]
        public void ComponentTemplate_ShouldSetProperty()
        {
            var code = @"
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""BasicComponent"">
    <Foo Length=""3px"">
    </Foo>
</component-template>
";
            var expressionExecutor = new ExpressionExecutor();
            var template = Common.ParseComponentTemplateCode(code);
            var propertySetter = template.Templates.Single().PropertySetters.Single();
            Assert.Equal("Length", propertySetter.PropertyName);
            Assert.Equal(new LengthPropertyValue("px", 3), propertySetter.Value);
        }


        [Fact]
        public void ComponentTemplate_ParsesTreeStructure()
        {
            var code = @"
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""BasicComponent"">
    <Foo Name=""Comp-1"">
        <Foo Name=""Comp-1-1"">
            <Foo Name=""Comp-1-1-1"">
            </Foo>
        </Foo>
        <Foo Name=""Comp-1-2"" />
    </Foo>
    <Foo Name=""Comp-2"">
    </Foo>
</component-template>
";
            var expressionExecutor = new ExpressionExecutor();
            var template = Common.ParseComponentTemplateCode(code);

            Assert.Equal(new StringPropertyValue("Comp-1"), template.Templates[0].PropertySetters["Name"].Value);
            Assert.Equal(new StringPropertyValue("Comp-1-1"), template.Templates[0].Templates[0].PropertySetters["Name"].Value);
            Assert.Equal(new StringPropertyValue("Comp-1-1-1"), template.Templates[0].Templates[0].Templates[0].PropertySetters["Name"].Value);
            Assert.Equal(new StringPropertyValue("Comp-1-2"), template.Templates[0].Templates[1].PropertySetters["Name"].Value);
            Assert.Equal(new StringPropertyValue("Comp-2"), template.Templates[1].PropertySetters["Name"].Value);
        }


        [Fact]
        public void ComponentTemplate_ParsesNamedScope()
        {
            var code = @"
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""BasicComponent"">
    <Bar Name=""Comp-1"">
        <Foo Name=""Comp-1-default-1"" />
        <Foo Name=""Comp-1-default-2"" />

        <template scope=""other"">
            <Foo Name=""Comp-1-other"">
            </Foo>
        </template>
    </Bar>
</component-template>
";
            var expressionExecutor = new ExpressionExecutor();
            var template = Common.ParseComponentTemplateCode(code);

            var root = template.Templates[0];

            Assert.Equal(new StringPropertyValue("Comp-1"), root.PropertySetters["Name"].Value);
            Assert.Equal(new StringPropertyValue("Comp-1-default-1"), root.Templates["default"].ToArray()[0].PropertySetters["Name"].Value);
            Assert.Equal(new StringPropertyValue("Comp-1-default-2"), root.Templates["default"].ToArray()[1].PropertySetters["Name"].Value);
            Assert.Equal(new StringPropertyValue("Comp-1-other"), root.Templates["other"].ToArray()[0].PropertySetters["Name"].Value);
        }


        [Fact]
        public void ComponentTemplate_ParsesPlaceholder()
        {
            var code = @"
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""BasicComponent"">
    <Foo>
        <Foo Name=""Comp-1"">
        </Foo>
        <component-placeholder />
    </Foo>
</component-template>
";
            var expressionExecutor = new ExpressionExecutor();
            var template = Common.ParseComponentTemplateCode(code);

            var placeholder = template.Templates[0].Templates[1];
            Assert.Equal(typeof(Components.ComponentPlaceholderComponent), placeholder.ComponentType);
        }
    }
}