// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions
{
    public interface IPlatformWindow : IDisposable
    {
        IComponentCollection ComponentTree { get; }
        void Show();
        AbsoluteSize ClientSize { get; }
    }
}
