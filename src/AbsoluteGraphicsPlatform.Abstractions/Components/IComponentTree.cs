// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    public interface IComponentTree : IComponentCollection
    {
        IComponent Owner { get; }
        IEnumerable<IComponent> FindAllChildren();
    }
}
