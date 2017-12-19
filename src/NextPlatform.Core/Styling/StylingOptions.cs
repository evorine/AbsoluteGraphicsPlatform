// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Abstractions.Styling;
using System.Linq;

namespace NextPlatform.Styling
{
    public class StylingOptions
    {
        readonly ICollection<IStyleValueProvider> valueBinders;

        public StylingOptions()
        {
            valueBinders = new List<IStyleValueProvider>();
        }

        public ICollection<IStyleValueProvider> ValueBinders => valueBinders;
    }
}
