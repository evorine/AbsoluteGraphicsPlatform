// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    public interface IComponentCollection : IEnumerable<IComponent>
    {
        IComponent this[int index] { get; }
        
        int Count { get; }
        void Add(IComponent component);
        void Insert(int index, IComponent component);
        bool Contains(IComponent item);
        void Clear();
        bool Remove(IComponent item);
    }
}
