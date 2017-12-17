// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using NextPlatform.Styling.Models;

namespace NextPlatform.Styling
{
    public class Style : IStyle
    {
        public Style()
        {
            styleItems = new List<StyleDeclaration>();
        }

        List<StyleDeclaration> styleItems;
        public IEnumerable<StyleDeclaration> StyleItems
        {
            get { return styleItems.AsEnumerable(); }
        }
    }
}
