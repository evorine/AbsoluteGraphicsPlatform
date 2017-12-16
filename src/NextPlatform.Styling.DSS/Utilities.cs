// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace NextPlatform.Styling.DSS
{
    internal static class Utilities
    {
        internal static string CreateString(this IEnumerable<char> chars) => new string(chars.ToArray());
    }
}
