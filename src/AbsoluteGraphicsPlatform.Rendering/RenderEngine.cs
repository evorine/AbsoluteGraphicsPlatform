// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Layout;

namespace AbsoluteGraphicsPlatform.Rendering
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
