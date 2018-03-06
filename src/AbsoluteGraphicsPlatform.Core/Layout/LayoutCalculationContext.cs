using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Layout
{
    internal class LayoutCalculationContext
    {
        internal readonly IDictionary<IElement, LayoutBoxInformation> LayoutBoxes;

        internal LayoutCalculationContext()
        {
            LayoutBoxes = new Dictionary<IElement, LayoutBoxInformation>();
        }

        internal LayoutBoxInformation GetLayoutBoxInformation(IElement element)
        {
            if (LayoutBoxes.TryGetValue(element, out var box))
                return box;

            box = new LayoutBoxInformation();
            LayoutBoxes[element] = box;
            return box;
        }

        internal void SetLayoutBoxInformation(IElement component, LayoutBoxInformation boxInformation)
        {
            LayoutBoxes[component] = boxInformation;
        }

    }
}
