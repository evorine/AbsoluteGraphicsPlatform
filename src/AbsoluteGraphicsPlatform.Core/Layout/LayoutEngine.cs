﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.Layout
{
#warning TODO: Optimization
    /* TODO: We are doing the same calculations for all the siblings.
     * It is possible to do the calculation at once for a component's children.
     * Currently I'm leaving this like this as it is enough to proceed.
     * Optimizations will come later. */
    public class LayoutEngine : ILayoutEngine
    {
        float unitToPixel(float unit)
        {
            return unit;
        }
        float pixelToUnit(float pixel)
        {
            return pixel;
        }

        public LayoutCalculationResult ProcessLayout(AbsoluteSize clientSize, IElementTree componentTree)
        {
            //componentTree.Restructure();
            var context = new LayoutCalculationContext();

            var rootComponentBox = context.GetLayoutBoxInformation(componentTree.Owner);
            rootComponentBox.AbsoluteBox = new AbsoluteRectangle(0, 0, clientSize.Width, clientSize.Height);
            rootComponentBox.AbsoluteMarginBox = rootComponentBox.AbsoluteBox;
            rootComponentBox.AbsolutePaddingBox = rootComponentBox.AbsoluteBox;
            rootComponentBox.LayoutDirection = LayoutDirection.Vertical;

            var childrenOffset = new AbsolutePoint();
            foreach (var component in componentTree.Owner.ElementTree.Children)
                processComponent(component, context, ref childrenOffset);

            var filteredBoxes = context.LayoutBoxes.ToDictionary(x => (ILayoutBox)x.Key, x => x.Value);
            return new LayoutCalculationResult(filteredBoxes);
        }

        private void validateMeasures(ILayoutBox layoutComponent)
        {
            // Currently margins and paddings don't support related lengths (Ratios like 1x, 5x).
            //if (layoutComponent.Margin.HasUnitOf(UnitType.Ratio))
            //    throw new NotSupportedException("Siblings related lengths are not supported on margins");
            //if (layoutComponent.Padding.HasUnitOf(UnitType.Ratio))
            //    throw new NotSupportedException("Siblings related lengths are not supported on paddings");
        }

        private void processComponent(IElement element, LayoutCalculationContext context, ref AbsolutePoint currentOffset)
        {
            if (element is ILayoutBox layoutComponent)
            {
                validateMeasures(layoutComponent);
                var parentLayoutBox = context.GetLayoutBoxInformation(element.Parent);

                var layoutBox = calculateRelativeLayoutBoxes(layoutComponent, parentLayoutBox.AbsolutePaddingBox.Size);
                
                // Convert relative location to absolute location
                layoutBox.AbsoluteMarginBox.Offset(parentLayoutBox.AbsolutePaddingBox.Location);
                layoutBox.AbsoluteBox.Offset(parentLayoutBox.AbsolutePaddingBox.Location);
                layoutBox.AbsolutePaddingBox.Offset(parentLayoutBox.AbsolutePaddingBox.Location);

                // Adjust location because of previous siblings
                layoutBox.AbsoluteMarginBox.Offset(currentOffset);
                layoutBox.AbsoluteBox.Offset(currentOffset);
                layoutBox.AbsolutePaddingBox.Offset(currentOffset);

                // Add this component to offset too to adjust next siblings (based on margin box).
                if (parentLayoutBox.LayoutDirection == LayoutDirection.Vertical)
                    currentOffset.Y += layoutBox.AbsoluteMarginBox.Size.Height;
                if (parentLayoutBox.LayoutDirection == LayoutDirection.Horizontal)
                    currentOffset.X += layoutBox.AbsoluteMarginBox.Size.Width;

                context.SetLayoutBoxInformation(element, layoutBox);
            }
            else
            {
                // If this is not an ILayoutBox (layoutable) component, set it's client from it's parent.
                context.SetLayoutBoxInformation(element, context.GetLayoutBoxInformation(element.Parent));
            }

            var childrenOffset = new AbsolutePoint();
            // Continue with the children
            foreach (var child in element.Children)
                processComponent(child, context, ref childrenOffset);
        }

        private LayoutBoxInformation calculateRelativeLayoutBoxes(ILayoutBox layoutComponent, AbsoluteSize clientSize)
        {
            RelativeLength width = layoutComponent.Width;
            RelativeLength height = layoutComponent.Height;

            var component = (IComponent)layoutComponent;

            var siblings = component.Parent.Children.Where(x => x != component);
            var totalSiblingsWidth = siblings.Where(x => x is ILayoutBox).Select(x => ((ILayoutBox)x).Width).Aggregate((total, sibling) => { return total + sibling; });
            var totalSiblingsHeight = siblings.Where(x => x is ILayoutBox).Select(x => ((ILayoutBox)x).Height).Aggregate((total, sibling) => { return total + sibling; });

            var totalWidth = totalSiblingsWidth + width;
            var totalHeight = totalSiblingsHeight + height;

            // Does it have related length (Like 1x or 5x)?
            var hasRelatedWidth = width[UnitType.Ratio] != 0;
            var hasRelatedHeight = height[UnitType.Ratio] != 0;

            // Assume siblings related lengths to '0' if this component is 'Fill'
            if (width == RelativeLength.Infinity) totalSiblingsWidth -= totalSiblingsWidth[UnitType.Ratio];
            if (height == RelativeLength.Infinity) totalSiblingsHeight -= totalSiblingsHeight[UnitType.Ratio];

            // Assume the length as 'Fill' if this component have related length but siblings don't.
            if (hasRelatedWidth && totalSiblingsWidth[UnitType.Ratio] == 0) width = RelativeLength.Infinity;
            if (hasRelatedHeight && totalSiblingsHeight[UnitType.Ratio] == 0) height = RelativeLength.Infinity;

            // Assume the length as 'content length' if this component is 'Shrink' and at least one of the siblings has related or fill length.
            if (width == RelativeLength.NaN && (totalSiblingsWidth[UnitType.Ratio] != 0 || totalSiblingsWidth == RelativeLength.Infinity)) width = calculateContentWidth(layoutComponent);
            if (height == RelativeLength.NaN && (totalSiblingsHeight[UnitType.Ratio] != 0 || totalSiblingsHeight == RelativeLength.Infinity)) height = calculateContentHeight(layoutComponent);


            // Calculate size
            var absoluteWidth = calculateLength(width, totalWidth, clientSize.Width);
            var absoluteHeight = calculateLength(height, totalHeight, clientSize.Height);

            // Calculate margins (based on parent client area)
            var marginTop = calculateLength(layoutComponent.Margin.Top, clientSize.Height);
            var marginRight = calculateLength(layoutComponent.Margin.Right, clientSize.Width);
            var marginBottom = calculateLength(layoutComponent.Margin.Bottom, clientSize.Height);
            var marginLeft = calculateLength(layoutComponent.Margin.Left, clientSize.Width);

            // Calculate paddings (based on self client area)
            var paddingTop = calculateLength(layoutComponent.Padding.Top, absoluteHeight);
            var paddingRight = calculateLength(layoutComponent.Padding.Right, absoluteWidth);
            var paddingBottom = calculateLength(layoutComponent.Padding.Bottom, absoluteHeight);
            var paddingLeft = calculateLength(layoutComponent.Padding.Left, absoluteWidth);

            return new LayoutBoxInformation()
            {
                AbsoluteMarginBox = new AbsoluteRectangle(
                    0,
                    0,
                    absoluteWidth + marginLeft + marginRight,
                    absoluteHeight + marginTop + marginBottom
                ),
                AbsoluteBox = new AbsoluteRectangle(
                    marginLeft,
                    marginTop,
                    absoluteWidth,
                    absoluteHeight
                ),
                AbsolutePaddingBox = new AbsoluteRectangle(
                    marginLeft + paddingLeft,
                    marginTop + paddingTop,
                    absoluteWidth - paddingLeft - paddingRight,
                    absoluteHeight - paddingTop - paddingBottom
                ),
                LayoutDirection = layoutComponent.LayoutDirection
            };
        }

        private RelativeLength calculateContentHeight(ILayoutBox layoutComponent)
        {
            return RelativeLength.Zero;
        }

        private RelativeLength calculateContentWidth(ILayoutBox layoutComponent)
        {
            return RelativeLength.Zero;
        }

        private float calculateLength(RelativeLength length, RelativeLength totalLength, float absoluteClientLength)
        {
            var independentLength =
                length[UnitType.Pixel] +
                unitToPixel(length[UnitType.Unit]) +
                (absoluteClientLength * length[UnitType.Percentage] / 100);

            var totalIndependentLength =
                totalLength[UnitType.Pixel] +
                unitToPixel(totalLength[UnitType.Unit]) +
                (absoluteClientLength * totalLength[UnitType.Percentage] / 100);

            if (length[UnitType.Ratio] != 0)
            {
                // Get the dynamic length
                var rest = absoluteClientLength - totalIndependentLength;
                var totalDynamicLength = totalLength[UnitType.Ratio];

                var factor = rest / totalLength[UnitType.Ratio];
                return independentLength + (factor * length[UnitType.Ratio]);
            }
            else if (length == RelativeLength.Zero) return 0;
            else if (length == RelativeLength.Infinity) return absoluteClientLength - totalIndependentLength;
            else if (length == RelativeLength.NaN) throw new NotImplementedException();
            else return independentLength;
        }

        private float calculateLength(RelativeLength length, float absoluteClientLength)
        {
            return length[UnitType.Pixel] + unitToPixel(length[UnitType.Unit]) + (absoluteClientLength * length[UnitType.Percentage] / 100);
        }
    }
}
