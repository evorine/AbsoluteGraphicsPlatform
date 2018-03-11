// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseDSS(this IApplicationBuilderBase builder)
        {
            builder.RegisterService<DssRuntime>();
            builder.RegisterService<DssParser>();
            builder.RegisterService<IStyleSetter, DssStyleSetter>();
        }
    }
}
