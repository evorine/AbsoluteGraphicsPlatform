using NextPlatform.Abstractions;
using NextPlatform.Abstractions.Components;
using NextPlatform.Abstractions.Layout;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;

namespace NextPlatform.Layout
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
