// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Rendering;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Drawing;

namespace AbsoluteGraphicsPlatform.Abstractions
{
    public interface IFrameRenderer
    {
        void DrawRectangle(AbsoluteRectangle rect, IBrush fill);
        void DrawLine(AbsoluteLine line, IBrush brush);
        void DrawText(AbsolutePoint location, Typeface typeface, string text, IBrush brush);
        void DrawMultilineText(AbsoluteRectangle box, Typeface typeface, string text, IBrush brush, float lineHeight = 1.2f);
    }
}
