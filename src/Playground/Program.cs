using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using NextPlatform.Core.Layout;
using NextPlatform.Metrics;
using NextPlatform.Platforms.WindowsForms;
using NextPlatform.Rendering;
using NextPlatform.Controls.Abstractions;
using NextPlatform.Controls;
using NextPlatform.Rendering.Skia;

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
            componentRoot.Width = Length.Fill;
            componentRoot.Height = Length.Fill;
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentTree.AppendRootComponent(componentRoot);

            var componentTop = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentTop.Name = "Top";
            componentTop.Width = Length.Fill;
            componentTop.Height = new Length(20, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentRoot.Components.Append(componentTop);
            componentTop.Parent = componentRoot;

            var componentBottom = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentBottom.Name = "Bottom";
            componentBottom.Width = Length.Fill;
            componentBottom.Height = Length.Fill;
            componentBottom.LayoutDirection = LayoutDirection.Horizontal;
            componentRoot.Components.Append(componentBottom);
            componentBottom.Parent = componentRoot;

            // LEFT
            var componentLeft = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentLeft.Name = "Left";
            componentLeft.Width = new Length(1, UnitType.Ratio);
            componentLeft.Height = Length.Shrink;
            componentLeft.LayoutDirection = LayoutDirection.Vertical;
            componentBottom.Components.Append(componentLeft);
            componentLeft.Parent = componentBottom;

            var componentLeft1 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentLeft1.Name = "Left1";
            componentLeft1.Width = Length.Fill;
            componentLeft1.Height = new Length(10, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentLeft.Components.Append(componentLeft1);
            componentLeft1.Parent = componentLeft;

            var componentLeft2 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentLeft2.Name = "Left2";
            componentLeft2.Width = Length.Fill;
            componentLeft2.Height = new Length(20, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentLeft.Components.Append(componentLeft2);
            componentLeft2.Parent = componentLeft;

            // RIGHT
            var componentRight = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentRight.Name = "Right";
            componentRight.Width = new Length(3, UnitType.Ratio);
            componentRight.Height = Length.Fill;
            componentRight.LayoutDirection = LayoutDirection.Vertical;
            componentBottom.Components.Append(componentRight);
            componentRight.Parent = componentBottom;

            var componentRight1 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentRight1.Name = "Right1";
            componentRight1.Width = Length.Fill;
            componentRight1.Height = new Length(35, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentRight.Components.Append(componentRight1);
            componentRight1.Parent = componentRight;

            var componentRight2 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
            componentRight2.Name = "Right2";
            componentRight2.Width = Length.Fill;
            componentRight2.Height = new Length(20, UnitType.Unit);
            componentRoot.LayoutDirection = LayoutDirection.Vertical;
            componentRight.Components.Append(componentRight2);
            componentRight2.Parent = componentRight;

            componentTree.Recalculate();

        }
    }
}
