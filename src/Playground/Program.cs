﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Extensions.FileProviders.Physical;
using AbsoluteGraphicsPlatform;
using AbsoluteGraphicsPlatform.Platforms.WindowsForms;
using AbsoluteGraphicsPlatform.Rendering.Skia;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.Abstractions;

namespace Playground
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //AnotherPlayground.Play();
            //return;

            var appBuilder = new ApplicationBuilder();
            appBuilder.UseAgpml();
            appBuilder.UseDSS();
            appBuilder.Configure<AgpxOptions>((options) =>
            {
                //options.Styles.Add(parseTestStyle());
            });
            appBuilder.UseSkia();
            
            var app = appBuilder.Build();

            app.LoadLayout(new SourceCodeInfo("Box_Source", boxTemplate));
            app.LoadLayout(new SourceCodeInfo("MyLayout_Source", layoutTemplate));

            var factory = app.GetService<IComponentFactory>();
            var windowComponent = factory.CreateComponent<WindowComponent>();

            var window = (PlatformWindow)app.CreatePlatformWindow();
            window.ComponentTree = windowComponent.ComponentTree;


            var styleSetter = (DssStyleSetter)app.GetService<IStyleSetter>();
            styleSetter.ApplyFullStyleRecursivly(windowComponent.ComponentTree);

            app.Start(window);
        }


        private static IStyle parseTestStyle()
        {
            var fileInfo = new PhysicalFileInfo(new System.IO.FileInfo(@"C:\Playground\AbsoluteGraphicsPlatform\tests\TestFiles\TestStyle1.dss"));
            var dssParser = new DSSParser();

            var sourceInfo = new SourceCodeInfo(fileInfo);
            var style = dssParser.Parse(sourceInfo);
            return style;
        }

        const string boxTemplate = @"
<component-template Name=""Box"">
    <Component>
        <component-placeholder />
    </Component>
</component-template>";

        const string layoutTemplate = @"
<component-template Name=""Window"">
    <Box Width=""fill"" Height=""fill"" LayoutDirection=""Vertical"">
        <Box Width=""fill"" Height=""50px"" />
        <Box Width=""fill"" Height=""fill"" LayoutDirection=""Horizontal"">
            <Box Width=""1x"" Height=""shrink"" LayoutDirection=""Vertical"">
                <Box Width=""fill"" Height=""40px"" />
                <Box Width=""fill"" Height=""40px"" />
            </Box>
            <Box Width=""3x"" Height=""fill"" LayoutDirection=""Vertical"">
                <Box Width=""fill"" Height=""40px"" />
                <Box Width=""fill"" Height=""80px"" />
            </Box>
        </Box>
    </Box>
</component-template>";


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
                /*
                var componentTemplateCollection = new ComponentTemplateCollection();
                var componentFactory = new ComponentFactory(componentTemplateCollection);

                ComponentRoot = componentFactory.CreateComponent<VisualElement>();
                ComponentRoot.Name = "Root";
                ComponentRoot.Width = CompositeLength.Fill;
                ComponentRoot.Height = CompositeLength.Fill;
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                componentTree.RootComponent = ComponentRoot;

                ComponentTop = componentFactory.CreateComponent<VisualElement>();
                ComponentTop.Name = "Top";
                ComponentTop.Width = CompositeLength.Fill;
                ComponentTop.Height = new CompositeLength(50, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentRoot.Components.Append(ComponentTop);

                ComponentBottom = componentFactory.CreateComponent<VisualElement>();
                ComponentBottom.Name = "Bottom";
                ComponentBottom.Width = CompositeLength.Fill;
                ComponentBottom.Height = CompositeLength.Fill;
                ComponentBottom.LayoutDirection = LayoutDirection.Horizontal;
                ComponentRoot.Components.Append(ComponentBottom);

                // LEFT
                ComponentLeft = componentFactory.CreateComponent<VisualElement>();
                ComponentLeft.Name = "Left";
                ComponentLeft.Width = new CompositeLength(1, UnitType.Ratio);
                ComponentLeft.Height = CompositeLength.Shrink;
                ComponentLeft.LayoutDirection = LayoutDirection.Vertical;
                ComponentBottom.Components.Append(ComponentLeft);

                ComponentLeft1 = componentFactory.CreateComponent<VisualElement>();
                ComponentLeft1.Name = "Left1";
                ComponentLeft1.Width = CompositeLength.Fill;
                ComponentLeft1.Height = new CompositeLength(40, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentLeft.Components.Append(ComponentLeft1);

                ComponentLeft2 = componentFactory.CreateComponent<VisualElement>();
                ComponentLeft2.Name = "Left2";
                ComponentLeft2.Width = CompositeLength.Fill;
                ComponentLeft2.Height = new CompositeLength(40, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentLeft.Components.Append(ComponentLeft2);

                // RIGHT
                ComponentRight = componentFactory.CreateComponent<VisualElement>();
                ComponentRight.Name = "Right";
                ComponentRight.Width = new CompositeLength(3, UnitType.Ratio);
                ComponentRight.Height = CompositeLength.Fill;
                ComponentRight.LayoutDirection = LayoutDirection.Vertical;
                ComponentBottom.Components.Append(ComponentRight);

                ComponentRight1 = componentFactory.CreateComponent<VisualElement>();
                ComponentRight1.Name = "Right1";
                ComponentRight1.Width = CompositeLength.Fill;
                ComponentRight1.Height = new CompositeLength(40, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentRight.Components.Append(ComponentRight1);

                ComponentRight2 = componentFactory.CreateComponent<VisualElement>();
                ComponentRight2.Name = "Right2";
                ComponentRight2.Width = CompositeLength.Fill;
                ComponentRight2.Height = new CompositeLength(80, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentRight.Components.Append(ComponentRight2);
                */
            }
        }

    }
}
