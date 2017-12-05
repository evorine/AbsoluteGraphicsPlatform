using NextPlatform.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions.Layout
{
    public class LayoutCalculationResult
    {
        readonly IDictionary<ILayoutBox, LayoutBoxInformation> layoutBoxes;
        public LayoutCalculationResult(IDictionary<ILayoutBox, LayoutBoxInformation> layoutBoxes)
        {
            this.layoutBoxes = layoutBoxes;
        }

        public LayoutBoxInformation GetLayoutBoxInformation(ILayoutBox component)
        {
            return layoutBoxes[component];
        }
    }
}
