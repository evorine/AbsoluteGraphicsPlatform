// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Controls.Abstractions;
using NextPlatform.Core;
using NextPlatform.Core.Layout;
using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NextPlatform.Rendering.Skia
{
    public class SkiaRenderEngine : RenderEngine
    {
        public SkiaRenderEngine(ILayoutEngine layoutEngine)
            : base(layoutEngine)
        {

        }

        public override void RenderFrame(FrameBitmapBuffer buffer, IPlatformWindow owner)
        {
            var ly = (LayoutEngine)layoutEngine;
            layoutEngine.ProcessLayout(owner.ClientSize, owner.ComponentTree);

            var info = new SKImageInfo(buffer.Width, buffer.Height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
            using (var surface = SKSurface.Create(info, buffer.Pixels, buffer.RowBytes))
            {
                foreach (var component in owner.ComponentTree.AllComponents)
                {
                    var frameRenderer = new FrameRenderer(owner.ClientSize, surface);
                    var renderContext = new RenderContext()
                    {
                        FrameRenderer = frameRenderer,
                        ClientSize = owner.ClientSize,
                        LayoutInfo = ly.layoutData[component]
                    };

                    if (component is IVisualElement element)
                        element.Render(renderContext);
                }
            }
        }
    }
}
