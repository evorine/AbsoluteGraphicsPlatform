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
    }
}
