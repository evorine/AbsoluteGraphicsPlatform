// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Platforms.WindowsForms;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Rendering.Skia;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Layout;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Styling;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.AGPML;
using Microsoft.Extensions.FileProviders.Physical;

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
            appBuilder.UseLayoutLoader();
            appBuilder.ConfigureStyling((options) =>
            {
                options.Styles.Add(parseTestStyle());
            });
            appBuilder.UseSkia();
            
            var app = appBuilder.Build();

            var window = app.CreatePlatformWindow();
            var testData = new BasicTestData(window.ComponentTree);

            app.Start(window);
        }


        private static IStyle parseTestStyle()
        {
            var fileInfo = new PhysicalFileInfo(new System.IO.FileInfo(@"C:\Playground\AbsoluteGraphicsPlatform\tests\TestFiles\TestStyle1.dss"));
            var dssParser = new AbsoluteGraphicsPlatform.DSS.StyleParser();

            var sourceInfo = new SourceCodeInfo(fileInfo);
            var style = dssParser.Parse(sourceInfo);
            return style;
        }

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
                ComponentRoot = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentRoot.Name = "Root";
                ComponentRoot.Width = CompositeLength.Fill;
                ComponentRoot.Height = CompositeLength.Fill;
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                componentTree.RootComponent = ComponentRoot;

                ComponentTop = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentTop.Name = "Top";
                ComponentTop.Width = CompositeLength.Fill;
                ComponentTop.Height = new CompositeLength(50, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentRoot.Components.Append(ComponentTop);

                ComponentBottom = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentBottom.Name = "Bottom";
                ComponentBottom.Width = CompositeLength.Fill;
                ComponentBottom.Height = CompositeLength.Fill;
                ComponentBottom.LayoutDirection = LayoutDirection.Horizontal;
                ComponentRoot.Components.Append(ComponentBottom);

                // LEFT
                ComponentLeft = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentLeft.Name = "Left";
                ComponentLeft.Width = new CompositeLength(1, UnitType.Ratio);
                ComponentLeft.Height = CompositeLength.Shrink;
                ComponentLeft.LayoutDirection = LayoutDirection.Vertical;
                ComponentBottom.Components.Append(ComponentLeft);

                ComponentLeft1 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentLeft1.Name = "Left1";
                ComponentLeft1.Width = CompositeLength.Fill;
                ComponentLeft1.Height = new CompositeLength(40, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentLeft.Components.Append(ComponentLeft1);

                ComponentLeft2 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentLeft2.Name = "Left2";
                ComponentLeft2.Width = CompositeLength.Fill;
                ComponentLeft2.Height = new CompositeLength(40, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentLeft.Components.Append(ComponentLeft2);

                // RIGHT
                ComponentRight = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentRight.Name = "Right";
                ComponentRight.Width = new CompositeLength(3, UnitType.Ratio);
                ComponentRight.Height = CompositeLength.Fill;
                ComponentRight.LayoutDirection = LayoutDirection.Vertical;
                ComponentBottom.Components.Append(ComponentRight);

                ComponentRight1 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentRight1.Name = "Right1";
                ComponentRight1.Width = CompositeLength.Fill;
                ComponentRight1.Height = new CompositeLength(40, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentRight.Components.Append(ComponentRight1);

                ComponentRight2 = componentTree.ComponentFactory.CreateComponent<VisualElement>();
                ComponentRight2.Name = "Right2";
                ComponentRight2.Width = CompositeLength.Fill;
                ComponentRight2.Height = new CompositeLength(80, UnitType.Pixel);
                ComponentRoot.LayoutDirection = LayoutDirection.Vertical;
                ComponentRight.Components.Append(ComponentRight2);
            }
        }

    }
}
