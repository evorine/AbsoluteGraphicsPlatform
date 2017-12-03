﻿using NextPlatform.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Metrics;
using NextPlatform.Core.Layout;

namespace NextPlatform.Rendering
{
    public class RenderContext : IRenderContext
    {
        public Size ClientSize { get; set; }
        public IFrameRenderer FrameRenderer { get; set; }
        public LayoutInfo LayoutInfo { get; set; }
    }
}