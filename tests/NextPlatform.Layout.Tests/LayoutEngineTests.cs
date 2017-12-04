using NextPlatform.Controls;
using NextPlatform.Core;
using NextPlatform.Core.Layout;
using NextPlatform.Metrics;
using System;
using Xunit;

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


            layoutEngine.ProcessLayout(new Size(800, 600, UnitType.Pixel), componentTree);
        }
    }
}
