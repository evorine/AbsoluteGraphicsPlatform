// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NextPlatform.Controls.Abstractions;
using NextPlatform.Styling;
using NextPlatform.Abstractions;
using NextPlatform.Metrics;

namespace NextPlatform.Controls
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
        }

        private Color randomColor()
        {
            var bytes = new byte[3];
            Core.DUMMY.rnd.NextBytes(bytes);
            return new Color(bytes[0], bytes[1], bytes[2], 255);
        }
    }
}
