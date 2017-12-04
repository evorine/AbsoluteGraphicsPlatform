// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

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
            ComponentRoot.Width = CompositeLength.Fill;
            ComponentRoot.Height = CompositeLength.Fill;
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentTree.AppendRootComponent(ComponentRoot);

            ComponentTop = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentTop.Name = "Top";
            ComponentTop.Width = CompositeLength.Fill;
            ComponentTop.Height = new CompositeLength(50, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRoot.Components.Append(ComponentTop);
            ComponentTop.Parent = ComponentRoot;

            ComponentBottom = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentBottom.Name = "Bottom";
            ComponentBottom.Width = CompositeLength.Fill;
            ComponentBottom.Height = CompositeLength.Fill;
            ComponentBottom.LayoutDirection = LayoutDirection.Horizontal;
            ComponentRoot.Components.Append(ComponentBottom);
            ComponentBottom.Parent = ComponentRoot;

            // LEFT
            ComponentLeft = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentLeft.Name = "Left";
            ComponentLeft.Width = new CompositeLength(1, UnitType.Ratio);
            ComponentLeft.Height = CompositeLength.Shrink;
            ComponentLeft.LayoutDirection = LayoutDirection.Vertical;
            ComponentBottom.Components.Append(ComponentLeft);
            ComponentLeft.Parent = ComponentBottom;

            ComponentLeft1 = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentLeft1.Name = "Left1";
            ComponentLeft1.Width = CompositeLength.Fill;
            ComponentLeft1.Height = new CompositeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentLeft.Components.Append(ComponentLeft1);
            ComponentLeft1.Parent = ComponentLeft;

            ComponentLeft2 = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentLeft2.Name = "Left2";
            ComponentLeft2.Width = CompositeLength.Fill;
            ComponentLeft2.Height = new CompositeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentLeft.Components.Append(ComponentLeft2);
            ComponentLeft2.Parent = ComponentLeft;

            // RIGHT
            ComponentRight = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentRight.Name = "Right";
            ComponentRight.Width = new CompositeLength(3, UnitType.Ratio);
            ComponentRight.Height = CompositeLength.Fill;
            ComponentRight.LayoutDirection = LayoutDirection.Vertical;
            ComponentBottom.Components.Append(ComponentRight);
            ComponentRight.Parent = ComponentBottom;

            ComponentRight1 = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentRight1.Name = "Right1";
            ComponentRight1.Width = CompositeLength.Fill;
            ComponentRight1.Height = new CompositeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRight.Components.Append(ComponentRight1);
            ComponentRight1.Parent = ComponentRight;

            ComponentRight2 = ComponentTree.ComponentFactory.CreateComponent<VisualElement>();
            ComponentRight2.Name = "Right2";
            ComponentRight2.Width = CompositeLength.Fill;
            ComponentRight2.Height = new CompositeLength(80, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRight.Components.Append(ComponentRight2);
            ComponentRight2.Parent = ComponentRight;

            ComponentTree.Recalculate();
        }
    }
}
