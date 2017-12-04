// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions
{
    public interface ILayoutBox
    {
        LayoutDirection LayoutDirection { get; set; }

        CompositeLength Width { get; set; }
        CompositeLength Height { get; set; }
        Rectangle Margin { get; set; }
        Rectangle Padding { get; set; }
    }
}
