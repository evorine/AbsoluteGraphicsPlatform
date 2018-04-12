// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.AGPML.Tests;
using AbsoluteGraphicsPlatform.Tests.Common.Components;

namespace AbsoluteGraphicsPlatform.Layout.Tests
{
    public class DocumentModelTests
    {
        [Fact]
        public void ProcessBasicDocumentModel()
        {
            var fooTemplateCode = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>

<component-template Name=""Foo"">
    <primitive Name=""container"">
    </primitive>
</component-template>
";

            var documentModelTree = Common.CreateDocumentModelTreeFromTemplate(fooTemplateCode);

            Assert.IsAssignableFrom<FooComponent>(documentModelTree.OwnerComponent);
            Assert.IsAssignableFrom<FooComponent>(documentModelTree.RootDocumentObject.Element);
            Assert.IsAssignableFrom<PrimitiveComponent>(documentModelTree.RootDocumentObject.Children[0].Element);
            Assert.Empty(documentModelTree.RootDocumentObject.Children[0].Children);
        }


        [Fact]
        public void ProcessReferencedTemplates()
        {
            var fooTemplateCode = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>

<component-template Name=""Foo"">
    <primitive Name=""container"">
        <Bar>
            <BasicTemplateless />
        </Bar>
    </primitive>
</component-template>
";

            var barTemplateCode = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>

<component-template Name=""Bar"">
    <primitive Name=""container"">
        <primitive Name=""Previous"" />
        <component-placeholder />
        <primitive Name=""Next"" />
    </primitive>
</component-template>
";

            Common.ParseComponentTemplateCode(barTemplateCode);
            var documentModelTree = Common.CreateDocumentModelTreeFromTemplate(fooTemplateCode);


        }

    }
}
