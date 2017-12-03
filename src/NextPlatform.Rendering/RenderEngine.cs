// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Controls.Abstractions;
using NextPlatform.Core;
using NextPlatform.Core.Layout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NextPlatform.Rendering
{
    public abstract class RenderEngine : IRenderEngine
    {
        protected readonly ILayoutEngine layoutEngine;
        public RenderEngine(ILayoutEngine layoutEngine)
        {
            this.layoutEngine = layoutEngine;
        }

        public abstract void RenderFrame(FrameBitmapBuffer buffer, IPlatformWindow owner);
    }
}
