using NextPlatform.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Core
{
    public abstract class ApplicationBase : IApplication
    {
        public ApplicationBase(IRenderEngine renderEngine)
        {
            RenderEngine = renderEngine;
        }

        public IRenderEngine RenderEngine { get; }

        public abstract IPlatformWindow CreatePlatformWindow();
        public abstract void Start(IPlatformWindow window);
    }
}
