using NextPlatform.Abstractions;
using NextPlatform.Controls.Abstractions;
using System;
using System.Collections.Generic;

namespace NextPlatform.Core.Layout
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
