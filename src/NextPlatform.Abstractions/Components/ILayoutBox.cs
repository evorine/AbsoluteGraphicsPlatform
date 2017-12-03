// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Controls.Abstractions
{
    public interface ILayoutBox
    {
        LayoutDirection LayoutDirection { get; set; }

        Length Width { get; set; }
        Length Height { get; set; }
        Rectangle Margin { get; set; }
        Rectangle Padding { get; set; }
    }
}
