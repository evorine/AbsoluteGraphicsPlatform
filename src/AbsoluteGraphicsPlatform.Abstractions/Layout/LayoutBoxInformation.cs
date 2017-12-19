// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions.Layout
{
    public class LayoutBoxInformation
    {
        public AbsoluteRectangle AbsoluteBox;
        public AbsoluteRectangle AbsoluteMarginBox;
        public AbsoluteRectangle AbsolutePaddingBox;

        public AbsoluteLine TopBorder;
        public AbsoluteLine RightBorder;
        public AbsoluteLine BottomBorder;
        public AbsoluteLine LeftBorder;

        public LayoutDirection LayoutDirection { get; set; }
    }
}
