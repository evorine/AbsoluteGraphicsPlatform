// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace NextPlatform.Styling
{
    public class Style : IStyle
    {
        public Style()
        {
            styleItems = new List<StyleItem>();
        }

        List<StyleItem> styleItems;
        public IEnumerable<StyleItem> StyleItems
        {
            get { return styleItems.AsEnumerable(); }
        }
    }
}
