// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using NextPlatform.Styling.Parser;

namespace NextPlatform.Styling
{
    public class Style : IStyle
    {
        public Style()
        {
            styleItems = new List<StylePropertySetter>();
        }

        List<StylePropertySetter> styleItems;
        public IEnumerable<StylePropertySetter> StyleItems
        {
            get { return styleItems.AsEnumerable(); }
        }
    }
}
