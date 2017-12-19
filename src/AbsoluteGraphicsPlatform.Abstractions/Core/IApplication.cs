// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions
{
    public interface IApplication
    {
        IPlatformWindow CreatePlatformWindow();
        void Start(IPlatformWindow window);

        TService GetService<TService>() where TService : class;
        TOptions GetOptions<TOptions>() where TOptions : class, new();
    }
}
