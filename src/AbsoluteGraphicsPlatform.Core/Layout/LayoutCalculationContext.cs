using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Layout
{
    internal class LayoutCalculationContext
    {
        internal readonly IDictionary<IComponent, LayoutBoxInformation> LayoutBoxes;

        internal LayoutCalculationContext()
        {
            LayoutBoxes = new Dictionary<IComponent, LayoutBoxInformation>();
        }

        internal LayoutBoxInformation GetLayoutBoxInformation(IComponent component)
        {
            if (LayoutBoxes.TryGetValue(component, out var box))
                return box;

            box = new LayoutBoxInformation();
            LayoutBoxes[component] = box;
            return box;
        }

        internal void SetLayoutBoxInformation(IComponent component, LayoutBoxInformation boxInformation)
        {
            LayoutBoxes[component] = boxInformation;
        }

    }
}
