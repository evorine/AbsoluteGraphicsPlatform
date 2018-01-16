// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Styling;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class DSSOptions
    {
        readonly ICollection<IStyleValueProvider> valueBinders;

        public DSSOptions()
        {
            valueBinders = new List<IStyleValueProvider>();
            Styles = new StyleCollection();
        }

        public ICollection<IStyleValueProvider> ValueBinders => valueBinders;

        public StyleCollection Styles { get; }
    }
}
