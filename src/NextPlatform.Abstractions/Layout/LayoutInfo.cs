// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Layout
{
    public class LayoutInfo
    {
        public Rectangle AbsoluteBox { get; set; }
        public Rectangle AbsoluteMarginBox { get; set; }
        public Rectangle AbsolutePaddingBox { get; set; }
        public LayoutDirection LayoutDirection { get; set; }
    }
}
