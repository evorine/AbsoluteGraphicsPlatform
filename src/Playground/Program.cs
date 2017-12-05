using System;
using NextPlatform.Core.Layout;
using NextPlatform.Metrics;
using NextPlatform.Platforms.WindowsForms;
using NextPlatform.Controls.Abstractions;
using NextPlatform.Rendering.Skia;
using NextPlatform.Abstractions;
using NextPlatform.Components;

namespace Playground
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var layoutEngine = new LayoutEngine();
            var renderEngine = new SkiaRenderEngine(layoutEngine);

            var app = new Application(renderEngine);
            var window = app.CreatePlatformWindow();

            addControls(window.ComponentTree);
            
            app.Start(window);
        }


        private static void addControls(IComponentTree componentTree)
        {
            var componentRoot = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentRoot.Name = "Root";
            componentRoot.Width = CompositeLength.Fill;
            componentRoot.Height = CompositeLength.Fill;
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentTree.RootComponent = componentRoot;

            var componentTop = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentTop.Name = "Top";
            componentTop.Width = CompositeLength.Fill;
            componentTop.Height = new CompositeLength(20, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentRoot.Components.Append(componentTop);
            componentTop.Parent = componentRoot;

            var componentBottom = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentBottom.Name = "Bottom";
            componentBottom.Width = CompositeLength.Fill;
            componentBottom.Height = CompositeLength.Fill;
            componentBottom.LayoutDirection = LayoutDirection.Horizontal;
            componentRoot.Components.Append(componentBottom);
            componentBottom.Parent = componentRoot;

            // LEFT
            var componentLeft = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentLeft.Name = "Left";
            componentLeft.Width = new CompositeLength(1, UnitType.Ratio);
            componentLeft.Height = CompositeLength.Shrink;
            componentLeft.LayoutDirection = LayoutDirection.Vertical;
            componentBottom.Components.Append(componentLeft);
            componentLeft.Parent = componentBottom;

            var componentLeft1 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentLeft1.Name = "Left1";
            componentLeft1.Width = CompositeLength.Fill;
            componentLeft1.Height = new CompositeLength(10, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentLeft.Components.Append(componentLeft1);
            componentLeft1.Parent = componentLeft;

            var componentLeft2 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentLeft2.Name = "Left2";
            componentLeft2.Width = CompositeLength.Fill;
            componentLeft2.Height = new CompositeLength(20, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentLeft.Components.Append(componentLeft2);
            componentLeft2.Parent = componentLeft;

            // RIGHT
            var componentRight = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentRight.Name = "Right";
            componentRight.Width = new CompositeLength(3, UnitType.Ratio);
            componentRight.Height = CompositeLength.Fill;
            componentRight.LayoutDirection = LayoutDirection.Vertical;
            componentBottom.Components.Append(componentRight);
            componentRight.Parent = componentBottom;

            var componentRight1 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentRight1.Name = "Right1";
            componentRight1.Width = CompositeLength.Fill;
            componentRight1.Height = new CompositeLength(35, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentRight.Components.Append(componentRight1);
            componentRight1.Parent = componentRight;

            var componentRight2 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentRight2.Name = "Right2";
            componentRight2.Width = CompositeLength.Fill;
            componentRight2.Height = new CompositeLength(20, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentRight.Components.Append(componentRight2);
            componentRight2.Parent = componentRight;
        }
    }
}
