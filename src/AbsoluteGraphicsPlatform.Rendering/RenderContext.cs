// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Abstractions.Layout;

namespace AbsoluteGraphicsPlatform.Rendering
{
    public class RenderContext : IRenderContext
    {
        public AbsoluteSize ClientSize { get; set; }
        public IFrameRenderer FrameRenderer { get; set; }
        public LayoutBoxInformation LayoutInfo { get; set; }
    }
}
