using NextPlatform.Controls;
using NextPlatform.Controls.Abstractions;
using NextPlatform.Core;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Layout.Tests
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

        public BasicTestData(ComponentTree ComponentTree)
        {
            ComponentRoot = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentRoot.Name = "Root";
            ComponentRoot.Width = Length.Fill;
            ComponentRoot.Height = Length.Fill;
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentTree.AppendRootComponent(ComponentRoot);

            ComponentTop = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentTop.Name = "Top";
            ComponentTop.Width = Length.Fill;
            ComponentTop.Height = new Length(50, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRoot.Components.Append(ComponentTop);
            ComponentTop.Parent = ComponentRoot;

            ComponentBottom = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentBottom.Name = "Bottom";
            ComponentBottom.Width = Length.Fill;
            ComponentBottom.Height = Length.Fill;
            ComponentBottom.LayoutDirection = LayoutDirection.Horizontal;
            ComponentRoot.Components.Append(ComponentBottom);
            ComponentBottom.Parent = ComponentRoot;

            // LEFT
            ComponentLeft = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentLeft.Name = "Left";
            ComponentLeft.Width = new Length(1, UnitType.Ratio);
            ComponentLeft.Height = Length.Shrink;
            ComponentLeft.LayoutDirection = LayoutDirection.Vertical;
            ComponentBottom.Components.Append(ComponentLeft);
            ComponentLeft.Parent = ComponentBottom;

            ComponentLeft1 = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentLeft1.Name = "Left1";
            ComponentLeft1.Width = Length.Fill;
            ComponentLeft1.Height = new Length(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentLeft.Components.Append(ComponentLeft1);
            ComponentLeft1.Parent = ComponentLeft;

            ComponentLeft2 = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentLeft2.Name = "Left2";
            ComponentLeft2.Width = Length.Fill;
            ComponentLeft2.Height = new Length(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentLeft.Components.Append(ComponentLeft2);
            ComponentLeft2.Parent = ComponentLeft;

            // RIGHT
            ComponentRight = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentRight.Name = "Right";
            ComponentRight.Width = new Length(3, UnitType.Ratio);
            ComponentRight.Height = Length.Fill;
            ComponentRight.LayoutDirection = LayoutDirection.Vertical;
            ComponentBottom.Components.Append(ComponentRight);
            ComponentRight.Parent = ComponentBottom;

            ComponentRight1 = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentRight1.Name = "Right1";
            ComponentRight1.Width = Length.Fill;
            ComponentRight1.Height = new Length(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRight.Components.Append(ComponentRight1);
            ComponentRight1.Parent = ComponentRight;

            ComponentRight2 = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentRight2.Name = "Right2";
            ComponentRight2.Width = Length.Fill;
            ComponentRight2.Height = new Length(80, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRight.Components.Append(ComponentRight2);
            ComponentRight2.Parent = ComponentRight;

            ComponentTree.Recalculate();
        }
    }
}
