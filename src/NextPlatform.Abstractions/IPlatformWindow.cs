// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions.Components;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions
{
    public interface IPlatformWindow : IDisposable
    {
        IComponentTree ComponentTree { get; }
        void Show();
        AbsoluteSize ClientSize { get; }
    }
}
