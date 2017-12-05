// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions
{
    public class LayoutBoxInformation
    {
        public Thickness AbsoluteBox { get; set; }
        public Thickness AbsoluteMarginBox { get; set; }
        public Thickness AbsolutePaddingBox { get; set; }
        public LayoutDirection LayoutDirection { get; set; }
    }
}
