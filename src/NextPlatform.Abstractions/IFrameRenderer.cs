// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Rendering;
using NextPlatform.Metrics;

namespace NextPlatform.Abstractions
{
    public interface IFrameRenderer
    {
        void DrawRectangle(Thickness rect, Color fillColor);
    }
}
