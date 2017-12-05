using NextPlatform.Abstractions;
using NextPlatform.Controls.Abstractions;
using System;
using System.Collections.Generic;

namespace NextPlatform.Layout
{
    public class LayoutCalculationContext
    {
        readonly IDictionary<IComponent, LayoutBoxInformation> layoutBoxes;

        public LayoutCalculationContext()
        {
            layoutBoxes = new Dictionary<IComponent, LayoutBoxInformation>();
        }

    }
}
