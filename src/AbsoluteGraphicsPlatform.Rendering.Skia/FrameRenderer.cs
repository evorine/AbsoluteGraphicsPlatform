// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Drawing;
using AbsoluteGraphicsPlatform.Metrics;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AbsoluteGraphicsPlatform.Rendering.Skia
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
            canvas.Save();
            var paint = fill.ToSKPaint();
            canvas.DrawRect(new SKRect(rectangle.X, rectangle.Y, rectangle.Right, rectangle.Bottom), paint);
            canvas.Restore();
        }

        public void DrawLine(AbsoluteLine line, IBrush brush)
        {
            canvas.Save();
            var paint = brush.ToSKPaint();
            canvas.DrawLine(line.X1, line.Y1, line.X2, line.Y2, paint);
            canvas.Restore();
        }

        public void DrawText(AbsolutePoint location, Typeface typeface, string text, IBrush brush)
        {
            var paint = typeface.ToSKPaint(brush);
            canvas.DrawText(text, location.X, location.Y, paint);
        }

        public void DrawMultilineText(AbsoluteRectangle box, Typeface typeface, string text, IBrush brush, float lineHeight = 1.2f)
        {

            var paint = typeface.ToSKPaint(brush);
            canvas.Save();
            canvas.ClipRect(box.ToSKRect());
            var lines = splitLines(text, paint, box.Width);
            for(var i = 0; i < lines.Length; i++)
            {
                DrawText(new AbsolutePoint(box.Location.X, box.Location.Y + (i + 1) * typeface.Size * lineHeight), typeface, lines[i].text, brush);
            }
            canvas.Restore();
        }

        private IEnumerable<string> splitNewLines(string text)
        {
            using (StringReader sr = new StringReader(text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        private (string text, float width)[] splitLines(string text, SKPaint paint, float maxWidth)
        {
            var lines = splitNewLines(text);
            var spaceWidth = paint.MeasureText(" ");
            
            return lines.SelectMany((line) =>
            {
                var result = new List<(string, float)>();

                var words = line.Split(new[] { " " }, StringSplitOptions.None);

                var lineResult = new StringBuilder();
                float width = 0;
                foreach (var word in words)
                {
                    var wordWidth = paint.MeasureText(word);
                    var wordWithSpaceWidth = wordWidth + spaceWidth;
                    var wordWithSpace = word + " ";

                    if (width + wordWidth > maxWidth)
                    {
                        result.Add((lineResult.ToString(), width));
                        lineResult = new StringBuilder(wordWithSpace);
                        width = wordWithSpaceWidth;
                    }
                    else
                    {
                        lineResult.Append(wordWithSpace);
                        width += wordWithSpaceWidth;
                    }
                }

                result.Add((lineResult.ToString(), width));
                return result.ToArray();
            }).ToArray();
        }
    }
}
