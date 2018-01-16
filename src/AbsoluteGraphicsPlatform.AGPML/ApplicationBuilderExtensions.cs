// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace AbsoluteGraphicsPlatform.AGPML
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseLayoutLoader(this IApplicationBuilderBase builder)
        {
            builder.RegisterService<AGPMLParser>();
        }
    }
}
