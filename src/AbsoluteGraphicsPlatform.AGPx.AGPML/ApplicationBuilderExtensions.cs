// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseLayoutLoader(this IApplicationBuilderBase builder)
        {
            builder.RegisterService<AGPMLParser>();
            builder.RegisterService<ComponentTemplateCollection>();
        }
    }
}
