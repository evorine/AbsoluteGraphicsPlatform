﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions.Components
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
