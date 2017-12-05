﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Abstractions.Components;
using NextPlatform.Abstractions.Layout;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextPlatform.Layout
{
    public class LayoutEngine2 /*: ILayoutEngine*/
    {
        public IDictionary<IComponent, LayoutBoxInformation> layoutData = new Dictionary<IComponent, LayoutBoxInformation>();

        public void ProcessLayout(AbsoluteSize clientSize, IComponentTree componentTree)
        {
            generateLayoutDatas(componentTree);
            var rootComponent = componentTree.RootComponent;
            layoutData[rootComponent].AbsoluteBox = new AbsoluteRectangle(0, 0, clientSize.Width, clientSize.Height);
            layoutData[rootComponent].AbsoluteMarginBox = layoutData[rootComponent].AbsoluteBox;
            layoutData[rootComponent].AbsolutePaddingBox = layoutData[rootComponent].AbsoluteBox;
            layoutData[rootComponent].LayoutDirection = LayoutDirection.Vertical;

            var offset = new AbsoluteRectangle();
            foreach (var component in rootComponent.Components)
                processComponent(component, rootComponent.Components, ref offset);
        }


        private float calculateLength(CompositeLength componentLength, CompositeLength totalLength, float absoluteClientLength)
        {
            // Calculate unrelated length in pixel
            // TODO: Temporarly Unit type is calculated as Pixel type.
            var lengthUnrelated = componentLength[UnitType.Pixel] + componentLength[UnitType.Unit] + (absoluteClientLength * componentLength[UnitType.Percentage] / 100);
            var totalUnrelated = totalLength[UnitType.Pixel] + totalLength[UnitType.Unit] + (absoluteClientLength * totalLength[UnitType.Percentage] / 100);

            /*
            // If there is a sibling using Ratio, all Fills are targeted as Shrink
            if (componentLength[UnitType.Ratio] != 0 && componentLength == LengthExpression.Fill)
                return ...;
            */
            
            // If there is a related length we have to calculate it with siblings
            if (componentLength[UnitType.Ratio] != 0)
            {

                // Get the dynamic length
                var rest = absoluteClientLength - totalUnrelated;
                var totalDynamicLength = totalLength[UnitType.Ratio];



                var factor = rest / totalDynamicLength;
                return lengthUnrelated + (factor * componentLength[UnitType.Ratio]);
            }
            else if (componentLength == CompositeLength.Fill)
            {
                return absoluteClientLength - totalUnrelated + lengthUnrelated;
            }
            else
            {
                // Calculate unrelated length in pixel
                // TODO: Temporarly Unit type is calculated as Pixel type.
                return lengthUnrelated;
            }
        }

        private void processComponent(IComponent component, IEnumerable<IComponent> siblings, ref AbsoluteRectangle offset)
        {
            var parentLayoutData = layoutData[component.Parent];
            if (component is ILayoutBox box)
            {
                var hasClientWidth = box.Width != CompositeLength.Shrink;
                var clientWidth = parentLayoutData.AbsolutePaddingBox.Right - parentLayoutData.AbsolutePaddingBox.Left;
                var hasClientHeight = box.Height != CompositeLength.Shrink;
                var clientHeight = parentLayoutData.AbsolutePaddingBox.Bottom - parentLayoutData.AbsolutePaddingBox.Top;

                var totalWidth = siblings.Where(x => x is ILayoutBox).Select(x => ((ILayoutBox)x).Width).Aggregate((total, sibling) => { return total + sibling; });
                var width = calculateLength(box.Width, totalWidth, clientWidth);

                var totalHeight = siblings.Where(x => x is ILayoutBox).Select(x => ((ILayoutBox)x).Height).Aggregate((total, sibling) => { return total + sibling; });
                var height = calculateLength(box.Height, totalHeight, clientHeight);

                layoutData[component].AbsoluteMarginBox = new AbsoluteRectangle(
                    parentLayoutData.AbsoluteMarginBox.Top + offset.Top,
                    parentLayoutData.AbsoluteMarginBox.Left + width + offset.Left,
                    parentLayoutData.AbsoluteMarginBox.Top + height + offset.Top,
                    parentLayoutData.AbsoluteMarginBox.Left + offset.Left
                );
                layoutData[component].AbsoluteBox = layoutData[component].AbsoluteMarginBox;
                layoutData[component].AbsolutePaddingBox = layoutData[component].AbsoluteMarginBox;
                layoutData[component].LayoutDirection = box.LayoutDirection;

                if (parentLayoutData.LayoutDirection == LayoutDirection.Horizontal) offset.X += width;
                else offset.Y += height;
            }
            else
            {
                layoutData[component].AbsoluteMarginBox = parentLayoutData.AbsoluteMarginBox;
                layoutData[component].AbsoluteBox = parentLayoutData.AbsoluteBox;
                layoutData[component].AbsolutePaddingBox = parentLayoutData.AbsolutePaddingBox;
                layoutData[component].LayoutDirection = parentLayoutData.LayoutDirection;
            }

            var childOffset = new AbsoluteRectangle();
            foreach (var child in component.Components)
                processComponent(child, component.Components, ref childOffset);
        }

        private void generateLayoutDatas(IComponentTree componentTree)
        {
            foreach(var component in componentTree.AllComponents)
            {
                layoutData[component] = new LayoutBoxInformation()
                {
                    AbsoluteBox = new AbsoluteRectangle(),
                    AbsoluteMarginBox = new AbsoluteRectangle(),
                    AbsolutePaddingBox = new AbsoluteRectangle()
                };
            }
        }
    }
}
