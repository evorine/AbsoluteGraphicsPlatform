// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using System.Linq;

namespace AbsoluteGraphicsPlatform.Styling
{
    public class StylingOptions
    {
        readonly ICollection<IStyleValueProvider> valueBinders;

        public StylingOptions()
        {
            valueBinders = new List<IStyleValueProvider>();
            Styles = new StyleCollection();
        }

        public ICollection<IStyleValueProvider> ValueBinders => valueBinders;

        public StyleCollection Styles { get; }
    }
}
