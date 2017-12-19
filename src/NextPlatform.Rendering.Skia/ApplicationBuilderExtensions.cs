// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NextPlatform.Abstractions;
using NextPlatform.Styling;
using NextPlatform.Abstractions.Layout;

namespace NextPlatform.Rendering.Skia
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilderBase UseSkia(this IApplicationBuilderBase applicationBuilder)
        {
            var layoutEngine = new Layout.LayoutEngine();
            var renderEngine = new SkiaRenderEngine(layoutEngine);

            applicationBuilder.RegisterService<ILayoutEngine>(layoutEngine);
            applicationBuilder.RegisterService<IRenderEngine>(renderEngine);

            return applicationBuilder;
        }
    }
}
