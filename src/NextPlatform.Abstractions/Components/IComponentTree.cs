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
        IEnumerable<IComponent> RootComponents { get; }
        IEnumerable<IComponent> LeafComponents { get; }
        void AppendRootComponent(IComponent component);
        void Recalculate();
    }
}
