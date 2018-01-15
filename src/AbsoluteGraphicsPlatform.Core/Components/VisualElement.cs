// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Metrics;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Drawing;
using AbsoluteGraphicsPlatform.Styling;

namespace AbsoluteGraphicsPlatform.Components
{
    public class VisualElement : Component, IVisualElement, ILayoutBox
    {
        public VisualElement()
        {
        }


        [ComponentProperty]
        public virtual LayoutDirection LayoutDirection { get; set; }

        [ComponentProperty]
        public virtual CompositeLength Width { get; set; }

        [ComponentProperty]
        public virtual CompositeLength Height { get; set; }

        [ComponentProperty]
        public virtual Thickness Margin { get; set; }

        [ComponentProperty]
        public virtual Thickness Padding { get; set; }

        public LayoutBoxInformation CalculatedLayoutBox { get; set; }


        public virtual void Render(IRenderContext renderContext)
        {
            // Rectangle
            renderContext.FrameRenderer.DrawRectangle(renderContext.LayoutInfo.AbsoluteBox, new SolidColorBrush(randomColorTransparent()));


            // Borders
            var (top, right, bottom, left) = renderContext.LayoutInfo.AbsoluteBox.GetBorders();
            top.Thickness = 3;
            right.Thickness = 3;
            bottom.Thickness = 3;
            left.Thickness = 3;
            var borderBrush = new SolidColorBrush(randomColorTransparent());
            renderContext.FrameRenderer.DrawLine(top, borderBrush);
            renderContext.FrameRenderer.DrawLine(right, borderBrush);
            renderContext.FrameRenderer.DrawLine(bottom, borderBrush);
            renderContext.FrameRenderer.DrawLine(left, borderBrush);


            // Text
            var typeface = new Typeface("Roboto", 12, false, FontWeight.Normal);
            renderContext.FrameRenderer.DrawMultilineText(renderContext.LayoutInfo.AbsoluteBox, typeface, string.Join(" ", System.Linq.Enumerable.Repeat(Name, 10)), new SolidColorBrush(randomColor()));
        }

        private Color randomColorTransparent()
        {
            var bytes = new byte[3];
            DUMMY.rnd.NextBytes(bytes);
            return new Color(bytes[0], bytes[1], bytes[2], 150);
        }
        private Color randomColor()
        {
            var bytes = new byte[3];
            DUMMY.rnd.NextBytes(bytes);
            return new Color(bytes[0], bytes[1], bytes[2], 255);
        }
    }
}
