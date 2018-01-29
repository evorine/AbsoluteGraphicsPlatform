// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.Layout.Tests
{
    public class BasicTestData
    {
        /* Layout is:
         * <component Width="Fill" Height="Fill" LayoutDirection="Vertical">
         *   <component Width="Fill" Height="50px" />
         *   <component Width="Fill" Height="Fill" LayoutDirection="Horizontal">
         *     <component Width="1x" Height="Shrink" LayoutDirection="Vertical">
         *       <component Width="Fill" Height="40px" />
         *       <component Width="Fill" Height="40px" />
         *     </component>
         *     <component Width="3x" Height="Fill" LayoutDirection="Vertical">
         *       <component Width="Fill" Height="40px" />
         *       <component Width="Fill" Height="80px" />
         *     </component>
         *   </component>
         * </component>
         * */
        
        public VisualElement ComponentRoot { get; }
        public VisualElement ComponentTop { get; }
        public VisualElement ComponentBottom { get; }
        public VisualElement ComponentLeft { get; }
        public VisualElement ComponentLeft1 { get; }
        public VisualElement ComponentLeft2 { get; }
        public VisualElement ComponentRight { get; }
        public VisualElement ComponentRight1 { get; }
        public VisualElement ComponentRight2 { get; }

        public BasicTestData(IComponentTree componentTree)
        {
            var componentTemplateCollection = new ComponentTemplateProvider();
            var componentFactory = new ComponentFactory(componentTemplateCollection);

            ComponentRoot = componentFactory.CreateComponent<VisualElement>();
            ComponentRoot.Name = "Root";
            ComponentRoot.Width = CompositeLength.Fill;
            ComponentRoot.Height = CompositeLength.Fill;
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            //componentTree.RootComponent = ComponentRoot;

            ComponentTop = componentFactory.CreateComponent<VisualElement>();
            ComponentTop.Name = "Top";
            ComponentTop.Width = CompositeLength.Fill;
            ComponentTop.Height = new CompositeLength(50, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRoot.Children.Add(ComponentTop);

            ComponentBottom = componentFactory.CreateComponent<VisualElement>();
            ComponentBottom.Name = "Bottom";
            ComponentBottom.Width = CompositeLength.Fill;
            ComponentBottom.Height = CompositeLength.Fill;
            ComponentBottom.LayoutDirection = LayoutDirection.Horizontal;
            ComponentRoot.Children.Add(ComponentBottom);

            // LEFT
            ComponentLeft = componentFactory.CreateComponent<VisualElement>();
            ComponentLeft.Name = "Left";
            ComponentLeft.Width = new CompositeLength(1, UnitType.Ratio);
            ComponentLeft.Height = CompositeLength.Shrink;
            ComponentLeft.LayoutDirection = LayoutDirection.Vertical;
            ComponentBottom.Children.Add(ComponentLeft);

            ComponentLeft1 = componentFactory.CreateComponent<VisualElement>();
            ComponentLeft1.Name = "Left1";
            ComponentLeft1.Width = CompositeLength.Fill;
            ComponentLeft1.Height = new CompositeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentLeft.Children.Add(ComponentLeft1);

            ComponentLeft2 = componentFactory.CreateComponent<VisualElement>();
            ComponentLeft2.Name = "Left2";
            ComponentLeft2.Width = CompositeLength.Fill;
            ComponentLeft2.Height = new CompositeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentLeft.Children.Add(ComponentLeft2);

            // RIGHT
            ComponentRight = componentFactory.CreateComponent<VisualElement>();
            ComponentRight.Name = "Right";
            ComponentRight.Width = new CompositeLength(3, UnitType.Ratio);
            ComponentRight.Height = CompositeLength.Fill;
            ComponentRight.LayoutDirection = LayoutDirection.Vertical;
            ComponentBottom.Children.Add(ComponentRight);

            ComponentRight1 = componentFactory.CreateComponent<VisualElement>();
            ComponentRight1.Name = "Right1";
            ComponentRight1.Width = CompositeLength.Fill;
            ComponentRight1.Height = new CompositeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRight.Children.Add(ComponentRight1);

            ComponentRight2 = componentFactory.CreateComponent<VisualElement>();
            ComponentRight2.Name = "Right2";
            ComponentRight2.Width = CompositeLength.Fill;
            ComponentRight2.Height = new CompositeLength(80, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRight.Children.Add(ComponentRight2);

            //componentTree.Restructure();
        }
    }
}
