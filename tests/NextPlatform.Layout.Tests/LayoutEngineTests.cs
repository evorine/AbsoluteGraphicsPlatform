// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;
using NextPlatform.Metrics;

namespace NextPlatform.Layout.Tests
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

            layoutEngine.ProcessLayout(new AbsoluteSize(800, 600), componentTree);

            Assert.Equal(0, layoutEngine.layoutData[testData.ComponentTop].AbsoluteBox.Top[UnitType.Pixel]);
            Assert.Equal(800, layoutEngine.layoutData[testData.ComponentTop].AbsoluteBox.Right[UnitType.Pixel]);
            Assert.Equal(50, layoutEngine.layoutData[testData.ComponentTop].AbsoluteBox.Bottom[UnitType.Pixel]);
            Assert.Equal(0, layoutEngine.layoutData[testData.ComponentTop].AbsoluteBox.Left[UnitType.Pixel]);

            Assert.Equal(50, layoutEngine.layoutData[testData.ComponentBottom].AbsoluteBox.Top[UnitType.Pixel]);
            Assert.Equal(800, layoutEngine.layoutData[testData.ComponentBottom].AbsoluteBox.Right[UnitType.Pixel]);
            Assert.Equal(600, layoutEngine.layoutData[testData.ComponentBottom].AbsoluteBox.Bottom[UnitType.Pixel]);
            Assert.Equal(0, layoutEngine.layoutData[testData.ComponentBottom].AbsoluteBox.Left[UnitType.Pixel]);

            Assert.Equal(50, layoutEngine.layoutData[testData.ComponentLeft].AbsoluteBox.Top[UnitType.Pixel]);
            Assert.Equal(200, layoutEngine.layoutData[testData.ComponentLeft].AbsoluteBox.Right[UnitType.Pixel]);
            Assert.Equal(130, layoutEngine.layoutData[testData.ComponentLeft].AbsoluteBox.Bottom[UnitType.Pixel]);
            Assert.Equal(0, layoutEngine.layoutData[testData.ComponentLeft].AbsoluteBox.Left[UnitType.Pixel]);

            Assert.Equal(50, layoutEngine.layoutData[testData.ComponentLeft1].AbsoluteBox.Top[UnitType.Pixel]);
            Assert.Equal(200, layoutEngine.layoutData[testData.ComponentLeft1].AbsoluteBox.Right[UnitType.Pixel]);
            Assert.Equal(90, layoutEngine.layoutData[testData.ComponentLeft1].AbsoluteBox.Bottom[UnitType.Pixel]);
            Assert.Equal(0, layoutEngine.layoutData[testData.ComponentLeft1].AbsoluteBox.Left[UnitType.Pixel]);

            Assert.Equal(90, layoutEngine.layoutData[testData.ComponentLeft2].AbsoluteBox.Top[UnitType.Pixel]);
            Assert.Equal(200, layoutEngine.layoutData[testData.ComponentLeft2].AbsoluteBox.Right[UnitType.Pixel]);
            Assert.Equal(130, layoutEngine.layoutData[testData.ComponentLeft2].AbsoluteBox.Bottom[UnitType.Pixel]);
            Assert.Equal(0, layoutEngine.layoutData[testData.ComponentLeft2].AbsoluteBox.Left[UnitType.Pixel]);

            Assert.Equal(50, layoutEngine.layoutData[testData.ComponentRight].AbsoluteBox.Top[UnitType.Pixel]);
            Assert.Equal(800, layoutEngine.layoutData[testData.ComponentRight].AbsoluteBox.Right[UnitType.Pixel]);
            Assert.Equal(600, layoutEngine.layoutData[testData.ComponentRight].AbsoluteBox.Bottom[UnitType.Pixel]);
            Assert.Equal(200, layoutEngine.layoutData[testData.ComponentRight].AbsoluteBox.Left[UnitType.Pixel]);

            Assert.Equal(50, layoutEngine.layoutData[testData.ComponentRight1].AbsoluteBox.Top[UnitType.Pixel]);
            Assert.Equal(800, layoutEngine.layoutData[testData.ComponentRight1].AbsoluteBox.Right[UnitType.Pixel]);
            Assert.Equal(90, layoutEngine.layoutData[testData.ComponentRight1].AbsoluteBox.Bottom[UnitType.Pixel]);
            Assert.Equal(200, layoutEngine.layoutData[testData.ComponentRight1].AbsoluteBox.Left[UnitType.Pixel]);

            Assert.Equal(90, layoutEngine.layoutData[testData.ComponentRight2].AbsoluteBox.Top[UnitType.Pixel]);
            Assert.Equal(800, layoutEngine.layoutData[testData.ComponentRight2].AbsoluteBox.Right[UnitType.Pixel]);
            Assert.Equal(170, layoutEngine.layoutData[testData.ComponentRight2].AbsoluteBox.Bottom[UnitType.Pixel]);
            Assert.Equal(200, layoutEngine.layoutData[testData.ComponentRight2].AbsoluteBox.Left[UnitType.Pixel]);
        }
    }
}
