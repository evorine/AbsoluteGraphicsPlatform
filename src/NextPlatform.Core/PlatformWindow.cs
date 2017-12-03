using NextPlatform.Abstractions;
using NextPlatform.Controls.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Metrics;

namespace NextPlatform.Core
{
    public abstract class PlatformWindow : IPlatformWindow
    {
        public PlatformWindow()
        {
            ComponentTree = new ComponentTree();
        }

        public IComponentTree ComponentTree { get; }

        public abstract Size ClientSize { get; }
        public abstract void Dispose();
        public abstract void Show();
    }
}
