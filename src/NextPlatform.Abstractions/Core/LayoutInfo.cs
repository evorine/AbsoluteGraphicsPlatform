using NextPlatform.Controls.Abstractions;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Core.Layout
{
    public class LayoutInfo
    {
        public Rectangle AbsoluteBox { get; set; }
        public Rectangle AbsoluteMarginBox { get; set; }
        public Rectangle AbsolutePaddingBox { get; set; }
        public LayoutDirection LayoutDirection { get; set; }
    }
}
