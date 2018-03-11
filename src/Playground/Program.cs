// Licensed under the MIT license.
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
            appBuilder.UseDss();
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
            window.ComponentTree = windowComponent.ElementTree;


            var styleSetter = (DssStyleSetter)app.GetService<IStyleSetter>();
            styleSetter.ApplyFullStyleRecursivly(windowComponent.ElementTree);

            app.Start(window);
        }


        private static IStyle parseTestStyle()
        {
            var fileInfo = new PhysicalFileInfo(new System.IO.FileInfo(@"C:\Playground\AbsoluteGraphicsPlatform\tests\TestFiles\TestStyle1.dss"));
            var expressionExecutor = new ExpressionExecutor();
            var dssParser = new DssParser();
            var dssCompiler = new DssCompiler(expressionExecutor);

            var sourceInfo = new SourceCodeInfo(fileInfo);
            var instructions = dssParser.Parse(sourceInfo);
            var style = dssCompiler.Compile(instructions);
            return style;
        }

        const string boxTemplate = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
<component-template Name=""Box"">
    <Component>
        <component-placeholder />
    </Component>
</component-template>";

        const string layoutTemplate = @"
<?using AbsoluteGraphicsPlatform.Components?>
<?using AbsoluteGraphicsPlatform.Tests.Common.Components?>
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
    }
}
