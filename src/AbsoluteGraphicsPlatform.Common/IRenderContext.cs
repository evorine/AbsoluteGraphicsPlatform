// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions
{
    public interface IRenderContext
    {
        AbsoluteSize ClientSize { get; }
        IFrameRenderer FrameRenderer { get; }
        LayoutBoxInformation LayoutInfo { get; }
    }
}
