// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions.Layout;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions
{
    public interface IRenderContext
    {
        AbsoluteSize ClientSize { get; }
        IFrameRenderer FrameRenderer { get; }
        LayoutBoxInformation LayoutInfo { get; }
    }
}
