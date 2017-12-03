using NextPlatform.Core;
using NextPlatform.Core.Layout;
using NextPlatform.Rendering;
using System;
using Xunit;

namespace NextPlatform.Metrics.Tests
{
    public class LayoutEngineTests
    {
        [Fact]
        public void TestBasic()
        {
            /*
             * <component Width="Fill" Height="Fill" LayoutDirection="Vertical">
             *   <component Width="Fill" Height="20u" />
             *   <component Width="Fill" Height="Fill" LayoutDirection="Horizontal">
             *     <component Width="1x" Height="Shrink" LayoutDirection="Vertical">
             *       <component Width="Fill" Height="10u" />
             *       <component Width="Fill" Height="20u" />
             *     </component>
             *     <component Width="3x" Height="Fill" LayoutDirection="Vertical">
             *       <component Width="Fill" Height="35u" />
             *       <component Width="Fill" Height="20u" />
             *     </component>
             *   </component>
             * </component>
             * */
            var layoutEngine = new LayoutEngine();
            var componentTree = new ComponentTree();

            var componentRoot = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentRoot.Name = "Root";
            componentRoot.Width = Length.Fill;
            componentRoot.Height = Length.Fill;
            componentRoot.LayoutDirection = Controls.Abstractions.LayoutDirection.Vertical;
            componentTree.AppendRootComponent(componentRoot);

            var componentTop = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentTop.Name = "Top";
            componentTop.Width = Length.Fill;
            componentTop.Height = new Length(20, UnitType.Unit);
            componentRoot.LayoutDirection = Controls.Abstractions.LayoutDirection.Vertical;
            componentRoot.Components.Append(componentTop);
            componentTop.Parent = componentRoot;

            var componentBottom = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentBottom.Name = "Bottom";
            componentBottom.Width = Length.Fill;
            componentBottom.Height = Length.Fill;
            componentBottom.LayoutDirection = Controls.Abstractions.LayoutDirection.Horizontal;
            componentRoot.Components.Append(componentBottom);
            componentBottom.Parent = componentRoot;

            // LEFT
            var componentLeft = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentLeft.Name = "Left";
            componentLeft.Width = new Length(1, UnitType.Ratio);
            componentLeft.Height = Length.Shrink;
            componentLeft.LayoutDirection = Controls.Abstractions.LayoutDirection.Vertical;
            componentBottom.Components.Append(componentLeft);
            componentLeft.Parent = componentBottom;

            var componentLeft1 = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentLeft1.Name = "Left1";
            componentLeft1.Width = Length.Fill;
            componentLeft1.Height = new Length(10, UnitType.Unit);
            componentRoot.LayoutDirection = Controls.Abstractions.LayoutDirection.Vertical;
            componentLeft.Components.Append(componentLeft1);
            componentLeft1.Parent = componentLeft;

            var componentLeft2 = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentLeft2.Name = "Left2";
            componentLeft2.Width = Length.Fill;
            componentLeft2.Height = new Length(20, UnitType.Unit);
            componentRoot.LayoutDirection = Controls.Abstractions.LayoutDirection.Vertical;
            componentLeft.Components.Append(componentLeft2);
            componentLeft2.Parent = componentLeft;

            // RIGHT
            var componentRight = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentRight.Name = "Right";
            componentRight.Width = new Length(3, UnitType.Ratio);
            componentRight.Height = Length.Fill;
            componentRight.LayoutDirection = Controls.Abstractions.LayoutDirection.Vertical;
            componentBottom.Components.Append(componentRight);
            componentRight.Parent = componentBottom;

            var componentRight1 = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentRight1.Name = "Right1";
            componentRight1.Width = Length.Fill;
            componentRight1.Height = new Length(35, UnitType.Unit);
            componentRoot.LayoutDirection = Controls.Abstractions.LayoutDirection.Vertical;
            componentRight.Components.Append(componentRight1);
            componentRight1.Parent = componentRight;

            var componentRight2 = componentTree.ComponentFactory.CreateComponent<Controls.VisualElement>();
            componentRight2.Name = "Right2";
            componentRight2.Width = Length.Fill;
            componentRight2.Height = new Length(20, UnitType.Unit);
            componentRoot.LayoutDirection = Controls.Abstractions.LayoutDirection.Vertical;
            componentRight.Components.Append(componentRight2);
            componentRight2.Parent = componentRight;

            componentTree.Recalculate();

            Assert.Contains(componentRoot, componentTree.AllComponents);
            Assert.Contains(componentTop, componentTree.AllComponents);
            Assert.Contains(componentBottom, componentTree.AllComponents);
            Assert.Contains(componentLeft, componentTree.AllComponents);
            Assert.Contains(componentLeft1, componentTree.AllComponents);
            Assert.Contains(componentLeft2, componentTree.AllComponents);
            Assert.Contains(componentRight, componentTree.AllComponents);
            Assert.Contains(componentRight1, componentTree.AllComponents);
            Assert.Contains(componentRight2, componentTree.AllComponents);

            Assert.Contains(componentTop, componentTree.LeafComponents);
            Assert.Contains(componentLeft1, componentTree.LeafComponents);
            Assert.Contains(componentLeft2, componentTree.LeafComponents);
            Assert.Contains(componentRight1, componentTree.LeafComponents);
            Assert.Contains(componentRight2, componentTree.LeafComponents);

            Assert.DoesNotContain(componentRoot, componentTree.LeafComponents);
            Assert.DoesNotContain(componentBottom, componentTree.LeafComponents);
            Assert.DoesNotContain(componentLeft, componentTree.LeafComponents);
            Assert.DoesNotContain(componentRight, componentTree.LeafComponents);


            layoutEngine.ProcessLayout(new Size(800, 600, UnitType.Pixel), componentTree);
        }
    }
}
