// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Abstractions.Components;
using NextPlatform.Metrics;

namespace NextPlatform.Abstractions.Layout
{
    public interface ILayoutEngine
    {
        void ProcessLayout(AbsoluteSize clientSize, IComponentTree componentTree);
    }
}
