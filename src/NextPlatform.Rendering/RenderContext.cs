// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Metrics;
using NextPlatform.Abstractions.Layout;

namespace NextPlatform.Rendering
{
    public class RenderContext : IRenderContext
    {
        public AbsoluteSize ClientSize { get; set; }
        public IFrameRenderer FrameRenderer { get; set; }
        public LayoutBoxInformation LayoutInfo { get; set; }
    }
}
