// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Abstractions;
using NextPlatform.Abstractions.Layout;

namespace NextPlatform.Rendering.Skia
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilderBase UseSkia(this IApplicationBuilderBase applicationBuilder)
        {
            applicationBuilder.RegisterService<IRenderEngine, SkiaRenderEngine>();
            return applicationBuilder;
        }
    }
}
