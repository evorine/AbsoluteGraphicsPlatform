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

        RelativeLength Width { get; set; }
        RelativeLength Height { get; set; }
        RelativeThickness Margin { get; set; }
        RelativeThickness Padding { get; set; }

        LayoutBoxInformation CalculatedLayoutBox { get; set; }
    }
}
