// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform
{
    public abstract class PlatformWindow : IPlatformWindow
    {
        public PlatformWindow()
        {
        }

        public IComponentTree ComponentTree { get; set; }

        public abstract AbsoluteSize ClientSize { get; }
        public abstract void Dispose();
        public abstract void Show();
    }
}
