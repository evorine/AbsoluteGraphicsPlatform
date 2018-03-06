// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    public interface IElementTree
    {
        IComponent Owner { get; }
        IElementCollection Children { get; }
        IEnumerable<IElement> FindAllChildren();
    }
}
