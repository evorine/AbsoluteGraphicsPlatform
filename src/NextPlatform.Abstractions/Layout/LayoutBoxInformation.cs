// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions.Layout
{
    public class LayoutBoxInformation
    {
        public AbsoluteRectangle AbsoluteBox { get; set; }
        public AbsoluteRectangle AbsoluteMarginBox { get; set; }
        public AbsoluteRectangle AbsolutePaddingBox { get; set; }
        public LayoutDirection LayoutDirection { get; set; }
    }
}
