// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.Layout.Tests
{
    public class LayoutEngineTests
    {
        [Fact]
        public void TestComponentTreeStructure()
        {
            var layoutEngine = new LayoutEngine();
            var componentTree = new ComponentTree();
            var testData = new BasicTestData(componentTree);

            Assert.Contains(testData.ComponentRoot, componentTree.AllComponents);
            Assert.Contains(testData.ComponentTop, componentTree.AllComponents);
            Assert.Contains(testData.ComponentBottom, componentTree.AllComponents);
            Assert.Contains(testData.ComponentLeft, componentTree.AllComponents);
            Assert.Contains(testData.ComponentLeft1, componentTree.AllComponents);
            Assert.Contains(testData.ComponentLeft2, componentTree.AllComponents);
            Assert.Contains(testData.ComponentRight, componentTree.AllComponents);
            Assert.Contains(testData.ComponentRight1, componentTree.AllComponents);
            Assert.Contains(testData.ComponentRight2, componentTree.AllComponents);

            Assert.Contains(testData.ComponentTop, componentTree.LeafComponents);
            Assert.Contains(testData.ComponentLeft1, componentTree.LeafComponents);
            Assert.Contains(testData.ComponentLeft2, componentTree.LeafComponents);
            Assert.Contains(testData.ComponentRight1, componentTree.LeafComponents);
            Assert.Contains(testData.ComponentRight2, componentTree.LeafComponents);

            Assert.DoesNotContain(testData.ComponentRoot, componentTree.LeafComponents);
            Assert.DoesNotContain(testData.ComponentBottom, componentTree.LeafComponents);
            Assert.DoesNotContain(testData.ComponentLeft, componentTree.LeafComponents);
            Assert.DoesNotContain(testData.ComponentRight, componentTree.LeafComponents);
        }

        [Fact]
        public void TestLayoutCalculation_Basic()
        {
            var layoutEngine = new LayoutEngine();
            var componentTree = new ComponentTree();
            var testData = new BasicTestData(componentTree);

            var result = layoutEngine.ProcessLayout(new AbsoluteSize(800, 600), componentTree);

            Assert.Equal(0, result.GetLayoutBoxInformation(testData.ComponentTop).AbsoluteBox.Top);
            Assert.Equal(800, result.GetLayoutBoxInformation(testData.ComponentTop).AbsoluteBox.Right);
            Assert.Equal(50, result.GetLayoutBoxInformation(testData.ComponentTop).AbsoluteBox.Bottom);
            Assert.Equal(0, result.GetLayoutBoxInformation(testData.ComponentTop).AbsoluteBox.Left);

            Assert.Equal(50, result.GetLayoutBoxInformation(testData.ComponentBottom).AbsoluteBox.Top);
            Assert.Equal(800, result.GetLayoutBoxInformation(testData.ComponentBottom).AbsoluteBox.Right);
            Assert.Equal(600, result.GetLayoutBoxInformation(testData.ComponentBottom).AbsoluteBox.Bottom);
            Assert.Equal(0, result.GetLayoutBoxInformation(testData.ComponentBottom).AbsoluteBox.Left);

            Assert.Equal(50, result.GetLayoutBoxInformation(testData.ComponentLeft).AbsoluteBox.Top);
            Assert.Equal(200, result.GetLayoutBoxInformation(testData.ComponentLeft).AbsoluteBox.Right);
            Assert.Equal(130, result.GetLayoutBoxInformation(testData.ComponentLeft).AbsoluteBox.Bottom);
            Assert.Equal(0, result.GetLayoutBoxInformation(testData.ComponentLeft).AbsoluteBox.Left);

            Assert.Equal(50, result.GetLayoutBoxInformation(testData.ComponentLeft1).AbsoluteBox.Top);
            Assert.Equal(200, result.GetLayoutBoxInformation(testData.ComponentLeft1).AbsoluteBox.Right);
            Assert.Equal(90, result.GetLayoutBoxInformation(testData.ComponentLeft1).AbsoluteBox.Bottom);
            Assert.Equal(0, result.GetLayoutBoxInformation(testData.ComponentLeft1).AbsoluteBox.Left);

            Assert.Equal(90, result.GetLayoutBoxInformation(testData.ComponentLeft2).AbsoluteBox.Top);
            Assert.Equal(200, result.GetLayoutBoxInformation(testData.ComponentLeft2).AbsoluteBox.Right);
            Assert.Equal(130, result.GetLayoutBoxInformation(testData.ComponentLeft2).AbsoluteBox.Bottom);
            Assert.Equal(0, result.GetLayoutBoxInformation(testData.ComponentLeft2).AbsoluteBox.Left);

            Assert.Equal(50, result.GetLayoutBoxInformation(testData.ComponentRight).AbsoluteBox.Top);
            Assert.Equal(800, result.GetLayoutBoxInformation(testData.ComponentRight).AbsoluteBox.Right);
            Assert.Equal(600, result.GetLayoutBoxInformation(testData.ComponentRight).AbsoluteBox.Bottom);
            Assert.Equal(200, result.GetLayoutBoxInformation(testData.ComponentRight).AbsoluteBox.Left);

            Assert.Equal(50, result.GetLayoutBoxInformation(testData.ComponentRight1).AbsoluteBox.Top);
            Assert.Equal(800, result.GetLayoutBoxInformation(testData.ComponentRight1).AbsoluteBox.Right);
            Assert.Equal(90, result.GetLayoutBoxInformation(testData.ComponentRight1).AbsoluteBox.Bottom);
            Assert.Equal(200, result.GetLayoutBoxInformation(testData.ComponentRight1).AbsoluteBox.Left);

            Assert.Equal(90, result.GetLayoutBoxInformation(testData.ComponentRight2).AbsoluteBox.Top);
            Assert.Equal(800, result.GetLayoutBoxInformation(testData.ComponentRight2).AbsoluteBox.Right);
            Assert.Equal(170, result.GetLayoutBoxInformation(testData.ComponentRight2).AbsoluteBox.Bottom);
            Assert.Equal(200, result.GetLayoutBoxInformation(testData.ComponentRight2).AbsoluteBox.Left);
        }
    }
}
