// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Abstractions.Components
{
    public interface IComponentCollection : IEnumerable<IComponent>
    {
        IComponent RootComponent { get; }
        IComponent Parent { get; }
        IComponent Component { get; }

        string ContainerScope { get; }

        IComponent this[int index] { get; }
        IEnumerable<IComponent> FindAllComponents();
        
        int Count { get; }
        void Add(IComponent component);
        void Insert(int index, IComponent component);
        bool Contains(IComponent item);
        void Clear();
        bool Remove(IComponent item);

        void Restructure();
        void MarkAsDirty();

    }
}
