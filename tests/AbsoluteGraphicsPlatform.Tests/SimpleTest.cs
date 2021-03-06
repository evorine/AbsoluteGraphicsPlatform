// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using AbsoluteGraphicsPlatform.Tests.Common.Components;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.Tests
{
    public class ComponentSystemTests
    {
        [Fact]
        public void ComponentFactoryTest()
        {
            var fooTemplateCode = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""Foo"">
    <Component Name=""Container"">
        <component-placeholder />
    </Component>
</component-template>
";
            var fooTemplate = AGPML.Tests.Common.ParseComponentTemplateCode(fooTemplateCode);

            var foo = AGPML.Tests.Common.ComponentFactory.CreateComponent<FooComponent>();
            var foo_Component = foo.ElementTree.Children[0] as IComponent;
            var foo_Component_Placeholder = foo_Component.Children[0] as IComponent;

            Assert.Equal(typeof(FooComponent), foo.ComponentMetaInfo.ComponentType);
            Assert.Equal(1, foo.ElementTree.Children.Count);

            Assert.Equal(typeof(Component), foo_Component.ComponentMetaInfo.ComponentType);
            Assert.Equal(1, foo_Component.Children.Count);

            Assert.Equal(typeof(ComponentPlaceholderComponent), foo_Component_Placeholder.ComponentMetaInfo.ComponentType);
            Assert.Equal(0, foo_Component_Placeholder.Children.Count);
        }


        [Fact]
        public void ComponentFactoryTest_RecursiveComponent()
        {
            var fooTemplateCode = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""Foo"">
    <Component Name=""Container"">
        <component-placeholder />
    </Component>
</component-template>
";
            var barTemplateCode = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""Bar"">
    <Component>
        <component-placeholder />
        <Foo>
            <Component Name=""Leaf"" />
        </Foo>
    </Component>
</component-template>
";
            var fooTemplate = AGPML.Tests.Common.ParseComponentTemplateCode(fooTemplateCode);
            var barTemplate = AGPML.Tests.Common.ParseComponentTemplateCode(barTemplateCode);

            var bar = AGPML.Tests.Common.ComponentFactory.CreateComponent<BarComponent>();
            var bar_Component = bar.ElementTree.Children[0] as IComponent;
            var bar_Component_Placeholder = bar_Component.Children[0] as IComponent;
            var bar_Component_Foo = bar_Component.Children[1] as IComponent;
            var bar_Component_Foo_Component = bar_Component_Foo.Children[0] as IComponent;

            var foo_Component = bar_Component_Foo.ElementTree.Children[0] as IComponent;
            var foo_Component_Placeholder = foo_Component.Children[0] as IComponent;

            // Bar
            Assert.Equal(typeof(BarComponent), bar.ComponentMetaInfo.ComponentType);
            Assert.Equal(1, bar.ElementTree.Children.Count);

            Assert.Equal(typeof(Component), bar_Component.ComponentMetaInfo.ComponentType);
            Assert.Equal(2, bar_Component.Children.Count);

            Assert.Equal(typeof(ComponentPlaceholderComponent), bar_Component_Placeholder.ComponentMetaInfo.ComponentType);
            Assert.Equal(0, bar_Component_Placeholder.Children.Count);

            Assert.Equal(typeof(FooComponent), bar_Component_Foo.ComponentMetaInfo.ComponentType);
            Assert.Equal(1, bar_Component_Foo.Children.Count);

            Assert.Equal(typeof(Component), bar_Component_Foo_Component.ComponentMetaInfo.ComponentType);
            Assert.Equal(0, bar_Component_Foo_Component.Children.Count);

            // Foo
            Assert.Equal(typeof(Component), foo_Component.ComponentMetaInfo.ComponentType);
            Assert.Equal(1, foo_Component.Children.Count);

            Assert.Equal(typeof(ComponentPlaceholderComponent), foo_Component_Placeholder.ComponentMetaInfo.ComponentType);
            Assert.Equal(0, foo_Component_Placeholder.Children.Count);
        }
    }
}
