﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Controls.Abstractions;
using NextPlatform.Metrics;

namespace NextPlatform.Abstractions
{
    public interface ILayoutEngine
    {
        void ProcessLayout(Size clientSize, IComponentTree componentTree);
    }
}