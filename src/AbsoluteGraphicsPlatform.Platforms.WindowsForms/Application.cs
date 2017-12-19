// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Abstractions;

namespace AbsoluteGraphicsPlatform.Platforms.WindowsForms
{
    public class Application : ApplicationBase
    {
        public Application(IServiceProvider services)
            : base(services)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        }

        public override IPlatformWindow CreatePlatformWindow()
        {
            return new WinFormsWindow(this);
        }

        public override void Start(IPlatformWindow window)
        {
            var formsWindow = (WinFormsWindow)window;
            System.Windows.Forms.Application.Run(formsWindow.form);
        }
    }
}
