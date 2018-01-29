// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.Abstractions.Layout
{
    public interface ILayoutEngine
    {
        LayoutCalculationResult ProcessLayout(AbsoluteSize clientSize, IComponentCollection componentTree);
    }
}
