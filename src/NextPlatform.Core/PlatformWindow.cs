// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Metrics;

namespace NextPlatform
{
    public abstract class PlatformWindow : IPlatformWindow
    {
        public PlatformWindow()
        {
            ComponentTree = new ComponentTree();
        }

        public IComponentTree ComponentTree { get; }

        public abstract Size ClientSize { get; }
        public abstract void Dispose();
        public abstract void Show();
    }
}
