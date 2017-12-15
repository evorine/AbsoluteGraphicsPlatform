// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NextPlatform.Abstractions.Components;
using NextPlatform.Abstractions;
using NextPlatform.Metrics;
using NextPlatform.Styling;
using NextPlatform.Abstractions.Layout;

namespace NextPlatform.Components
{
    public class VisualElement : Component, IVisualElement, ILayoutBox
    {
        public VisualElement()
        {
            Style = new Style();
        }
        public virtual IStyle Style { get; set; }


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
            renderContext.FrameRenderer.DrawRectangle(renderContext.LayoutInfo.AbsoluteBox, randomColor());

            var (top, right, bottom, left) = renderContext.LayoutInfo.AbsoluteBox.GetBorders();
            top.Thickness = 3;
            right.Thickness = 3;
            bottom.Thickness = 3;
            left.Thickness = 3;
            var borderColor = randomColor();
            renderContext.FrameRenderer.DrawLine(top, borderColor);
            renderContext.FrameRenderer.DrawLine(right, borderColor);
            renderContext.FrameRenderer.DrawLine(bottom, borderColor);
            renderContext.FrameRenderer.DrawLine(left, borderColor);
        }

        private Color randomColor()
        {
            var bytes = new byte[3];
            DUMMY.rnd.NextBytes(bytes);
            return new Color(bytes[0], bytes[1], bytes[2], 200);
        }
    }
}
