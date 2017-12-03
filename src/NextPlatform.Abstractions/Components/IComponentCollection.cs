// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Controls.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Controls.Abstractions
{
    public interface IComponentCollection : IEnumerable<IComponent>
    {
        int Count { get; }
        void Append(IComponent component);
        bool Contains(IComponent item);
        void Clear();
        bool Remove(IComponent item);
    }
}
