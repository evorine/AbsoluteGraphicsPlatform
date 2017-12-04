// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Styling
{
    public struct StyleItem
    {
        public string Key { get; set; }
        public IStyleValue Value { get; set; }
    }
}
