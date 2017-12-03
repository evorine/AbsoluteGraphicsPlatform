// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace NextPlatform.Styling
{
    public interface IStyle
    {
        IEnumerable<StyleItem> StyleItems { get; }
    }
}
