using NextPlatform.Abstractions;
using NextPlatform.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPlatform.Platforms.WindowsForms
{
    public class Application : ApplicationBase
    {
        readonly IRenderEngine renderEngine;
        public Application(IRenderEngine renderEngine)
            : base(renderEngine)
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
