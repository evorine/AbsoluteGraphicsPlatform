// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions.Components
{
    public interface IComponentTree
    {
        IEnumerable<IComponent> AllComponents { get; }
        IComponent RootComponent { get; set; }
        IEnumerable<IComponent> LeafComponents { get; }
        void Restructure();
        void MarkAsDirty();
    }
}
