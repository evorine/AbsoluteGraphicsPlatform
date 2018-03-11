// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public sealed class TuplePropertyValue : IPropertyValue
    {
        readonly IPropertyValue[] values;

        public TuplePropertyValue(IPropertyValue[] values)
        {
            this.values = values;
        }

        public IPropertyValue[] Values => values;
    }
}
