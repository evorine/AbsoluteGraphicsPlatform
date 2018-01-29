// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.Abstractions.Layout
{
    public interface ILayoutEngine
    {
        LayoutCalculationResult ProcessLayout(AbsoluteSize clientSize, IComponentTree componentTree);
    }
}
