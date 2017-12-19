// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions.Layout
{
    public interface ILayoutBox
    {
        LayoutDirection LayoutDirection { get; set; }

        CompositeLength Width { get; set; }
        CompositeLength Height { get; set; }
        Thickness Margin { get; set; }
        Thickness Padding { get; set; }

        LayoutBoxInformation CalculatedLayoutBox { get; set; }
    }
}
