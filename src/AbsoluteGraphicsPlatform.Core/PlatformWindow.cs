// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform
{
    public abstract class PlatformWindow : IPlatformWindow
    {
        public PlatformWindow()
        {
            ComponentTree = new ComponentTree();
        }

        public IComponentTree ComponentTree { get; }

        public abstract AbsoluteSize ClientSize { get; }
        public abstract void Dispose();
        public abstract void Show();
    }
}
