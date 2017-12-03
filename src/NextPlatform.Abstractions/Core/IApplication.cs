// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions
{
    public interface IApplication
    {
        IRenderEngine RenderEngine { get; }
        IPlatformWindow CreatePlatformWindow();
        void Start(IPlatformWindow window);
    }
}
