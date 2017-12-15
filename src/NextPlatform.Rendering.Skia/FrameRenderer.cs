// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Abstractions.Drawing;
using NextPlatform.Drawing;
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
        readonly AbsoluteSize clientSize;

        public FrameRenderer(AbsoluteSize clientSize, SKSurface surface)
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

        public void DrawRectangle(AbsoluteRectangle rectangle, IBrush fill)
        {
            if (fill is SolidColorBrush solidBrush)
            {
                canvas.Save();
                var paint = new SKPaint();
                paint.IsAntialias = true;
                paint.Color = solidBrush.Color.ToSKColor();
                paint.StrokeWidth = 3;
                canvas.DrawRect(new SKRect(rectangle.X, rectangle.Y, rectangle.Right, rectangle.Bottom), paint);
                canvas.Restore();
            }
        }

        public void DrawLine(AbsoluteLine line, IBrush fill)
        {
            if (fill is SolidColorBrush solidBrush)
            {
                canvas.Save();
                var paint = new SKPaint();
                paint.IsAntialias = true;
                paint.Color = solidBrush.Color.ToSKColor();
                paint.StrokeWidth = line.Thickness;
                canvas.DrawLine(line.X1, line.Y1, line.X2, line.Y2, paint);
                canvas.Restore();
            }
        }
    }
}
