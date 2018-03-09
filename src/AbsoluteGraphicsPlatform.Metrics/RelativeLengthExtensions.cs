// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    public static class RelativeLengthExtensions
    {
        public static RelativeLength Sum(this IEnumerable<RelativeLength> lengths)
        {
            RelativeLength sum = RelativeLength.Zero;
            foreach (var length in lengths)
                sum += length;
            return sum;
        }
    }
}
