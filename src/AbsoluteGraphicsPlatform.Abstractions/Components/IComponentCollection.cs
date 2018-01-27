// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions.Components
{
    public interface IComponentCollection : IEnumerable<IComponent>
    {
        IComponent this[int index] { get; }
        int Count { get; }
        void Append(IComponent component);
        bool Contains(IComponent item);
        void Clear();
        bool Remove(IComponent item);
    }
}
