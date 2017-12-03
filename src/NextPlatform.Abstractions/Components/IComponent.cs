// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Controls.Abstractions
{
    public interface IComponent
    {
        string Name { get; set; }
        IComponentCollection Components { get; }
        IComponent Parent { get; }

        // This may be protected.
        void Emit(object payload);
    }
}
