// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    public interface IElementCollection : IEnumerable<IElement>
    {
        IElement this[int index] { get; }
        
        int Count { get; }
        void Add(IElement component);
        void Insert(int index, IElement component);
        bool Contains(IElement item);
        void Clear();
        bool Remove(IElement item);
    }
}
