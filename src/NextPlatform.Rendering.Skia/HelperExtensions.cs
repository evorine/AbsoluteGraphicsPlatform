// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Drawing;
using NextPlatform.Metrics;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Rendering.Skia
{
    public static class HelperExtensions
    {
        public static SKColor ToSKColor(this Color color)
        {
            return new SKColor(color.Red, color.Green, color.Blue, color.Alpha);
        }
        public static SKRect ToSKRect(this AbsoluteRectangle rectangle)
        {
            return new SKRect(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
        }

        public static SKPaint ToSKPaint(this IBrush brush)
        {
            if (brush is SolidColorBrush solidColorBrush)
            {
                return new SKPaint()
                {
                    Color = solidColorBrush.Color.ToSKColor(),
                    IsAntialias = true,
                    StrokeWidth = 1
                };
            }
            throw new NotImplementedException($"Unsupported brush type is passed in! Brush type: '{brush.GetType().FullName}'");
        }

        public static SKPaint ToSKPaint(this Typeface typeface, IBrush brush)
        {
            var paint = brush.ToSKPaint();
            paint.Typeface = SKTypeface.FromFamilyName(typeface.FontFamily);
            paint.TextSize = typeface.Size;
            return paint;
        }
    }
}
