// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions.Components;
using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.ComponentModel
{
    public class IVirtualComponentModel
    {
        IComponent RootComponent { get; set; }
    }
}
