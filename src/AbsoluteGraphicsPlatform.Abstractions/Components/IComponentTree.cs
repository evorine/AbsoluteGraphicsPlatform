// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Abstractions.Components
{
    public interface IComponentTree
    {
        IComponent Owner { get; }
        IComponent Component { get; }
        string ContainerScope { get; }
        IEnumerable<IComponentTree> Children { get; }
        IEnumerable<IComponent> AllComponents { get; }
        void Restructure();
        void MarkAsDirty();
    }
}
