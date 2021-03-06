﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
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
        
        public VisualComponent ComponentRoot { get; }
        public VisualComponent ComponentTop { get; }
        public VisualComponent ComponentBottom { get; }
        public VisualComponent ComponentLeft { get; }
        public VisualComponent ComponentLeft1 { get; }
        public VisualComponent ComponentLeft2 { get; }
        public VisualComponent ComponentRight { get; }
        public VisualComponent ComponentRight1 { get; }
        public VisualComponent ComponentRight2 { get; }

        public BasicTestData(IElementTree componentTree)
        {
            var componentTemplateCollection = new ComponentTemplateProvider();
            var componentFactory = new ComponentFactory(componentTemplateCollection);

            ComponentRoot = componentFactory.CreateComponent<VisualComponent>();
            ComponentRoot.Name = "Root";
            ComponentRoot.Width = RelativeLength.Infinity;
            ComponentRoot.Height = RelativeLength.Infinity;
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            //componentTree.RootComponent = ComponentRoot;

            ComponentTop = componentFactory.CreateComponent<VisualComponent>();
            ComponentTop.Name = "Top";
            ComponentTop.Width = RelativeLength.Infinity;
            ComponentTop.Height = new RelativeLength(50, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRoot.Children.Add(ComponentTop);

            ComponentBottom = componentFactory.CreateComponent<VisualComponent>();
            ComponentBottom.Name = "Bottom";
            ComponentBottom.Width = RelativeLength.Infinity;
            ComponentBottom.Height = RelativeLength.Infinity;
            ComponentBottom.LayoutDirection = LayoutDirection.Horizontal;
            ComponentRoot.Children.Add(ComponentBottom);

            // LEFT
            ComponentLeft = componentFactory.CreateComponent<VisualComponent>();
            ComponentLeft.Name = "Left";
            ComponentLeft.Width = new RelativeLength(1, UnitType.Ratio);
            ComponentLeft.Height = RelativeLength.NaN;
            ComponentLeft.LayoutDirection = LayoutDirection.Vertical;
            ComponentBottom.Children.Add(ComponentLeft);

            ComponentLeft1 = componentFactory.CreateComponent<VisualComponent>();
            ComponentLeft1.Name = "Left1";
            ComponentLeft1.Width = RelativeLength.Infinity;
            ComponentLeft1.Height = new RelativeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentLeft.Children.Add(ComponentLeft1);

            ComponentLeft2 = componentFactory.CreateComponent<VisualComponent>();
            ComponentLeft2.Name = "Left2";
            ComponentLeft2.Width = RelativeLength.Infinity;
            ComponentLeft2.Height = new RelativeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentLeft.Children.Add(ComponentLeft2);

            // RIGHT
            ComponentRight = componentFactory.CreateComponent<VisualComponent>();
            ComponentRight.Name = "Right";
            ComponentRight.Width = new RelativeLength(3, UnitType.Ratio);
            ComponentRight.Height = RelativeLength.Infinity;
            ComponentRight.LayoutDirection = LayoutDirection.Vertical;
            ComponentBottom.Children.Add(ComponentRight);

            ComponentRight1 = componentFactory.CreateComponent<VisualComponent>();
            ComponentRight1.Name = "Right1";
            ComponentRight1.Width = RelativeLength.Infinity;
            ComponentRight1.Height = new RelativeLength(40, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRight.Children.Add(ComponentRight1);

            ComponentRight2 = componentFactory.CreateComponent<VisualComponent>();
            ComponentRight2.Name = "Right2";
            ComponentRight2.Width = RelativeLength.Infinity;
            ComponentRight2.Height = new RelativeLength(80, UnitType.Pixel);
            ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
            ComponentRight.Children.Add(ComponentRight2);

            //componentTree.Restructure();
        }
    }
}
