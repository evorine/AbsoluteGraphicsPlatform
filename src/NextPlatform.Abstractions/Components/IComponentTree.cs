// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Controls.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Controls.Abstractions
{
    public interface IComponentTree
    {
        IComponentFactory ComponentFactory { get; }
        IEnumerable<IComponent> AllComponents { get; }
        IComponent RootComponent { get; set; }
        IEnumerable<IComponent> LeafComponents { get; }
    }
}
