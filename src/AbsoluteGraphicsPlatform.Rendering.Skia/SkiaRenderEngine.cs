// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using SkiaSharp;
using AbsoluteGraphicsPlatform.Abstractions.Layout;

namespace AbsoluteGraphicsPlatform.Rendering.Skia
{
    public class SkiaRenderEngine : RenderEngine
    {
        public SkiaRenderEngine(ILayoutEngine layoutEngine)
            : base(layoutEngine)
        {

        }

        public override void RenderFrame(FrameBitmapBuffer buffer, IPlatformWindow owner)
        {
            var layoutResult = layoutEngine.ProcessLayout(owner.ClientSize, owner.ComponentTree);

            var info = new SKImageInfo(buffer.Width, buffer.Height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
            using (var surface = SKSurface.Create(info, buffer.Pixels, buffer.RowBytes))
            {
                foreach (var component in owner.ComponentTree.FindAllComponents())
                {
                    if (component is ILayoutBox layoutBox && component is IVisualComponent element)
                    {
                        var frameRenderer = new FrameRenderer(owner.ClientSize, surface);
                        var renderContext = new RenderContext()
                        {
                            FrameRenderer = frameRenderer,
                            ClientSize = owner.ClientSize,
                            LayoutInfo = layoutResult.GetLayoutBoxInformation(layoutBox)
                        };

                        element.Render(renderContext);
                    }
                }
            }
        }
    }
}
