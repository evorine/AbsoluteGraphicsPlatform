﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Rendering;

namespace AbsoluteGraphicsPlatform.Abstractions
{
    public interface IRenderEngine
    {
        void RenderFrame(FrameBitmapBuffer buffer, IPlatformWindow owner);
    }
}
