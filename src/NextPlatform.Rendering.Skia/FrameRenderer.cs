// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Metrics;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Rendering.Skia
{
    public class FrameRenderer : IFrameRenderer
    {
        readonly SKSurface surface;
        readonly SKCanvas canvas;
        readonly Size clientSize;
        public FrameRenderer(Size clientSize, SKSurface surface)
        {
            this.clientSize = clientSize;
            this.surface = surface;
            canvas = surface.Canvas;
        }

        public void ResetBackground()
        {
            /*
            var paint = new SKPaint();
            paint.IsAntialias = true;
            paint.Color = new SKColor(0, 0, 0);
            paint.StrokeWidth = 3;
            canvas.DrawRect(new SKRect(0, 0, clientSize.Width.Magnitude, clientSize.Height.Magnitude), paint);*/
        }

        public void DrawRectangle(Rectangle rect, Color fillColor)
        {
            canvas.Save();
            var paint = new SKPaint();
            paint.IsAntialias = true;
            paint.Color = fillColor.ToSKColor();
            paint.StrokeWidth = 3;
            canvas.DrawRect(new SKRect(rect.Left[UnitType.Pixel], rect.Top[UnitType.Pixel], rect.Right[UnitType.Pixel], rect.Bottom[UnitType.Pixel]), paint);
            canvas.Restore();
        }
    }
}
